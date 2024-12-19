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


namespace _00.Services
{
    public class DataSrvice : IDataService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync("https://51e4-79-195-74-70.ngrok-free.app/api/auth/login", content);

            responce.EnsureSuccessStatusCode();

            var responceJson = await responce.Content.ReadAsStringAsync();
            var LoginResponce = JsonSerializer.Deserialize<LoginResponse>(responceJson, _serializerOptions);

            if (LoginResponce == null)
                throw new Exception($"{nameof(LoginResponce)} could not be deserialized");

            return LoginResponce;
        }

        public async Task<IEnumerable<GetUserResponse>> GetUsersAsync(int page =0,int pageSize = 10,string? firstNameFilter=null)
        {
            var responce = await _httpClient.GetAsync($"https://51e4-79-195-74-70.ngrok-free.app/api/users?page={page}&pageSize={pageSize}&");

            responce.EnsureSuccessStatusCode();

            var responseJson = await responce.Content.ReadAsStringAsync();
            var getUsersResponse = JsonSerializer.Deserialize<IEnumerable<GetUserResponse>>(responseJson,_serializerOptions);

            if (getUsersResponse == null)

                throw new Exception(($"{nameof(getUsersResponse)} could not be deserilizied"));
            return getUsersResponse;

        }

        public async Task<CreateUserResponce> CreateUserAsynk(CreateUserRequest request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson,Encoding.UTF8,"application/json");
            var responce = await _httpClient.PostAsync("https://51e4-79-195-74-70.ngrok-free.app/api/users", content);

            responce.EnsureSuccessStatusCode();

            var responceJson = await responce.Content.ReadAsStringAsync();
            var creatUserResponce = JsonSerializer.Deserialize<CreateUserResponce>(responceJson,_serializerOptions);

            if (creatUserResponce == null)
                throw new Exception($"{nameof(creatUserResponce)} could not be deserialized");

            return creatUserResponce;
        }
    }
}