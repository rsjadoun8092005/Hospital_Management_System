namespace HMS.Application.Responses
{
    public class PatientAppointmentResponse
    {
        public Guid AppointmentId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string Specialization {  get; set; } = string.Empty;
        public string Status {  get; set; } = string.Empty;
        public string VisitType {  get; set; } = string.Empty;
    }
}
