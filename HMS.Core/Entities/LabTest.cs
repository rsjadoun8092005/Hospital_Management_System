
namespace HMS.Core.Entities;

public class LabTest : BaseEntity
{
    public Guid LabTestId { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid? AppointmentId { get; set; }

    public string TestName { get; set; } = string.Empty;
    public string TestCategory { get; set; } = string.Empty;
    public DateTime TestDate { get; set; }
    public string Status { get; set; } = "Pending";

    public virtual Patient Patient { get; set; } = null!;
    public virtual Doctor Doctor { get; set; } = null!;
    public virtual Appointment? Appointment { get; set; }
    public virtual LabReport? LabReport { get; set; }
}
