using AutoMapper;
using Serilog;
using SimApi.Base;
using SimApi.Data;
using SimApi.Data.Uow;
using SimApi.Schema;

namespace SimApi.Operation;

public class DapperCategoryService : BaseService<Category, CategoryRequest, CategoryResponse>, IDapperCategoryService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public DapperCategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public virtual ApiResponse Delete(int Id)
    {
        try
        {
            unitOfWork.DapperRepository<Category>().DeleteById(Id);
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Delete Exception");
            return new ApiResponse(ex.Message);
        }
    }
    
    public virtual ApiResponse<List<CategoryResponse>> GetAll()
    {
        try
        {
            var entityList = unitOfWork.DapperRepository<Category>().GetAll();
            var mapped = mapper.Map<List<Category>, List<CategoryResponse>>(entityList);
            return new ApiResponse<List<CategoryResponse>>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GetAll Exception");
            return new ApiResponse<List<CategoryResponse>>(ex.Message);
        }
    }

    public virtual  ApiResponse<CategoryResponse> GetById(int id)
    {
        try
        {
            var entity = unitOfWork.DapperRepository<Category>().GetById(id);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + id);
                return new ApiResponse<CategoryResponse>("Record not found");
            }

            var mapped = mapper.Map<Category, CategoryResponse>(entity);
            return new ApiResponse<CategoryResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GetById Exception");
            return new ApiResponse<CategoryResponse>(ex.Message);
        }
    }

    public virtual ApiResponse Insert(CategoryRequest request)
    {
        try
        {
            var entity = mapper.Map<CategoryRequest, Category>(request);
            unitOfWork.DapperRepository<Category>().Insert(entity);
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Insert Exception");
            return new ApiResponse(ex.Message);
        }
    }

    public virtual ApiResponse Update(int id, CategoryRequest request)
    {
        try
        {
            var entity = mapper.Map<CategoryRequest, Category>(request);
            var exist = unitOfWork.DapperRepository<Category>().GetById(id);
            if (exist is null)
            {
                Log.Warning("Record not found for Id " + id);
                return new ApiResponse("Record not found");
            }

            unitOfWork.DapperRepository<Category>().Update(entity);
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Update Exception");
            return new ApiResponse(ex.Message);
        }
    }
}