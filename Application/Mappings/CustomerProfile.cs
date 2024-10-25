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
                TypeCustomer = "Customer" // Asegurarse de que el UserType se setee correctamente
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
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "El cliente no puede ser nulo.");
            }

            return new CustomerResponse()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Dni = customer.Dni,
                Email = customer.Email
            };
        }

        public static List<CustomerResponse> ToCustomerResponseList(List<DomainEntity.Customer> customers)
        {
            return customers.Select(customer => new CustomerResponse
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Dni = customer.Dni,
                Email = customer.Email,
                // Si en algún momento es necesario agregarlo
                // UserType = customer.UserType
            }).ToList();
        }
    }
}