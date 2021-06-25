using KutuphaneService.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace KutuphaneService.Application.Features.Queries.GetAllBooks
{
    public class GetAllBooksQuery
        : IRequest<List<BookListViewModel>>
    {
    }
}
