using Application.Common;
using Domain.Conversations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases.CreateConversation
{
    public class CreateConversationValidationUseCase : ICreateConversationUseCase
    {
        private readonly ICreateConversationUseCase _useCase;

        private readonly IIdentityService _identityService;

        public CreateConversationValidationUseCase(ICreateConversationUseCase useCase,
            IIdentityService identityService)
        {
            _useCase = useCase;
            _identityService = identityService;
        }

        public async Task<Conversation> ExecuteAsync(IEnumerable<Guid> participantIds)
        {
            var currentUserId = _identityService.GetCurrentUserId();

            if (participantIds?.Any() != true)
                throw new ArgumentException("participantIds is null or empty");

            if (participantIds.Count() > 4)
                throw new ArgumentException("Conversation cannot have more than 4 participants");

            if (participantIds.FirstOrDefault(participantId => participantId.Equals(currentUserId)) != default)
                throw new ArgumentException("User cannot add itself to conversation");

            var result = await _useCase.ExecuteAsync(participantIds);

            //;...

            return result;
        }
    }
}
