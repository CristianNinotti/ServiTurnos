using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<Customer>
            {
                new Customer
                { Id = 1, UserName = "Fana", Password = "fana123", FirstName = "Cristian", LastName = "Ninotti", Dni = 34732713, Email = "cristianninotti03@gmail.com", TypeCustomer = "admin"}


                

            });
    }   }
}
