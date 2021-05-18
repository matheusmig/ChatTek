using ChatTek.Infrastructure.DataAccess.Repositories;
using ChatTek.Infrastructure.Identity;
using ChatTek.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatTek.UseCases.RetrieveConversationByParticipantPaginated
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
