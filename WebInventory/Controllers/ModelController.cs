﻿using Application.Dtos;
using Application.Exceptions;
using Application.Interfaces;
using Domain.ResultHandler;
using Microsoft.AspNetCore.Mvc;
using ModelError = Domain.Entities.ModelError;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebInventory.Controllers
{
    /// <summary>
    /// Should interact with services from aplication layer
    /// Should use Dtos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : BaseApiController
    {
        private readonly IService _service;
        public ModelController(IService service) {
            _service = service;

        }
        // GET: api/<ModelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ModelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ModelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //GET: api/<ModelController>/GlobalError
        [HttpGet("/GlobalError")]
        public string GetGlobalEror()
        {
            throw new Exception("General");
        }

        //GET: api/<ModelController>/NotFound
        [HttpGet("/NotFound")]
        public string GetNotFoundEror()
        {
            throw new NotFoundException("Model", 0);
        }

        //GET: api/<ModelController>/ResultError
        [HttpGet("/ResultError")]
        public string GetResultError()
        {
            var result = Result<ModelDto>.Failure(ModelError.SomeError);
            if (result.IsFailure)
            {
                return result.Error?.Message;
            }
            return "ok";
        }

        //GET: api/<ModelController>/Success
        [HttpGet("/Success")]
        public IActionResult GetResultSuccess()
        {
            var result = Result<ModelDto>.Success(value: new ModelDto(455));
            return HandleActionResult(result);
        }

        //GET: api/<ModelController>/GlobalError
        [HttpGet("/GlobalError")]
        public string GetGlobalError()
        {
            throw new Exception("General");
        }

        //GET: api/<ModelController>/NotFound
        [HttpGet("/NotFound")]
        public string GetNotFoundError()
        {
            throw new NotFoundException("Model", 0);
        }
    }
}
