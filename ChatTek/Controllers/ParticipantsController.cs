using ChatTek.UseCases.CreateParticipant;
using ChatTek.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatTek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateParticipantRequest request,
            [FromServices] ICreateParticipantUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(request.FirstName, request.LastName);

            return Ok(new ParticipantViewModel(result));
        }
    }
}
