using Domain.Conversations;
using Domain.Messages;
using Domain.Participants;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Infrastructure.DataAccess
{
    public class ChattekDbContextFake
    {
        public ChattekDbContextFake()
        {
            var participant1 = new Participant(
                new Guid("378522FF-033B-4095-8CFD-AF292834FDD1"),
                "Vanderlei",
                "Luxemburgo"
            );

            var participant2 = new Participant(
                new Guid("3B985986-2BC4-4276-ABD8-5EEA22F50236"),
                "Guto",
                "Ferreira"
            );

            var participant3 = new Participant(
                new Guid("6889519B-C366-4F49-822D-8237D3506A32"),
                "Odair",
                "Hellman"
            );

            Participants = new Collection<Participant>();
            Participants.Add(participant1);
            Participants.Add(participant2);
            Participants.Add(participant3);


            var conversation1 = new Conversation(
                new Guid("9BF83AF2-769F-4350-8EC5-936474F1C2A4"),
                new List<Participant>() { participant1, participant2, participant3 }
                );

            var conversation2 = new Conversation(
                new Guid("0FFE2F28-649E-4960-83CF-8C1A0EFF9861"),
                new List<Participant>() { participant2, participant3 }
                );

            Conversations = new Collection<Conversation>();
            Conversations.Add(conversation1);
            Conversations.Add(conversation2);
        }

        public Collection<Participant> Participants { get; set; }
        public Collection<Conversation> Conversations { get; set; }
        public Collection<MessageText> Messages { get; set; }
    }
}
