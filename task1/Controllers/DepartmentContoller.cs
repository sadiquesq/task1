using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using task1.DTOs;
using task1.models;
using task1.Services;


namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentContoller : ControllerBase
    {
        private readonly IDeparmentServices _deparmentServices;

        private readonly MainDbContext _mainDbContext;

        private readonly IMapper _mapper;

        public DepartmentContoller(IDeparmentServices deparmentServices,MainDbContext mainDbContext,IMapper mapper)
        {
            _deparmentServices = deparmentServices;

            _mainDbContext = mainDbContext;


            _mapper = mapper;
        }



        [HttpGet("{id}")]

        public ActionResult<List<Department>> Get(int id)
        {
            //var dep = _mainDbContext.Departments
            //    .Include(e => e.Employee).Where(e => e.DepartmentId == id);

            var dep = _mainDbContext.Departments.
                Include(e => e.Employee).ToList().FirstOrDefault(e => e.DepartmentId == id);

            return Ok(dep);
        }



        [HttpGet]
        public ActionResult<List<Student>> Get() 
        
        {
            var stu = _mainDbContext.Students.ToList();
                //.Include(e => e.Address).ToList();
            return Ok(stu);
            //return Ok(new List<Student>());

        }



        [HttpGet("emp/{Id}")]

        public IActionResult empId(int Id)
        {
            //var emp = _mainDbContext.Employees.Where(e => e.Id == Id)
            //    .Include(e => e.Department).ToList();

            var emp = _mainDbContext.Employees.Include(r => r.Department).FirstOrDefault(e => e.Id == Id);

            if(emp == null)
            {
                return NotFound("employee is not found");
            }



            var dt = new EmployeeDTO
            {
                Id = emp.Id,
                DeparmentName = emp.Department.DepartmentName,
                Name = emp.Name
            };
            return Ok(dt);
        }



        [HttpPost]


        public IActionResult InputEmployee(EmployeeInsertDTO dto)
        {

            var n=_mapper.Map<Employee>(dto);

            //var n = new Employee
            //{
            //    Id =dto.Id,
            //    Name = dto.Name,
            //    DepartmentId = dto.DepartmentId
            //};

            var dep = _mainDbContext.Employees.Add(n);
            _mainDbContext.SaveChangesAsync();
            return Ok(dep);

        }
    }
}
