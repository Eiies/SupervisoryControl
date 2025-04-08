using Prism.Commands;
using Prism.Mvvm;
using SupervisoryControl.Core.Interfaces;
using System;
using System.Windows;

namespace SupervisoryControl.Shell.ViewModels;

    public class AddUserDialogViewModel : BindableBase
    {
        private readonly IMySqlService _mySqlService;
        private readonly IUserService _userService;
        private readonly Action<AddUserResult> _closeAction;

        private string _username = string.Empty;
        private string _password = string.Empty;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public DelegateCommand SaveUserCommand { get; }
        public DelegateCommand CloseCommand { get; }

        public AddUserDialogViewModel(
            IMySqlService mySqlService, 
            IUserService userService, 
            Action<AddUserResult> closeAction)
        {
            _mySqlService = mySqlService;
            _userService = userService;
            _closeAction = closeAction;

            SaveUserCommand = new DelegateCommand(ExecuteSaveUser, CanSaveUser)
                .ObservesProperty(() => Username)
                .ObservesProperty(() => Password);

            CloseCommand = new DelegateCommand(() => _closeAction(new AddUserResult { Success = false }));
        }

        private bool CanSaveUser() => 
            !string.IsNullOrWhiteSpace(Username) && 
            !string.IsNullOrWhiteSpace(Password) &&
            Password.Length >= 8;

        private async void ExecuteSaveUser()
        {
            try
            {
                var result = await _userService.AddUserAsync(Username, Password, role: 1);
                _closeAction(result);
            }
            catch (Exception ex)
            {
                _closeAction(new AddUserResult 
                { 
                    Success = false, 
                    Message = $"保存失败: {ex.Message}" 
                });
            }
        }
    }
