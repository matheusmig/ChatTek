using ChatTek.Models;
using System.Threading.Tasks;

namespace ChatTek.UseCases.CreateParticipant
{
    public interface ICreateParticipantUseCase
    {
        public Task<Participant> ExecuteAsync(
            string firstName,
            string lastName);
    }
}
