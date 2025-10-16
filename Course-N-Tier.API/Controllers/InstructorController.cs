using Course_N_Tier.BLL.Dtos;
using Course_N_Tier.BLL.Manager;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Course_N_Tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorManger instructorManger;

        public InstructorController(IInstructorManger instructorManger)
        {
            this.instructorManger = instructorManger;
        }

        [HttpGet("GetAllInstructors")]
        public IActionResult GetAllInstructors()
        {
            var instructors = instructorManger.GetAllInstructors();
            return Ok(instructors);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetInstructorById(Guid id)
        {
            var instructor = instructorManger.GetInstructorById(id);

            if (instructor == null)
                return NotFound("المدرب غير موجود");

            return Ok(instructor);
        }

        [HttpPost("AddInstructor")]
        public IActionResult AddInstructor([FromBody] InstructorAddDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            instructorManger.AddInstructor(dto);
            return Ok("تم إضافة المدرب بنجاح");
        }

        [HttpPut("UpdateInstructor/{id:guid}")]
        public IActionResult UpdateInstructor(Guid id, [FromBody] InstructorUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                instructorManger.UpdateInstructor(dto);
                return Ok("تم تحديث بيانات المدرب بنجاح");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteInstructor(Guid id)
        {
            try
            {
                instructorManger.DeleteInstructor(id);
                return Ok("تم حذف المدرب بنجاح");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
