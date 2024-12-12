using Microsoft.EntityFrameworkCore;
using TodoProject.Data;
using TodoProject.Data.Entities;
namespace TodoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //unit of work
            using var context = new ApplicationDbcontext();

            //zum testen
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            for (int i = 0; i < 100; i++)
            {
                UserEntity userEntity = new UserEntity
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Email = Faker.Internet.Email()
                };
                context.Add(userEntity);
                //context.Users.Add(userEntity);

            }
            context.SaveChanges();


            for (int i = 0; i < 100; i++)
            {
                AddressEntity addressEntity = new AddressEntity
                {
                    Street = Faker.Address.StreetAddress(),
                    HouseNumber = i * i,
                    City = Faker.Address.City(),
                    ZipCode=Faker.Address.ZipCode(),
                    Country = Faker.Address.Country(),
                };
                context.Add(addressEntity);
            }
            context.SaveChanges();   




            //foreach (var user in context.Users)
            //{
            //    Console.WriteLine(user.FirstName);
            //}
            //var temp = context.Users.Where(x => x.FirstName.StartsWith("m"));
            //foreach (var user in temp)
            //{
            //    Console.WriteLine(user.FirstName);
            //}
        }
    }
}
