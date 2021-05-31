using Domain.ValueObjects;

namespace Domain.Participants
{
    public interface IParticipantFactory
    {
        Participant NewParticipant(FullName fullName);
    }
}
