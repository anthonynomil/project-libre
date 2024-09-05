using Application.Interface;
using Entities;
using Models;
using Models.Enum;
using Models.Interface;

namespace Application.Service;

public sealed class CompanyApplicationService : ICompanyControllerService
{
    private readonly IAddressableApplicationService _addressableApplicationService;
    private readonly IBankDetailsApplicationService _bankDetailsApplicationService;
    private readonly IClientContactApplicationService _clientContactApplicationService;
    private readonly ICompanyRepository _companyRepository;

    public CompanyApplicationService(
        IAddressableApplicationService addressableApplicationService,
        IBankDetailsApplicationService bankDetailsApplicationService,
        IClientContactApplicationService clientContactApplicationService,
        ICompanyRepository companyRepository
    )
    {
        _addressableApplicationService = addressableApplicationService;
        _bankDetailsApplicationService = bankDetailsApplicationService;
        _clientContactApplicationService = clientContactApplicationService;
        _companyRepository = companyRepository;
    }

    #region ControllerExposedMethods
    public async Task<IResult<CompanyDto>> GetCompanyDtoByIdAsync(int id)
    {
        var companyEntity = await _companyRepository.GetByIdIncludeAllAsync(id);

        return companyEntity != null
            ? ResultSuccess<CompanyDto>.Retrieved(CompanyDto.From(companyEntity))
            : ResultError<CompanyDto>.NotFound();
    }

    public async Task<IResult<IEnumerable<CompanyDto>>> GetCompanyDtoPagedListAsync(
        CompanyDtoPagedListParameters dtoPagedListParameters
    )
    {
        var entitiesPagedList = await _companyRepository.GetPagedListAsync(dtoPagedListParameters);
        return ResultSuccess<IEnumerable<CompanyDto>>.Retrieved(CompanyDto.From(entitiesPagedList));
    }

    public async Task<IResult> CreateCompanyAsync(CompanyDtoCreate companyDto)
    {
        var companyEntity = new Company(companyDto.BusinessName);
        var populateResult = await PopulateOptionalValues(companyEntity, companyDto);
        if (populateResult.IsSuccessful == false)
            return populateResult;

        await _companyRepository.CreateAndSaveAsync(companyEntity);

        return ResultSuccess.Created();
    }

    private async Task<IResult> PopulateOptionalValues(
        Company companyEntity,
        CompanyDtoCreate companyDto
    )
    {
        var resultAggregator = new ResultAggregator();

        resultAggregator.AddResultRange(
            await _addressableApplicationService.AssignCountry(companyDto, companyEntity),
            await _addressableApplicationService.AssignAddress(companyDto, companyEntity),
            _bankDetailsApplicationService.AssignBankDetails(companyDto, companyEntity),
            await _clientContactApplicationService.AssignClientContactBatch(
                companyDto.Contacts,
                companyEntity
            )
        );

        if (companyDto.FinancialInformation != null)
        {
            companyEntity.FinancialInformation = new ClientFinancialInformation(
                companyDto.FinancialInformation.Budget,
                companyDto.FinancialInformation.PaymentMethod
            );
        }

        return resultAggregator.ToSingleResult(
            ApplicationResultCodeEnum.Populated,
            ApplicationResultCodeEnum.PopulationError
        );
    }

    public Task<IResult> UpdateCompanyAsync(int id, CompanyDtoUpdate companyDto)
    {
        throw new NotImplementedException();
        // var companyEntity = await _companyRepository.GetByIdAsync<Company>(id);
        // if (companyEntity == default)
        //     return Result<CompanyDto>.Error(HttpStatusCode.NotFound, "Company not found.");
        //
        // await _companyRepository.UpdateAndSaveAsync(companyEntity);
        //
        // return Result.Success(HttpStatusCode.NoContent, "Company updated.");
    }

    public async Task<IResult> DeleteCompanyAsync(int id)
    {
        var companyEntity = await _companyRepository.GetByIdAsync<Company>(id);
        if (companyEntity == null)
            return ResultError.NotFound();

        await _companyRepository.DeleteAndSaveAsync(companyEntity);

        return ResultSuccess.Deleted();
    }
    #endregion
}
