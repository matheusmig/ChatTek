using Domain.Participants;
using System;

namespace ChatTek.ViewModel
{
    public class ParticipantViewModel
    {
        public ParticipantViewModel(Participant participant)
        {
            Id = participant.Id;
            FirstName = participant.FullName.FirstName;
            LastName = participant.FullName.LastName;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}


