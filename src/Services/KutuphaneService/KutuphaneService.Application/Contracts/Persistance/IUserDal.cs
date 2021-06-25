using KutuphaneService.Domain.Entities;

namespace KutuphaneService.Application.Contracts.Persistance
{
    public interface IUserDal
        : IEntityRepository<User>
    {
    }
}
