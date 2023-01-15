using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class ApplicationDBContext:DbContext  //SQL server DB
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; } //table student insql server
    }
}
