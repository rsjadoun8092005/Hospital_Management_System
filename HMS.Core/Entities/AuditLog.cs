
namespace HMS.Core.Entities;

public class AuditLog : BaseEntity
{
    [Key]
    public Guid AuditId { get; set; }
    public Guid UserId { get; set; }

    public string ActionPerformed { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
    public string RecordId { get; set; } = string.Empty;
    public string IPAddress { get; set; } = string.Empty;
    public DateTime ActionDate { get; set; } = DateTime.UtcNow;

    public virtual User User { get; set; } = null!;
}
