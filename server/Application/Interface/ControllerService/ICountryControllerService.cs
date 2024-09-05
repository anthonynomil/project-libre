using Models;
using Models.Interface;

namespace Application.Interface;

public interface ICountryControllerService
{
    Task<IResult<CountryDto>> GetCountryDtoByIdAsync(int id);
    Task<IResult<IEnumerable<CountryDto>>> GetCountryDtoPagedListAsync(
        CountryDtoPagedListParameters dtoPagedListParameters
    );
}
