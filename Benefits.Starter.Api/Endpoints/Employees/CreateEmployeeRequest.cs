using Benefits.Starter.Domain;
using Benefits.Starter.Domain.enums;

namespace Benefits.Starter.Api.Endpoints.Employees
{
    public sealed class CreateEmployeeRequest
    {
        public Title Title { get; set; }
        public string FirstName { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; } = default!;
        public Address Address { get; set; } = default!;
    }
}
