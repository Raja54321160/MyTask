using Microsoft.EntityFrameworkCore;

namespace Raja_Form_API.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> op): base(op)
        {

        }
        public DbSet<Student> StudentDetails { get; set; }
    }
}
