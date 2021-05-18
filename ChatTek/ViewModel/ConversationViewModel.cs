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
            Participants = conversation.Participants.Select(x => new ParticipantViewModel(x)).ToList();
        }

        public Guid Id { get; }
        public IEnumerable<ParticipantViewModel> Participants { get; }
    }
}


