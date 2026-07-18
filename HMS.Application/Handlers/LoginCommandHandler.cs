
using BCrypt.Net;

namespace HMS.Application.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseModel<AuthResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ResponseModel<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
            
            if (user == null || !user.IsActive)
            {
                return ResponseModel<AuthResponse>.FailureResponse("Invalid email or password.");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return ResponseModel<AuthResponse>.FailureResponse("Invalid email or password.");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.RoleName),
                    new Claim("Name", $"{user.FirstName} {user.LastName}")
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpiryInMinutes"])),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = TokenHandler.CreateToken(tokenDescriptor);
            var jwtString = TokenHandler.WriteToken(token);

            var responseData = new AuthResponse
            {
                Token = jwtString,
                UserId = user.UserId,
                Role = user.Role.RoleName,
                Name = $"{user.FirstName} {user.LastName}"
            };

            return ResponseModel<AuthResponse>.SuccessResponse(responseData, "Login Successful.");
        }
    }
}
