using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Domain.Entities;

namespace KutuphaneService.Persistance.EntityFramework
{
    public class EfUserDal
         : EfEntityRepositoryBase<User>, IUserDal
    {
        public EfUserDal(KutuphaneContext context)
            : base(context)
        {
        }
    }
}
