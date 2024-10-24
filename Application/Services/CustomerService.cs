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
                return CustomerProfile.ToCustomerResponse(customers);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hay un error en la clase");
                throw new Exception(e.Message);
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

                if (!string.IsNullOrEmpty(customer.UserName) && customer.UserName != "string")
                {
                    customerEntity.UserName = customer.UserName;
                }

                if (!string.IsNullOrEmpty(customer.Password) && customer.Password != "string")
                {
                    customerEntity.Password = customer.Password;
                }

                if (!string.IsNullOrEmpty(customer.FirstName) && customer.FirstName != "string")
                {
                    customerEntity.FirstName = customer.FirstName;
                }

                if (!string.IsNullOrEmpty(customer.LastName) && customer.LastName != "string")
                {
                    customerEntity.LastName = customer.LastName;
                }

                if (customer.Dni != 0)
                {
                    customerEntity.Dni = customer.Dni;
                }

                if (!string.IsNullOrEmpty(customer.Email) && customer.Email != "string")
                {
                    customerEntity.Email = customer.Email;
                }


                if (customer.TypeCustomer != customer.TypeCustomer)
                {
                    customerEntity.TypeCustomer = customer.TypeCustomer;
                }

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
