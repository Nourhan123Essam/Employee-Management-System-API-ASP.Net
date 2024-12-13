namespace Employee_System_Backend.Models.DTOs
{
    public class SelectEmployeeDto
    {
        public Guid EmployeeId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int RoleId { get; set; } // Foreign Key for Role
        public int DesignationId { get; set; } // Foreign Key for Designation

        public string role {  get; set; }
        public string designation { get; set; }
    }
}
