using Clg_Dept_Student_APIs.DBContext;
using Clg_Dept_Student_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace Clg_Dept_Student_APIs.Services
{
    public class StudentService : IStudentService
    {
        private readonly ClgDeptStudentDbContext _dbContext;

        public StudentService(ClgDeptStudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Student>> GetAll()
        {
            try
            {
                var query = "select * from Student";
                return await _dbContext.Students.FromSqlRaw<Student>(query).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student GetStudentById(int id)
        {
            var std = _dbContext.Students.Find(id);
            if (std == null)
            {
                throw new KeyNotFoundException("Not found");
            }
            return std;
        }

        public async Task<Student> PostStudent(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public Student UpdateStudent(Student student)
        {
            _dbContext.Students.Update(student);
            _dbContext.SaveChangesAsync();
            return student;
        }

        public void DeleteStudent(int id)
        {
            var getStudentDetailsById = GetStudentById(id);
            _dbContext.Students.Remove(getStudentDetailsById);
            _dbContext.SaveChangesAsync();

        }
    }
}
