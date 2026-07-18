
namespace HMS.Application.Commands
{
    public class CreatePrescriptionCommand : IRequest<ResponseModel<Guid>>
    {
        public Guid AppointmentId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Symptoms { get; set; } = string.Empty;
        public string? Advice { get; set; }
        public DateOnly? FollowUpDate { get; set; }

        public List<PrescribedMedicineDto> Medicines { get; set; } = new List<PrescribedMedicineDto>();
    }
}