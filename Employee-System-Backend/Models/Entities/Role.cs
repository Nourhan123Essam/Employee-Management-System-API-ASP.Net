﻿using Employee_Management_Stytem.Models.Entities;

namespace Employee_System_Backend.Models.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}