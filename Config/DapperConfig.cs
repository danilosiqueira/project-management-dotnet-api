using Dapper;
using ProjectManagement.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

public static class DapperConfig
{
    public static void ConfigureDapper()
    {
        ConfigureTypeMap<User>();
        ConfigureTypeMap<Project>();
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
