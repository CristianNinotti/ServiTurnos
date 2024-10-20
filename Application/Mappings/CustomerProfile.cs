using Application.Models.Request;
using Application.Models.Response;
using DomainEntity = Domain.Entities;

namespace Application.Mappings
{
    public static class CustomerProfile
    {
        public static DomainEntity.Customer ToCustomerEntity(CustomerRequest request)
        {
            return new DomainEntity.Customer()
            {
                UserName = request.UserName,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Dni = request.Dni,
                Email = request.Email,
                TypeCustomer = request.TypeCustomer

            };
        }

        public static void ToCustomerEntityUpdate(DomainEntity.Customer customer, CustomerRequest request)
        {
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Dni = request.Dni;
        }

        public static CustomerResponse ToCustomerResponse(DomainEntity.Customer customer)
        {
            return new CustomerResponse()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Dni = customer.Dni,
                Email = customer.Email
            };
        }

        public static List<CustomerResponse> ToCustomerResponse(List<DomainEntity.Customer> customers)
        {
            return customers.Select(c => new CustomerResponse
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Dni = c.Dni,
                Email = c.Email

            }).ToList();
        }
    }
}
