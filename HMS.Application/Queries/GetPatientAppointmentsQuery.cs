namespace HMS.Application.Queries
{
    public class GetPatientAppointmentsQuery : IRequest<ResponseModel<List<PatientAppointmentResponse>>>
    {
        public Guid PatientId { get; set; }
    }
}
