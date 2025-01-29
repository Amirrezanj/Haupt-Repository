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
        public string AppTheme
        {
            get => Preferences.Default.Get("AppTheme", "Light");
            set => Preferences.Default.Set("AppTheme",value);
        }
    }
}
