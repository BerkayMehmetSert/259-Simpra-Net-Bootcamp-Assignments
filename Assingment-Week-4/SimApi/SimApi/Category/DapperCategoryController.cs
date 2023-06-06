using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Operation;
using SimApi.Schema;

namespace SimApi.Service;

[EnableMiddlewareLogger]
[ResponseGuid]
[Route("simapi/v1/[controller]")]
[ApiController]
public class DapperCategoryController : ControllerBase
{
    private readonly IDapperCategoryService service;

    public DapperCategoryController(IDapperCategoryService service)
    {
        this.service = service;
    }
    
    [HttpGet]
    public ApiResponse<List<CategoryResponse>> GetAll()
    {
        var accountList = service.GetAll();
        return accountList;
    }

    [HttpGet("{id}")]
    public ApiResponse<CategoryResponse> GetById(int id)
    {
        var account = service.GetById(id);
        return account;
    }

    [HttpPost]
    public ApiResponse Post([FromBody] CategoryRequest request)
    {
        return service.Insert(request);
    } 

    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] CategoryRequest request)
    {
        return service.Update(id, request);
    }

    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        return service.Delete(id);
    }
}