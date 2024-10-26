using model;
using ModelService.EmpService;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpService _employeeService;

        public EmployeesController(IEmpService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Employee>>>> GetEmployees()
        {
            var result = new Response<List<Employee>>();
            var employees = await _employeeService.GetAllEmployeesAsync();

            result.Message = "Get Successfully";
            result.Data = employees;
            result.Success = true;

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Response<Employee>>> GetEmployee(Guid id)
        {
            var result = new Response<Employee>();

            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            result.Message = "Get Successfully";
            result.Data = employee;
            result.Success = true;
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Response<bool>>> CreateEmployee(Employee employee)
        {
            var result = new Response<bool>();

            var Data = await _employeeService.CreateEmployeeAsync(employee);
            result.Message = "Added Successfully";
            result.Data = Data;
            result.Success = true;

            return Ok(result);
            //return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Response<bool>>> UpdateEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            var result = new Response<bool>();

            var Data = await _employeeService.UpdateEmployeeAsync(employee);

            result.Message = "Updated Successfully";
            result.Data = Data;
            result.Success = true;

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Response<bool>>> DeleteEmployee(Guid id)
        {
            var result = new Response<bool>();

            var Data = await _employeeService.DeleteEmployeeAsync(id);
            if (!Data)
                return BadRequest();


            result.Message = "Deleted Successfully";
            result.Data = Data;
            result.Success = true;

            return Ok(result);
        }
    }
}