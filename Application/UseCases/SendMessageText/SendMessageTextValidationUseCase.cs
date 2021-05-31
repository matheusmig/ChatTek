using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Domain.Conversations;
using Domain.Messages;

namespace Application.UseCases.SendMessageText
{
    public class SendMessageTextValidationUseCase : ISendMessageTextUseCase
    {
        private readonly ISendMessageTextUseCase _useCase;
        private readonly IConversationsRepository _conversationsRepository;
        private readonly IIdentityService _identityService;

        public SendMessageTextValidationUseCase(
            ISendMessageTextUseCase useCase,
            IConversationsRepository conversationsRepository,
            IIdentityService identityService)
        {
            _useCase = useCase;
            _conversationsRepository = conversationsRepository;
            _identityService = identityService;
        }

        public async Task<IMessage> ExecuteAsync(Guid conversationId, string content)
        {
            var conversation = await _conversationsRepository.GetAsync(conversationId, "Participants");
            if (conversation is not Conversation)
                throw new ArgumentException("Conversation not found");

            var currentUserId = _identityService.GetCurrentUserId();
            if (!conversation.Participants.Any(x => x.Id == currentUserId))
                throw new ArgumentException("Sender isn't a participating from selected conversation");

            if (string.IsNullOrEmpty(content))
                throw new ArgumentException("Content cannot be null");

            return await _useCase.ExecuteAsync(conversationId, content);
        }
    }
}
