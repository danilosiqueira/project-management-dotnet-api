using System.Data.Common;
using Dapper;

namespace ProjectManagement.Api.Repositories;

public class TaskRepository
{
    private readonly DbConnection _conn;
    private const string Table = "tasks";

    public TaskRepository(DbDataSource dbDataSrouce)
    {
        _conn = dbDataSrouce.CreateConnection();
    }

    public Task<Models.Task?> GetAsync(long id)
    {
        var sql = @$"select * from { Table } where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<Models.Task>(sql, new { Id = id });
    }

    public Task<Models.Task?> SaveAsync(Models.Task task)
    {
        var sql = @$"insert into { Table }
        (title, description, began_at, done_at, due_date, is_done, project_id, assigned_to, user_id)
        values (@Title, @Description, @BeganAt, @DoneAt, @DueDate, @IsDone, @ProjectId, @AssignedTo, @UserId) returning *";
        return _conn.QuerySingleOrDefaultAsync<Models.Task>(sql, task);
    }

    public Task<Models.Task?> UpdateAsync(Models.Task task)
    {
        var sql = @$"update { Table } set
        title = @Title,
        description = @Description,
        began_at = @BeganAt,
        done_at = @DoneAt,
        due_date = @DueDate,
        is_done = @IsDone,
        project_id = @ProjectId,
        assigned_to = @AssignedTo
        where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<Models.Task>(sql, task);
    }

    public Task<Models.Task?> GetOpenByAssigneeAsync(long assigneeId)
    {
        var sql = @$"select * from { Table } where is_done = false and assigned_to = @AssigneeId";
        return _conn.QuerySingleOrDefaultAsync<Models.Task>(sql, new { AssigneeId = assigneeId });
    }
}