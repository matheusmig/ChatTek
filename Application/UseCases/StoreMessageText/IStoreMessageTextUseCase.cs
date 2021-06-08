using Domain.Messages;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.StoreMessageText
{
    public interface IStoreMessageTextUseCase
    {
        public Task<IMessage> ExecuteAsync(Guid conversationId, Guid senderId, string content);
    }
}
