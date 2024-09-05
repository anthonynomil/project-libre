using Entities;
using Models.Interface;

namespace Application.Interface;

public interface IContactInformationApplicationService
{
    Task<IResult<ContactInformation>> GetContactInformationByIdAsync(int id);
    IResult AssignContactInformation(IContactableDtoCreate dtoCreate, IContactable entity);
}
