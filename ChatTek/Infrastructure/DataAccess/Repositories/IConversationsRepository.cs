using ChatTek.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatTek.Infrastructure.DataAccess.Repositories
{
    public interface IConversationsRepository
    {
        Task AddAsync(Conversation conversation);
        Task<IEnumerable<Conversation>> GetAllByUserAsync(Guid UserId, int top, int skip);
    }
}
