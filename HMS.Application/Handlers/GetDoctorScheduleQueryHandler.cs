namespace HMS.Application.Handlers
{
    public class GetDoctorScheduleQueryHandler : IRequestHandler<GetDoctorScheduleQuery, ResponseModel<List<TimeSpan>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDoctorScheduleQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<TimeSpan>>> Handle(
            GetDoctorScheduleQuery request,
            CancellationToken cancellationToken)
        {
            var dayOfWeek = request.Date.DayOfWeek;

            var schedule = await _context.DoctorSchedules
                .FirstOrDefaultAsync(s => s.DoctorId == request.DoctorId && s.DayOfWeek == dayOfWeek && s.IsActive, cancellationToken);

            if (schedule == null)
                return ResponseModel<List<TimeSpan>>.FailureResponse("Doctor is not available on this day.");

            var bookedTimes = await _context.Appointments
                .Where(a => a.DoctorId == request.DoctorId && a.AppointmentDate == request.Date && a.Status != "Cancelled")
                .Select(a => a.AppointmentTime)
                .ToListAsync(cancellationToken);

            var availableSlots = new List<TimeSpan>();
            var currentTime = schedule.StartTime;

            while (currentTime.Add(TimeSpan.FromMinutes(schedule.SlotDuration)) <= schedule.EndTime)
            {
                if (!bookedTimes.Contains(currentTime)) { availableSlots.Add(currentTime); }
                currentTime = currentTime.Add(TimeSpan.FromMinutes(schedule.SlotDuration));
            }

            return ResponseModel<List<TimeSpan>>.SuccessResponse(availableSlots, "Available slots retrieved successfully.");
        }
    }
}
