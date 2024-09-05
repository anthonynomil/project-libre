using Entities;

namespace Application.Interface;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> AnyByEmailAsync(string email);
    Task<User?> GetByIdIncludeAllAsync(int id);
    Task<User?> GetByEmailAndPasswordAsync(string email, string password);
}
