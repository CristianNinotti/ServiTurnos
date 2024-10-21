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
    private readonly AuthenticationServiceOptions _options;

    public AuthenticationService(IProfessionalRepository professionalRepository, IOptions<AuthenticationServiceOptions> options)
    {
        _professionalRepository = professionalRepository;
        _options = options.Value;
    }

    private Professional? ValidateUser(AuthenticationRequest authenticationRequest)
    {

        var professionals = _professionalRepository.GetProfessional();

        var user = professionals.FirstOrDefault(x => x.UserName.Equals(authenticationRequest.UserName) && x.Password.Equals(authenticationRequest.Password));

        return user;
    }

    public string Authenticate(AuthenticationRequest authenticationRequest)
    {
        var user = ValidateUser(authenticationRequest);

        if (user == null)
        {
            throw new Exception("Professional authentication failed");
        }

        var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

        var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.Id.ToString()));
        claimsForToken.Add(new Claim("given_name", user.FirstName));
        claimsForToken.Add(new Claim("family_name", user.LastName));

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