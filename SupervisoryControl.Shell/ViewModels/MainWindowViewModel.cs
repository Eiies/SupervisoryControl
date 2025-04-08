using SupervisoryControl.Core.Interfaces;
using System.Windows.Input;

namespace SupervisoryControl.Shell.ViewModels;

public class MainWindowViewModel :BindableBase {
    private readonly IMainService _mainService;
    private readonly IMySqlService _mySqlService;

    private string _welcomeMessage = string.Empty;
    private string _connectionResult = string.Empty;

    public ICommand ConnectCommand { get; }


    public string WelcomeMessage {
        get => _welcomeMessage;
        set => SetProperty(ref _welcomeMessage, value);
    }

    public string ConnectionResult {
        get => _connectionResult;
        set => SetProperty(ref _connectionResult, value);
    }

    public MainWindowViewModel(IMainService mainService, IMySqlService mySqlService) {
        _mainService = mainService;
        _mySqlService = mySqlService;

        WelcomeMessage = _mainService.GetWelcomeMessage();
        ConnectCommand = new DelegateCommand(ConnectToDatabase);
    }

    private void ConnectToDatabase() {
        if(_mySqlService.TryConnect(out var message)) {
            ConnectionResult = message;
        } else {
            ConnectionResult = message;
        }
    }
}

