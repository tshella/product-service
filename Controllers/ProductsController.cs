using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? name, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var result = await service.GetFilteredProductsAsync(name, page, pageSize);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await service.GetProductByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProductDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await service.AddProductAsync(dto);
        return Created("", result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] ProductDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await service.UpdateProductAsync(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await service.DeleteProductAsync(id);
        return NoContent();
    }
}
