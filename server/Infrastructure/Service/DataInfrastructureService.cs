using System.Net.Http.Json;
using Application.Interface;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Service;

public sealed class DataInfrastructureService(
    HttpClient httpClient,
    ILogger<DataInfrastructureService> logger
) : IDataInfrastructureService
{
    public async Task<T?> FetchData<T>(string url)
    {
        try
        {
            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadFromJsonAsync<T>();
        }
        catch (Exception error)
        {
            logger.Log(LogLevel.Error, "{message}", error.Message);
            return default;
        }
    }
}
