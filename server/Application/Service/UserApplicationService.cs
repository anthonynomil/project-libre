using Application.Interface;
using Entities;
using Models;
using Models.Interface;

namespace Application.Service;

public sealed class UserApplicationService
    : IAuthenticationControllerService,
        IUserControllerService
{
    private readonly IPersonApplicationService _personApplicationService;
    private readonly IUserRepository _userRepository;

    public UserApplicationService(
        IPersonApplicationService personApplicationService,
        IUserRepository userRepository
    )
    {
        _personApplicationService = personApplicationService;
        _userRepository = userRepository;
    }

    #region ControllerExposedMethods
    public async Task<IResult<UserDto>> GetUserDtoByIdAsync(int id)
    {
        var userEntity = await _userRepository.GetByIdIncludeAllAsync(id);

        return userEntity != null
            ? ResultSuccess<UserDto>.Retrieved(UserDto.From(userEntity))
            : ResultError<UserDto>.NotFound();
    }

    public async Task<IResult<UserDto>> GetUserDtoByCredentialsAsync(
        AuthenticationDtoLogin authenticationDtoLogin
    )
    {
        var userEntity = await _userRepository.GetByEmailAndPasswordAsync(
            authenticationDtoLogin.Email,
            authenticationDtoLogin.Password
        );

        return userEntity != null
            ? ResultSuccess<UserDto>.Retrieved(UserDto.From(userEntity))
            : ResultError<UserDto>.InvalidCredentials();
    }

    public async Task<IResult<IEnumerable<UserDto>>> GetUserDtoPagedListAsync(
        UserDtoPagedListParameters dtoPagedListParameters
    )
    {
        var entitiesPagedList = await _userRepository.GetPagedListAsync(dtoPagedListParameters);
        return ResultSuccess<IEnumerable<UserDto>>.Retrieved(UserDto.From(entitiesPagedList));
    }

    public async Task<IResult> CreateUserAsync(UserDtoCreate userDto)
    {
        var isEmailTaken = await _userRepository.AnyByEmailAsync(userDto.Email);
        if (isEmailTaken)
            return ResultError.AlreadyExists();

        var userEntity = new User(
            userDto.Email,
            userDto.Password,
            userDto.Firstname,
            userDto.Lastname
        );

        var populatePersonResult = await _personApplicationService.PopulatePersonOptionalValues(
            userDto,
            userEntity
        );
        if (populatePersonResult.IsSuccessful == false)
            return populatePersonResult;

        await _userRepository.CreateAndSaveAsync(userEntity);

        return ResultSuccess.Created();
    }

    public Task<IResult> UpdateUserAsync(int id, UserDtoUpdate userDto)
    {
        throw new NotImplementedException();
        // var userEntity = await _userRepository.GetByIdAsync<User>(id);
        //
        // if (userEntity == default)
        //     return Result<UserDto>.Error(HttpStatusCode.NotFound, "User not found.");
        //
        // if (userDto.Email != default)
        //     userEntity.Email = userDto.Email;
        // if (userDto.Password != default)
        //     userEntity.Password = userDto.Password;
        //
        // await _userRepository.UpdateAndSaveAsync(userEntity);
        //
        // return Result.Success(HttpStatusCode.NoContent, "User updated.");
    }

    public async Task<IResult> DeleteUserAsync(int id)
    {
        var userEntity = await _userRepository.GetByIdAsync<User>(id);
        if (userEntity == null)
            return ResultError.NotFound();

        await _userRepository.DeleteAndSaveAsync(userEntity);

        return ResultSuccess.Deleted();
    }
    #endregion
}
