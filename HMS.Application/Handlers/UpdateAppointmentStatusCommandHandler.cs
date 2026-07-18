namespace HMS.Application.Handlers
{
    public class UpdateAppointmentStatusCommandHandler : IRequestHandler<UpdateAppointmentStatusCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAppointmentStatusCommandHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<bool>> Handle(
            UpdateAppointmentStatusCommand request,
            CancellationToken cancellationToken)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == request.AppointmentId && a.DoctorId == request.DoctorId, cancellationToken);

            if (appointment == null)
            {
                return ResponseModel<bool>.FailureResponse("Appointment not found or unauthorized access.");
            }

            appointment.Status = request.Status;
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseModel<bool>.SuccessResponse(true, $"Appointment status updated to {request.Status}.");
        }
    }
}
