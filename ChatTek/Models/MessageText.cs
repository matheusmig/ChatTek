using ChatTek.Models.Common;
using System;

namespace ChatTek.Models
{
    public class MessageText : Entity
    {
        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public Guid SenderUserId { get; set; }
        public Guid TargetConversationId { get; set; }
    }
}
