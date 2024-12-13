namespace Employee_System_Backend.Models.DTOs
{
    public class AddProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Budget { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();

        public Guid LeaderId { get; set; } // Foreign Key for Project Leader
        public int ClientId { get; set; } // Foreign Key for Client
    }
}
