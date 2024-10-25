using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerResponse> GetAllCustomers()
        {
            try
            {
                var customers = _customerRepository.GetAllCustomers();
                // Verifica si customers es null
                if (customers == null)
                {
                    Console.WriteLine("No se encontraron clientes.");
                    return new List<CustomerResponse>(); // Retorna una lista vacía en lugar de null
                }

                return customers.Select(CustomerProfile.ToCustomerResponse).ToList(); // Usa LINQ para convertir la lista de DomainEntity.Customer a CustomerResponse
            }
            catch (Exception e)
            {
                Console.WriteLine("Hay un error en la clase: " + e.Message);
                throw; // Vuelve a lanzar la excepción original
            }
        }

        public CustomerResponse? GetCustomerById(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer != null)
            {
                return CustomerProfile.ToCustomerResponse(customer);
            }

            return null;
        }

        public void CreateCustomer(CustomerRequest entity)
        {
            var customerEntity = CustomerProfile.ToCustomerEntity(entity);
            _customerRepository.AddCustomer(customerEntity);
        }


        public bool UpdateCustomer(int id, CustomerRequest customer)
        {
            var customerEntity = _customerRepository.GetCustomerById(id);

            if (customerEntity != null)
            {
                CustomerProfile.ToCustomerEntityUpdate(customerEntity, customer);

                _customerRepository.UpdateCustomer(customerEntity);

                return true;
            }

            return false;
        }


        public bool DeleteCustomer(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer != null)
            {
                _customerRepository.DeleteCustomer(customer);

                return true;
            }

            return false;
        }
    }
}