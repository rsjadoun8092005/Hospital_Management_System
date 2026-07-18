
namespace HMS.Application.Commands
{
    public class BookAppointmentCommand : IRequest<ResponseModel<Guid>>
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string VisitType { get; set; } = "In-Person";
        public string? Reason { get; set; }
    }
}