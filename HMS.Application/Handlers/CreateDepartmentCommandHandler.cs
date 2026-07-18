namespace HMS.Application.Handlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, ResponseModel<int>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<int>> Handle(
            CreateDepartmentCommand request,
            CancellationToken cancellationToken)
        {
            var exists = await _context.Departments.AnyAsync(d => d.DepartmentName == request.DepartmentName, cancellationToken);

            if (exists)
            {
                return ResponseModel<int>.FailureResponse("A department with this name already exists");
            }

            var department = new Department
            {
                DepartmentName = request.DepartmentName,
                Description = request.Description
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync(cancellationToken);

            return ResponseModel<int>.SuccessResponse(department.DepartmentId, "Department created successfully.");
        }
    }
}
