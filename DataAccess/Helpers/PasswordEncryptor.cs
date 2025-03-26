using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Helpers
{
    public static class PasswordEncryptor
    {
        public static string GeneratePassword()
        {
            List<string> existentPasswords = UserManagerDB.GetAllPasswords();
            Random random = new Random();
            string newPassword;

            do
            {
                newPassword = random.Next(10000, 99999).ToString();
            } while (existentPasswords.Contains(newPassword));

            return newPassword;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
