using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatTek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] LoginRequest request,
            [FromServices] IAccessManager accessManager)
        {
            var token = await accessManager.ForgeTokenAsync(request.Username, request.Password);

            if (token == null)
                return BadRequest("Houve algum erro ao gerar token");

            return Ok(new { token });
        }

        private string ForgeToken(string username, string password)
        {
            return "a";
        }
    }
}
