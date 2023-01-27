using AngularASPcrud.Domain;
using AngularASPcrud.Domain.Models;
using AngularASPcrud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace AngularASPcrud.Services
{
    public class StudentService : IStudentService
    {   
        private static List<Student> stud = new List<Student>();


        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null) 
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return student;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return await _context.Students.FirstOrDefaultAsync(student => student.Id == id);
        }

        

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var Dbstudent = await _context.Students.FindAsync(student.Id);

            Dbstudent.firstname = student.firstname;
            Dbstudent.lastname = student.lastname;
            Dbstudent.course = student.course;
           
            await _context.SaveChangesAsync();
            return Dbstudent;
        }
    }
}
