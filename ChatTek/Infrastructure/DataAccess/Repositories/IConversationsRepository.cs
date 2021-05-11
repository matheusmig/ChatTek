using ChatTek.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatTek.Infrastructure.DataAccess.Repositories
{
    public interface IConversationsRepository
    {
        Task AddAsync(Conversation conversation);
        IEnumerable<Conversation> GetAllByUser(Guid UserId, int top, int skip);
    }
}
