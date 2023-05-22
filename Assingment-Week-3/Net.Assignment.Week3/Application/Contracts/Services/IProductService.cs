using Application.Contracts.Requests.Products;
using Application.Contracts.Responses.Products;

namespace Application.Contracts.Services;

public interface IProductService
{
    void CreateProduct(CreateProductRequest request);
    void UpdateProduct(int id, UpdateProductRequest request);
    void UpdateProductCategory(int id, int categoryId);
    void DeleteProduct(int id);
    ProductResponse GetProductById(int id);
    ProductResponse GetProductByName(string name);
    List<ProductResponse> GetAllProducts();
}