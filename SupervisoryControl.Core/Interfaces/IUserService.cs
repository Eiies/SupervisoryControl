namespace SupervisoryControl.Core.Interfaces;

/// <summary>
///     用户管理服务接口
/// </summary>
public interface IUserService{
    /// <summary>
    ///     添加新用户
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码（明文或哈希）</param>
    /// <param name="role">角色ID</param>
    /// <returns>操作结果</returns>
    Task<AddUserResult> AddUserAsync(string username, string password, int role);

    /// <summary>
    ///     删除用户
    /// </summary>
    /// <param name="username">用户名</param>
    Task<bool> DeleteUserAsync(string username);

    /// <summary>
    ///     更新用户角色
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="newRole">新角色ID</param>
    Task<bool> UpdateUserRoleAsync(string username, int newRole);

    /// <summary>
    ///     验证用户凭据
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    Task<bool> ValidateUserCredentialsAsync(string username, string password);
}

/// <summary>
///     添加用户操作结果
/// </summary>
public class AddUserResult{
    public bool Success{ get; set; }
    public string Message{ get; set; } = string.Empty;
    public string Username{ get; set; } = string.Empty;
}