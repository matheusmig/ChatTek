using ChatTek.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatTek.UseCases.RetrieveConversationByParticipantPaginated
{
    public interface IRetrieveConversationsByParticipantPaginatedUseCase
    {
        public Task<IEnumerable<Conversation>> ExecuteAsync(
            int top,
            int skip);
    }
}
