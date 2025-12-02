using HRIS.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.Commands.ReactivateEmployee
{
    public class ReactivateEmployeeCommandHandler : IRequestHandler<ReactivateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ReactivateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(
            ReactivateEmployeeCommand request, 
            CancellationToken cancellationToken
        )
        {
            var employee = await _employeeRepository.GetEmployeeByIDIncludingInactiveAsync(request.EmployeeID, cancellationToken);
            if (employee == null)
            {
                return false;   // Employee not found
            }
            employee.Reactivate("system"); // Assuming Reactivate is a method in Employee entity that sets IsActive to true

            // This is temporary, replace "system" with actual user
            employee.MarkUpdated("system");

            await _employeeRepository.UpdateAsync(employee, cancellationToken);
            
            return true; // Reactivation successful
        }
    }
}
