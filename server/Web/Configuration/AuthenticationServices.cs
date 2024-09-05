using System.Text;
using Entities.Enum;
using Infrastructure.Constant;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Protocols.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Web.Configuration;

internal static class AuthenticationServices
{
    private const string ConfigurationKey = "Jwt";
    private const string ConfigurationSeparator = ":";
    private static readonly string[] ConfigurationAttributes = ["Audience", "Issuer", "Expires"];

    private const string JwtIssuerKey = "Jwt:Issuer";
    private const string JwtAudienceKey = "Jwt:Audience";
    private const string JwtSecreteKey = "Jwt:Key";

    public static void SetupAuthentication(this WebApplicationBuilder builder)
    {
        builder.ValidateConfiguration();
        builder.SetupJwtBearerServices();
        builder.SetupAuthorization();
    }

    private static void ValidateConfiguration(this WebApplicationBuilder builder)
    {
        foreach (var configurationAttribute in ConfigurationAttributes)
        {
            if (string.IsNullOrWhiteSpace(builder.Configuration[$"{ConfigurationKey}{ConfigurationSeparator}{configurationAttribute}"]))
                throw new InvalidConfigurationException(
                    $"No {configurationAttribute} was provided for the {ConfigurationKey} configurationAttribute."
                );
        }
    }

    private static void SetupJwtBearerServices(this WebApplicationBuilder builder)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration[JwtIssuerKey],
            ValidAudience = builder.Configuration[JwtAudienceKey],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[JwtSecreteKey]!))
        };

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
               options.TokenValidationParameters = tokenValidationParameters;
            });
    }

    private static void SetupAuthorization(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(AuthorizationPolicyConstant.Authenticated, policy =>
                policy.RequireAuthenticatedUser())
            .AddPolicy(AuthorizationPolicyConstant.Admin, policy =>
                policy.RequireRole(((int)UserRoleEnum.Admin).ToString()));
    }
}