using Application.Features.Entreprise.Commands;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubsidiaryController(IMediator _mediator, ICancellationTokenService cancellationToken) : BaseApiController
    {
        // GET: api/<SubsidiaryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SubsidiaryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubsidiaryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSubsidiaryCommand subsidiaryCommand)
        {
            var result =await _mediator.Send(subsidiaryCommand, cancellationToken.CancellationToken);
            return HandleActionResult(result);
        }

        // PUT api/<SubsidiaryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubsidiaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
