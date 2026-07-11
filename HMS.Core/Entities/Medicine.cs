
namespace HMS.Core.Entities;

public class Medicine : BaseEntity
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = string.Empty;
    public string GenericName { get; set; } = string.Empty;
    public string? Manufacturer { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
    public DateOnly ExpiryDate { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}
