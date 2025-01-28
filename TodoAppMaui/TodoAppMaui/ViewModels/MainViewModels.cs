using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Abstractions;
using TodoAppMaui.Models;
using TodoAppMaui.Models.Requests;
using TodoAppMaui.Services;

namespace TodoAppMaui.ViewModels
{
    public class MainViewModels :INotifyPropertyChanged
    {
        private readonly IDataService _dataService;

        private readonly ILogger _logger;

        private string firstName = string.Empty;
        private string secondName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private string password = string.Empty;
        private string strasse = string.Empty;
        private string hausNumber = string.Empty;
        private string city = string.Empty;
        private string zipcode = string.Empty;
        private string country = string.Empty;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName == value) return;


                firstName = value;
                //Debug.WriteLine(value);
                PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(FirstName)));
                PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(FullName)));
                RegisterCommand.ChangeCanExecute();
            }

        }

        public string SecondName
        {
            get => secondName;
            set
            {
                if (secondName == value) return;

                secondName = value;
                PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(SecondName)));
                PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(FullName)));

                RegisterCommand.ChangeCanExecute();
            }

        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName == value) return;

                lastName = value;
                PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(LastName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));

                RegisterCommand.ChangeCanExecute();

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
                RegisterCommand.ChangeCanExecute();
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
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string Strasse
        {
            get => strasse;
            set
            {
                if (strasse == value) return;

                strasse = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Strasse)));
                RegisterCommand.ChangeCanExecute();
            }
        }


        public string HausNumber
        {
            get => hausNumber;
            set
            {
                if (hausNumber == value) return;

                hausNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HausNumber)));
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string City
        {
            get => city;
            set
            {
                if (city == value) return;

                city = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(City)));
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string Zipcode
        {
            get => zipcode;
            set
            {
                if (zipcode == value) return;

                zipcode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Zipcode)));
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string Country
        {
            get => country;
            set
            {
                if (country == value) return;

                country = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Country)));
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string FullName => $"{FirstName} {SecondName} {LastName}";

        public event PropertyChangedEventHandler? PropertyChanged;

        public Command RegisterCommand { get; }

        public Command TestCommand { get; }
        //public bool _isBusy
        //{

        //}


        public MainViewModels(IDataService dataService ,ILogger<MainViewModels> logger)
        {
            _dataService = dataService;

            RegisterCommand = new Command(Register, Check);
               
            _logger = logger;

            TestCommand = new Command(() => Items.Add("hi"));

        }
        public ObservableCollection<string> Items { get; } = new();
        private bool Check()
        {
            if(FirstName.Length<5 || FirstName.Length>15) return false;

            if(LastName.Length<5 || LastName.Length>15) return false;

            if (SecondName != null)
                if (SecondName.Length > 15) return false;

            if(!MailAddress.TryCreate(Email,out MailAddress? _)) return false;

            if (Password.Length < 5) return false;
            
            if(Strasse.Length < 2 ||  Strasse.Length > 50) return false;

            if(HausNumber.Length < 1 || HausNumber.Length > 4) return false;

            if(City.Length < 2 || City.Length > 25) return false ;

            if(Zipcode.Length != 5) return false;

            if(Country.Length <  2 || Country.Length > 50)return false;


            return true;
            
        }
        
        private async void Register()
        {
            try
            {
                var address = new CreateAddressRequest(strasse, hausNumber, city, zipcode, country);
                var user = new CreateUserRequest(firstName, secondName, lastName, email, password, address);

                await _dataService.CreateUserAsync(user);
                await Shell.Current.GoToAsync("///LoginPage");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception{ex}",ex);
            }
        }
    }
}
