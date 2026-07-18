namespace HMS.Application.Handlers
{
    public class GetPatientAppointmentsQueryHandler : IRequestHandler<GetPatientAppointmentsQuery, ResponseModel<List<PatientAppointmentResponse>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPatientAppointmentsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<PatientAppointmentResponse>>> Handle(
            GetPatientAppointmentsQuery request,
            CancellationToken cancellationToken)
        {
            var appointments = await _context.Appointments
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.User)
                .Where(a => a.PatientId == request.PatientId)
                .OrderByDescending(a => a.AppointmentDate)
                .ThenByDescending(a => a.AppointmentTime)
                .Select(a => new PatientAppointmentResponse
                {
                    AppointmentId = a.AppointmentId,
                    AppointmentDate = a.AppointmentDate,
                    AppointmentTime = a.AppointmentTime,
                    DoctorName = $"Dr. {a.Doctor.User.FirstName} {a.Doctor.User.LastName}",
                    Specialization = a.Doctor.Specialization,
                    Status = a.Status,
                    VisitType = a.VisitType
                })
                .ToListAsync(cancellationToken);

            return ResponseModel<List<PatientAppointmentResponse>>.SuccessResponse(appointments, "Appointments retrieved successfully.");
        }
    }
}
