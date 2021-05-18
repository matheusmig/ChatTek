using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Participants;

namespace Application.UseCases.GetAllParticipants
{
    public class GetAllParticipantsUseCase : IGetAllParticipantsUseCase
    {
        private readonly IParticipantRepository _participantRepository;
        
        public GetAllParticipantsUseCase(
            IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<IEnumerable<Participant>> ExecuteAsync()
        {
            return await _participantRepository.GetAllAsync();
        }
    }
}
