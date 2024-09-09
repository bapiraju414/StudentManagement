using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models.Domain;
using StudentManagement.Models.DTO;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly StudentDBContext studentDBContext;
        public TeachersController(StudentDBContext studentDBContext)
        {
            this.studentDBContext = studentDBContext;
        }


        [HttpGet(Name = "GetTeacherDetails")]
        public IActionResult Get()
        {
            var teachersdetails = this.studentDBContext.TeacherMaster.ToList();
            return Ok(teachersdetails);
        }

        [HttpPost(Name = "CreateTeacherDetails")]
        public IActionResult Post(TeacherDTO request)
        {
            var teacherdetails = new TeacherMaster
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Emailid = request.Emailid,
                DateofBirth = request.DateofBirth
            };

            this.studentDBContext.Add(teacherdetails);
            this.studentDBContext.SaveChanges();
            return Ok(teacherdetails);
        }
    }
}
