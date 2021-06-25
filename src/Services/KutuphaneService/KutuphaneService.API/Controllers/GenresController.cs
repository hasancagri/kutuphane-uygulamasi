using KutuphaneService.Application.Features.Queries.GetAllGenres;
using KutuphaneService.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace KutuphaneService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController
        : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getallgenres")]
        [ProducesResponseType(typeof(List<GenreListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<GenreListViewModel>>> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllGenresQuery());
            return Ok(result);
        }
    }
}
