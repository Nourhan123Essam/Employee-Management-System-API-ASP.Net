using AutoMapper;
using Employee_Management_Stytem.Data;
using Employee_Management_Stytem.Models.Entities;
using Employee_System_Backend.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_System_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public EmployeeController(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.Include(e => e.Role).Include(e => e.Designation).ToList();
            var res = new List<SelectEmployeeDto>();
            foreach (var employee in allEmployees)
            {
                var emp = mapper.Map<SelectEmployeeDto>(employee);
                emp.role = employee.Role.Name;
                emp.designation = employee.Designation.Name;
                res.Add(emp);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto employeeDto)
        {
            var emp = new Employee();
            emp = mapper.Map<Employee>(employeeDto);
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();                                                                                                   
            return Ok(new { message = "Employee Added Successfully!" });
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, AddEmployeeDto employeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee is null) return NotFound();

            employee.Phone = employeeDto.Phone;
            employee.Salary = employeeDto.Salary;
            employee.Email = employeeDto.Email;
            employee.Address = employeeDto.Address;
            employee.Name = employeeDto.Name;
            employee.HireDate = employeeDto.HireDate;
            employee.IsActive = employeeDto.IsActive;
            employee.DesignationId = employeeDto.DesignationId;
            employee.RoleId = employeeDto.RoleId;

            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
            return Ok(new { message = "Employee Updated Successfully!" });
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null) return NotFound();

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok(new { messages = "Employee Deleted Successfully!" });
        }
    }
}
