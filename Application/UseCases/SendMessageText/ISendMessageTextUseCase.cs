using Domain.Messages;
using System;
using System.Threading.Tasks;

namespace Application.UseCases.SendMessageText
{
    public interface ISendMessageTextUseCase
    {
        public Task<IMessage> ExecuteAsync(Guid conversationId, string content);
    }
}
