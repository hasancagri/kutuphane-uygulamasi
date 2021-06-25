using KutuphaneService.Domain.Entities;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Contracts.Persistance
{
    public interface IBookDal
        : IEntityRepository<Book>
    {
        Task<int> GetUserBooksCount(int userId);
    }
}
