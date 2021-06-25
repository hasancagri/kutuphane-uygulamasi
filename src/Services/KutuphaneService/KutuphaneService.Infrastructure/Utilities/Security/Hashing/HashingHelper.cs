using KutuphaneService.Application.Contracts.Infrastucture.Hashing;
using System.Security.Cryptography;
using System.Text;

namespace KutuphaneService.Infrastructure.Utilities.Security.Hashing
{
    public class HashingHelper
         : IHashingHelper
    {
        public void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            };
        }

        public bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (passwordHash[i] != computedHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
