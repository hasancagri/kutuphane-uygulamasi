using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Domain.Entities;

namespace KutuphaneService.Persistance.EntityFramework
{
    public class EfGenreDal
         : EfEntityRepositoryBase<Genre>, IGenreDal
    {
        public EfGenreDal(KutuphaneContext context)
            : base(context)
        {
        }
    }
}
