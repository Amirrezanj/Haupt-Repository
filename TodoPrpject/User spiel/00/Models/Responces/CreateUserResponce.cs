using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Models.Responces
{
    public record CreateUserResponce(Guid id , string Email, string FirstName, string LastNAme, DateTime BirthDate);
}
