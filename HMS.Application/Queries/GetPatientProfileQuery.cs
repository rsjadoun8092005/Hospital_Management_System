namespace HMS.Application.Queries
{
    public class GetPatientProfileQuery : IRequest<ResponseModel<PatientProfileResponse>>
    {
        public Guid UserId { get; set; }
    }
}
