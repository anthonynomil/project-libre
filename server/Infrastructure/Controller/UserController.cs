using Application.Interface;
using Infrastructure.Abstract;
using Infrastructure.Constant;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Infrastructure.Controller;

[ApiController]
[Route("[controller]")]
public sealed class UserController(IUserControllerService service) : BaseController
{
    [HttpGet("{id:int}")]
    [Authorize(Policy = AuthorizationPolicyConstant.Admin)]
    [ProducesResponseType(typeof(IEnvelop<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetUserDtoByIdAsync(id);
        return SendEnvelopWithValue(result);
    }

    [HttpGet]
    [Authorize(Policy = AuthorizationPolicyConstant.Admin)]
    [ProducesResponseType(typeof(IEnvelop<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> PagedList([FromQuery] int? limit, [FromQuery] int? page)
    {
        var pagedListParameters = new UserDtoPagedListParameters(limit, page);
        var result = await service.GetUserDtoPagedListAsync(pagedListParameters);
        return SendEnvelopWithValue(result);
    }

    [HttpPost("[action]")]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create(UserDtoCreate userDto)
    {
        var result = await service.CreateUserAsync(userDto);
        return SendEnvelop(result);
    }

    [HttpPatch("{id:int}")]
    [Authorize(Policy = AuthorizationPolicyConstant.Admin)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Patch(int id, UserDtoUpdate userDto)
    {
        var result = await service.UpdateUserAsync(id, userDto);
        return SendEnvelop(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = AuthorizationPolicyConstant.Admin)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteUserAsync(id);
        return SendEnvelop(result);
    }
}
