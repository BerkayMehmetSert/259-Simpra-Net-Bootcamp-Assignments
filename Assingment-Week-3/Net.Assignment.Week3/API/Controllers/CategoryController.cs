using Application.Contracts.Requests.Categories;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateCategory([FromBody] CreateCategoryRequest request)
    {
        _service.CreateCategory(request);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequest request)
    {
        _service.UpdateCategory(id, request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory([FromRoute] int id)
    {
        _service.DeleteCategory(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoryById([FromRoute] int id)
    {
        var response = _service.GetCategoryById(id);
        return Ok(response);
    }

    [HttpGet("name/{name}")]
    public IActionResult GetCategoryByName([FromRoute] string name)
    {
        var response = _service.GetCategoryByName(name);
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetAllCategories()
    {
        var response = _service.GetAllCategories();
        return Ok(response);
    }
}