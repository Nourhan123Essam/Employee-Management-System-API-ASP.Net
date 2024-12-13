using AutoMapper;
using Employee_Management_Stytem.Models.Entities;
using Employee_System_Backend.Models.DTOs;
using Employee_System_Backend.Models.Entities;

namespace Employee_System_Backend.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Role, AddRoleDto>().ReverseMap();
            CreateMap<Client, AddClientDto>().ReverseMap();

            CreateMap<Project, AddProjectDto>().ReverseMap();
            CreateMap<Project, SelectProjectDto>().ReverseMap();

            CreateMap<Employee, AddEmployeeDto>().ReverseMap();
            CreateMap<SelectEmployeeDto, Employee>().ReverseMap();

            CreateMap<Designation, AddDesignationDto>().ReverseMap();
        }
    }
}
