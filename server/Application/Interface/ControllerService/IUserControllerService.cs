using Models;
using Models.Interface;

namespace Application.Interface;

public interface IUserControllerService
{
    Task<IResult<UserDto>> GetUserDtoByIdAsync(int id);
    Task<IResult<IEnumerable<UserDto>>> GetUserDtoPagedListAsync(UserDtoPagedListParameters id);
    Task<IResult> CreateUserAsync(UserDtoCreate userDto);
    Task<IResult> UpdateUserAsync(int id, UserDtoUpdate userDto);
    Task<IResult> DeleteUserAsync(int id);
}
