using Employee_System_Backend.Models.Entities;
using System.Data;

namespace Employee_Management_Stytem.Models.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public int RoleId { get; set; } // Foreign Key for Role
        public Role Role { get; set; } // Navigation Property
        public int DesignationId { get; set; } // Foreign Key for Designation
        public Designation Designation { get; set; } // Navigation Property

        public ICollection<Project>? ProjectsLed { get; set; } // Projects they are leading
        public ICollection<Project> Projects { get; set; }
    }




}

