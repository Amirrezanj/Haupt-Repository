using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMaui.Models;
using TodoAppMaui.Models.Requests;
using TodoAppMaui.Models.Responses;

namespace TodoAppMaui.Abstractions
{
    public interface IDataService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<IEnumerable<GetTodoItemsResponse>> GetTodoItemsAsync(string token, int page = 0, int pageSize = 10, string? titleFilter = null);
        Task<CreateTodoItemsResponse> CreateTodoItemAsync(CreateTodoItemsRequest request, string token);
        Task LogoutAsync(string token);


    }
}
