namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateApplicationUserCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
