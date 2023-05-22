namespace Application.Contracts.Requests.Categories;

public class UpdateCategoryRequest : BaseRequest
{
    public string Name { get; set; }
    public int Order { get; set; }
}