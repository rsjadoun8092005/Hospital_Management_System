namespace HMS.Application.Responses
{
    public class PatientProfileResponse
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BloodGroup {  get; set; } = string.Empty;
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? Allergies { get; set; }
        public string? MedicalHistory { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

    }
}