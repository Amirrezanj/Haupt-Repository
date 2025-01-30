using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Abstractions
{
    public interface IpreferenceService
    {
        string CurrentTheme { get; set; }
        double WindowWidth { get; set; }
        double WindowHeight { get; set; }
        double x {  get; set; }
        double y { get; set; }

    }
}
