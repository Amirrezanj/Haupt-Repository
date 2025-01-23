using System;
using System.Collections.Generic;
using System.Diagnostics;
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