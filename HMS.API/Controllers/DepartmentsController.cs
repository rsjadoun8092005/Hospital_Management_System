namespace HMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var response = await _mediator.Send(new GetDepartmentsQuery());

            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
