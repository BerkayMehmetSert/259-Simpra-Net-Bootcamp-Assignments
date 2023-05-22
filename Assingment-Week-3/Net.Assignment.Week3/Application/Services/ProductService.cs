using Application.Contracts.Repositories;
using Application.Contracts.Requests.Products;
using Application.Contracts.Responses.Products;
using Application.Contracts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Type;
using static Application.Contracts.Messages.ProductMessages;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ICategoryService categoryService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public void CreateProduct(CreateProductRequest request)
    {
        CheckIfProductExistsByName(request.Name);

        var product = _mapper.Map<Product>(request);

        _unitOfWork.ProductRepository.Create(product);
        _unitOfWork.SaveChanges();
    }

    public void UpdateProduct(int id, UpdateProductRequest request)
    {
        var product = GetProductEntity(id);

        if (product.Name != request.Name) CheckIfProductExistsByName(request.Name);

        var updatedProduct = _mapper.Map(request, product);

        _unitOfWork.ProductRepository.Update(updatedProduct);
        _unitOfWork.SaveChanges();
    }

    public void UpdateProductCategory(int id, int categoryId)
    {
        var product = GetProductEntity(id);
        var category = _categoryService.GetCategoryEntity(categoryId);

        product.Category = category;

        _unitOfWork.ProductRepository.Update(product);
        _unitOfWork.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = GetProductEntity(id);

        _unitOfWork.ProductRepository.Delete(product);
        _unitOfWork.SaveChanges();
    }

    public ProductResponse GetProductById(int id)
    {
        var product = GetProductEntity(id);

        return _mapper.Map<ProductResponse>(product);
    }

    public ProductResponse GetProductByName(string name)
    {
        var product = _unitOfWork.ProductRepository.Get(x => x.Name.Equals(name));

        return product is not null
            ? _mapper.Map<ProductResponse>(product)
            : throw new NotFoundException(ProductNotFoundByName);
    }

    public List<ProductResponse> GetAllProducts()
    {
        var products = _unitOfWork.ProductRepository.GetAll();
        
        return products is not null
            ? _mapper.Map<List<ProductResponse>>(products)
            : throw new NotFoundException(ProductListIsEmpty);
    }

    private void CheckIfProductExistsByName(string name)
    {
        var product = _unitOfWork.ProductRepository.Get(x => x.Name.Equals(name));

        if (product is not null) throw new BusinessException(ProductAlreadyExistsByName);
    }

    private Product GetProductEntity(int id)
    {
        var product = _unitOfWork.ProductRepository.Get(x => x.Id.Equals(id));

        return product ?? throw new NotFoundException(ProductNotFoundById);
    }
}