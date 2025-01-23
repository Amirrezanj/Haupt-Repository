using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.ViewModels
{
    public class MainViewModels :INotifyPropertyChanged
    {
        private string firstName = string.Empty;
        private string secondName = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private string password = string.Empty;
        private string strasse = string.Empty;
        private string hausNumber = string.Empty;

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName == value) return;


                firstName = value;
                Debug.WriteLine(value);
                PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(firstName)));
                PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(nameof(FullName)));
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

            }

        }

        public string Email
        {
            get => email;
            set
            {
                if (email == value) return;

                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }

        }


        public string Password
        {
            get => password;
            set
            {
                if (password == value) return;

                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public string Strasse
        {
            get => strasse;
            set
            {
                if (strasse == value) return;

                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Strasse)));
            }
        }


        public string HausNumber
        {
            get => hausNumber;
            set
            {
                if (hausNumber == value) return;

                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HausNumber)));
            }
        }

        public string FullName => $"{FirstName} {SecondName} {LastName}";

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
