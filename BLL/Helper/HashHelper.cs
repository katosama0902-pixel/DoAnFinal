using System.Security.Cryptography;
using System.Text;

// Namespace đã sửa thành DoAnFinal.Helper
namespace DoAnFinal
{
    public static class HashHelper
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";

            using (MD5 md5 = MD5.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes(password);
                byte[] hash = md5.ComputeHash(input);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}