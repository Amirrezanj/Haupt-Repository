using Faker;
using System.Runtime.CompilerServices;
using TodoAppApi.Data.Entities;
using TodoAppApi.Data.Entities;
using TodoAppApi.Data;

namespace TodoAppApi.Data;

public static class Seed
{
    public static async Task SeedDatabaseAsync(this ApplicationDbContext dbContext)
    {
        if (dbContext.Users.Any())
            return;

        for (int i = 0; i < 50; i++)
        {
            var user = new UserEntity
            {
                FirstName = Name.First(),
                SecondName = i % 2 == 0 ? Name.First() : null,
                LastName = Name.Last(),
                Email = Internet.Email(),
                Address = new AddressEntity
                {
                    Street = Address.StreetName(),
                    HouseNumber = ((i + 1) * 2).ToString(),
                    City = Address.City(),
                    ZipCode = Address.ZipCode(),
                    Country = Address.Country()
                }
            };

            for (int x = 0; x < 15; x++)
            {
                var todo = new TodoEntity
                {
                    Title = Lorem.Sentence(),
                    Description = Lorem.Paragraph(),
                    DueDate = DateTime.Now.AddDays(Random.Shared.Next(1, 25)),
                };

                user.Todos.Add(todo);
            }

            dbContext.Users.Add(user);
        }

        await dbContext.SaveChangesAsync();
    }
}
