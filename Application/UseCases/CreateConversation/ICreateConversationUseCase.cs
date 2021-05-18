using Domain.Conversations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases.CreateConversation
{
    public interface ICreateConversationUseCase
    {
        public Task<Conversation> ExecuteAsync(
            IEnumerable<Guid> participantIds);
    }
}
