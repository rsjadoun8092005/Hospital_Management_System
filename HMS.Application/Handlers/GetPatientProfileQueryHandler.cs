namespace HMS.Application.Handlers
{
    public class GetPatientProfileQueryHandler : IRequestHandler<GetPatientProfileQuery, ResponseModel<PatientProfileResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPatientProfileQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<PatientProfileResponse>> Handle(
            GetPatientProfileQuery request,
            CancellationToken cancellationToken)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.UserId == request.UserId, cancellationToken);

            if (patient == null)
                return ResponseModel<PatientProfileResponse>.FailureResponse("Patient profile not found.");

            var response = new PatientProfileResponse
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BloodGroup = patient.BloodGroup,
                Height = patient.Height,
                Weight = patient.Weight,
                Allergies = patient.Allergies,
                MedicalHistory = patient.MedicalHistory,
                PhoneNumber = patient.PhoneNumber
            };

            return ResponseModel<PatientProfileResponse>.SuccessResponse(response);
        }
    }
}
