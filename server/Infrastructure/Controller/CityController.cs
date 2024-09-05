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
public sealed class CityController(ICityControllerService service) : BaseController
{
    [HttpGet("{id:int}")]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop<CityDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetCityDtoByIdAsync(id);
        return SendEnvelopWithValue(result);
    }

    [HttpGet]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop<IEnumerable<CityDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> PagedList([FromQuery] int? limit, [FromQuery] int? page)
    {
        var pagedListParameters = new CityDtoPagedListParameters(limit, page);
        var result = await service.GetCityDtoPagedListAsync(pagedListParameters);
        return SendEnvelopWithValue(result);
    }
}
