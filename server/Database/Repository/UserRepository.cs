using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository;

public sealed class UserRepository(ProjetLibreContext context)
    : BaseRepository<User>(context),
        IUserRepository
{
    public Task<bool> AnyByEmailAsync(string email)
    {
        return context.Set<User>().AsNoTracking().AnyAsync(e => e.Email == email);
    }

    public Task<User?> GetByIdIncludeAllAsync(int id)
    {
        return context
            .Set<User>()
            .Include(e => e.Address)
            .ThenInclude(e => e!.City)
            .Include(e => e.Country)
            .Include(e => e.UserRoles)
            .SingleOrDefaultAsync(e => e.Id == id);
    }

    public Task<User?> GetByEmailAndPasswordAsync(string email, string password)
    {
        return context
            .Set<User>()
            .Include(e => e.UserRoles)
            .SingleOrDefaultAsync(e => e.Email == email && e.Password == password);
    }
}
