using KutuphaneService.Application.Features.Commands.CreateUser;
using KutuphaneService.Application.Features.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace KutuphaneService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController
        : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createuser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Login([FromBody] LoginUserQuery query)
        {
            var token = await _mediator.Send(query);
            return Ok(token);
        }
    }
}
