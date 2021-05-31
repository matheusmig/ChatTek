using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Participants
{
    public interface IParticipantRepository
    {
        Task AddAsync(Participant model);
        Task<Participant> GetAsync(Guid id);
        Task<Participant> FindByFullNameAsync(FullName fullName);
        Task<IEnumerable<Participant>> GetAllAsync();
    }
}
