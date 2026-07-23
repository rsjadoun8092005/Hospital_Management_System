namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{doctorId}/schedule")]
        public async Task<IActionResult> GetSchedule(Guid doctorId, [FromQuery] string date)
        {
            var query = new GetDoctorScheduleQuery
            {
                DoctorId = doctorId,
                Date = DateOnly.Parse(date)
            };

            var response = await _mediator.Send(query);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{doctorId}/patients/{patientId}/records")]
        public async Task<IActionResult> GetPatientRecords(Guid doctorId, Guid patientId)
        {
            var query = new GetPatientRecordsQuery
            {
                RequestingDoctorId = doctorId,
                PatientId = patientId
            };

            var response = await _mediator.Send(query);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("appointments/status")]
        public async Task<IActionResult> UpdateAppointmentStatus([FromBody] UpdateAppointmentStatusCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("prescriptions")]
        public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
