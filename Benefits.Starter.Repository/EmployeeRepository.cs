using Benefits.Starter.Domain;
using Benefits.Starter.Repository.Data;
using Benefits.Starter.Service.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Repository
{
    public sealed class EmployeeRepository : IEmployeeRepository
    {
        private readonly BenefitsStarterDbContext _dbContext;

        public EmployeeRepository(BenefitsStarterDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken)
        {
            var normalised = email.Trim().ToLowerInvariant();
            return _dbContext.Employees.AnyAsync(e => e.Email == normalised, cancellationToken);
        }

        public Task<bool> EmployeeNoExistsAsync(string employeeNo, CancellationToken cancellationToken)
        {
            var trimmed = employeeNo.Trim();
            return _dbContext.Employees.AnyAsync(e => e.EmployeeNo == trimmed, cancellationToken);
        }
    }
}
