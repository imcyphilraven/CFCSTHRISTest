using HRIS.Application.Common.Interfaces;
using HRIS.Application.DTOs;
using HRIS.Application.Employees.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Queries.GetEmployeeByID
{
    public class GetEmployeeByIDQueryHandler : IRequestHandler<GetEmployeeByIDQuery, DTOs.EmployeeDetailDTO?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIDQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<DTOs.EmployeeDetailDTO?> Handle(GetEmployeeByIDQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeID, cancellationToken);
            if (employee == null)
            {
                return null;
            }
            var employeeDetailDTO = new DTOs.EmployeeDetailDTO
            {
                EmployeeId = employee.EmployeeID,
                EmploymentId = employee.EmploymentID,
                FirstName =  employee.FirstName,

                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                ExtensionName = employee.ExtensionName,
                BirthDate = employee.BirthDate,
                BirthPlace = employee.BirthPlace,
                SexAtBirth = employee.SexAtBirth,
                CivilStatusID = employee.CivilStatusID,
                IsFilipino = employee.IsFilipino,
                IsDualCitizen = employee.IsDualCitizen,
                ImageSource = employee.ImageSource
            };
            return employeeDetailDTO;
        }
    }
}
