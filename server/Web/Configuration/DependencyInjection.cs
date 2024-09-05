using Application.Interface;
using Application.Service;
using Database.Repository;
using Infrastructure.Configuration;
using Infrastructure.Service;
using Microsoft.OpenApi.Models;

namespace Web.Configuration;

internal static class DependencyInjection
{
    public static void SetupDependencyInjection(this WebApplicationBuilder app)
    {
        app.AddApplicationServices();
        app.AddControllerServices();
        app.AddInfrastructureServices();
        app.AddRepositoryServices();
        if (app.Environment.IsDevelopment())
            app.AddDevelopmentServices();
    }

    private static void AddApplicationServices(this IHostApplicationBuilder app)
    {
        app.Services.AddScoped<IAuthenticationControllerService, UserApplicationService>();
        app.Services.AddScoped<IAddressableApplicationService, AddressableApplicationService>();
        app.Services.AddScoped<IBankDetailsApplicationService, BankDetailsApplicationService>();
        app.Services.AddScoped<IClientContactApplicationService, ClientContactApplicationService>();
        app.Services.AddScoped<
            IContactInformationApplicationService,
            ContactInformationApplicationService
        >();
        app.Services.AddScoped<
            IInitializationApplicationService,
            InitializationApplicationService
        >();
        app.Services.AddScoped<IPersonApplicationService, PersonApplicationService>();
    }

    private static void AddControllerServices(this IHostApplicationBuilder app)
    {
        app.Services.AddScoped<ICompanyControllerService, CompanyApplicationService>();
        app.Services.AddScoped<ICityControllerService, CityApplicationService>();
        app.Services.AddScoped<ICountryControllerService, CountryApplicationService>();
        app.Services.AddScoped<IUserControllerService, UserApplicationService>();
    }

    private static void AddInfrastructureServices(this IHostApplicationBuilder app)
    {
        app.Services.AddSingleton<
            IUrlResolverInfrastructureService,
            UrlResolverInfrastructureService
        >();

        app.Services.AddScoped<HttpClient>();
        app.Services.AddScoped<IDataInfrastructureService, DataInfrastructureService>();
    }

    private static void AddRepositoryServices(this IHostApplicationBuilder app)
    {
        app.Services.AddScoped<IAddressRepository, AddressRepository>();
        app.Services.AddScoped<IBankDetailsRepository, BankDetailsRepository>();
        app.Services.AddScoped<ICityRepository, CityRepository>();
        app.Services.AddScoped<IClientContactRepository, ClientContactRepository>();
        app.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        app.Services.AddScoped<IContactInformationRepository, ContactInformationRepository>();
        app.Services.AddScoped<ICountryRepository, CountryRepository>();
        app.Services.AddScoped<IPersonRepository, PersonRepository>();
        app.Services.AddScoped<IUserRepository, UserRepository>();
        app.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    }

    private static void AddDevelopmentServices(this IHostApplicationBuilder app)
    {
        app.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition(
                "JwtBearer",
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lowercase for Swagger UI
                }
            );
            c.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "JwtBearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                }
            );
            c.SchemaFilter<SwaggerEnumSchemaFilter>();
        });
    }
}
