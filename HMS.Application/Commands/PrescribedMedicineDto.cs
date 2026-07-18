namespace HMS.Application.Commands
{
    public class PrescribedMedicineDto
    {
        public int MedicineId { get; set; }
        public string Dosage { get; set; } = string.Empty;
        public string Frequency {  get; set; } = string.Empty;
        public string Duration {  get; set; } = string.Empty;
        public string? Instructions {  get; set; }
    }
}
