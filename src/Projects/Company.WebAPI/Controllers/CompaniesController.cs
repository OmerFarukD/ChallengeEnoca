using Company.Application.Features.Company.Commands;
using Company.Application.Features.Company.Dtos;
using Company.Application.Features.Company.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateCompanyDto createCompanyDto)
    {
        var data = await Mediator.Send(new CreateCompanyCommand.Command(createCompanyDto));
        return Created("",data);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var data = await Mediator.Send(new DeleteCompanyCommand.Command(id));
        return Ok(data);
    }

    [HttpPost("isactiveupdate")]
    public async Task<IActionResult> IsActiveUpdate( [FromBody] UpdateIsActiveDto updateIsActiveDto)
    {
        var data = await Mediator.Send(new IsActiveUpdateCommand.Command(updateIsActiveDto));
        return Ok(data);
    }

    [HttpPost("orderdateupdate")]
    public async Task<IActionResult> OrderDateUpdate( [FromRoute] OrderDateUpdateDto orderDateUpdateDto)
    {
        var data = await Mediator.Send(new OrderDateUpdateCommand.Command(orderDateUpdateDto));
        return Ok(data);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var data = await Mediator.Send(new GetCompanyListQuery.Query());
        return Ok(data);
    }
}