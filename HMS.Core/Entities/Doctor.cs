
namespace HMS.Core.Entities;

public class Doctor : BaseEntity
{
    public Guid DoctorId { get; set; }
    public Guid UserId { get; set; }
    public int DepartmentId { get; set; }

    public string Qualification { get; set; } = string.Empty;
    public string Specialization {  get; set; } = string.Empty;
    public int Experience { get; set; }
    public decimal ConsultationFee {  get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public string Gender {  get; set; } = string.Empty;

    public DateOnly DateOfJoining { get; set; }
    public bool IsAvailable { get; set; } = true;

    public virtual User User { get; set; } = null!;
    public virtual Department Department { get; set; } = null!;
    public virtual ICollection<DoctorSchedule> Schedules { get; set; } = new List<DoctorSchedule>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
