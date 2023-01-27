
using AngularASPcrud.Domain.Models;
using AngularASPcrud.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AngularASPcrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // vet fan inte varken vad jag gör eller varför det inte funkar?! 

        //[HttpGet]
        //[Route("GetFullName")]
        //public ActionResult<List<Student>> GetFullName()
        //{

        //}

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllStudentsAsync());
        }


        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var student = await _studentService.GetByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpPost]
        [Route("CreateStudent")]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            return Ok(await _studentService.CreateStudentAsync(student));
        }

        [HttpPut]
        [Route("UpdateStudent/{id:int}")]
        public async Task<IActionResult> UpdateStudent(Student updatedStudent)
        {
            var student = await _studentService.GetAllStudentsAsync();
            if (student is null)
            {
                return NotFound();
            }
            return Ok(await _studentService.UpdateStudentAsync(updatedStudent));


        }

        [HttpDelete]
        [Route("DeleteStudent/{id:int}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            try
            {
                var student = await _studentService.GetByIdAsync(id);

                if (student == null)
                {
                    return NotFound();
                }


                return await _studentService.DeleteStudentAsync(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }

}

