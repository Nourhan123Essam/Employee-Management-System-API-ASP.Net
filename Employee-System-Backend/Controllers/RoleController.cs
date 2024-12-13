using AutoMapper;
using Employee_Management_Stytem.Data;
using Employee_Management_Stytem.Models.Entities;
using Employee_System_Backend.Models.DTOs;
using Employee_System_Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_System_Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public RoleController(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var allRoles = dbContext.Roles.ToList();
            return Ok(allRoles);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetRoleById(int id)
        {
            var role = dbContext.Roles.Find(id);
            if (role is null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public IActionResult AddRole(AddRoleDto roleDto)
        {
            var role = new Role();
            role = mapper.Map<Role>(roleDto);
            dbContext.Roles.Add(role);
            dbContext.SaveChanges();
            return Ok(new { message = "Role Added Successfully!" });
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateRole(int id, AddRoleDto roleDto)
        {
            var role = dbContext.Roles.Find(id);
            if (role is null) return NotFound();
        
            role.Name = roleDto.Name;

            dbContext.Roles.Update(role);
            dbContext.SaveChanges();
            return Ok(new { message = "Role Updated Successfully!" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRole(int id)
        {
            var role = dbContext.Roles.Find(id);
            if (role is null) return NotFound();

            dbContext.Roles.Remove(role);
            dbContext.SaveChanges();
            return Ok(new { messages = "Role Deleted Successfully!" });
        }
    }
}
