using Entities;

namespace Application.Interface;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<Company?> GetByIdIncludeAllAsync(int id);
}
