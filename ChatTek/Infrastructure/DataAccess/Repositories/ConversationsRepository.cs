using ChatTek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTek.Infrastructure.DataAccess.Repositories
{
    public class ConversationsRepository : IConversationsRepository
    {
        private readonly ChattekDbContext _dbContext;

        public ConversationsRepository(ChattekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Conversation conversation)
        {
            await _dbContext.Conversations.AddAsync(conversation);              
        }

        public IEnumerable<Conversation> GetAllByUser(Guid UserId, int top, int skip)
        {
            /* var result = _dbContext.Conversations
                 .Where(x => x.Participants.Any(y => y.Id == UserId))
                 .Skip(skip)
                 .Take(top)
                 .AsEnumerable();

             return result;*/

            return null;

        }
    }
}
