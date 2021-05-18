using Infrastructure.DataAccess;
using System;
using System.Threading.Tasks;
using Domain.Participants;

namespace Application.UseCases.CreateParticipant
{
    public class CreateParticipantUseCase : ICreateParticipantUseCase
    {
        private readonly ChattekDbContext _dbContext; //TODO: change to UoW
        private readonly IParticipantRepository _participantRepository;
        

        public CreateParticipantUseCase(
            ChattekDbContext dbContext,
            IParticipantRepository participantRepository)
        {
            _dbContext = dbContext;
            _participantRepository = participantRepository;
        }

        public async Task<Participant> ExecuteAsync(string firstName, string lastName)
        {
            var newParticipant = new Participant(
                Guid.NewGuid(),
                firstName,
                lastName);

            await _participantRepository.AddAsync(newParticipant);

            await _dbContext.SaveChangesAsync();

            return newParticipant;
        }
    }
}
