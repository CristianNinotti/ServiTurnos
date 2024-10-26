using Application.Interfaces;
using Application.Models.Helpers;
using Application.Models.Request;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.ThirdServices;

public class AuthenticationService : IAuthenticationService
{
    private readonly IProfessionalRepository _professionalRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISuperAdminRepository _superAdminRepository;
    private readonly AuthenticationServiceOptions _options;

    public AuthenticationService(
        IProfessionalRepository professionalRepository,
        ICustomerRepository customerRepository,
        ISuperAdminRepository superAdminRepository,
        IOptions<AuthenticationServiceOptions> options)
    {
        _professionalRepository = professionalRepository;
        _customerRepository = customerRepository;
        _superAdminRepository = superAdminRepository;
        _options = options.Value;
    }


    private User? ValidateUser(AuthenticationRequest authenticationRequest)
    {
        
        User? user = null;

        
        var professionals = _professionalRepository.GetProfessional();
        user = professionals.FirstOrDefault(x =>
            x.UserName.Equals(authenticationRequest.UserName) &&
            x.Password.Equals(authenticationRequest.Password));

        if (user != null)
            return user;

        
        var customers = _customerRepository.GetAllCustomers(); 
        user = customers.FirstOrDefault(x =>
            x.UserName.Equals(authenticationRequest.UserName) &&
            x.Password.Equals(authenticationRequest.Password));

        if (user != null)
            return user;

        
        var superAdmins = _superAdminRepository.GetAllSuperAdmins(); 
        user = superAdmins.FirstOrDefault(x =>
            x.UserName.Equals(authenticationRequest.UserName) &&
            x.Password.Equals(authenticationRequest.Password));

        return user; 
    }



    public string Authenticate(AuthenticationRequest authenticationRequest)
    {
        var user = ValidateUser(authenticationRequest);

        if (user == null)
        {
            throw new Exception("Authentication failed");
        }

        var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

        var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("Id", user.Id.ToString()));
        claimsForToken.Add(new Claim("Name", user.FirstName));
        claimsForToken.Add(new Claim("LastName", user.LastName));
        claimsForToken.Add(new Claim("TypeCustomer", user.TypeCustomer));

        var jwtSecurityToken = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(30),
            credentials);

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);

        return tokenToReturn.ToString();
    }
}