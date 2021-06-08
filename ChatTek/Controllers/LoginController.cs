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
        public async Task<ActionResult> Authenticate(
            [FromBody] LoginRequest model,
            [FromServices] IAccessManager accessManager)
        {
            var token = await accessManager.ForgeTokenAsync(model.Username, model.Password);

            if (token is null)
                return BadRequest("User or password invalid");

            return Ok( new { token });
        }

        [HttpGet("Anonymous")]
        [AllowAnonymous]
        public ActionResult TestAnonymous()
        {
            return Ok( "You're acessing as anonymous, authorization not required");
        }

        [HttpGet("Authorized")]
        [Authorize]
        public ActionResult TestAuthorize()
        {
            return Ok("You are a logged in user");
        }

        [HttpGet("Role")]
        [Authorize(Roles = "Manager")]
        public ActionResult TestRoleBased()
        {
            return Ok("You have the role Managers");
        }

        [HttpGet("Claim")]
        [Authorize(Policy = "MarketingOnly")]
        public ActionResult TestClaimBased()
        {
            return Ok("You have the claim Department with Marketing value");
        }

        [HttpGet("Policy")]
        [Authorize(Policy = "ManagerFromMarketing")]
        public ActionResult TestPoliciesBased()
        {
            return Ok("You have role Manager and claim Department with Marketing value");
        }
    }
}
