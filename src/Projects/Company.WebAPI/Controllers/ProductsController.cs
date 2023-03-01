using Company.Application.Features.Product.Commands;
using Company.Application.Features.Product.Dtos;
using Company.Application.Features.Product.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Company.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController
{

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody]AddProductDto addProductDto)
    {
        var data = await Mediator.Send( new AddProductCommand.Command(addProductDto));
        return Created("", data);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var data = await Mediator.Send(new GetProductListQuery.Query());
        return Ok(data);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
    {
        var data = await Mediator.Send(new UpdateProductCommand.Command(updateProductDto));
        return Ok(data);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await Mediator.Send(new DeleteProductCommand.Command(id));
        return Ok(data);
    }
}