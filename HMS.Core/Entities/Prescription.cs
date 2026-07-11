
namespace HMS.Core.Entities;

public class Prescription : BaseEntity
{
    public Guid PrescriptionId { get; set; }
    public Guid AppointmentId { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }

    public string Diagnosis { get; set; } = string.Empty;
    public string Symptoms { get; set; } = string.Empty;
    public string? Advice { get; set; }
    public DateOnly? FollowUpDate { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;
    public virtual Patient Patient { get; set; } = null!;
    public virtual Doctor Doctor { get; set; } = null!;
    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}
