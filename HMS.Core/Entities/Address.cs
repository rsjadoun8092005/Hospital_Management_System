
namespace HMS.Core.Entities;

public class Address : BaseEntity
{
    public int AddressId { get; set; }

    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country {  get; set; } = string.Empty;
    public int Pincode { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
