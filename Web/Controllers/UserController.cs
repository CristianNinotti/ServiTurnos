using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new List<User> {

                            new User {
                                Id =1, 
                                UserName="Fana",
                                Password="asd",
                                FirstName="Cristian", 
                                LastName="Ninotti", 
                                DNI=34732713,
                                Email="cristianninotti03@gmail.com"
                                }
            });
        }
    }
}
