using Application.Interface;
using Entities;
using Models;
using Models.Interface;

namespace Application.Service;

public sealed class AddressableApplicationService : IAddressableApplicationService
{
    private readonly ICityRepository _cityRepository;
    private readonly ICountryRepository _countryRepository;

    public AddressableApplicationService(
        ICityRepository cityRepository,
        ICountryRepository countryRepository
    )
    {
        _cityRepository = cityRepository;
        _countryRepository = countryRepository;
    }

    #region ApplicationExposedMethods
    public async Task<IResult> AssignAddress(IAddressableDtoCreate dtoCreate, IAddressable entity)
    {
        if (dtoCreate.Address == null)
            return ResultSuccess.Populated();

        var addressResult = await CreateAddressAsync(dtoCreate.Address);
        if (addressResult.IsSuccessful == false)
            return addressResult;

        entity.Address = addressResult.Value;

        return ResultSuccess.Populated();
    }

    public async Task<IResult> AssignCountry(IAddressableDtoCreate dtoCreate, IAddressable entity)
    {
        if (dtoCreate.CountryId.HasValue == false)
            return ResultSuccess.Populated();

        var country = await _countryRepository.GetByIdAsync<Country>(dtoCreate.CountryId.Value);
        if (country == null)
            return ResultError.NotFound();

        entity.Country = country;

        return ResultSuccess.Populated();
    }
    #endregion

    private async Task<IResult<Address>> CreateAddressAsync(AddressDtoCreate addressDto)
    {
        var city = await _cityRepository.GetByIdAsync<City>(addressDto.CityId);
        if (city == null)
            return ResultError<Address>.NotFound();

        var address = new Address(
            city,
            addressDto.Number,
            addressDto.NumberComplement,
            addressDto.Road
        );

        return ResultSuccess<Address>.Retrieved(address);
    }
}
