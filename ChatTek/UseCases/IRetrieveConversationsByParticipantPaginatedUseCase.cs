using ChatTek.Models;
using System.Collections.Generic;

namespace ChatTek.UseCases
{
    public interface IRetrieveConversationsByParticipantPaginatedUseCase
    {
        public IEnumerable<Conversation> Execute (
            int top,
            int skip);
    }
}
