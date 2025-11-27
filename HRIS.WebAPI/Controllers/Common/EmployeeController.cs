using HRIS.Application.Common.Interfaces;
using HRIS.Application.DTOs;
using HRIS.Application.Employees.Queries.GetEmployees;
using HRIS.Application.Employees.Queries.GetEmployeeByID;
using HRIS.Application.Employees.Commands.CreateEmployee;
using HRIS.Application.Employees.Commands.DeleteEmployee;
using HRIS.Application.Employees.Commands.UpdateEmployee;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;



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

        // Query: Get All
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<EmployeeDTO>>> GetAllEmployees(
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetEmployeesQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpGet("{employeeId:guid}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(
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
            [FromBody] CreateEmployeeCommand command, 
            CancellationToken cancellationToken)
        {
            var employeeId = await _mediator.Send(command, cancellationToken);

            return Ok(employeeId);
        }

        // Command: Update
        [HttpPut("{employeeId:guid}")]
        public async Task<IActionResult> UpdateEmployee(
            Guid employeeId, 
            [FromBody] UpdateEmployeeCommand command, 
            CancellationToken cancellationToken)
        {
            if (employeeId != command.EmployeeID)
            {
                return BadRequest();
            }
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



        //private readonly IEmployeeRepository _employeeRepository;

        //public EmployeeController(IEmployeeRepository employeeRepository)
        //{
        //    _employeeRepository = employeeRepository;
        //}

        // READ
        //[HttpGet]
        //public async Task<IActionResult> GetAllEmployees(CancellationToken cancellationToken)
        //{
        //    var employees = await _employeeRepository.GetAllAsync(cancellationToken);
        //    return Ok(employees);
        //}

        //[HttpGet("{employeeId}")]
        //public async Task<IActionResult> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken)
        //{
        //    var employee = await _employeeRepository.GetByIdAsync(employeeId, cancellationToken);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(employee);
        //}

        //// WRITE
        //[HttpPost]
        //public async Task<IActionResult> CreateEmployee([FromBody] HRIS.Domain.Entities.Domain.HRIS.Employee employee, CancellationToken cancellationToken)
        //{
        //    var createdEmployee = await _employeeRepository.AddAsync(employee, cancellationToken);
        //    return CreatedAtAction(nameof(GetEmployeeById), new { employeeId = createdEmployee.EmployeeID }, createdEmployee);
        //}

        //[HttpPut("{employeeId}")]
        //public async Task<IActionResult> UpdateEmployee(Guid employeeId, [FromBody] HRIS.Domain.Entities.Domain.HRIS.Employee employee, CancellationToken cancellationToken)
        //{
        //    if (employeeId != employee.EmployeeID)
        //    {
        //        return BadRequest();
        //    }
        //    await _employeeRepository.UpdateAsync(employee, cancellationToken);
        //    return NoContent();
        //}

        //[HttpDelete("{employeeId}")]
        //public async Task<IActionResult> DeleteEmployee(Guid employeeId, CancellationToken cancellationToken)
        //{
        //    var employee = await _employeeRepository.GetByIdAsync(employeeId, cancellationToken);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    // Additional checks for related data can be added here
        //    // employee.IsActive = true; 

        //    await _employeeRepository.UpdateAsync(employee, cancellationToken);
        //    return NoContent();
        //}

    }
}
