using KutuphaneService.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace KutuphaneService.Application.Features.Queries.SearchFilter
{
    public class SearchFilterQuery
          : IRequest<List<BookListViewModel>>
    {
        public string Filter { get; set; }
    }
}
