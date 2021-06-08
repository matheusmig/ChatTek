using System;
using System.Threading.Tasks;

namespace Application.Common
{
    public interface IChatHubClient
    {
        Task ReceiveMessage(Guid conversationId, Guid senderId, string content);
    }
}
