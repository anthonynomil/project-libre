using Application.Interface;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Service;

public sealed class UrlResolverInfrastructureService(IConfiguration config)
    : IUrlResolverInfrastructureService
{
    public string GetUrl(string key)
    {
        return config.GetSection("Endpoints").GetValue<string>(key)
            ?? throw new NullReferenceException();
    }
}
