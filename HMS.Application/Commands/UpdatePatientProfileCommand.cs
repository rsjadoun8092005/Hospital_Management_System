
namespace HMS.Application.Commands
{
    public class UpdatePatientProfileCommand : IRequest<ResponseModel<bool>>
    {
        public Guid UserId { get; set; }
        public string BloodGroup { get; set; } = string.Empty;
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? Allergies { get; set; }
        public string? MedicalHistory { get; set; }
    }
}