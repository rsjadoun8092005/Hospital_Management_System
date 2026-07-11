
namespace HMS.Core.Entities;

public class PrescriptionMedicine : BaseEntity
{
    public Guid PrescriptionMedicineId { get; set; }
    public Guid PrescriptionId { get; set; }
    public int MedicineId { get; set; }

    public string Dosage { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string? Instructions { get; set; }

    public virtual Prescription Prescription { get; set; } = null!;
    public virtual Medicine Medicine { get; set; } = null!;
}
