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
        #region Auth
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task LogoutAsync(string token);
        #endregion Auth
        #region TodoItems
        Task<IEnumerable<GetTodoItemResponse>> GetTodoItemsAsync(string token,int page = 0, int pageSize = 10, string? titleFilter = null );
        Task<CreateTodoItemsResponse> CreateTodoItemAsync(CreateTodoItemsRequest request,string token);
        Task<GetTodoItemResponse> GetTodoItemAsync(string token, Guid id);
        Task<UpdateTodoItemResponse> UpdateTodoItemAsync(string token, UpdateTodoItemRequest request);
        Task DeleteTodoItemAsync(string token, Guid id);
        #endregion TodoItems
        #region Users
        Task<CreateUserResponce> CreateUserAsynk(CreateUserRequest request);
        Task DeleteUserAsync(string token);
        Task<IEnumerable<GetUserResponse>> GetUsersAsync(int page=0 ,int pageSize=10,string? firNameFilter=null);
        #endregion Users

    }
}