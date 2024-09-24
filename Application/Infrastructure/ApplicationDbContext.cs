using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure
{
    public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    public DbSet<Persona> Personas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Aquí puedes configurar las entidades si es necesario
      base.OnModelCreating(modelBuilder);
    }


  }
}
