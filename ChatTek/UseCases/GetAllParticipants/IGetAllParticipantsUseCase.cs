using ChatTek.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatTek.UseCases.GetAllParticipants
{
    public interface IGetAllParticipantsUseCase
    {
        public Task<IEnumerable<Participant>> ExecuteAsync();
    }
}
