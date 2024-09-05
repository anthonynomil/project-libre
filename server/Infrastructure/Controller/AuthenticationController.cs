using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interface;
using Infrastructure.Abstract;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;

namespace Infrastructure.Controller;

[ApiController]
[Route("[controller]/[action]")]
public sealed class AuthenticationController(
    IConfiguration config,
    IAuthenticationControllerService service
) : BaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(IEnvelop<AuthenticationDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login(AuthenticationDtoLogin authenticationDtoLogin)
    {
        var userResult = await service.GetUserDtoByCredentialsAsync(authenticationDtoLogin);
        if (userResult.IsSuccessful == false)
            return SendEnvelop(userResult);

        var result = ResultSuccess<AuthenticationDto>.Retrieved(
            new AuthenticationDto
            {
                User = userResult.Value!,
                Token = GenerateJsonWebToken(userResult.Value!)
            },
            "Authentication successful."
        );

        return SendEnvelopWithValue(result);
    }

    private string GenerateJsonWebToken(UserDto userDto)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = CreateJwtClaims(userDto);
        var expires = int.Parse(config["Jwt:Expires"]!);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(expires),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static List<Claim> CreateJwtClaims(UserDto userDto)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userDto.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        claims.AddRange(
            userDto.UserRoles.Select(
                userUserRole => new Claim(ClaimTypes.Role, ((int)userUserRole.Value).ToString())
            )
        );

        return claims;
    }
}
