namespace HMS.Application.Handlers
{
    public class BookAppointmentCommandHandler : IRequestHandler<BookAppointmentCommand, ResponseModel<Guid>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookAppointmentCommandHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<Guid>> Handle(
            BookAppointmentCommand request,
            CancellationToken cancellationToken)
        {
            var isSlotTaken = await _context.Appointments
                .AnyAsync(a => a.DoctorId == request.DoctorId
                            && a.AppointmentDate == request.AppointmentDate
                            && a.AppointmentTime == request.AppointmentTime
                            && a.Status != "Cancelled", cancellationToken);

            if (isSlotTaken)
            {
                return ResponseModel<Guid>.FailureResponse("This slot is no longer available. Please select another.");
            }

            var appointment = new Appointment
            {
                AppointmentId = Guid.NewGuid(),
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                AppointmentDate = request.AppointmentDate,
                AppointmentTime = request.AppointmentTime,
                VisitType = request.VisitType,
                Reason = request.Reason,
                Status = "Pending"
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseModel<Guid>.SuccessResponse(appointment.AppointmentId, "Appointment booked successfully.");
        }
    }
}
