using KutuphaneService.Application.Features.Commands.CreateBook;
using KutuphaneService.Application.Features.Commands.RentBook;
using KutuphaneService.Application.Features.Queries.GetAllBooks;
using KutuphaneService.Application.Features.Queries.GetUserBooks;
using KutuphaneService.Application.Features.Queries.SearchFilter;
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
    public class BooksController
        : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getallbooks")]
        [ProducesResponseType(typeof(List<BookListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<BookListViewModel>>> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return Ok(result);
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(List<BookListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<BookListViewModel>>> Search(string filter)
        {
            var result = await _mediator.Send(new SearchFilterQuery { Filter = filter.TrimStart() });
            return Ok(result);
        }


        [HttpGet("getuserbooks")]
        [ProducesResponseType(typeof(List<BookListViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<BookListViewModel>>> GetUserBooks(int userId)
        {
            var result = await _mediator.Send(new GetUserBooksQuery { UserId = userId });
            return Ok(result);
        }

        [HttpPost("createbook")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create([FromBody] CreateBookCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("rentbook")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> RentBook([FromBody] RentBookCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
