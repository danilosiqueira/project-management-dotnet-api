using Dapper;
using ProjectManagement.Api.Models;
using System.Reflection;
using Task = ProjectManagement.Api.Models.Task;

namespace ProjectManagement.Api.Config;

public static class DapperConfig
{
    public static void ConfigureDapper()
    {
        ConfigureTypeMap<User>();
        ConfigureTypeMap<Project>();
        ConfigureTypeMap<ResourceType>();
        ConfigureTypeMap<Resource>();
        ConfigureTypeMap<Task>();
    }

    private static void ConfigureTypeMap<T>()
    {
        SqlMapper.SetTypeMap(
            typeof(T),
            new CustomPropertyTypeMap(
                typeof(T),
                (type, columnName) =>
                {
                    var propertyName = ConvertToPascalCase(columnName);
                    return type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                }
            )
        );
    }

    private static string ConvertToPascalCase(string snake_case)
    {
        return string.Join("", snake_case.Split('_').Select(word => char.ToUpper(word[0]) + word.Substring(1)));
    }
}
