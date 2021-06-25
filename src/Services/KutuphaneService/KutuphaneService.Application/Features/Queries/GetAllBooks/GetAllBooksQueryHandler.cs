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

namespace KutuphaneService.Application.Features.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler
         : IRequestHandler<GetAllBooksQuery, List<BookListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IBookDal _bookDal;

        public GetAllBooksQueryHandler(IMapper mapper, IBookDal bookDal)
        {
            _mapper = mapper;
            _bookDal = bookDal;
        }

        public async Task<List<BookListViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var list = await _bookDal.GetList(includes: new List<Expression<Func<Book, object>>>
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
