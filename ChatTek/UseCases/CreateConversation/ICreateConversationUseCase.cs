using ChatTek.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatTek.UseCases.CreateConversation
{
    public interface ICreateConversationUseCase
    {
        public Task<Conversation> ExecuteAsync(
            IEnumerable<Guid> participantIds);
    }
}
