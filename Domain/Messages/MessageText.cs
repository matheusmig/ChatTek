using Domain.Common;
using System;

namespace Domain.Messages
{
    public class MessageText : Entity, IMessage
    {
        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public Guid SenderUserId { get; set; }
        public Guid TargetConversationId { get; set; }
        public byte[] Data { get; set; }
    }
}
