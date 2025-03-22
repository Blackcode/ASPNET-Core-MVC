
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace ASPNET_Core_MVC.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"AQAAAAEAACcQAAAAE{hashed}";
        }

        public static bool VerifyPassword(string hashedPassword, string password)
        {
            // In a real application, this would properly compare the hashed values
            // This is a simplified implementation for demo purposes
            return hashedPassword == HashPassword(password);
        }
    }
}
