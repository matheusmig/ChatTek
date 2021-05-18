using ChatTek.Infrastructure.DataAccess;
using ChatTek.Infrastructure.DataAccess.Repositories;
using ChatTek.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatTek.UseCases.GetAllParticipants
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
