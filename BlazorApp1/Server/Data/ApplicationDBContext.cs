using BlazorApp1.Shared;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Shared.Models;
namespace BlazorApp1.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseInMemoryDatabase("InMemoryDB");
            }
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}

