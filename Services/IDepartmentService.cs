using Clg_Dept_Student_APIs.Models;

namespace Clg_Dept_Student_APIs.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAll();
        Department GetDepartmentsById(int id);
        Task<Department> PostDepartment(Department department);

        Department UpdateDept(Department department);
        public void DeleteDepartment(int id);

    }
}
