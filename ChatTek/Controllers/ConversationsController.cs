using ChatTek.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ChatTek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationsController : ControllerBase
    {
        // GET api/Conversations?Top=1;Skip=2
        // GET api/Conversations
        [HttpGet]
        public IActionResult GetByUser(
            [FromQuery] int? top, 
            [FromQuery] int? skip,
            [FromServices] IRetrieveConversationsByParticipantPaginatedUseCase useCase)
        {
            var result = useCase.Execute(top ?? 5, skip ?? 0);

            return Ok(result);
        }     
    }
}
