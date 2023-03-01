using Company.Application.Features.Order.Commands;
using Company.Application.Features.Order.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add( [FromBody] AddOrderDto addOrderDto)
    {
        var data = await Mediator.Send(new AddOrderCommand.Command(addOrderDto));
        return Created("", data);
    }
}