using CubosBankAPI.Application.DTOs;
using CubosBankAPI.Application.DTOs.RequestDTO;
using CubosBankAPI.Application.DTOs.ResponseDTO;
using CubosBankAPI.Application.Services.Interfaces;
using CubosBankAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CubosBankAPI.Api.Controllers
{
    [ApiController]
    [Route("people")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePerson([FromBody] PersonRequestDTO person)
        {
            try
            {
                Person persona = new(person.Name, person.Document, person.Password);
                var personCreated = await _personService.CreatePerson(persona);
                return Ok(personCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}