using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.Starter.Service.Employees
{
    public sealed record CreateEmployeeResult(Guid Id, string EmployeeNo);
}
