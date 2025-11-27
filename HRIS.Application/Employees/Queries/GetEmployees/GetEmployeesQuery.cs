using HRIS.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<IReadOnlyCollection<EmployeeDTO>>
    {

    }
}
