using ChatTek.Models;
using System;
using System.Threading.Tasks;

namespace ChatTek.Infrastructure.DataAccess.Repositories
{
    public interface IParticipantRepository
    {
        Task AddAsync(Participant model);
        Task<Participant> GetAsync(Guid id);
        Task<Participant> FindByFullNameAsync(string firstName, string LastName);
    }
}
