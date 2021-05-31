using System;

namespace Domain.Messages
{
    public interface IMessagesFactory
    {
        IMessage NewMessage(string content, Guid sendId, Guid conversationId, DateTime sentOn);
    }
}
