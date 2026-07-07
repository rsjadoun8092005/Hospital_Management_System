
namespace HMS.Core.Entities;

public class User : BaseEntity
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Patient? Patient{ get; set; }
    public virtual Doctor? Doctor { get; set; }
}