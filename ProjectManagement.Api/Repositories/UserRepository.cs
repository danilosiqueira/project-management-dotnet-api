using System.Data.Common;
using Dapper;
using ProjectManagement.Api.Models;

namespace ProjectManagement.Api.Repositories;

public class UserRepository
{
    private readonly DbConnection _conn;
    private const string Table = "users";

    public UserRepository(DbDataSource dbDataSrouce)
    {
        _conn = dbDataSrouce.CreateConnection();
    }

    public Task<User?> GetByLoginAsync(string login)
    {
        var sql = @$"select * from { Table } where login = @Login";
        return _conn.QuerySingleOrDefaultAsync<User>(sql, new { Login = login });
    }

    public Task<User?> SaveAsync(User user)
    {
        var sql = @$"insert into { Table } (name, login, password)
        values (@Name, @Login, @Password) returning *";
        return _conn.QuerySingleOrDefaultAsync<User>(sql, user);
    }

    public Task<User?> UpdateAsync(User user)
    {
        var sql = @$"update { Table } set name = @Name, password = @Password where id = @Id";
        return _conn.QuerySingleOrDefaultAsync<User>(sql, user);
    }
}