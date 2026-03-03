using Benefits.Starter.Service.Employees;
using FastEndpoints;
using global::Benefits.Starter.Domain.enums;

namespace Benefits.Starter.Api.Endpoints.Employees
{
    
    public sealed class GetEmployeeEndpoint : EndpointWithoutRequest<GetEmployeeResponse>
    {
        private readonly EmployeeService _service;

        public GetEmployeeEndpoint(EmployeeService service) => _service = service;

        public override void Configure()
        {
            Get("/employees/{employeeNo}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var employeeNo = Route<string>("employeeNo");

            var employee = await _service.GetByEmployeeNoAsync(employeeNo, ct);

            if (employee is null)
            {
                await Send.NotFoundAsync(ct);
                return;
            }

            await Send.OkAsync(new GetEmployeeResponse
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                Title = employee.Title,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                Email = employee.Email,
                Address = new AddressDto
                {
                    Line1 = employee.Address.Line1,
                    Line2 = employee.Address.Line2,
                    City = employee.Address.City,
                    Postcode = employee.Address.Postcode,
                    Country = employee.Address.Country
                }
            }, ct);
        }
    }
}
