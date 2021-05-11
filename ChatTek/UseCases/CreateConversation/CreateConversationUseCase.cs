using ChatTek.Infrastructure.DataAccess;
using ChatTek.Infrastructure.DataAccess.Repositories;
using ChatTek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTek.UseCases.CreateConversation
{
    public class CreateConversationUseCase : ICreateConversationUseCase
    {
        private readonly ChattekDbContext _dbContext; //TODO: change to UoW

        private readonly IConversationsRepository _conversationRepository;
        private readonly IParticipantRepository _participantRepository;

        public CreateConversationUseCase(
            ChattekDbContext dbContext,
            IConversationsRepository conversationsRepository,
            IParticipantRepository participantRepository)
        {
            _dbContext = dbContext;
            _conversationRepository = conversationsRepository;
            _participantRepository = participantRepository;
        }

        public async Task<Conversation> ExecuteAsync(IEnumerable<Guid> participantIds)
        {
            if (participantIds?.Any() != true)
                throw new ArgumentException("participantIds is null or empty");

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
