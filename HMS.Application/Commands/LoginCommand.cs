
namespace HMS.Application.Commands
{
    public class LoginCommand : IRequest<ResponseModel<AuthResponse>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
