using _00.Models.Requests;
using _00.Models.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Abstractions
{
    public interface IDataService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task LogoutAsync(string token);
        Task<IEnumerable<GetUserResponse>> GetTodoItemsAsync(string token,int page = 0, int pageSize = 10, string? titleFilter = null );
        Task<CreateTodoItemsResponse> CreateTodoItemAsync(CreateTodoItemsRequest request,string token);
        Task <IEnumerable<GetUserResponse>> GetUsersAsync(int page=0 ,int pageSize=10,string? firNameFilter=null);
        Task<CreateUserResponce> CreateUserAsynk(CreateUserRequest request);
    }
}