
namespace HMS.Application.Commands
{
    public class UpdateAppointmentStatusCommand : IRequest<ResponseModel<bool>>
    {
        public Guid AppointmentId { get; set; }
        public Guid DoctorId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}