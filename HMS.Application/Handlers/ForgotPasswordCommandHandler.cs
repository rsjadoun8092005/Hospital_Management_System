namespace HMS.Application.Handlers
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ResponseModel<bool>>
    {
        private readonly IApplicationDbContext _context;

        public ForgotPasswordCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<bool>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user == null || !user.IsActive)
            {
                return ResponseModel<bool>.SuccessResponse(true, "If that email exists in our system, a reset link has been sent.");
            }

            // TODO: Generate a unique, time-sensitive reset token
            var resetToken = Guid.NewGuid().ToString();

            // TODO: In a production environment, save this token to the database with an expiration time

            // TODO: Integrate an IEmailService to send the actual email to the user
            var mockResetLink = $"https://your-frontend-url.com/reset-password?token={resetToken}";
            Console.WriteLine($"[MOCK EMAIL] To: {user.Email} - Click here to reset: {mockResetLink}");

            return ResponseModel<bool>.SuccessResponse(true, "If that email exists in our system, a reset link has been sent.");
        }
    }
}
