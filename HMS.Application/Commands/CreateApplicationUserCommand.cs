
namespace HMS.Application.Commands
{
    public class CreateApplicationUserCommand : IRequest<ResponseModel<Guid>>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }

        public string? RoleName { get; set; } = "Patient";
    }
}
