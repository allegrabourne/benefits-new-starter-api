using Benefits.Starter.Domain;
using Benefits.Starter.Domain.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Service.Employees
{
    public sealed record CreateEmployeeRequest(
        Title Title,
        string FirstName,
        string Surname,
        DateOnly DateOfBirth,
        Gender Gender,
        string Email,
        Address Address);
}
