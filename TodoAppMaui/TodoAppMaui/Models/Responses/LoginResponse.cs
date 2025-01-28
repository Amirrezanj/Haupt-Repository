using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Models.Responses
{
    public record LoginResponse(string Token, DateTime TokenExpiry);    
    
}
