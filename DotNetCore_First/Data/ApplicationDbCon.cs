using DotNetCore_First.Models;
using Microsoft.EntityFrameworkCore;
namespace DotNetCore_First.Data
{
    public class ApplicationDbCon: DbContext
    {
        public ApplicationDbCon(DbContextOptions<ApplicationDbCon> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Rector> Rectors { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Council> Councils { get; set; }
    }
}
