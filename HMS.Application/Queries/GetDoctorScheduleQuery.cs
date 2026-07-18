namespace HMS.Application.Queries
{
    public class GetDoctorScheduleQuery : IRequest<ResponseModel<List<TimeSpan>>>
    {
        public Guid DoctorId { get; set; }
        public DateOnly Date {  get; set; }
    }
}
