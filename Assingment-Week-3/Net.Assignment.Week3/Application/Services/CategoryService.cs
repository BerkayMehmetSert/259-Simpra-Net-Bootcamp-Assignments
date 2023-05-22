using Application.Contracts.Repositories;
using Application.Contracts.Requests.Categories;
using Application.Contracts.Responses.Categories;
using Application.Contracts.Services;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Exceptions.Type;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.Messages.CategoryMessages;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void CreateCategory(CreateCategoryRequest request)
    {
        CheckIfCategoryExistsByName(request.Name);

        var category = _mapper.Map<Category>(request);

        _unitOfWork.CategoryRepository.Create(category);
        _unitOfWork.SaveChanges();
    }

    public void UpdateCategory(int id, UpdateCategoryRequest request)
    {
        var category = GetCategoryEntity(id);

        if (category.Name != request.Name) CheckIfCategoryExistsByName(request.Name);
        
        var updatedCategory = _mapper.Map(request, category);

        _unitOfWork.CategoryRepository.Update(updatedCategory);
        _unitOfWork.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = GetCategoryEntity(id);

        _unitOfWork.CategoryRepository.Delete(category);
        _unitOfWork.SaveChanges();
    }

    public CategoryResponse GetCategoryById(int id)
    {
        var category = GetCategoryEntity(id);

        return _mapper.Map<CategoryResponse>(category);
    }

    public CategoryResponse GetCategoryByName(string name)
    {
        var category = _unitOfWork.CategoryRepository.Get(x => x.Name.Equals(name));

        return category is not null
            ? _mapper.Map<CategoryResponse>(category)
            : throw new NotFoundException(CategoryNotFoundByName);
    }

    public List<CategoryResponse> GetAllCategories()
    {
        var categories = _unitOfWork.CategoryRepository.GetAll(
            include: source => source
                .Include(x => x.Products)
        );

        return categories is not null
            ? _mapper.Map<List<CategoryResponse>>(categories)
            : throw new NotFoundException(CategoryListIsEmpty);
    }

    private void CheckIfCategoryExistsByName(string name)
    {
        var category = _unitOfWork.CategoryRepository.Get(x => x.Name.Equals(name));

        if (category is not null) throw new BusinessException(CategoryAlreadyExistsByName);
    }

    public Category GetCategoryEntity(int id)
    {
        var category = _unitOfWork.CategoryRepository.Get(
            predicate: x => x.Id == id,
            include: source => source
                .Include(x => x.Products)
        );

        return category ?? throw new NotFoundException(CategoryNotFoundById);
    }
}