using Application.Contracts.Requests.Categories;
using Application.Contracts.Responses.Categories;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Mapper;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category, CategoryResponse>();
    }
}