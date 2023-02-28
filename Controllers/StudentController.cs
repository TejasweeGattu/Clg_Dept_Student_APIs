using Clg_Dept_Student_APIs.Models;
using Clg_Dept_Student_APIs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clg_Dept_Student_APIs.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    // [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _istudentService;
        public StudentController(IStudentService studentService)
        {
            _istudentService = studentService;
        }

        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetAll()
        {
            var std = await _istudentService.GetAll();
            if (std == null)
            {
                return NotFound("Record not entered");
            }
            return Ok(std);
        }

        [HttpGet("GetStudentsById")]
        public IActionResult GetStudents(int id)
        {
            Student std = _istudentService.GetStudentById(id);
            if (std == null)
            {
                return NotFound("Not found");
            }
            return Ok(std);
        }

        [HttpPost("AddStudents")]
        public IActionResult Create([FromBody] Student student)
        {
            var std = _istudentService.PostStudent(student);
            if (std == null)
            {
                return BadRequest();
            }
            return Ok(std);
        }

        [HttpPut("UpdateStudents")]
        public IActionResult UpdateStudent(Student student)
        {
            var std = _istudentService.UpdateStudent(student);
            if (std == null)
            {
                return BadRequest();
            }
            return Ok(std);
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteDept(int id)
        {
            _istudentService.DeleteStudent(id);
            return Ok(new { message = "User deleted" });
        }


    }
}
