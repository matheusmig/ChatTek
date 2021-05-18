using Domain.Participants;
using System.Threading.Tasks;

namespace Application.UseCases.CreateParticipant
{
    public interface ICreateParticipantUseCase
    {
        public Task<Participant> ExecuteAsync(
            string firstName,
            string lastName);
    }
}
