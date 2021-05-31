using System;
using System.Threading.Tasks;
using Domain.Messages;
using Domain.Participants;

namespace Application.UseCases.SendMessageText
{
    public class SendMessageTextUseCase : ISendMessageTextUseCase
    {
        private readonly IParticipantRepository _participantRepository;
        
        public SendMessageTextUseCase(
            IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public Task<IMessage> ExecuteAsync(Guid conversationId, string content)
        {
            throw new NotImplementedException();
        }
    }
}
