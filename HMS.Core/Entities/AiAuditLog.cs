
namespace HMS.Core.Entities;

public class AiAuditLog : BaseEntity
{
    [Key]
    public Guid LogId { get; set; }
    public Guid UserId { get; set; }

    public string FeatureUsed { get; set; } = string.Empty;
    public string Prompt { get; set; } = string.Empty;
    public string AiResponse { get; set; } = string.Empty;
    public int? TokensUsed { get; set; }
    public long ResponseTime { get; set; }

    public virtual User User { get; set; } = null!;
}
