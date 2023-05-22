namespace Application.Contracts.Requests.Products;

public class CreateProductRequest : BaseRequest
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Tag { get; set; }
}