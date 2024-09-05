namespace Application.Interface;

public interface IDataInfrastructureService
{
    Task<T?> FetchData<T>(string url);
}
