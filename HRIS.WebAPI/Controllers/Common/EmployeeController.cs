using HRIS.Application.Common.Interfaces;
using HRIS.Application.Employees.Queries.GetEmployees;
using HRIS.Application.Employees.Queries.GetEmployeeByID;
using HRIS.Application.Employees.Commands.CreateEmployee;
using HRIS.Application.Employees.Commands.DeleteEmployee;
using HRIS.Application.Employees.Commands.UpdateEmployee;
using HRIS.Application.Employees.DTOs;


using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HRIS.Application.Common.Model;
using HRIS.WebAPI.Contracts.Employee;




namespace HRIS.WebAPI.Controllers.Common
{
    [Route("api/employee")]
    public class EmployeeController : BaseController
    {
        // using MediatR pattern
        private readonly ISender _mediator;

        public EmployeeController(ISender mediator)
        {
            _mediator = mediator;
        }

        // Query: Get all with pagination
        [HttpGet]
        public async Task<ActionResult<PagedResult<EmployeeListDTO>>> GetAllEmployees(
            [FromQuery] GetEmployeesQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }


        // Query: Get by ID
        [HttpGet("{employeeId:guid}")]
        public async Task<ActionResult<EmployeeDetailDTO>> GetEmployeeById(
            Guid employeeId, 
            CancellationToken cancellationToken)
        {
            var query = new GetEmployeeByIDQuery
            {
                EmployeeID = employeeId
            };

            var result = await _mediator.Send(query, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // Command: Create
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(
            [FromBody] CreateEmployeeRequest request, 
            CancellationToken cancellationToken)
        {
            var command = new CreateEmployeeCommand
            {
                EmploymentId = request.EmploymentID,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                ExtensionName = request.ExtensionName,
                BirthDate = request.BirthDate,
                BirthPlace = request.BirthPlace,
                SexAtBirth = request.SexAtBirth,
                CivilStatusId = request.CivilStatusID,
                IsFilipino = request.IsFilipino,
                IsDualCitizen = request.IsDualCitizen,
                ImageSource = request.ImageSource
            };

            var employeeId = await _mediator.Send(command, cancellationToken);

            return Ok(employeeId);
        }

        // Command: Update
        [HttpPut("{employeeId:guid}")]
        public async Task<IActionResult> UpdateEmployee(
            Guid employeeId, 
            [FromBody] UpdateEmployeeRequest request, 
            CancellationToken cancellationToken)
        {
            if (employeeId != request.EmployeeID)
            {
                return BadRequest();
            }

            var command = new UpdateEmployeeCommand
            {
                EmployeeID = request.EmployeeID,
                EmploymentID = request.EmploymentID,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                ExtensionName = request.ExtensionName,
                BirthDate = request.BirthDate,
                BirthPlace = request.BirthPlace,
                SexAtBirth = request.SexAtBirth,
                CivilStatusID = request.CivilStatusID,
                IsFilipino = request.IsFilipino,
                IsDualCitizen = request.IsDualCitizen,
                ImageSource = request.ImageSource
            };

            var result = await _mediator.Send(command, cancellationToken);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        // Command: Delete
        [HttpDelete("{employeeId:guid}")]
        public async Task<IActionResult> DeleteEmployee(
            Guid employeeId, 
            CancellationToken cancellationToken)
        {
            var command = new DeleteEmployeeCommand
            {
                EmployeeID = employeeId
            };

            var result = await _mediator.Send(command, cancellationToken);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
