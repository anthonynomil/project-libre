using Entities.Abstract;
using Models.Abstract;
using Models.Interface;

namespace Application.Interface;

public interface IPersonApplicationService
{
    Task<IResult> PopulatePersonOptionalValues(PersonDtoCreate dtoCreate, Person entity);
}
