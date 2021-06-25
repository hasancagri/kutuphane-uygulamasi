using KutuphaneService.Domain.Entities;

namespace KutuphaneService.Application.Contracts.Persistance
{
    public interface IPublisherDal
        : IEntityRepository<Publisher>
    {
    }
}
