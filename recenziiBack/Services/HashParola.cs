using System.Security.Cryptography;
using System.Text;

namespace recenziiBack.Services
{
    public static class HashParola
    {
        public static string HashPass(string parola)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(parola));
                return BitConverter.ToString(hashedBytes).Replace("-", " ").ToLower();
            }
        }
    }
}
