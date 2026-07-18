namespace HMS.Application.Handlers
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, ResponseModel<List<DepartmentResponse>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<DepartmentResponse>>> Handle(
            GetDepartmentsQuery request,
            CancellationToken cancellationToken)
        {
        var departments = await _context.Departments
        .Where(d => d.IsActive)
        .Select(d => new DepartmentResponse
        {
            DepartmentId = d.DepartmentId,
            DepartmentName = d.DepartmentName,
            Description = d.Description
        })
        .ToListAsync(cancellationToken);

        return ResponseModel<List<DepartmentResponse>>.SuccessResponse(departments, "Departments retrieved successfully.");
        }
    }
}
