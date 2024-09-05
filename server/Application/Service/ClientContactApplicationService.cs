using Application.Interface;
using Entities;
using Models;
using Models.Interface;

namespace Application.Service;

public sealed class ClientContactApplicationService : IClientContactApplicationService
{
    private readonly IPersonApplicationService _personApplicationService;
    private readonly IClientContactRepository _clientContactRepository;

    public ClientContactApplicationService(
        IPersonApplicationService personApplicationService,
        IClientContactRepository clientContactRepository
    )
    {
        _personApplicationService = personApplicationService;
        _clientContactRepository = clientContactRepository;
    }

    #region ApplicationExposedMethods
    public async Task<IResult<ClientContact>> GetClientContactByIdAsync(int id)
    {
        var clientContact = await _clientContactRepository.GetByIdAsync<ClientContact>(id);

        return clientContact != null
            ? ResultSuccess<ClientContact>.Retrieved(clientContact)
            : ResultError<ClientContact>.NotFound();
    }

    public async Task<IResult> AssignClientContactBatch(
        IEnumerable<ClientContactDtoCreate>? dtoCreateEnumerable,
        IClient entity
    )
    {
        if (dtoCreateEnumerable == null)
            return ResultSuccess.Populated();

        entity.Contacts = new List<ClientContact>();
        foreach (var dtoCreate in dtoCreateEnumerable)
        {
            var clientContact = new ClientContact(dtoCreate.Firstname, dtoCreate.Lastname);
            var populateResult = await _personApplicationService.PopulatePersonOptionalValues(
                dtoCreate,
                clientContact
            );

            if (populateResult.IsSuccessful == false)
                return populateResult;

            entity.Contacts.Add(clientContact);
        }

        return ResultSuccess.Populated();
    }
    #endregion
}
