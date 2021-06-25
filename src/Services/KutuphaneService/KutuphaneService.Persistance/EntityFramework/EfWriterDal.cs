using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Domain.Entities;

namespace KutuphaneService.Persistance.EntityFramework
{
    public class EfWriterDal
         : EfEntityRepositoryBase<Writer>, IWriterDal
    {
        public EfWriterDal(KutuphaneContext context)
            : base(context)
        {
        }
    }
}
