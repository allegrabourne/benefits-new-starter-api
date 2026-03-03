using Benefits.Starter.Domain;
using Benefits.Starter.Service.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Test.Fakes
{
    public sealed class FakeEmployeeRepository : IEmployeeRepository
    {
        public bool EmailExists { get; set; }
        public bool EmployeeNoExists { get; set; }
        public Employee? AddedEmployee { get; private set; }
        public int AddCallCount { get; private set; }
        public Employee? EmployeeToReturn { get; set; }

        public Task AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            AddedEmployee = employee;
            AddCallCount++;
            return Task.CompletedTask;
        }

        public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken)
            => Task.FromResult(EmailExists);

        public Task<bool> EmployeeNoExistsAsync(string employeeNo, CancellationToken cancellationToken)
            => Task.FromResult(EmployeeNoExists);

        public Task<Employee?> GetEmployeeByNumberAsync(string employeeNo, CancellationToken cancellationToken)
            => Task.FromResult(EmployeeToReturn);
    }
}
