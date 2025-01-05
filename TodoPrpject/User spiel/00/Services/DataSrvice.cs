using _00.Abstractions;
using _00.Models.Requests;
using _00.Models.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _00.Services;
using _00.Models;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Net.Http;



namespace _00.Services
{
    public class DataSrvice : IDataService
    {
#if DEBUG
        private static readonly HttpClient _httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler()));
#else
        private static private static readonly _HttpClient _= new httpClient();
#endif
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public DataSrvice(string url)
        {
            _httpClient.BaseAddress = new Uri(url);
            
        }
        public class LoggingHandler : DelegatingHandler
        {
            public LoggingHandler(HttpMessageHandler innerHandler)
                : base(innerHandler)
            {
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Debug.WriteLine("Request:");
                Debug.WriteLine(request.ToString());
                if (request.Content != null)
                {
                    Debug.WriteLine(await request.Content.ReadAsStringAsync());
                }
                Debug.WriteLine(string.Empty);

                HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

                Debug.WriteLine("Response:");
                Debug.WriteLine(response.ToString());
                if (response.Content != null)
                {
                    Debug.WriteLine(await response.Content.ReadAsStringAsync());
                }
                Debug.WriteLine(string.Empty);

                return response;
            }
        }
        


        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync("/api/auth/login", content);

            responce.EnsureSuccessStatusCode();

            var responceJson = await responce.Content.ReadAsStringAsync();
            var LoginResponce = JsonSerializer.Deserialize<LoginResponse>(responceJson, _serializerOptions);

            if (LoginResponce == null)
                throw new Exception($"{nameof(LoginResponce)} could not be deserialized");

            return LoginResponce;
        }
        public async Task LogoutAsync(string token)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Delete;
            request.RequestUri = new Uri("/api/auth/logout",UriKind.Relative);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",token);
            
            var response= await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }


        public async Task<IEnumerable<GetTodoItemResponse>> GetTodoItemsAsync(string token, int page = 0, int pageSize = 10, string? titleFilter = null)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("/api/todoitems", UriKind.Relative);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage responseMessage = await _httpClient.SendAsync(request);

            var responseJson= await responseMessage.Content.ReadAsStringAsync();
            var getTodoItemsResponse = JsonSerializer.Deserialize<IEnumerable<GetTodoItemResponse>>(responseJson,_serializerOptions);

            if (getTodoItemsResponse == null)
            {
                throw new Exception(($"{nameof(getTodoItemsResponse)} could not be deserilizied"));
            }
            return getTodoItemsResponse;
        }


        public async Task<GetTodoItemResponse> GetTodoItemAsync(string token, Guid id)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Get;
            requestMessage.RequestUri = new Uri($"/api/todoitems/{id}", UriKind.Relative);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await _httpClient.SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();

            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<GetTodoItemResponse>(responseJson, _serializerOptions);

            if (response == null)
                throw new Exception($"{nameof(GetTodoItemResponse)} could not be deserialized");

            return response;
        }

        public async Task<CreateTodoItemsResponse> CreateTodoItemAsync(CreateTodoItemsRequest request, string token)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent (requestJson,Encoding.UTF8,"application/json");
            //var response = await _httpClient.PostAsync("/api/todoitems", content);
            

            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = new Uri("/api/todoitems", UriKind.Relative);
            requestMessage.Content = content;
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage);

            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            var creatTodoResonse = JsonSerializer.Deserialize<CreateTodoItemsResponse>(responseJson,_serializerOptions);

            if (creatTodoResonse == null)
            {
                throw new Exception($"{nameof(creatTodoResonse)} couldnt be deserializied");
            }
            return creatTodoResonse;
        }
        public async Task<UpdateTodoItemResponse> UpdateTodoItemAsync(string token, UpdateTodoItemRequest request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Put;
            requestMessage.RequestUri = new Uri($"/api/todoitems/{request.Id}", UriKind.Relative);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();

            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<UpdateTodoItemResponse>(responseJson, _serializerOptions);

            if (response == null)
                throw new Exception($"{nameof(UpdateTodoItemResponse)} could not be deserialized");

            return response;
        }

        public async Task DeleteTodoItemAsync(string token, Guid id)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Delete;
            requestMessage.RequestUri = new Uri($"/api/todoitems/{id}", UriKind.Relative);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await _httpClient.SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();
        }


        public async Task<CreateUserResponce> CreateUserAsynk(CreateUserRequest request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson,Encoding.UTF8,"application/json");
            var responce = await _httpClient.PostAsync("/api/users", content);

            responce.EnsureSuccessStatusCode();

            var responceJson = await responce.Content.ReadAsStringAsync();
            var creatUserResponce = JsonSerializer.Deserialize<CreateUserResponce>(responceJson,_serializerOptions);

            if (creatUserResponce == null)
                throw new Exception($"{nameof(creatUserResponce)} could not be deserialized");

            return creatUserResponce;
        }
        public async Task DeleteUserAsync(string token)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Delete;
            requestMessage.RequestUri = new Uri("/api/users", UriKind.Relative);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var responseMessage = await _httpClient.SendAsync(requestMessage);
            responseMessage.EnsureSuccessStatusCode();
        }
        public async Task<IEnumerable<GetUserResponse>> GetUsersAsync(int page =0,int pageSize = 10,string? firstNameFilter=null)
        {
            var responce = await _httpClient.GetAsync($"/api/users?page={page}&pageSize={pageSize}&");

            responce.EnsureSuccessStatusCode();

            var responseJson = await responce.Content.ReadAsStringAsync();
            var getUsersResponse = JsonSerializer.Deserialize<IEnumerable<GetUserResponse>>(responseJson,_serializerOptions);

            if (getUsersResponse == null)

                throw new Exception(($"{nameof(getUsersResponse)} could not be deserilizied"));
            return getUsersResponse;

        }
        
    }
}

