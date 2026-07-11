
namespace HMS.Core.Entities;

public class Discharge : BaseEntity
{
    public Guid DischargeId { get; set; }
    public Guid AdmissionId { get; set; }

    public DateTime DischargeDate { get; set; }
    public string FinalDiagnosis { get; set; } = string.Empty;
    public string? DoctorRemarks { get; set; }

    public virtual Admission Admission { get; set; } = null!;
}
