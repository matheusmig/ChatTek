using Domain.Common;
using Domain.Conversations;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Participants
{
    public class Participant : Entity
    {
        public Participant(Guid id, FullName fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public FullName FullName { get; set; }

        public IEnumerable<Conversation> Conversations { get; set; }
    }
}
