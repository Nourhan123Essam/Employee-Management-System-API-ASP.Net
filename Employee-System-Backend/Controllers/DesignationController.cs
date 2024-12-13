using AutoMapper;
using Employee_Management_Stytem.Data;
using Employee_System_Backend.Models.DTOs;
using Employee_System_Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_System_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public DesignationController(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAllDesignations()
        {
            var allDesignation = dbContext.Designations.ToList();
            return Ok(allDesignation);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetDesignationById(int id)
        {
            var designation = dbContext.Designations.Find(id);
            if (designation is null) return NotFound();
            return Ok(designation);
        }

        [HttpPost]
        public IActionResult AddDesignation(AddDesignationDto designationDto)
        {
            var designation = mapper.Map<Designation>(designationDto);
            dbContext.Designations.Add(designation);
            dbContext.SaveChanges();
            return Ok(new { message = "Designation Added Successfully!" });
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateDesignation(int id, AddDesignationDto designationDto)
        {
            var designation = dbContext.Designations.Find(id);
            if (designation is null) return NotFound();

            designation.Name = designationDto.Name;

            dbContext.Designations.Update(designation);
            dbContext.SaveChanges();
            return Ok(new { message = "Designation Updated Successfully!" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteDesignation(int id)
        {
            var designation = dbContext.Designations.Find(id);
            if (designation is null) return NotFound();

            dbContext.Designations.Remove(designation);
            dbContext.SaveChanges();
            return Ok(new { messages = "Designation Deleted Successfully!" });
        }
    }
}
