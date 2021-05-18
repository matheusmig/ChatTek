using Application.UseCases.CreateParticipant;
using Application.UseCases.GetAllParticipants;
using ChatTek.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatTek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllParticipants(
            [FromServices] IGetAllParticipantsUseCase useCase)
        {
            var result = await useCase.ExecuteAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateParticipantRequest request,
            [FromServices] ICreateParticipantUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(
                request.FirstName,
                request.LastName);

            return Ok(new ParticipantViewModel(result));
        }
    }
}
