using Application.Contracts.Responses.Products;

namespace Application.Contracts.Responses.Categories;

public class CategoryResponse : BaseResponse
{
    public string Name { get; set; }
    public int Order { get; set; }
    public virtual List<ProductResponse> Products { get; set; }
}