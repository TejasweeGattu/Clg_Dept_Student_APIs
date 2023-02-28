using Clg_Dept_Student_APIs.Models;
using Clg_Dept_Student_APIs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clg_Dept_Student_APIs.Controllers
{
    [Route("api/Colleges")]
    [ApiController]
    //  [Authorize]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeService _icollegeService;

        // private readonly ILogger _logger;
        public CollegeController(ICollegeService icollegeService)
        {
            _icollegeService = icollegeService;
            // _logger = logger;
        }


        [HttpGet("GetColleges")]
        public async Task<IActionResult> GetAll()
        {
            // _logger.LogInformation("Logs for Get method");

            try
            {
                var clg = await _icollegeService.GetAll();
                if (clg == null)
                {
                    return NotFound("Record Not Entered");
                }
                return Ok(clg);
            }
            catch (Exception e)
            {

                // _logger.LogCritical(e.Message, e.InnerException);
                Console.WriteLine(e.Message);

            }
            return BadRequest();

        }

        [HttpGet("GetCollegesById")]

        public IActionResult GetColleges(int id)
        {
            // _logger.LogInformation("Logs for Get method");

            try
            {

                College clg = _icollegeService.GetCollegeById(id);
                if (clg == null)
                {
                    return NotFound("Record Not Entered");
                }
                return Ok(clg);
            }
            catch (Exception e)
            {

                //   _logger.LogCritical(e.Message, e.InnerException);
                Console.WriteLine(e.Message);
            }
            return BadRequest();

        }


        [HttpPost("AddColleges")]
        public async Task<IActionResult> Post([FromBody] College clg)
        {
            //  _logger.LogInformation("Logs for post method");


            try
            {
                var colleges = await _icollegeService.PostCollege(clg);
                if (colleges == null)
                {
                    return NotFound("Record Not Entered");
                }
                return Ok(colleges);
            }
            catch (Exception e)
            {
                //  _logger.LogCritical(e.Message, e.InnerException);
                Console.WriteLine(e.Message);
            }
            return BadRequest();

        }

        [HttpPut("UpdateCollege")]
        public ActionResult UpdateCollege([FromBody] College clg)
        {
            // _logger.LogInformation("Logs for update method");
            try
            {
                var clgdetails = _icollegeService.Update(clg);
                if (clgdetails == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(clgdetails);
                }
            }
            catch (Exception e)
            {
                //_logger.LogCritical(e.Message, e.InnerException, e.ToString);
                //_logger.LogError(e.Message, e.InnerException);
                Console.WriteLine(e.Message);

            }
            return BadRequest();
        }
        [HttpDelete("DeleteCollegeById")]

        public IActionResult DeleteColleges(int id)
        {

            //_logger.LogInformation("Logs for delete method");
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                else
                {
                    _icollegeService.DeleteCollegeById(id);
                    return Ok(new { message = "User deleyed" });
                }

            }
            catch (Exception e)
            {
                //   _logger.LogCritical(e.Message, e.InnerException);
                Console.WriteLine(e.Message);

            }
            return BadRequest();

        }
    }
}
