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
public sealed class CompanyController(ICompanyControllerService service) : BaseController
{
    [HttpGet("{id:int}")]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop<CompanyDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await service.GetCompanyDtoByIdAsync(id);
        return SendEnvelopWithValue(result);
    }

    [HttpGet]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop<IEnumerable<CompanyDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> PagedList([FromQuery] int? limit, [FromQuery] int? page)
    {
        var pagedListParameters = new CompanyDtoPagedListParameters(limit, page);
        var result = await service.GetCompanyDtoPagedListAsync(pagedListParameters);
        return SendEnvelopWithValue(result);
    }

    [HttpPost("[action]")]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create(CompanyDtoCreate userDto)
    {
        var result = await service.CreateCompanyAsync(userDto);
        return SendEnvelop(result);
    }

    [HttpPatch("{id:int}")]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Patch(int id, CompanyDtoUpdate userDto)
    {
        var result = await service.UpdateCompanyAsync(id, userDto);
        return SendEnvelop(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Policy = AuthorizationPolicyConstant.Authenticated)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(IEnvelop), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await service.DeleteCompanyAsync(id);
        return SendEnvelop(result);
    }
}
