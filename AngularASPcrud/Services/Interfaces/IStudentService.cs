using AngularASPcrud.Domain.Models;


namespace AngularASPcrud.Services.Interfaces
{
    public interface IStudentService
    {

        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(int id);
    }
}
