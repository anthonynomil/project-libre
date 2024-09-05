using Models;
using Models.Interface;

namespace Application.Interface;

public interface IAuthenticationControllerService
{
    Task<IResult<UserDto>> GetUserDtoByCredentialsAsync(
        AuthenticationDtoLogin authenticationDtoLogin
    );
}
