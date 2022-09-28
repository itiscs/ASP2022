using Microsoft.AspNetCore.SignalR;

namespace ChatFromMetanit.Hubs
{
    public class ChatHub:Hub
    {
        public async Task Login(string userName)
        {
            await Clients.Others.SendAsync("Send", "Entered chat", userName);
        }

        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Send", message, userName);
        }
    }
}
