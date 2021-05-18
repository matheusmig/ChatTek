using Domain.Conversations;
using Domain.Participants;
using Infrastructure.DataAccess;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases.CreateConversation
{
    public class CreateConversationUseCase : ICreateConversationUseCase
    {
        private readonly ChattekDbContext _dbContext; //TODO: change to UoW

        private readonly IConversationsRepository _conversationRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IIdentityService _identityService;

        public CreateConversationUseCase(
            ChattekDbContext dbContext,
            IConversationsRepository conversationsRepository,
            IParticipantRepository participantRepository,
            IIdentityService identityService)
        {
            _dbContext = dbContext;
            _conversationRepository = conversationsRepository;
            _participantRepository = participantRepository;
            _identityService = identityService;
        }

        public async Task<Conversation> ExecuteAsync(IEnumerable<Guid> participantIds)
        {
            var currentUserId = _identityService.GetCurrentUserId();

            //TODO: Decorate with validator
            if (participantIds?.Any() != true)
                throw new ArgumentException("participantIds is null or empty");
            
            if (participantIds.Count() > 4)
                throw new ArgumentException("Conversation cannot have more than 4 participants");

            if (participantIds.FirstOrDefault(participantId => participantId.Equals(currentUserId)) != default)
                throw new ArgumentException("User cannot add itself to conversation");

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

            var newConversation = new Conversation(
                Guid.NewGuid(),
                foundParticipants);

            await _conversationRepository.AddAsync(newConversation);

            await _dbContext.SaveChangesAsync();

            return newConversation;
        }
    }
}
