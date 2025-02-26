using Application.Features.Identity.Commands;
using Application.Features.Identity.Queries;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator _mediator, ICancellationTokenService cancellationToken) : BaseApiController
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand userCommand)
        {
            var result = await _mediator.Send(userCommand, cancellationToken.CancellationToken);
            return HandleActionResult(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //GET: api/<UserController>/Authenticate
        [HttpGet("/Authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] AuthenticateQuery authenticateQuery)
        {
            var result = await _mediator.Send(authenticateQuery, cancellationToken.CancellationToken);
            return HandleActionResult(result);
        }
    }
}
