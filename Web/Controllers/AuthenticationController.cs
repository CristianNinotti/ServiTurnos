using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly IAuthenticationService _customAuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _customAuthenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            string token = _customAuthenticationService.Authenticate(authenticationRequest);

            return Ok(token);
        }
    }
}