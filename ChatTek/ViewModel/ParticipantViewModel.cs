using ChatTek.Models;
using System;

namespace ChatTek.ViewModel
{
    public class ParticipantViewModel
    {

        public ParticipantViewModel(Participant participant)
        {
            Id = participant.Id;
            FirstName = participant.FirstName;
            LastName = participant.LastName;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}


