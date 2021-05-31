using System.Threading.Tasks;
using Domain.Participants;
using Domain.ValueObjects;
using Application.Common;

namespace Application.UseCases.CreateParticipant
{
    public class CreateParticipantUseCase : ICreateParticipantUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParticipantRepository _participantRepository;
        private readonly IParticipantFactory _factory;

        public CreateParticipantUseCase(
            IUnitOfWork unitOfWork,
            IParticipantRepository participantRepository,
            IParticipantFactory factory)
        {
            _unitOfWork = unitOfWork;
            _participantRepository = participantRepository;
            _factory = factory;
        }

        public async Task<Participant> ExecuteAsync(string firstName, string lastName)
        {
            var newParticipant = _factory.NewParticipant(new FullName(firstName, lastName));

            await _participantRepository.AddAsync(newParticipant);

            await _unitOfWork.SaveAsync();

            return newParticipant;
        }
    }
}
