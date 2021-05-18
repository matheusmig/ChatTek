using Domain.Common;
using Domain.Participants;
using System;
using System.Collections.Generic;

namespace Domain.Conversations
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
