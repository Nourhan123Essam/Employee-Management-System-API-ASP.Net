using Employee_Management_Stytem.Models.Entities;
using Employee_System_Backend.Models.Entities;

namespace Employee_System_Backend.Models.DTOs
{
    public class SelectProjectDto
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Budget { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid LeaderId { get; set; } // Foreign Key for Project Leader
        public int ClientId { get; set; } // Foreign Key for Client

        public string Leader { get; set; } // Navigation Property
        public string Client { get; set; } // Navigation Property
    }
}
