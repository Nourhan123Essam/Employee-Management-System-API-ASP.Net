using AutoMapper;
using Employee_Management_Stytem.Data;
using Employee_System_Backend.Models.DTOs;
using Employee_System_Backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_System_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ClientController(ApplicationDbContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var allClients = dbContext.Clients.ToList();
            return Ok(allClients);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetClientById(int id)
        {
            var project = dbContext.Clients.Find(id);
            if (project is null) return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public IActionResult AddClient(AddClientDto clientDto)
        {
            var client = mapper.Map<Client>(clientDto);
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
            return Ok(new { message = "Client Added Successfully!" });
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateClient(int id, AddClientDto clientDto)
        {
            var client = dbContext.Clients.Find(id);
            if (client is null) return NotFound();

            client.Name = clientDto.Name;
            client.Email = clientDto.Email;
            client.Address = clientDto.Address;
            client.Phone = clientDto.Phone;
          

            dbContext.Clients.Update(client);
            dbContext.SaveChanges();
            return Ok(new { message = "Client Updated Successfully!" });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteClient(int id)
        {
            var client = dbContext.Clients.Find(id);
            if (client is null) return NotFound();
            
            var projects  = dbContext.Projects.Where(p => p.ClientId == id).ToList();
            //delete all the projects related to that client
            dbContext.Projects.RemoveRange(projects);
            dbContext.SaveChanges();
            
            //now I can delete the client safely
            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();
            return Ok(new { messages = "Client Deleted Successfully!" });
        }
    }
}
