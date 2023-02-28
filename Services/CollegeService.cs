using Clg_Dept_Student_APIs.DBContext;
using Clg_Dept_Student_APIs.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Clg_Dept_Student_APIs.Services
{
    public class CollegeService : ICollegeService
    {
        private readonly ClgDeptStudentDbContext _dbContext;
        public CollegeService(ClgDeptStudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<College>> GetAll()
        {
            //var query = $"select * from [dbo].[College]";
            //return await _dbContext.Colleges.FromSqlRaw<College>(query).ToListAsync();
            var obj = await _dbContext.Colleges
                .Include(c => c.Departments)
                .ThenInclude(c => c.Students)
                .OrderByDescending(x => x.Cid).AsNoTracking().ToListAsync();
            return obj;

        }

        public College GetCollegeById(int id)
        {
            try
            {
                var clg = _dbContext.Colleges.Find(id);
                if (clg == null)
                {
                    throw new KeyNotFoundException("College not found");

                }
                return clg;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<College> PostCollege(College college)
        {
            await _dbContext.Colleges.AddAsync(college);
            await _dbContext.SaveChangesAsync();
            return college;
        }

        public College Update(College clg)
        {
            _dbContext.Colleges.Update(clg);
            _dbContext.SaveChangesAsync();
            return clg;
        }

        public void DeleteCollegeById(int id)
        {
            try
            {
                var getCollegeDetailsById = GetCollegeById(id);
                _dbContext.Colleges.Remove(getCollegeDetailsById);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


