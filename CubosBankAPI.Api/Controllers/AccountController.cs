using CubosBankAPI.Application.DTOs.RequestDTO;
using CubosBankAPI.Application.Services.Interfaces;
using CubosBankAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CubosBankAPI.Api.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly ICardService _cardService;

        public AccountController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("{accountId}/cards)")]
        public async Task<ActionResult> CreateCard([FromBody] CardDTORequestCreation accountInfo, [FromRoute] Guid accountId)
        {
            try
            {
                var accountCreated = await _cardService.CreateCard(new Card(accountInfo.CardType, accountInfo.Number, accountInfo.CVV, accountId));
                return Ok(accountCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
  
    }
}
