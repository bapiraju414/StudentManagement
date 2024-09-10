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


        [HttpPut(Name = "UpdateStudentDetails")]       
        public IActionResult Put(Int64 id, StudentDto request)
        {

            var student = studentDBContext.StudentMaster.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Emailid = request.Emailid;
            student.DateofBirth = request.DateofBirth;          
                        
            this.studentDBContext.SaveChanges();
            return Ok(student);
        }

        [HttpDelete(Name = "DeleteStudentDetails")]
        public IActionResult Delete(Int64 id)
        {

            var teacher = studentDBContext.StudentMaster.Find(id);

            if (teacher == null)
            {
                return NotFound();
            }
            this.studentDBContext.Remove(id);
            this.studentDBContext.SaveChanges();
            return Ok(teacher);
        }


    }
}
