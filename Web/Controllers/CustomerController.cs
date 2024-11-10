using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/customer")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    [Authorize(Policy = "CustomerOrProfessionalOrSuperAdmin")]
    public IActionResult GetAllCustomer()
    {
        var response = _customerService.GetAllCustomers();

        if (response.Count is 0)
        {
            return NotFound("Customer not found");
        }

        return Ok(response);
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "CustomerOrProfessionalOrSuperAdmin")]
    public ActionResult<CustomerResponse?> GetCustomerById([FromRoute] int id)
    {
        var response = _customerService.GetCustomerById(id);

        if (response is null)
        {
            return NotFound("Customer not found");
        }

        return Ok(response);
    }

    [HttpPost]
    
    public IActionResult CreateCustomer([FromBody] CustomerRequest customer)
    {
        _customerService.CreateCustomer(customer);
        return Ok("Usuario creado con éxito");
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "CustomerOrSuperAdmin")]
    public ActionResult<bool> UpdateCustomer([FromRoute] int id, [FromBody] CustomerRequest customer)
    {
        return Ok(_customerService.UpdateCustomer(id, customer));
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "CustomerOrSuperAdmin")]
   
    public ActionResult<bool> DeleteCustomer([FromRoute] int id)
    {
        return Ok(_customerService.DeleteCustomer(id));
    }
}