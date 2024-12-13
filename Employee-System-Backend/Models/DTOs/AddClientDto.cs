namespace Employee_System_Backend.Models.DTOs
{
    public class AddClientDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
    }
}
