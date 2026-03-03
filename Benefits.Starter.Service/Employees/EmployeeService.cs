using Benefits.Starter.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Benefits.Starter.Service.Employees
{
    public sealed class EmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<CreateEmployeeResult> CreateAsync(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (await _repo.EmailExistsAsync(request.Email, cancellationToken))
                throw new InvalidOperationException("Email must be unique.");

            var employeeNo = await GenerateUniqueEmployeeNoAsync(cancellationToken);

            var employee = new Employee(
                employeeNo: employeeNo,
                title: request.Title,
                firstName: request.FirstName,
                surname: request.Surname,
                dateOfBirth: request.DateOfBirth,
                gender: request.Gender,
                email: request.Email,
                address: request.Address);

            await _repo.AddAsync(employee, cancellationToken);

            return new CreateEmployeeResult(employee.Id, employee.EmployeeNo);
        }

        private async Task<string> GenerateUniqueEmployeeNoAsync(CancellationToken cancellationToken)
        {
            for (var attempt = 0; attempt < 10; attempt++)
            {
                var candidate = $"EMP{RandomNumberGenerator.GetInt32(0, 1_000_000):D6}";

                if (!await _repo.EmployeeNoExistsAsync(candidate, cancellationToken))
                    return candidate;
            }

            throw new InvalidOperationException("Unable to generate a unique employee number.");
        }
    }
}
