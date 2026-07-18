namespace HMS.Application.Handlers
{
    public class UpdatePatientProfileCommandHandler : IRequestHandler<UpdatePatientProfileCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdatePatientProfileCommandHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<bool>> Handle(
            UpdatePatientProfileCommand request,
            CancellationToken cancellationToken)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.UserId == request.UserId, cancellationToken);

            if (patient == null)
                return ResponseModel<bool>.FailureResponse("Patient profile not found.");

            patient.BloodGroup = request.BloodGroup;
            patient.Height = request.Height;
            patient.Weight = request.Weight;
            patient.Allergies = request.Allergies;
            patient.MedicalHistory = request.MedicalHistory;

            await _context.SaveChangesAsync(cancellationToken);

            return ResponseModel<bool>.SuccessResponse(true, "Profile updated successfully.");
        }
    }
}
