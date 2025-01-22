using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMaui.Models
{
    public record CreateUserRequest(string FirstName ,
        string? SecondName ,
        string LastName ,
        string Email,
        string Password,
        CreateAddressRequest Address);
    
    
}
