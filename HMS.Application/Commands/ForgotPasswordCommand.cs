
namespace HMS.Application.Commands
{
    public class ForgotPasswordCommand : IRequest<ResponseModel<bool>>
    {
        public string Email { get; set; } = string.Empty;
    }
}
