using Clg_Dept_Student_APIs.Models;
using Clg_Dept_Student_APIs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clg_Dept_Student_APIs.Controllers
{
    [Route("api/Departments")]
    [ApiController]
    //   [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _idepartmentService;
        public DepartmentController(IDepartmentService idepartmentService)
        {
            _idepartmentService = idepartmentService;
        }

        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetAll()
        {
            var dept = await _idepartmentService.GetAll();
            if (dept == null)
            {
                return NotFound("Record not entered");
            }
            return Ok(dept);
        }

        [HttpGet("GetDepartmentsById")]
        public IActionResult GetDept(int id)
        {
            Department department = _idepartmentService.GetDepartmentsById(id);
            if (department == null)
            {
                return NotFound("Not found");
            }
            return Ok(department);
        }

        [HttpPost("AddDepartments")]
        public IActionResult Create([FromBody] Department department)
        {
            var dept = _idepartmentService.PostDepartment(department);
            if (dept == null)
            {
                return BadRequest();
            }
            return Ok(dept);
        }

        [HttpPut("UpdateDepartments")]
        public IActionResult UpdateDeptartment(Department department)
        {
            var dept = _idepartmentService.UpdateDept(department);
            if (dept == null)
            {
                return BadRequest();
            }
            return Ok(dept);
        }

        [HttpDelete("DeleteDept")]
        public IActionResult DeleteDept(int id)
        {
            _idepartmentService.DeleteDepartment(id);
            return Ok(new { message = "User deleted" });
        }



    }
}
