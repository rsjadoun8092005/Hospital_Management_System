
namespace HMS.Core.Entities;

public class Payment : BaseEntity
{
    public Guid PaymentId { get; set; }
    public Guid BillId { get; set; }

    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string? TransactionId { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }

    public virtual Bill Bill { get; set; } = null!;
}
