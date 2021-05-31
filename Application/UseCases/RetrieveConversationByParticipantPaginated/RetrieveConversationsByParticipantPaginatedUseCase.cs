using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common;
using Domain.Conversations;

namespace Application.UseCases.RetrieveConversationByParticipantPaginated
{
    public class RetrieveConversationsByParticipantPaginatedUseCase : IRetrieveConversationsByParticipantPaginatedUseCase
    {
        private readonly IConversationsRepository _conversationRepository;
        private readonly IIdentityService _identityService;

        public RetrieveConversationsByParticipantPaginatedUseCase(IConversationsRepository conversationsRepository,
            IIdentityService identityService)
        {
            _conversationRepository = conversationsRepository;
            _identityService = identityService;
        }

        public async Task<IEnumerable<Conversation>> ExecuteAsync(int top, int skip)
        {
            var currentUserId = _identityService.GetCurrentUserId();

            var result = await _conversationRepository.GetAllByUserAsync(currentUserId, top, skip);

            return result;
        }
    }
}
