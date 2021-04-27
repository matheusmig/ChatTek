using ChatTek.Infrastructure.DataAccess.Repositories;
using ChatTek.Infrastructure.Identity;
using ChatTek.Models;
using System.Collections.Generic;

namespace ChatTek.UseCases
{
    public class RetrieveConversationsByParticipantPaginated : IRetrieveConversationsByParticipantPaginated
    {
        private readonly IConversationsRepository _conversationRepository;
        private readonly IIdentityService _identityService;

        public RetrieveConversationsByParticipantPaginated(IConversationsRepository conversationsRepository,
            IIdentityService identityService)
        {
            _conversationRepository = conversationsRepository;
            _identityService = identityService;
        }

        public IEnumerable<Conversation> Execute(int top, int skip)
        {
            var currentUserId = _identityService.GetCurrentUserId();

            var result = _conversationRepository.GetAllByUser(currentUserId, top, skip);

            return result;
        }
    }
}
