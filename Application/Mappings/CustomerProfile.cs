using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
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
                UserName = customer.UserName,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Dni = customer.Dni,
                Email = customer.Email,
                TypeCustomer = customer.TypeCustomer
            };
        }

        public static List<CustomerResponse> ToCustomerResponse(List<DomainEntity.Customer> customers)
        {
            return customers.Select(c => new CustomerResponse
            {
                Id = c.Id,
                UserName = c.UserName,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Dni = c.Dni,
                Email = c.Email,
                TypeCustomer = c.TypeCustomer

            }).ToList();
        }
    }
}
