using Employee_Management_Stytem.Models.Entities;

namespace Employee_System_Backend.Models.Entities
{
    public class Project
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
        public Employee Leader { get; set; } // Navigation Property
        public int ClientId { get; set; } // Foreign Key for Client
        public Client Client { get; set; } // Navigation Property

        public ICollection<Employee> Employees { get; set; }
    }
}
