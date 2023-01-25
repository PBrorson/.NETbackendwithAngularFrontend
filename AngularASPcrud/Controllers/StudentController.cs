using AngularASPcrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

namespace AngularASPcrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;


        public StudentController(StudentDbContext studentcontext)
        {
            _studentDbContext = studentcontext; 
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Students.ToListAsync(); 
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student student)
        {
            _studentDbContext.Students.Add(student);
            await _studentDbContext.SaveChangesAsync();
            return student; 

        }
        [HttpPatch]
        [Route("UpdateStudent/id")] 
        public async Task<Student>UpdateStudent (Student student)
        {
            _studentDbContext.Entry(student).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return student; 

        }
        [HttpDelete]
        [Route("DeleteStudent/id")] 
        public IActionResult DeleteStudent(int id) 
        {
            var student = _studentDbContext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentDbContext.Students.Remove(student);
            _studentDbContext.SaveChanges();

            return Ok();
           
        }
        
    }
}
