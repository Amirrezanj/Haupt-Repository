using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Abstractions;

namespace TodoAppMaui.Services
{
    internal class PreferenceService : IpreferenceService
    {
        private const string _currentThemeKey = "CurrentTheme";
        public string CurrentTheme
        {
            get => Preferences.Default.Get(_currentThemeKey, "Light");
            set => Preferences.Default.Set(_currentThemeKey,value);
        }
        public double WindowWidth
        {
            get => Preferences.Default.Get("WindowWidth", 1000);
            set => Preferences.Default.Set("WindowWidth", value);
        }
        public double WindowHeight
        {
            get => Preferences.Default.Get("WindowWidth",1000);
            set => Preferences.Default.Set("WindowWidth", value);
        }
        public double x
        {
            get => Preferences.Default.Get("x", 0);
            set => Preferences.Default.Set("x", value);
        }
        public double y
        {
            get=>Preferences.Default.Get("y", 0);
            set=>Preferences.Default.Set("y", value);
        }


       
    }
}
