using System.Text;
using _00.Services ;
using _00.Models;
using _00.Abstractions;
using _00.Models.Requests;
using _00.Models.Responces;

namespace _00
{
    public class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private static async Task Main(string[] args)
        {
            //await userErstellenAsync();
            //await GetUsersAsync();
            ////await DeleteUserAsync();
            ///
            //DataSrvice dataSrvice = new DataSrvice();
            //CreateUserRequest request = new CreateUserRequest("amirnjjjj@gmail.com", "Test.123", "amir", "njj", new DateTime(1996, 12, 05));
            //CreateUserResponce responce = await dataSrvice.CreateUserAsynk(request);
            //Console.WriteLine(responce.id);
            //Console.WriteLine(responce.FirstName);

            IDataService dataService = new DataService("https://b4eb-79-195-74-70.ngrok-free.app/");

            //get users
            //var users = await dataService.GetUsersAsync(0,100,"amir");
            // var users = await dataService.GetUsersAsync(firstNameFilter : "");

            //foreach (var user in users)
            //{
            //    Console.WriteLine(user.id);
            //    Console.WriteLine(user.FirstName);
            //}


            var loginRequest = new LoginRequest("amirnjjjj@gmail.com", "Test.123");
            var loginResponse = await dataService.LoginAsync(loginRequest);
            Console.WriteLine(loginResponse.Token);
            Console.WriteLine(loginResponse.TokenExpiry);

            //logout
            //await dataService.LogoutAsync(loginResponse.Token);


            //todoitem erstellen
            var creatTodoItemsRequest = new CreateTodoItemsRequest("spielen", "Fifa", DateTime.Parse("2024-12-20T09:01:36.427Z"));
            var todoitemsRespnse = dataService.CreateTodoItemAsync(creatTodoItemsRequest, loginResponse.Token);
            Console.WriteLine(todoitemsRespnse.Id);

            //get todo items
            var todoitems = await dataService.GetTodoItemsAsync(loginResponse.Token, 0, 100);
            foreach (var todoitem in todoitems)
            {
                Console.WriteLine(todoitem);


            }

            //private static async Task GetUsersAsync()
            //{
            //    HttpResponseMessage Response = await _httpClient.GetAsync("https://e5e9-79-195-74-70.ngrok-free.app/api/users");
            //    if (Response.IsSuccessStatusCode)
            //    {
            //        string content = await Response.Content.ReadAsStringAsync();
            //        Console.WriteLine(content);
            //    }
            //}

            //private static async Task userErstellenAsync()
            //{
            //    var json = @"
            //    {
            //        ""email"":""blabla@gmail.com"",
            //        ""firstName"":""amir"",
            //        ""lastName"":""njj"",
            //        ""password"":""Amir.123"",
            //        ""birthDate"":""1996-12-19T09:27:38.417Z""
            //     }";
            //    var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");
            //    var response = await _httpClient.PostAsync("https://e5e9-79-195-74-70.ngrok-free.app/api/users", httpcontent);

            //    Console.WriteLine((int)response.StatusCode);
            //}

            //private static async Task DeleteUserAsync()
            //{
            //    var deleteResponce = await _httpClient.DeleteAsync("https://e5e9-79-195-74-70.ngrok-free.app/api/users/1");
            //    string deleteResponceContent = await deleteResponce.Content.ReadAsStringAsync();
            //    Console.WriteLine(deleteResponceContent);
            //}
        }
    }
}