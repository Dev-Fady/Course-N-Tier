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
        public async Task<IActionResult> GetAllStudets() {
            var studets = await studentManger.GetAllStuedt();
            return Ok(studets);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student =await studentManger.GetStuedtById(id);

            if (student == null)
                return NotFound("الطالب غير موجود");

            return Ok(student);
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentAddDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           await studentManger.AddStudent(studentDto);
            return Ok("تم إضافة الطالب بنجاح");
        }
        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentUpdateDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await studentManger.UpdateStudent(studentDto);
                return Ok("تم تحديث بيانات الطالب بنجاح");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                await studentManger.DeleteStudent(id);
                return Ok("تم حذف الطالب بنجاح");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
