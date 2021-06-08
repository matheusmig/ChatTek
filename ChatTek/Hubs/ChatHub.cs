using Application.Common;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatTek.Hubs
{
    public class ChatHub : Hub<IChatHubClient>
    {
        private readonly ILogger _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        private Guid GetCurrentUserId()
        {
            var nameId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
            return new Guid(nameId);
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"New client connected {Context.ConnectionId}");

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            _logger.LogInformation(ex, $"Client disconnected {Context.ConnectionId}");

            await base.OnDisconnectedAsync(ex);
        }

        [HubMethodName("SendMessageToConversation")]
        public async Task SendMessageToConversationAsyncBlaBlaBlaBla(Guid conversationId, string content)
        {
            var senderId = GetCurrentUserId();

            //await _storeMessageTextUseCase
            //    .ExecuteAsync(conversationId, senderId, content);

            //await Clients.All.SendAsync("ReceiveMessage",conversationId, senderId, content); //Not Strongly Type dHub
            await Clients.All.ReceiveMessage(conversationId, senderId, content); //Strongly Type Hub            
        }
    }
}
