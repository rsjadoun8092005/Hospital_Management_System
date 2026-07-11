
namespace HMS.Core.Entities;

public class Admission : BaseEntity
{
    public Guid AdmissionId { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public int RoomId { get; set; }

    public DateTime AdmissionDate { get; set; }
    public DateTime? ExpectedDischarge { get; set; }
    public string AdmissionReason { get; set; } = string.Empty;

    public virtual Patient Patient { get; set; } = null!;
    public virtual Doctor Doctor { get; set; } = null!;
    public virtual Room Room { get; set; } = null!;
    public virtual Discharge? Discharge { get; set; }
}
