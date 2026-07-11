
namespace HMS.Core.Entities;

public class LabReport : BaseEntity
{
    public Guid ReportId { get; set; }
    public Guid LabTestId { get; set; }

    public string? ReportFile { get; set; }
    public string? Result { get; set; }
    public string? Remarks { get; set; }
    public DateTime ReportDate { get; set; }
    public string? VerifiedBy { get; set; }

    public virtual LabTest LabTest { get; set; } = null!;
}
