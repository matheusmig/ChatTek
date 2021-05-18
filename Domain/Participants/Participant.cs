using Domain.Common;
using Domain.Conversations;
using System;
using System.Collections.Generic;

namespace Domain.Participants
{
    public class Participant : Entity
    {
        public Participant(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Conversation> Conversations { get; set; }
    }
}
