using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ServiTurnosDbContext : DbContext
    {
        public ServiTurnosDbContext(DbContextOptions<ServiTurnosDbContext> options) : base(options)
        {
             
        }
        public DbSet<Professional> Professional { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    }
}

