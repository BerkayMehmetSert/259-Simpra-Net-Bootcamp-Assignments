using Dapper;
using SimApi.Base;
using SimApi.Base.Utilities;
using SimApi.Data.Context;

namespace SimApi.Data.Repository;

public class DapperRepository<Entity> : IDapperRepository<Entity> where Entity : BaseModel
{
    protected readonly SimDapperDbContext dbContext;
    private bool disposed;

    public DapperRepository(SimDapperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void DeleteById(int id)
    {
        var tableName = DapperRepositoryHelper.GetTableName<Entity>();
        var deleteQuery = $"DELETE FROM {tableName} WHERE \"Id\" = @Id;";
        using var connection = dbContext.CreateConnection();

        connection.Execute(deleteQuery, new { Id = id });
    }

    public List<Entity> Filter(string sql)
    {
        var tableName = DapperRepositoryHelper.GetTableName<Entity>();
        var query = $"SELECT * FROM {tableName} WHERE {sql};";
        using var connection = dbContext.CreateConnection();

        return connection.Query<Entity>(query).ToList();
    }

    public List<Entity> GetAll()
    {
        var tableName = DapperRepositoryHelper.GetTableName<Entity>();
        var query = $"SELECT * FROM {tableName};";
        using var connection = dbContext.CreateConnection();

        return connection.Query<Entity>(query).ToList();
    }

    public Entity GetById(int id)
    {
        var tableName = DapperRepositoryHelper.GetTableName<Entity>();
        var query = $"SELECT * FROM {tableName} WHERE \"Id\" = @Id;";
        using var connection = dbContext.CreateConnection();

        return connection.QueryFirstOrDefault<Entity>(query, new { Id = id });
    }

    public void Insert(Entity entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.CreatedBy = "sim@sim.com";
        var query = DapperRepositoryHelper.GenerateInsertQuery<Entity>();
        using var connection = dbContext.CreateConnection();

        connection.Execute(query, entity);
    }

    public void Update(Entity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        entity.UpdatedBy = "sim@sim.com";
        var query = DapperRepositoryHelper.GenerateUpdateQuery<Entity>();
        using var connection = dbContext.CreateConnection();

        connection.Execute(query, entity);
    }
}
