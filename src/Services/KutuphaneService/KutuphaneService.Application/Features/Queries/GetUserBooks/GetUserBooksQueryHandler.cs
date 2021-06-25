using AutoMapper;
using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Application.Models;
using KutuphaneService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Features.Queries.GetUserBooks
{
    public class GetUserBooksQueryHandler
         : IRequestHandler<GetUserBooksQuery, List<BookListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IBookDal _bookDal;

        public GetUserBooksQueryHandler(IMapper mapper, IBookDal bookDal)
        {
            _mapper = mapper;
            _bookDal = bookDal;
        }

        public async Task<List<BookListViewModel>> Handle(GetUserBooksQuery request, CancellationToken cancellationToken)
        {
            var list = await _bookDal.GetList(predicate: x => x.UserId == request.UserId,
                includes: new List<Expression<Func<Book, object>>>
            {
                x=>x.Genre,
                x=>x.Publisher,
                x=>x.Writer
            });
            var result = _mapper.Map<List<BookListViewModel>>(list);
            return result;
        }
    }
}
