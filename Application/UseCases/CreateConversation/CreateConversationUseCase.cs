using Application.Common;
using Domain.Conversations;
using Domain.Participants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.CreateConversation
{
    public class CreateConversationUseCase : ICreateConversationUseCase
    {
        private readonly IUnitOfWork _unitOfWork; 

        private readonly IConversationsRepository _conversationRepository;
        private readonly IParticipantRepository _participantRepository;


        private readonly IConversationsFactory _conversationsFactory;

        public CreateConversationUseCase(
            IUnitOfWork unitOfWork,
            IConversationsRepository conversationsRepository,
            IParticipantRepository participantRepository,
            IConversationsFactory conversationsFactory)
        {
            _unitOfWork = unitOfWork;
            _conversationRepository = conversationsRepository;
            _participantRepository = participantRepository;
            _conversationsFactory = conversationsFactory;
        }

        public async Task<Conversation> ExecuteAsync(IEnumerable<Guid> participantIds)
        {
            var foundParticipants = new List<Participant>();

            foreach(var id in participantIds)
            {
                var participant = await _participantRepository.GetAsync(id);
                if (participant is null)
                {
                    throw new Exception($"Participant {participant} not found!");
                }

                foundParticipants.Add(participant);
            }

            var newConversation = _conversationsFactory.NewConversation(foundParticipants);

            await _conversationRepository.AddAsync(newConversation);

            await _unitOfWork.SaveAsync();

            return newConversation;
        }
    }
}
