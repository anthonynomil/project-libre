using Entities;
using Models;
using Models.Interface;

namespace Application.Interface;

public interface IClientContactApplicationService
{
    Task<IResult<ClientContact>> GetClientContactByIdAsync(int id);
    Task<IResult> AssignClientContactBatch(
        IEnumerable<ClientContactDtoCreate>? dtoCreateEnumerable,
        IClient entity
    );
}
