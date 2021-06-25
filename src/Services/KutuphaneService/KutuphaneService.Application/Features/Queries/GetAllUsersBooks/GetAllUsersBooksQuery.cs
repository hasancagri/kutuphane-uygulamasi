using KutuphaneService.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace KutuphaneService.Application.Features.Queries.GetAllUsersBooks
{
    public class GetAllUsersBooksQuery
        : IRequest<List<Book>>
    {
    }
}
