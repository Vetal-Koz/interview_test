using InterviewTest.Core.DTO;
using InterviewTest.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            EmployeeWrapper employee = await _employeeService.GetEmplyeeByID(id);

            return Ok(employee);
        }

        [HttpPut("enable/{id}")]
        public async Task<IActionResult> EnableEmployee([FromRoute] int id, [FromBody] bool enable)
        {
            await _employeeService.EnableEmployee(id, enable);

            return Ok();
        }
    }
}