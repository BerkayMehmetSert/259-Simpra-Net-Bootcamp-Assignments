namespace Application.Contracts.Requests.Categories;

public class CreateCategoryRequest : BaseRequest
{
    public string Name { get; set; }
    public int Order { get; set; }
}