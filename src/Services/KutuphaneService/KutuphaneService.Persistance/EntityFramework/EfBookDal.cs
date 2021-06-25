using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneService.Persistance.EntityFramework
{
    public class EfBookDal
        : EfEntityRepositoryBase<Book>, IBookDal
    {
        public EfBookDal(KutuphaneContext context)
            : base(context)
        {
        }

        public async Task<int> GetUserBooksCount(int userId)
        {
            return _context.Books.Count(x => x.UserId == userId);
        }
    }
}
