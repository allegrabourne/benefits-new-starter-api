namespace Benefits.Starter.Api.Endpoints.Employees
{
    public sealed class CreateEmployeeResponse
    {
        public Guid Id { get; set; }
        public string EmployeeNo { get; set; } = default!;
    }
}
