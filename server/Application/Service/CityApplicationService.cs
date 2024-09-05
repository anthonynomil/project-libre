using Application.Interface;
using Entities;
using Models;
using Models.Interface;

namespace Application.Service;

public sealed class CityApplicationService : ICityControllerService
{
    private readonly ICityRepository _cityRepository;

    public CityApplicationService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    #region ControllerExposedMethods
    public async Task<IResult<CityDto>> GetCityDtoByIdAsync(int id)
    {
        var cityEntity = await _cityRepository.GetByIdAsync<City>(id);

        return cityEntity != null
            ? ResultSuccess<CityDto>.Retrieved(CityDto.From(cityEntity))
            : ResultError<CityDto>.NotFound();
    }

    public async Task<IResult<IEnumerable<CityDto>>> GetCityDtoPagedListAsync(
        CityDtoPagedListParameters dtoPagedListParameters
    )
    {
        var entitiesPagedList = await _cityRepository.GetPagedListAsync(dtoPagedListParameters);
        return ResultSuccess<IEnumerable<CityDto>>.Retrieved(CityDto.From(entitiesPagedList));
    }
    #endregion
}
