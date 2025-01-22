using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Models;
using TodoAppMaui.Models.Responses;

namespace TodoAppMaui.Abstractions
{
    public interface IDataService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
    }
}
