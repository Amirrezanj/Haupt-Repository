using System.Security.Cryptography;

namespace TodoAppApi.Helpers
{
    public static class TokenHelper
    {
        public static string GenerateToken(int length = 32)
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[length];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
