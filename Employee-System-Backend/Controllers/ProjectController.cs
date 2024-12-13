using AutoMapper;
using Employee_Management_Stytem.Data;
using Employee_System_Backend.Models.DTOs;
using Employee_System_Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_System_Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ProjectController(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var allProjects = dbContext.Projects.Include(p => p.Leader).Include(p => p.Client).ToList();
            var res = new List<SelectProjectDto>();
            foreach (var project in allProjects)
            {
                var pr = mapper.Map<SelectProjectDto>(project);
                pr.Leader = project.Leader.Name;
                pr.Client = project.Client.Name;
                res.Add(pr);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProjectById(int id)
        {
            var project = dbContext.Projects.Find(id);
            if (project is null) return NotFound();
            var res = mapper.Map<SelectProjectDto>(project);
            res.Leader = project.Leader.Name;
            res.Client = project.Client.Name;
            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddProject(AddProjectDto projectDto)
        {
            var project = mapper.Map<Project>(projectDto);
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();
            return Ok(new { message = "Project Added Successfully!" });
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateProject(int id, AddProjectDto projectDto)
        {
            var project = dbContext.Projects.Find(id);
            if (project is null) return NotFound();

            project.Name = projectDto.Name;
            project.Description = projectDto.Description;
            project.Status = projectDto.Status;
            project.StartDate = projectDto.StartDate;
            project.EndDate = projectDto.EndDate;
            project.Budget = projectDto.Budget;
            project.ClientId = projectDto.ClientId;
            project.LeaderId = projectDto.LeaderId;

            dbContext.Projects.Update(project);
            dbContext.SaveChanges();
            return Ok(new { message = "Project Updated Successfully!" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProject(int id)
        {
            var role = dbContext.Projects.Find(id);
            if (role is null) return NotFound();

            dbContext.Projects.Remove(role);
            dbContext.SaveChanges();
            return Ok(new { messages = "Project Deleted Successfully!" });
        }
    }
}
