using Application.Contracts.Requests.Products;
using Application.Contracts.Responses.Products;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<CreateProductRequest, Product>();
        CreateMap<UpdateProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}