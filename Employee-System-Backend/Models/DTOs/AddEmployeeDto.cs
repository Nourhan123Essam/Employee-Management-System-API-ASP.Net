using Employee_System_Backend.Models.Entities;

namespace Employee_System_Backend.Models.DTOs
{
    public class AddEmployeeDto
    {
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

    }
}
