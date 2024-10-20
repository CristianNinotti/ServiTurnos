using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Data;

public class CustomerRepository : ICustomerRepository
{
    private readonly ServiTurnosDbContext _context;

    public CustomerRepository(ServiTurnosDbContext context)
    {
        _context = context;
    }

    public List<Customer> GetAllCustomers()
    {
        return _context.Customers.ToList();
    }

    public Customer? GetCustomerById(int id)
    {
        return _context.Customers.FirstOrDefault(x => x.Id.Equals(id));
    }

    public void AddCustomer(Customer entity)
    {
        _context.Customers.Add(entity);
        _context.SaveChanges();
    }

    public void UpdateCustomer(Customer entity)
    {
        _context.Customers.Update(entity);
        _context.SaveChanges();
    }

    public void DeleteCustomer(Customer entity)
    {
        _context.Customers.Remove(entity);
        _context.SaveChanges();
    }
}
