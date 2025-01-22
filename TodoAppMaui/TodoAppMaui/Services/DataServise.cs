using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TodoAppMaui.Abstractions;
using TodoAppMaui.Models;
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
        public DataService()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:5027");

        }
        public class LoggingHandler : DelegatingHandler
        {
            public LoggingHandler(HttpMessageHandler innerHandler)
                : base(innerHandler)
            {
            }
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync("/api/users", content);

            responce.EnsureSuccessStatusCode();

            var responceJson = await responce.Content.ReadAsStringAsync();
            var creatUserResponce = JsonSerializer.Deserialize<CreateUserResponse>(responceJson, _serializerOptions);

            if (creatUserResponce == null)
                throw new Exception($"{nameof(creatUserResponce)} could not be deserialized");

            return creatUserResponce;
        }
    }
}