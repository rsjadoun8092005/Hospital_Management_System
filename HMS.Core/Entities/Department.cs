
namespace HMS.Core.Entities;

public class Department : BaseEntity
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
