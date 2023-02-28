using Clg_Dept_Student_APIs.DBContext;
using Clg_Dept_Student_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Clg_Dept_Student_APIs.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ClgDeptStudentDbContext _dbContext;

        public DepartmentService(ClgDeptStudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Department>> GetAll()
        {
            //var query = "select * from Department";
            //return await _dbContext.Departments.FromSqlRaw<Department>(query).ToListAsync();
            var obj = await _dbContext.Departments.Include(c => c.Students).ToListAsync();
            return obj;

        }

        public Department GetDepartmentsById(int id)
        {
            var dept = _dbContext.Departments.Find(id);
            if (dept == null)
            {
                throw new KeyNotFoundException("Not found");
            }
            return dept;
        }

        public async Task<Department> PostDepartment(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();
            return department;
        }

        public Department UpdateDept(Department department)
        {
            _dbContext.Departments.Update(department);
            _dbContext.SaveChangesAsync();
            return department;
        }

        public void DeleteDepartment(int id)
        {
            var getDeptdetailsById = GetDepartmentsById(id);
            _dbContext.Departments.Remove(getDeptdetailsById);
            _dbContext.SaveChangesAsync();

        }
    }
}
