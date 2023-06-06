using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace SimApi.Base.Utilities;

public class DapperRepositoryHelper
{
    public static IEnumerable<PropertyInfo> GetProperties(Type entityType)
    {
        return entityType.GetProperties();
    }

    public static string GetTableName<T>() where T : class
    {
        var tableAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute)) as TableAttribute;

        if (tableAttribute is not null && !string.IsNullOrWhiteSpace(tableAttribute.Schema))
        {
            return $"\"{tableAttribute.Schema}\".\"{tableAttribute.Name}\"";
        }

        return $"\"{typeof(T).Name}\"";
    }

    public static string GenerateInsertQuery<T>() where T : class
    {
        var properties = GetProperties(typeof(T));
        var tableName = GetTableName<T>();

        var columns = properties.Select(p =>
        {
            var descriptionAttribute = p.GetCustomAttribute<DescriptionAttribute>();

            if (descriptionAttribute is not null && !string.IsNullOrWhiteSpace(descriptionAttribute.Description))
            {
                return $"\"{descriptionAttribute.Description}\"";
            }

            return $"\"{p.Name}\"";
        });

        var parameterNames = properties.Select(p => p.Name.Equals("Id") ? "DEFAULT" : $"@{p.Name}");

        var insertQuery =
            $"INSERT INTO {tableName} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", parameterNames)})";

        return insertQuery;
    }

    public static string GenerateUpdateQuery<T>() where T : class
    {
        var properties = GetProperties(typeof(T));
        var tableName = GetTableName<T>();
        var excludedProperties = new[] { "Id", "CreatedAt", "CreatedBy" };

        var updateColumns = properties.Where(p => !excludedProperties.Contains(p.Name))
            .Select(p => $"\"{p.Name}\"=@{p.Name}");

        var idColumn = properties.First(p => p.Name.Equals("Id"));
        var idParameter = $"@{idColumn.Name}";

        var updateQuery = $"UPDATE {tableName} SET {string.Join(", ", updateColumns)} WHERE \"Id\"={idParameter}";

        return updateQuery;
    }
}