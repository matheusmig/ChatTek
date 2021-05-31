using Domain.Participants;
using System;
using System.Collections.Generic;

namespace Domain.Conversations
{
    public interface IConversationsFactory
    {
        Conversation NewConversation(IEnumerable<Participant> participants);
    }
}
