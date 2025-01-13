using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
namespace TodoAppApi.Helpers
{
    public abstract class PasswordHelper
    {
        public static string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);



        }
        public static string HashPassword(string password , string salt)
        {
            byte[]saltBytes = Convert.FromBase64String(salt);
            byte[] pwBytes = KeyDerivation.Pbkdf2(password,saltBytes,KeyDerivationPrf.HMACSHA256,10000,32);
            return Convert.ToBase64String(pwBytes);
        }
        public static bool VerifyPassword(string password , string passwordHash , string salt)
        {
            return HashPassword(password,salt)==passwordHash;
        }
    }
}
