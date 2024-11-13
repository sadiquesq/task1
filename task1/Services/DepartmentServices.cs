using Microsoft.AspNetCore.Mvc;
using task1.Controllers;
using task1.models;

namespace task1.Services
{


    public interface IDeparmentServices
    {
        Task<Department> getDepartment(int id);
    }
    public class DepartmentServices : IDeparmentServices
    {

        private readonly MainDbContext _dbContext;

        public DepartmentServices(MainDbContext db)
        {
            _dbContext = db;
        }
        public async Task<Department> getDepartment(int id)
        {
            var dep = await _dbContext.Departments.FindAsync(id);
            return dep;
        }



    }
}
