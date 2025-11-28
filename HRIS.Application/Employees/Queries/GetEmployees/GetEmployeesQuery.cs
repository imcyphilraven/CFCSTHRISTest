using HRIS.Application.Common.Model;
using HRIS.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<PagedResult<EmployeeDTO>>           //IRequest<IReadOnlyCollection<EmployeeDTO>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public string? SearchTerm { get; set; }
        public bool? IsActive { get; set; }

        public string? SortBy { get; set; }
        public bool IsDescending { get; set; } = false;

    }
}
