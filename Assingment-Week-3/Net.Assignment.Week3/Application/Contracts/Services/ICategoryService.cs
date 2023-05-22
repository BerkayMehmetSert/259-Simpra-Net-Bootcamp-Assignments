using Application.Contracts.Requests.Categories;
using Application.Contracts.Responses.Categories;
using Domain.Entities;

namespace Application.Contracts.Services;

public interface ICategoryService
{
    void CreateCategory(CreateCategoryRequest request);
    void UpdateCategory(int id, UpdateCategoryRequest request);
    void DeleteCategory(int id);
    CategoryResponse GetCategoryById(int id);
    CategoryResponse GetCategoryByName(string name);
    List<CategoryResponse> GetAllCategories();
    Category GetCategoryEntity(int id);
}