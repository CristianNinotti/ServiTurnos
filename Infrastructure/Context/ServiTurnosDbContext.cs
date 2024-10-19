using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Context
{
    public class ServiTurnosDbContext : DbContext
    {
        public ServiTurnosDbContext(DbContextOptions<ServiTurnosDbContext> options) : base(options)
        {
             
        }
        public DbSet<Professional> Professional { get; set; }

        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Meet> Meetings { get; set; }
    }
}