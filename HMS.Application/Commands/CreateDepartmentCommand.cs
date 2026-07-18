namespace HMS.Application.Commands
{
    public class CreateDepartmentCommand : IRequest<ResponseModel<int>>
    {
        public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
