using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Abstractions;

namespace TodoAppMaui.ViewModels
{
    public class SettingViewModels : INotifyPropertyChanged
    {
        private readonly IpreferenceService _preferenceService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public SettingViewModels(IpreferenceService preferenceService)
        {
            _preferenceService = preferenceService;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        
    }
}
