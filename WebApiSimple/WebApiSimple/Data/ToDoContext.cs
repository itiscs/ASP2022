using Microsoft.EntityFrameworkCore;
using WebApiSimple.Models;

namespace WebApiSimple.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=todosdb;Username=postgres;Password=1");
        //}

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
