using HRIS.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Queries.GetEmployeeByID
{
    public class GetEmployeeByIDQuery : IRequest<EmployeeDTO?>
    {
        public Guid EmployeeID { get; set; }

        
    }
}
