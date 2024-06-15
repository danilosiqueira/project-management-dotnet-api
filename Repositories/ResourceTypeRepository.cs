using System.Data.Common;
using Dapper;
using ProjectManagement.Models;

namespace ProjectManagement.Repositories;

public class ResourceTypeRepository
{
    private readonly DbConnection _conn;
    private const string Table = "resource_types";

    public ResourceTypeRepository(DbDataSource dbDataSrouce)
    {
        _conn = dbDataSrouce.CreateConnection();
    }

    public Task<ResourceType?> GetAsync(long id)
    {
        var sql = @$"select * from { Table } where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<ResourceType>(sql, new { Id = id });
    }

    public Task<ResourceType?> SaveAsync(ResourceType resourceType)
    {
        var sql = @$"insert into { Table } (title) values (@Title) returning *";
        return _conn.QuerySingleOrDefaultAsync<ResourceType>(sql, resourceType);
    }

    public Task<ResourceType?> UpdateAsync(ResourceType ResourceType)
    {
        var sql = @$"update { Table } set title = @Title where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<ResourceType>(sql, ResourceType);
    }
}