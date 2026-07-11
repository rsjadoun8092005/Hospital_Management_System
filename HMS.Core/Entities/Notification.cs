
namespace HMS.Core.Entities;

public class Notification : BaseEntity
{
    public Guid NotificationId { get; set; }
    public Guid UserId { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string NotificationType { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;

    public virtual User User { get; set; } = null!;
}
