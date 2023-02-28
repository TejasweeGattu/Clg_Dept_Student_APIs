using Clg_Dept_Student_APIs.Models;

namespace Clg_Dept_Student_APIs.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Student GetStudentById(int id);
        Task<Student> PostStudent(Student student);
        Student UpdateStudent(Student student);
        public void DeleteStudent(int id);
    }
}
