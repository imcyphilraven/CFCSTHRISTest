using HRIS.Application.Common.Interfaces;
using HRIS.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IReadOnlyCollection<EmployeeDTO>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
           _employeeRepository = employeeRepository;
        }

        public async Task<IReadOnlyCollection<EmployeeDTO>> Handle(
                GetEmployeesQuery request, 
                CancellationToken cancellationToken
        )
        {
            var employees = await _employeeRepository.GetAllAsync(cancellationToken);
            
            // Map Employee entities to EmployeeDTOs
            var employeeDTOs = employees.Select(e => new EmployeeDTO
            {
                EmploymentId = e.EmploymentID,
                FirstName = e.FirstName,
                MiddleName = e.MiddleName,
                LastName = e.LastName,
                ExtensionName = e.ExtensionName,
                BirthDate = e.BirthDate,
                BirthPlace = e.BirthPlace,
                SexAtBirth = e.SexAtBirth,
                CivilStatusID = e.CivilStatusID,
                IsFilipino = e.IsFilipino,
                IsDualCitizen = e.IsDualCitizen,
                ImageSource = e.ImageSource,
                // Map other properties as needed
            })
                .ToList()
                .AsReadOnly();


            return employeeDTOs;
        }
    }
}
