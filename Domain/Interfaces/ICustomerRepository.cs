using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer? GetCustomerById(int id);
        void AddCustomer(Customer entity);
        void UpdateCustomer(Customer entity);
        void DeleteCustomer(Customer entity);
    }
}
