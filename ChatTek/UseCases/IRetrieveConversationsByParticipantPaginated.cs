using ChatTek.Models;
using System.Collections.Generic;

namespace ChatTek.UseCases
{
    public interface IRetrieveConversationsByParticipantPaginated
    {
        public IEnumerable<Conversation> Execute (
            int top,
            int skip);
    }
}
