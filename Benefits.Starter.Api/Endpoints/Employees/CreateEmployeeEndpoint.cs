using Benefits.Starter.Service.Employees;
using FastEndpoints;
using static FastEndpoints.Ep;

namespace Benefits.Starter.Api.Endpoints.Employees
{
    public sealed class CreateEmployeeEndpoint
     : Endpoint<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        private readonly EmployeeService _service;

        public CreateEmployeeEndpoint(EmployeeService service)
        {
            _service = service;
        }

        public override void Configure()
        {
            Post("/employees");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateEmployeeRequest request, CancellationToken ct)
        {
            try
            {
                var result = await _service.CreateAsync(
                    new Service.Employees.CreateEmployeeRequest(
                        request.Title,
                        request.FirstName,
                        request.Surname,
                        request.DateOfBirth,
                        request.Gender,
                        request.Email,
                        request.Address
                    ),
                    ct);

                await Send.OkAsync(new CreateEmployeeResponse
                {
                    Id = result.Id,
                    EmployeeNo = result.EmployeeNo
                }, ct);
            }
            catch (InvalidOperationException ex)
            {
                AddError(ex.Message);
                await Send.ErrorsAsync(409, ct);
            }
        }
    }
}
