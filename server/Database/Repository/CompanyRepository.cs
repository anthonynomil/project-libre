using Application.Interface;
using Database.Abstract;
using Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository;

public sealed class CompanyRepository(ProjetLibreContext context)
    : BaseRepository<Company>(context),
        ICompanyRepository
{
    public Task<Company?> GetByIdIncludeAllAsync(int id)
    {
        return context
            .Set<Company>()
            .Include(e => e.Country)
            .Include(e => e.Address)
            .ThenInclude(e => e!.City)
            .Include(e => e.BankDetails)
            .Include(e => e.FinancialInformation)
            .Include(e => e.ClientMissions)
            .Include(e => e.Contacts)
            .ThenInclude(c => c.Address)
            .ThenInclude(c => c!.City)
            .Include(e => e.Contacts)
            .ThenInclude(c => c.Country)
            .Include(e => e.Contacts)
            .ThenInclude(c => c.ContactInformation)
            .SingleOrDefaultAsync(e => e.Id == id);
    }
}
