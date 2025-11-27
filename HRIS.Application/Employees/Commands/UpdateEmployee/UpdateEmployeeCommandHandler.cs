using HRIS.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(
            UpdateEmployeeCommand request, 
            CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeID, cancellationToken);
            if (employee == null)
            {
                return false;
            }


            // Update employee properties
            employee.EmploymentID = request.EmploymentID;
            employee.FirstName = request.FirstName;
            employee.MiddleName = request.MiddleName;
            employee.LastName = request.LastName;
            employee.ExtensionName = request.ExtensionName;
            employee.BirthDate = request.BirthDate;
            employee.BirthPlace = request.BirthPlace;
            employee.SexAtBirth = request.SexAtBirth;
            employee.CivilStatusID = request.CivilStatusID;
            employee.IsFilipino = request.IsFilipino;
            employee.IsDualCitizen = request.IsDualCitizen;
            employee.ImageSource = request.ImageSource;


            await _employeeRepository.UpdateAsync(employee, cancellationToken);

            return true;
        }
    }
}
