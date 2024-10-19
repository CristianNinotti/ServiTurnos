using Domain.Entities;
using System.Collections.Generic;

public class DbContext : DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    public DbSet<Professional> Professionals { get; set; }
    //public DbSet<Customer> Customers { get; set; }
    //public DbSet<Meet> Meetings { get; set; }
}