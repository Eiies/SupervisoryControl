using MySql.Data.MySqlClient;
using SupervisoryControl.Core.Interfaces;

namespace SupervisoryControl.Infrastructure.Services;
public class MySqlService :IMySqlService {
    private readonly string _connectionString = "server=localhost;port=3306;user=root;password=root;database=test_go";
    public bool TryConnect(out string message) {
        try {
            using var connection = new MySqlConnection(_connectionString);
            connection.Open();
            message = "连接成功！";
            return true;
        } catch(Exception ex) {
            message = $"连接失败：{ex.Message}";
            return false;
        }
    }
}

