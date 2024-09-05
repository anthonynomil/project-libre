using Entities;
using Models.Interface;

namespace Application.Interface;

public interface IBankDetailsApplicationService
{
    Task<IResult<BankDetails>> GetBankDetailsByIdAsync(int id);
    IResult AssignBankDetails(IChargeableDtoCreate dtoCreate, IChargeable entity);
}
