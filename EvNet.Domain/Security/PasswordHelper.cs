using System.Security.Cryptography;
using System.Text;

namespace EvNet.Domain.Security
{
    public static class PasswordHelper
    {
        public static string Hash(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var sb = new StringBuilder();
            foreach (var b in bytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public static bool Verify(string password, string hash)
        {
            return Hash(password) == hash;
        }
    }
}
