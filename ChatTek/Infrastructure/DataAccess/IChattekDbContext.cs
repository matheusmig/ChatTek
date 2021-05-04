using ChatTek.Models;
using System.Collections.ObjectModel;

namespace ChatTek.Infrastructure.DataAccess
{
    public interface IChattekDbContext
    {
        public Collection<Participant> Participants { get; set; }
        public Collection<Conversation> Conversations { get; set; }
        public Collection<MessageText> Messages { get; set; }
    }
}
