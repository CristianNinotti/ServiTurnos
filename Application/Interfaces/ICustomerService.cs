using Application.Models.Request;
using Application.Models.Response;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerResponse> GetAllCustomers();
        CustomerResponse? GetCustomerById(int id);
        void CreateCustomer(CustomerRequest entity);
        bool UpdateCustomer(int id, CustomerRequest customer);
        bool DeleteCustomer(int id);
    }
}
