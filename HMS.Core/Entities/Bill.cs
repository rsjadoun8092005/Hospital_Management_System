
namespace HMS.Core.Entities;

public class Bill : BaseEntity
{
    public Guid BillId { get; set; }
    public Guid PatientId { get; set; }
    public Guid? AppointmentId { get; set; }

    public DateTime BillDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Discount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public string BillStatus { get; set; } = "Unpaid";

    public virtual Patient Patient { get; set; } = null!;
    public virtual Appointment? Appointment { get; set; }
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
