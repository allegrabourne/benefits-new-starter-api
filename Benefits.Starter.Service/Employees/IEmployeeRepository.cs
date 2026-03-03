using Benefits.Starter.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Service.Employees
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee, CancellationToken cancellationToken);

        Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken);

        Task<bool> EmployeeNoExistsAsync(string employeeNo, CancellationToken cancellationToken);

        Task<Employee?> GetEmployeeByNumberAsync(string employeeNo, CancellationToken cancellationToken);
    }
}
