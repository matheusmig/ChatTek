using Domain.Conversations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.RetrieveConversationByParticipantPaginated
{
    public interface IRetrieveConversationsByParticipantPaginatedUseCase
    {
        public Task<IEnumerable<Conversation>> ExecuteAsync(
            int top,
            int skip);
    }
}
