
namespace HMS.Application.Handlers
{
    public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand, ResponseModel<Guid>>
    {
        private readonly IApplicationDbContext _context;

        public CreateApplicationUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<Guid>> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (existingUser != null)
            {
                return ResponseModel<Guid>.FailureResponse("A user with this email already exists.");
            }

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == request.RoleName, cancellationToken);

            if (role == null)
            {
                return ResponseModel<Guid>.FailureResponse($"Role '{request.RoleName}' does not exist in the system.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                RoleId = role.RoleId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = passwordHash,
                PhoneNumber = request.PhoneNumber,
            };

            if (role.RoleName == "Patient")
            {
                newUser.Patient = new Patient
                {
                    PatientId = Guid.NewGuid(),
                    UserId = newUser.UserId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber ?? string.Empty,
                };
            }

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseModel<Guid>.SuccessResponse(newUser.UserId, "User registered successfully.");
        }
    }
}
