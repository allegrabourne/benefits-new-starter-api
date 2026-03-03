using Benefits.Starter.Domain.enums;

namespace Benefits.Starter.Api.Endpoints.Employees
{
    public sealed class GetEmployeeResponse
    {
        public Guid Id { get; set; }
        public string EmployeeNo { get; set; } = default!;
        public Title Title { get; set; }
        public string FirstName { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; } = default!;
        public AddressDto Address { get; set; } = default!;
    }
}
