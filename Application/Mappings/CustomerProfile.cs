﻿using Application.Models.Request;
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
                TypeCustomer = "Customer",
                Phone = request.Phone,
                Address = request.Address,
            };
        }


        public static CustomerResponse ToCustomerResponse(DomainEntity.Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "El cliente no puede ser nulo.");
            }

            return new CustomerResponse()
            {
                UserName = customer.UserName,
                Password = customer.Password,
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Dni = customer.Dni,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
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
                Phone = customer.Phone,
                Address = customer.Address

            }).ToList();
        }
    }
}