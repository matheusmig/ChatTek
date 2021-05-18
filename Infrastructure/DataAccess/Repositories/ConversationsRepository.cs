using Domain.Conversations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Repositories
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

        public async Task<IEnumerable<Conversation>> GetAllByUserAsync(Guid UserId, int top, int skip)
        {
            var result = await _dbContext.Conversations
                .Where(x => x.Participants.Any(y => y.Id == UserId))
                .Skip(skip)
                .Take(top)
                .ToListAsync();

             return result;
        }
    }
}
