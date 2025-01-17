using Faker;
using System.Runtime.CompilerServices;
using TodoAppApi.Data.Entities;
using TodoAppApi.Data.Entities;
using TodoAppApi.Data;
using TodoAppApi.Helpers;

namespace TodoAppApi.Data;

public static class Seed
{
    private const string _firstName = "admin";
    private const string _lastName = "admin";
    private const string _email = "admin@gmail.com";
    private const string _pw = "admin.123";
    private const string _street = "adminstrasse";
    private const string _houseNumber = "22";
    private const string _city = "adminStadt";
    private const string _zipcode = "22";
    private const string _country = "adminLand";


    public static async Task SeedDatabaseAsync(this ApplicationDbContext dbContext)
    {

        if (dbContext.Users.Any())
            return;
        var salt = PasswordHelper.GenerateSalt();
        var hash = PasswordHelper.HashPassword(_pw, salt);  

        UserEntity admin = new UserEntity
        {
            FirstName = _firstName,
            LastName = _lastName,
            Email = _email,
            Role = Collections.Roles.Admin,
            PasswordSalt = salt,
            PasswordHash = hash,
            Address = new AddressEntity
            {
                Street = _street,
                HouseNumber = _houseNumber,
                City = _city,
                ZipCode = _zipcode,
                Country = _country
            }
        };
        dbContext.Add(admin);
        await dbContext.SaveChangesAsync();
    }
}
