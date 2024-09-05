using Models;
using Models.Interface;

namespace Application.Interface;

public interface ICityControllerService
{
    Task<IResult<CityDto>> GetCityDtoByIdAsync(int id);
    Task<IResult<IEnumerable<CityDto>>> GetCityDtoPagedListAsync(
        CityDtoPagedListParameters dtoPagedListParameters
    );
}
