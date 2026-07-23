namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{patientId}/profile")]
        public async Task<IActionResult> GetProfile(Guid patientId)
        {
            var response = await _mediator.Send(new GetPatientProfileQuery { UserId = patientId});

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdatePatientProfileCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("appointments")]
        public async Task<IActionResult> BookAppointment([FromBody] BookAppointmentCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{patientId}/appointments")]
        public async Task<IActionResult> GetPatientAppointments(Guid patientId)
        {
            var response = await _mediator.Send(new GetPatientAppointmentsQuery { PatientId = patientId });

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("appointments/cancel")]
        public async Task<IActionResult> CancelAppointment([FromBody] CancelAppointmentCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
