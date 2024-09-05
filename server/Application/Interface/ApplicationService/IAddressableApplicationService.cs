using Entities;
using Models.Interface;

namespace Application.Interface;

public interface IAddressableApplicationService
{
    Task<IResult> AssignAddress(IAddressableDtoCreate dtoCreate, IAddressable entity);
    Task<IResult> AssignCountry(IAddressableDtoCreate dtoCreate, IAddressable entity);
}
