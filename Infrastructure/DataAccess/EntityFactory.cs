using Domain.Conversations;
using Domain.Messages;
using Domain.Participants;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Infrastructure.DataAccess
{
    public class EntityFactory : IParticipantFactory, IConversationsFactory, IMessagesFactory
    {
        public Conversation NewConversation(IEnumerable<Participant> participants)
        {
            return new Conversation(
                Guid.NewGuid(),
                participants);
        }

        public IMessage NewMessage(string content, Guid sendId, Guid conversationId, DateTime sentOn)
        {
            return new MessageText()
            {
                Content = content,
                SenderUserId = sendId,
                TargetConversationId = conversationId,
                SentOn = sentOn
            };
        }

        public Participant NewParticipant(FullName fullName)
        {
            return new Participant(
                Guid.NewGuid(),
                fullName
                );
        }
    }
}
