using Application.UseCases.CreateConversation;
using Application.UseCases.RetrieveConversationByParticipantPaginated;
using ChatTek.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationsController : ControllerBase
    {
        // GET api/Conversations?Top=1;Skip=2
        // GET api/Conversations
        [HttpGet]
        public async Task<IActionResult> GetByUserAsync(
            [FromQuery] int? top,
            [FromQuery] int? skip,
            [FromServices] IRetrieveConversationsByParticipantPaginatedUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(top ?? 5, skip ?? 0);

            return Ok(result.Select(x => new ConversationViewModel(x)));
        }

        // POST api/Conversations
        [HttpPost]
        public async Task<IActionResult> CreateByUser(
            [FromBody] CreateConversationRequest request,
            [FromServices] ICreateConversationUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(request.Participants);

            if (result == null)
                return BadRequest();

            return Ok(new ConversationViewModel(result));
        }
    }
}
