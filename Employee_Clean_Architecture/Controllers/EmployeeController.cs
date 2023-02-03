using Employee_Application.Commands;
using Employee_Application.Handlers;
using Employee_Application.Queries;
using Employee_Application.Responses;
using Employee_Core.Entities;
using Employee_Core.Repositories;
using Employee_Core.Repositories.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Clean_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IMediator _mediator;
      
        private readonly DeleteEmployeeHandler _deleteEmployeeUseCase;
     

       // private readonly IRepository<Employee> _EmployeeRepository;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Employee>> Get()
        {
            var employeelist = await _mediator.Send(new GetAllEmployeeQuery());
            return employeelist.ToList();
           
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteResponse>> Delete(int id)
        {
            await _mediator.Send(new DeleteCommand { EmployeeId = id });
            return new DeleteResponse { Message = "Employee successfully deleted." };
        }

        [HttpGet("EmployeeByLastName")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByLastName(string lastname)
        {
            var employees = await _mediator.Send(new GetEmployeeByLastNameCommand { lastname = lastname });
            return Ok(employees);
        }


    }
}
