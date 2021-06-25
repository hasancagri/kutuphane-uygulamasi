using KutuphaneService.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace KutuphaneService.Application.Features.Queries.GetAllGenres
{
    public class GetAllGenresQuery
         : IRequest<List<GenreListViewModel>>
    {
    }
}
