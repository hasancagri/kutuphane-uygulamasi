using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Features.Queries.GetAllUsersBooks
{
    class GetAllUsersBooksQueryHandler
        : IRequestHandler<GetAllUsersBooksQuery, List<Book>>
    {
        private readonly IBookDal _bookDal;

        public GetAllUsersBooksQueryHandler(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public async Task<List<Book>> Handle(GetAllUsersBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookDal.GetList(x => x.UserId != null && !x.IsMailSend,
                includes: new List<Expression<Func<Book, object>>>
                {
                    x=>x.User
                });
        }
    }
}
