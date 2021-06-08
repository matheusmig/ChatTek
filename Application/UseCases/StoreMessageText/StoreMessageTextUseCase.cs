using System;
using System.Threading.Tasks;
using Domain.Messages;
using Domain.Participants;

namespace Application.UseCases.StoreMessageText
{
    public class StoreMessageTextUseCase : IStoreMessageTextUseCase
    {
        private readonly IParticipantRepository _participantRepository;
        
        public StoreMessageTextUseCase(
            IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public Task<IMessage> ExecuteAsync(Guid conversationId, Guid senderId, string content)
        {
            throw new NotImplementedException();
        }
    }
}
