using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoAppMaui.Abstractions;
using TodoAppMaui.Models.Responses;
using System.Collections.ObjectModel;
using TodoAppMaui.Models;
using TodoAppMaui.Models.Requests;

namespace TodoAppMaui.ViewModels
{
    public class TodoViewModles : INotifyPropertyChanged
    {
        

        private readonly IDataService _dataService;
        private readonly ILogger _logger;
        private string title=string.Empty;

        private string description=string.Empty;

        private DateTime dueDate;

        private bool isDone;

        private Kategorie _Kategorie;
        public ObservableCollection<Kategorie> Kategories { get; } =
           new ObservableCollection<Kategorie>(Enum.GetValues(typeof(Kategorie)).Cast<Kategorie>());

        public Command Showtodoes { get; }

        public Command Createtodoes { get; }
        public Command Logout { get; }
        public Command GetTodos { get; }

        public event EventHandler? FailedShowTodos ;


        public IEnumerable<GetTodoItemsResponse>? TodoItems { get; set; }
        public ObservableCollection<GetTodoItemsResponse> TodoCollection { get; set; }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TodoViewModles(IDataService dataService, ILogger<LoginViewModels> logger)
        {
            _dataService = dataService;
            _logger = logger;
            Showtodoes = new Command(GetTodoItems);
            Createtodoes = new Command(CreateTodoes);
            Logout = new Command(LoggingOut);
            GetTodos = new Command(GetTodoItems);
        }
        public string Title
        {
            get => title;
            set
            {
                if (title == value) return;
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
                Showtodoes.ChangeCanExecute();
            }
        }
        
        public string Description
        {
            get => description;
            set
            {
                if(description == value) return;

                description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
                Showtodoes.ChangeCanExecute();
            }
        }
        public DateTime DueDate
        {
            get => dueDate;
            set
            {
                if (dueDate == value) return;

                dueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DueDate)));
                Showtodoes.ChangeCanExecute();
            }
        }
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if (!value) return;
                isDone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDone)));
                Showtodoes.ChangeCanExecute();

            }
        }

        public Kategorie SelectedKategory
        {
            get => _Kategorie;
            set
            {
                if (_Kategorie != value)
                {
                    _Kategorie = value;
                    OnPropertyChanged(nameof(SelectedKategory));
                }
            }
        }


        private async void GetTodoItems()
        {
            try
            {
                var token = await SecureStorage.GetAsync("Bearer");

                TodoItems = await _dataService.GetTodoItemsAsync(token);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: {ex}", ex);
            }

            TodoCollection = new(TodoItems);
            OnPropertyChanged(nameof(TodoCollection));
        }

        private async void CreateTodoes()
        {
            try
            {
                var token = await SecureStorage.GetAsync("Bearer");
                var request = new CreateTodoItemsRequest(Title, description, dueDate,SelectedKategory );
                await _dataService.CreateTodoItemAsync(request, token);
            }
            catch(Exception ex)
            {
                  _logger.LogError("Exception{ex}", ex);

                FailedShowTodos?.Invoke(this, EventArgs.Empty);
            }
        }

        private async void LoggingOut()
        {
            var token = await SecureStorage.GetAsync("Bearer");

            await _dataService.LogoutAsync(token);
            await Shell.Current.GoToAsync("///LoginPage");
        }
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
