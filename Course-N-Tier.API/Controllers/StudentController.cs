using Course_N_Tier.BLL.Dtos;
using Course_N_Tier.BLL.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course_N_Tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManger studentManger;

        public StudentController(IStudentManger studentManger)
        {
            this.studentManger = studentManger;
        }

        [HttpGet("GetAllStudets")]
        public IActionResult GetAllStudets() {
            var studets = studentManger.GetAllStuedt();
            return Ok(studets);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetStudentById(Guid id)
        {
            var student = studentManger.GetStuedtById(id);

            if (student == null)
                return NotFound("الطالب غير موجود");

            return Ok(student);
        }
        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] StudentAddDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            studentManger.AddStudent(studentDto);
            return Ok("تم إضافة الطالب بنجاح");
        }
        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] StudentUpdateDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                studentManger.UpdateStudent(studentDto);
                return Ok("تم تحديث بيانات الطالب بنجاح");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id:Guid}")]
        public IActionResult DeleteStudent(Guid id)
        {
            try
            {
                studentManger.DeleteStudent(id);
                return Ok("تم حذف الطالب بنجاح");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
