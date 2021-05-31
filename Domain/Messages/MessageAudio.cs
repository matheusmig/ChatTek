using Domain.Common;
using System;

namespace Domain.Messages
{
    public class MessageAudio : Entity, IMessage
    {
        public byte[] Data { get; set; }

        public DateTime SentOn { get; set; }

        public Guid SenderUserId { get; set; }
        public Guid TargetConversationId { get; set; }
    }
}
