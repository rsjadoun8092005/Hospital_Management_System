
namespace HMS.Application.Commands
{
    public class CancelAppointmentCommand : IRequest<ResponseModel<bool>>
    {
        public Guid AppointmentId { get; set; }
        public Guid PatientId { get; set; }
    }
}