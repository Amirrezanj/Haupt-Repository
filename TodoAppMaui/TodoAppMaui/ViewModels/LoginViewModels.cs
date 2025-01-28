using Microsoft.Extensions.Logging;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Abstractions;
using TodoAppMaui.Models.Requests;
using TodoAppMaui.Models.Responses;

namespace TodoAppMaui.ViewModels
{
    public class LoginViewModels : INotifyPropertyChanged
    {
        private readonly IDataService _dataService;
        private readonly ILogger _logger;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string email = string.Empty;
        private string password = string.Empty;

        public Command LoginCommand { get; }

        public LoginViewModels(IDataService dataService, ILogger<LoginViewModels> logger)
        {
            _dataService = dataService;
            _logger = logger;
            LoginCommand = new Command(Login);
        }
        private async void Login()
        {
            try
            {
                var request = new LoginRequest(Email, Password);
                await _dataService.LoginAsync(request);
                
                LoginResponse response = await _dataService.LoginAsync(request);
                await SecureStorage.Default.SetAsync("Bearer", response.Token);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception{ex}", ex);
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (email == value) return;

                email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
                LoginCommand.ChangeCanExecute();
            }

        }

        public string Password
        {
            get => password;
            set
            {
                if (password == value) return;

                password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                LoginCommand.ChangeCanExecute();
            }
        }
    }
}
