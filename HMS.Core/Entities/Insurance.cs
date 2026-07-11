
namespace HMS.Core.Entities;

public class Insurance : BaseEntity
{
    public Guid InsuranceId { get; set; }
    public Guid PatientId { get; set; }

    public string ProviderName { get; set; } = string.Empty;
    public string PolicyNumber { get; set; } = string.Empty;
    public decimal CoverageAmount { get; set; }
    public DateOnly ExpiryDate { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
