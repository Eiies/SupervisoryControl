using MySql.Data.MySqlClient;
using SupervisoryControl.Core.Interfaces;

namespace SupervisoryControl.Infrastructure.Services;

public class UserService(string connectionString) : IUserService{ // 通过构造函数注入连接字符串
    public async Task<AddUserResult> AddUserAsync(string username, string password, int role){
        const string sql = @"
            INSERT INTO 用户表 (user, password, Role) 
            VALUES (@username, @password, @role);
        ";

        try{
            await using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            await using var cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password); // 实际应存储哈希值
            cmd.Parameters.AddWithValue("@role", role);

            var rowsAffected = await cmd.ExecuteNonQueryAsync();
            if (rowsAffected == 1) return new AddUserResult{ Success = true, Username = username };

            return new AddUserResult{ Success = false, Message = "数据库操作异常" };
        } catch (MySqlException ex) when (ex.Number == 1062){
            return new AddUserResult{ Success = false, Message = $"用户名 '{username}' 已存在" };
        }
    }

    public Task<bool> DeleteUserAsync(string username){
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUserRoleAsync(string username, int newRole){
        throw new NotImplementedException();
    }

    public Task<bool> ValidateUserCredentialsAsync(string username, string password){
        throw new NotImplementedException();
    }
}