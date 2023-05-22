using Application.Contracts.Requests.Products;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductRequest request)
    {
        _service.CreateProduct(request);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequest request)
    {
        _service.UpdateProduct(id, request);
        return Ok();
    }

    [HttpPut("{id}/category/{categoryId}")]
    public IActionResult UpdateProductCategory([FromRoute] int id, [FromRoute] int categoryId)
    {
        _service.UpdateProductCategory(id, categoryId);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct([FromRoute] int id)
    {
        _service.DeleteProduct(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById([FromRoute] int id)
    {
        var response = _service.GetProductById(id);
        return Ok(response);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetProductByName([FromRoute] string name)
    {
        var response = _service.GetProductByName(name);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var response = _service.GetAllProducts();
        return Ok(response);
    }
}