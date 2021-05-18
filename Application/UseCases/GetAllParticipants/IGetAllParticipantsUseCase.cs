using Domain.Participants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.GetAllParticipants
{
    public interface IGetAllParticipantsUseCase
    {
        public Task<IEnumerable<Participant>> ExecuteAsync();
    }
}
