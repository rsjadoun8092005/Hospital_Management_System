
namespace HMS.Core.Entities;

public class Patient : BaseEntity
{
    public Guid PatientId { get; set; }
    public Guid UserId { get; set; }
    public int? AddressId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string BloodGroup {  get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }
    public string PhoneNumber {  get; set; } = string.Empty;
    public string EmergencyContact {  get; set; } = string.Empty;

    public decimal? Height { get; set; }
    public decimal? Weight { get; set; }
    public string? Allergies { get; set; }
    public string? MedicalHistory { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual Address Address { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
