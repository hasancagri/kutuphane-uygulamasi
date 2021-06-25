using AutoMapper;
using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Features.Queries.GetAllGenres
{
    public class GetAllGenresQueryHandler
          : IRequestHandler<GetAllGenresQuery, List<GenreListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGenreDal _genreDal;

        public GetAllGenresQueryHandler(IMapper mapper, IGenreDal genreDal)
        {
            _mapper = mapper;
            _genreDal = genreDal;
        }

        public async Task<List<GenreListViewModel>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var list = await _genreDal.GetList();
            var result = _mapper.Map<List<GenreListViewModel>>(list);
            return result;
        }
    }
}
