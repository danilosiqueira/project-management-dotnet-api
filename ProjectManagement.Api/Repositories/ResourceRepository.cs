using System.Data.Common;
using Dapper;
using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Repositories;

public class ResourceRepository
{
    private readonly DbConnection _conn;
    private const string Table = "resources";

    public ResourceRepository(DbDataSource dbDataSrouce)
    {
        _conn = dbDataSrouce.CreateConnection();
    }

    public Task<Resource?> GetAsync(long id)
    {
        var sql = @$"select * from { Table } where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<Resource>(sql, new { Id = id });
    }

    public Task<Resource?> SaveAsync(Resource resource)
    {
        var sql = @$"insert into { Table } (title, type_id) values (@Title, @TypeId) returning *";
        return _conn.QuerySingleOrDefaultAsync<Resource>(sql, resource);
    }

    public Task<Resource?> UpdateAsync(Resource Resource)
    {
        var sql = @$"update { Table } set title = @Title where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<Resource>(sql, Resource);
    }
}