using HRIS.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newEmployee = new HRIS.Domain.Entities.Domain.HRIS.Employee
            {
                EmployeeID = Guid.NewGuid(),
                EmploymentID = request.EmploymentId,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                ExtensionName = request.ExtensionName,
                BirthDate = request.BirthDate,
                BirthPlace = request.BirthPlace,
                SexAtBirth = request.SexAtBirth,
                CivilStatusID = request.CivilStatusId,
                IsFilipino = request.IsFilipino,
                IsDualCitizen = request.IsDualCitizen,
                ImageSource = request.ImageSource
            };
            var createdEmployee = await _employeeRepository.AddAsync(newEmployee, cancellationToken);

            return createdEmployee.EmployeeID;
        }
    }
}
