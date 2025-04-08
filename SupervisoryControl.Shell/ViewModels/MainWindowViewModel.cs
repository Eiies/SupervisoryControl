using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using SupervisoryControl.Core.Interfaces;
using SupervisoryControl.Shell.Views;

namespace SupervisoryControl.Shell.ViewModels;

public class MainWindowViewModel : BindableBase{
    private readonly IMainService _mainService;
    private readonly IMySqlService _mySqlService;
    private readonly IUserService _userService;
    
    private string _connectionResult = string.Empty;

    private string _welcomeMessage = string.Empty;
    
    private string _addUserResult = string.Empty;
    private string _addUserResultColor = "Black"; // 改为存颜色值，如使用Brush类型更佳

    public MainWindowViewModel(IMainService mainService, IMySqlService mySqlService, IUserService userService){
        _mainService = mainService;
        _mySqlService = mySqlService;
        _userService = userService; // 初始化userService

        WelcomeMessage = _mainService.GetWelcomeMessage();
        ConnectCommand = new DelegateCommand(ConnectToDatabase);
        ShowAddUserDialogCommand = new DelegateCommand(ShowAddUserDialog);
    }

    public ICommand ConnectCommand{ get; }

    public ICommand ShowAddUserDialogCommand{ get; }


    public string WelcomeMessage{
        get => _welcomeMessage;
        set => SetProperty(ref _welcomeMessage, value);
    }

    public string ConnectionResult{
        get => _connectionResult;
        set => SetProperty(ref _connectionResult, value);
    }

    private void ConnectToDatabase(){
        if (_mySqlService.TryConnect(out var message))
            ConnectionResult = message;
        else
            ConnectionResult = message;
    }
    
    public string AddUserResult
    {
        get => _addUserResult;
        set => SetProperty(ref _addUserResult, value);
    }

    public string AddUserResultColor
    {
        get => _addUserResultColor;
        set => SetProperty(ref _addUserResultColor, value);
    }

    private void ShowAddUserDialog()
    {
        var dialog = new AddUserDialog();
        var dialogVm = new AddUserDialogViewModel(
            mySqlService: _mySqlService,
            userService: _userService,
            closeAction: result =>
            {
                dialog.Close();
            
                // UI更新必须回到主线程执行
                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (result.Success)
                    {
                        AddUserResult = $"✅ 用户 {result.Username} 添加成功";
                        AddUserResultColor = "Green";
                    }
                    else
                    {
                        AddUserResult = $"❌ {result.Message}";
                        AddUserResultColor = "Red";
                    }
                });
            });

        dialog.DataContext = dialogVm;
        dialog.Owner = Application.Current.MainWindow;
        dialog.ShowDialog();
    }
}