
using ClienteMvc.Data;
using Microsoft.EntityFrameworkCore;

Data / ApplicationDbContext.cs:

using Microsoft.EntityFrameworkCore;
using ClienteMvc.Models;

namespace ClienteMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(c => c.ID_Cliente);
        }
    }
}

