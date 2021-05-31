using System.Threading.Tasks;
using Domain.Participants;
using Domain.ValueObjects;

namespace Application.UseCases.CreateParticipant
{
    public class CreateParticipantValidationUseCase : ICreateParticipantUseCase
    {
        private readonly ICreateParticipantUseCase _useCase;
        private readonly IParticipantRepository _participantRepository;

        public CreateParticipantValidationUseCase(
            ICreateParticipantUseCase useCase,
            IParticipantRepository participantRepository)
        {
            _useCase = useCase;
            _participantRepository = participantRepository;
        }

        public async Task<Participant> ExecuteAsync(string firstName, string lastName)
        {
            var existing = await _participantRepository.FindByFullNameAsync(new FullName(firstName, lastName));

            if (existing == null)
                return await _useCase.ExecuteAsync(firstName, lastName);

            return null;
        }
    }
}
