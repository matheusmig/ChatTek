using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Conversations
{
    public interface IConversationsRepository
    {
        Task AddAsync(Conversation conversation);
        Task<IEnumerable<Conversation>> GetAllByUserAsync(Guid UserId, int top, int skip);
    }
}
