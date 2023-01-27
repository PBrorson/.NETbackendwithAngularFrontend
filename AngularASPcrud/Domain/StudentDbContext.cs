using AngularASPcrud.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularASPcrud.Domain
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }


    }
}
