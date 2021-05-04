using ChatTek.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatTek.Infrastructure.DataAccess.Repositories
{
    public class ConversationsRepository : IConversationsRepository
    {
        private readonly IChattekDbContext _dbContext;

        public ConversationsRepository(IChattekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Conversation> GetAllByUser(Guid UserId, int top, int skip)
        {
            var result = _dbContext.Conversations
                .Where(x => x.Participants.Any(y => y.Id == UserId))
                .Skip(skip)
                .Take(top)
                .AsEnumerable();

            return result;

        }
    }
}
