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
        private readonly IAccountService _accountService;

        public PersonController(IPersonService personService, IAccountService accountService)
        {
            _personService = personService;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePerson([FromBody] PersonRequestDTO personInfo)
        {
            try
            {
                var personCreated = await _personService.CreatePerson(new Person(personInfo.Name, personInfo.Document, personInfo.Password));
                return Ok(personCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{peopleId}/accounts")]
        public async Task<ActionResult> CreateAccount([FromBody] AccountDTORequestCreation accountInfo, [FromRoute] Guid peopleId)
        {
            try
            {
                var accountCreated = await _accountService.CreateAccount(new Account(accountInfo.Branch, accountInfo.Number, peopleId));
                return Ok(accountCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }   
    }
}