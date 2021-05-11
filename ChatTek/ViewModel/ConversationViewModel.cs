using ChatTek.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatTek.ViewModel
{
    public class ConversationViewModel
    {

        public ConversationViewModel(Conversation conversation)
        {
            Id = conversation.Id;
            /*ParticipantsIdName = conversation.Participants.Select(x => (x.Id, $"{x.FirstName} {x.LastName}"));*/
        }

        public Guid Id { get; }
        public IEnumerable<(Guid, string)> ParticipantsIdName { get; }
    }
}


