using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoAppMaui.Abstractions;
using TodoAppMaui.Models;
using TodoAppMaui.Models.Requests;
using TodoAppMaui.Models.Responses;

namespace TodoAppMaui.Services
{
    public class DataService : IDataService
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

        private readonly ISecureStorageService _secureStorageService;

        public DataService(ISecureStorageService secureStorageService)
        {
            _secureStorageService = secureStorageService;
            _httpClient.BaseAddress = new Uri("http://localhost:5027");
        }


        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/Session", content);

            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var LoginResponse = JsonSerializer.Deserialize<LoginResponse>(responseJson, _serializerOptions);

            if (LoginResponse == null)
                throw new Exception($"{nameof(LoginResponse)} could not be deserialized");

            await _secureStorageService.SetSessionCredentialsAsync(new SessionCredentials(LoginResponse.Token, LoginResponse.Expiry));

            return LoginResponse;
        }

        public async Task<CreateTodoItemsResponse> CreateTodoItemAsync(CreateTodoItemsRequest request, string token)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            var tok = await _secureStorageService.GetSessionCredentialsAsync();


            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = new Uri("/users/current/todos", UriKind.Relative);
            requestMessage.Content = content;
            //requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tok.Token);

            HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage);

            responseMessage.EnsureSuccessStatusCode();
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            var creatTodoResonse = JsonSerializer.Deserialize<CreateTodoItemsResponse>(responseJson, _serializerOptions);

            if (creatTodoResonse == null)
            {
                throw new Exception($"{nameof(creatTodoResonse)} couldnt be deserializied");
            }
            return creatTodoResonse;
        }


        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync("/users", content);

            responce.EnsureSuccessStatusCode();

            var responceJson = await responce.Content.ReadAsStringAsync();
            var creatUserResponce = JsonSerializer.Deserialize<CreateUserResponse>(responceJson, _serializerOptions);

            if (creatUserResponce == null)
                throw new Exception($"{nameof(creatUserResponce)} could not be deserialized");

            return creatUserResponce;
        }

        public async Task LogoutAsync(string token)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Delete;
            request.RequestUri = new Uri("/session/current", UriKind.Relative);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            _secureStorageService.DeleteSessionCredentials();
        }

        public async Task<IEnumerable<GetTodoItemsResponse>> GetTodoItemsAsync(string token, int page = 0, int pageSize = 10, string? titleFilter = null)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri("users/current/todos", UriKind.Relative);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            HttpResponseMessage responseMessage = await _httpClient.SendAsync(request);

            responseMessage.EnsureSuccessStatusCode();

            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            var getTodoItemsResponse = JsonSerializer.Deserialize<IEnumerable<GetTodoItemsResponse>>(responseJson, _serializerOptions);

            if (getTodoItemsResponse == null)
            {
                throw new Exception(($"{nameof(getTodoItemsResponse)} could not be deserilizied"));
            }
            return getTodoItemsResponse;
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

    }
}