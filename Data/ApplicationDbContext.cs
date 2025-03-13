using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<ToDoTask> ToDoTask { get; set; }
    }
}
