using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Models.Domain;
using StudentManagement.Models.DTO;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdentsController : ControllerBase
    {
        private readonly StudentDBContext studentDBContext;
        public StdentsController(StudentDBContext studentDBContext)
        {
            this.studentDBContext = studentDBContext;
        }


        [HttpGet(Name = "GetStudentDetails")]
        public IActionResult Get()
        {
            var studentsdetails = this.studentDBContext.StudentMaster.ToList();
            return Ok(studentsdetails);
        }

        [HttpPost(Name = "CreateStudentDetails")]
        public IActionResult Post(StudentDto request)
        {
            var studentsdetails = new StudentMaster
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Emailid = request.Emailid,
                DateofBirth = request.DateofBirth
            };

            this.studentDBContext.Add(studentsdetails);
            this.studentDBContext.SaveChanges();
            return Ok(studentsdetails);
        }
    }
}
