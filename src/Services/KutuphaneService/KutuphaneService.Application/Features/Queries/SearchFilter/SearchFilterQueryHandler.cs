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

namespace KutuphaneService.Application.Features.Queries.SearchFilter
{
    public class SearchFilterQueryHandler
         : IRequestHandler<SearchFilterQuery, List<BookListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IBookDal _bookDal;

        public SearchFilterQueryHandler(IMapper mapper, IBookDal bookDal)
        {
            _mapper = mapper;
            _bookDal = bookDal;
        }

        public async Task<List<BookListViewModel>> Handle(SearchFilterQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Book, bool>> predicate = x => x.Genre.GenreName.ToLower().Contains(request.Filter.ToLower()) || x.Publisher.PublisherName.ToLower().Contains(request.Filter.ToLower()) || x.Writer.WriterName.ToLower().Contains(request.Filter.ToLower())
            || x.BookName.ToLower().Contains(request.Filter.ToLower());
            var list = await _bookDal.GetList(
                predicate: predicate,
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
