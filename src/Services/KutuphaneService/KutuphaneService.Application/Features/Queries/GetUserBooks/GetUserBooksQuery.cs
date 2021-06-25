using KutuphaneService.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace KutuphaneService.Application.Features.Queries.GetUserBooks
{
    public class GetUserBooksQuery
         : IRequest<List<BookListViewModel>>
    {
        public int UserId { get; set; }
    }
}
