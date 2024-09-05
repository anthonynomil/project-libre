using Application.Interface;
using Entities.Abstract;
using Models;
using Models.Abstract;
using Models.Enum;
using Models.Interface;

namespace Application.Service;

public sealed class PersonApplicationService : IPersonApplicationService
{
    private readonly IAddressableApplicationService _addressableApplicationService;
    private readonly IContactInformationApplicationService _contactInformationApplicationService;

    public PersonApplicationService(
        IAddressableApplicationService addressableApplicationService,
        IContactInformationApplicationService contactInformationApplicationService
    )
    {
        _addressableApplicationService = addressableApplicationService;
        _contactInformationApplicationService = contactInformationApplicationService;
    }

    #region ApplicationExposedMethods
    public async Task<IResult> PopulatePersonOptionalValues(
        PersonDtoCreate dtoCreate,
        Person entity
    )
    {
        var resultAggregator = new ResultAggregator();

        entity.Birthdate = dtoCreate.Birthdate;

        resultAggregator.AddResultRange(
            await _addressableApplicationService.AssignCountry(dtoCreate, entity),
            await _addressableApplicationService.AssignAddress(dtoCreate, entity),
            _contactInformationApplicationService.AssignContactInformation(dtoCreate, entity)
        );

        return resultAggregator.ToSingleResult(
            ApplicationResultCodeEnum.Populated,
            ApplicationResultCodeEnum.PopulationError
        );
    }
    #endregion
}
