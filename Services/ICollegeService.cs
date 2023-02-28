using Clg_Dept_Student_APIs.Models;

namespace Clg_Dept_Student_APIs.Services
{
    public interface ICollegeService
    {
        Task<List<College>> GetAll();
        public College GetCollegeById(int id);
        Task<College> PostCollege(College college);
        public College Update(College clg);
        public void DeleteCollegeById(int id);
    }
}
