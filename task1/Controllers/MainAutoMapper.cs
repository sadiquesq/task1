using AutoMapper;
using task1.DTOs;
using task1.models;

namespace task1.Controllers
{
    public class MainAutoMapper : Profile
    {
        public MainAutoMapper()
        {
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<EmployeeInsertDTO, Employee>();

            CreateMap<Employee, EmployeeInsertDTO>();
        }

    }
}
