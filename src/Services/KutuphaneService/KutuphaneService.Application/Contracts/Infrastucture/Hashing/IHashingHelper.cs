namespace KutuphaneService.Application.Contracts.Infrastucture.Hashing
{
    public interface IHashingHelper
    {
        void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash);
        bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash);
    }
}
