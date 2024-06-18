using System.Data.Common;
using Dapper;
using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Repositories;

public class ProjectRepository
{
    private readonly DbConnection _conn;
    private const string Table = "projects";

    public ProjectRepository(DbDataSource dbDataSrouce)
    {
        _conn = dbDataSrouce.CreateConnection();
    }

    public Task<Project?> GetAsync(long id)
    {
        var sql = @$"select * from { Table } where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<Project>(sql, new { Id = id });
    }

    public Task<Project?> SaveAsync(Project project)
    {
        var sql = @$"insert into { Table } (title, description, began_at, is_subproject, parent_id, user_id)
        values (@Title, @Description, @BeganAt, @IsSubproject, @ParentId, @UserId) returning *";
        return _conn.QuerySingleOrDefaultAsync<Project>(sql, project);
    }

    public Task<Project?> UpdateAsync(Project Project)
    {
        var sql = @$"update { Table } set
        title = @Title, 
        description = @Description, 
        began_at = @BeganAt, 
        is_subproject = @IsSubproject, 
        parent_id = @ParentId
        where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<Project>(sql, Project);
    }
}