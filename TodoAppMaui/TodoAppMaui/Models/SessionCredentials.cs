using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Models
{
    public record SessionCredentials(string Token, DateTime TokenExpiry);
}
