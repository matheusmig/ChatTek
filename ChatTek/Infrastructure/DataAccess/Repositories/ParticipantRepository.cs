using ChatTek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ChatTek.Infrastructure.DataAccess.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ChattekDbContext _dbContext;

        public ParticipantRepository(ChattekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Participant model)
        {
            await _dbContext.Participants.
                AddAsync(model);
        }

        public async Task<Participant> GetAsync(Guid id)
        {
            return await _dbContext.Participants.
                FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Participant> FindByFullNameAsync(string firstName, string LastName)
        {
            return await _dbContext.Participants.
                FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == LastName);
        }
    }
}
