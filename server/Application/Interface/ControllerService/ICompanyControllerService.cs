using Models;
using Models.Interface;

namespace Application.Interface;

public interface ICompanyControllerService
{
    Task<IResult<CompanyDto>> GetCompanyDtoByIdAsync(int id);
    Task<IResult<IEnumerable<CompanyDto>>> GetCompanyDtoPagedListAsync(
        CompanyDtoPagedListParameters dtoPagedListParameters
    );
    Task<IResult> CreateCompanyAsync(CompanyDtoCreate companyDto);
    Task<IResult> UpdateCompanyAsync(int id, CompanyDtoUpdate companyDto);
    Task<IResult> DeleteCompanyAsync(int id);
}
