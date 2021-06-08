using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Domain.Conversations;
using Domain.Messages;

namespace Application.UseCases.StoreMessageText
{
    public class StoreMessageTextValidationUseCase : IStoreMessageTextUseCase
    {
        private readonly IStoreMessageTextUseCase _useCase;
        private readonly IConversationsRepository _conversationsRepository;

        public StoreMessageTextValidationUseCase(
            IStoreMessageTextUseCase useCase,
            IConversationsRepository conversationsRepository,
            IIdentityService identityService)
        {
            _useCase = useCase;
            _conversationsRepository = conversationsRepository;
        }

        public async Task<IMessage> ExecuteAsync(Guid conversationId, Guid senderId, string content)
        {
            var conversation = await _conversationsRepository.GetAsync(conversationId, "Participants");
            if (conversation is not Conversation)
                throw new ArgumentException("Conversation not found");

            if (!conversation.Participants.Any(x => x.Id == senderId))
                throw new ArgumentException("Sender isn't a participating from selected conversation");

            if (string.IsNullOrEmpty(content))
                throw new ArgumentException("Content cannot be null");

            return await _useCase.ExecuteAsync(conversationId, senderId, content);
        }
    }
}
