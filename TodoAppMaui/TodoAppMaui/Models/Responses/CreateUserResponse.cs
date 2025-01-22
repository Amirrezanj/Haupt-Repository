using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Models.Responses
{
    public record CreateUserResponse(Guid Id ,
        string FirstName ,
        string? SecondName,
        string LastName,
        string Email
        );
    
    
}
