using MySql.Data.MySqlClient;
using SupervisoryControl.Core.Interfaces;

namespace SupervisoryControl.Infrastructure.Services;
public class MySqlService :IMySqlService {
    public bool TryConnect(out string message) {
        
        var builder = new MySqlConnectionStringBuilder{
            Server = "127.0.0.1",
            Database = "test_go",
            UserID = "root",
            Password = "root",
            Port = 3306,
            CharacterSet = "utf8mb4",
            Pooling = true,
            ConnectionTimeout = 15
        };
        
        try{
            using var connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            message = "连接成功！";
            return true;
        } catch(Exception ex) {
            message = $"连接失败：{ex.Message}";
            return false;
        }
    }
}

