using ChatTek.Models;
using System;
using System.Collections.Generic;

namespace ChatTek.Infrastructure.DataAccess.Repositories
{
    public interface IConversationsRepository
    {
        public IEnumerable<Conversation> GetAllByUser(Guid UserId, int top, int skip);
    }
}
