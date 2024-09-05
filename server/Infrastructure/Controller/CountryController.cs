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
public sealed class CountryController(ICountryControllerService service) : BaseController
{
    [HttpGet("{id:int}")]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop<CountryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetCountryDtoByIdAsync(id);
        return SendEnvelopWithValue(result);
    }

    [HttpGet]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop<IEnumerable<CountryDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> PagedList([FromQuery] int? limit, [FromQuery] int? page)
    {
        var pagedListParameters = new CountryDtoPagedListParameters(limit, page);
        var result = await service.GetCountryDtoPagedListAsync(pagedListParameters);
        return SendEnvelopWithValue(result);
    }
}
