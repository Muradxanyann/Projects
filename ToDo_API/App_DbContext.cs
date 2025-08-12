using Microsoft.EntityFrameworkCore;
using ToDoModel;

namespace TodoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TodoModel> TodoItems { get; set; } = null!;
    }
}