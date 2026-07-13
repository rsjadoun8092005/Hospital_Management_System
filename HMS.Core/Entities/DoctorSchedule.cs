
namespace HMS.Core.Entities;

public class DoctorSchedule : BaseEntity
{
    [Key]
    public int ScheduleId { get; set; }
    public Guid DoctorId { get; set; }

    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int SlotDuration { get; set; }
    public string Status { get; set; } = "Active";

    public virtual Doctor Doctor { get; set; } = null!;
}
