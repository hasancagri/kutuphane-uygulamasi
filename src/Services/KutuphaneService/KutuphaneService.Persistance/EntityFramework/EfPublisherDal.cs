using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Domain.Entities;

namespace KutuphaneService.Persistance.EntityFramework
{
    public class EfPublisherDal
          : EfEntityRepositoryBase<Publisher>, IPublisherDal
    {
        public EfPublisherDal(KutuphaneContext context)
            : base(context)
        {
        }
    }
}
