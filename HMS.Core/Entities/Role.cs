namespace HMS.Core.Entities;

public class Role : BaseEntity
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
