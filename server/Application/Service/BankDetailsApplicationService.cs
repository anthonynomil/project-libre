using Application.Interface;
using Entities;
using Models;
using Models.Interface;

namespace Application.Service;

public sealed class BankDetailsApplicationService : IBankDetailsApplicationService
{
    private readonly IBankDetailsRepository _bankDetailsRepository;

    public BankDetailsApplicationService(IBankDetailsRepository bankDetailsRepository)
    {
        _bankDetailsRepository = bankDetailsRepository;
    }

    #region ApplicationExposedMethods
    public async Task<IResult<BankDetails>> GetBankDetailsByIdAsync(int id)
    {
        var bankDetails = await _bankDetailsRepository.GetByIdAsync<BankDetails>(id);

        return bankDetails != null
            ? ResultSuccess<BankDetails>.Retrieved(bankDetails)
            : ResultError<BankDetails>.NotFound();
    }

    public IResult AssignBankDetails(IChargeableDtoCreate dtoCreate, IChargeable entity)
    {
        if (dtoCreate.BankDetails == null)
            return ResultSuccess.Populated();

        var bankDetails = new BankDetails(dtoCreate.BankDetails.Bic, dtoCreate.BankDetails.Iban);
        entity.BankDetails = bankDetails;

        return ResultSuccess.Populated();
    }
    #endregion
}
