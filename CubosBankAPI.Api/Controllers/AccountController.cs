using Microsoft.AspNetCore.Mvc;

namespace CubosBankAPI.Api.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAccounts()
        {
            return Ok(
                "Aqui você deve retornar uma lista de contas."
                );
        }
  
    }
}
