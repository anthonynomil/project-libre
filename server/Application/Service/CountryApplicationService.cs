using Application.Interface;
using Entities;
using Models;
using Models.Interface;

namespace Application.Service;

public sealed class CountryApplicationService : ICountryControllerService
{
    private readonly ICountryRepository _countryRepository;

    public CountryApplicationService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    #region ControllerExposedMethods
    public async Task<IResult<CountryDto>> GetCountryDtoByIdAsync(int id)
    {
        var countryEntity = await _countryRepository.GetByIdAsync<Country>(id);

        return countryEntity != null
            ? ResultSuccess<CountryDto>.Retrieved(CountryDto.From(countryEntity))
            : ResultError<CountryDto>.NotFound();
    }

    public async Task<IResult<IEnumerable<CountryDto>>> GetCountryDtoPagedListAsync(
        CountryDtoPagedListParameters dtoPagedListParameters
    )
    {
        var entitiesPagedList = await _countryRepository.GetPagedListAsync(dtoPagedListParameters);
        return ResultSuccess<IEnumerable<CountryDto>>.Retrieved(CountryDto.From(entitiesPagedList));
    }
    #endregion
}
