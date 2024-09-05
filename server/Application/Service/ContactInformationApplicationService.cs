using Application.Interface;
using Entities;
using Models;
using Models.Interface;

namespace Application.Service;

public sealed class ContactInformationApplicationService : IContactInformationApplicationService
{
    private readonly IContactInformationRepository _contactInformationRepository;

    public ContactInformationApplicationService(
        IContactInformationRepository contactInformationRepository
    )
    {
        _contactInformationRepository = contactInformationRepository;
    }

    #region ApplicationExposedMethods
    public async Task<IResult<ContactInformation>> GetContactInformationByIdAsync(int id)
    {
        var contactInformation =
            await _contactInformationRepository.GetByIdAsync<ContactInformation>(id);

        return contactInformation != null
            ? ResultSuccess<ContactInformation>.Retrieved(contactInformation)
            : ResultError<ContactInformation>.NotFound();
    }

    public IResult AssignContactInformation(IContactableDtoCreate dtoCreate, IContactable entity)
    {
        if (dtoCreate.ContactInformation == null)
            return ResultSuccess.Populated();

        var contactInformation = new ContactInformation(
            dtoCreate.ContactInformation.PhoneNumber,
            dtoCreate.ContactInformation.MailAddress
        );
        entity.ContactInformation = contactInformation;

        return ResultSuccess.Populated();
    }
    #endregion
}
