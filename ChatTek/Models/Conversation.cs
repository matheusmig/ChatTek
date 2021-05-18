using ChatTek.Models.Common;
using System;
using System.Collections.Generic;

namespace ChatTek.Models
{
    public class Conversation : Entity
    {
        public Conversation() { }

        public Conversation(Guid id, IEnumerable<Participant> participants)
        {
            Id = id;
            Participants = participants;
        }

        public IEnumerable<Participant> Participants { get; set; }
    }
}
