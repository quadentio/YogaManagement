using System.Security.Cryptography;
using System.Text;

namespace Utilities.Helper
{
    public static class EncryptionHelper
    {
        /// <summary>
        /// Create salt
        /// </summary>
        /// <returns>Salt</returns>
        public static string CreateSalt()
        {
            try
            {
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                return Convert.ToBase64String(salt);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Hash password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns>HashPassword</returns>
        public static string HashPassword(string password, string salt)
        {
            try
            {
                var combinedPassword = String.Concat(password, salt);
                var sha256 = new SHA256Managed();
                var bytes = Encoding.UTF8.GetBytes(combinedPassword);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}
