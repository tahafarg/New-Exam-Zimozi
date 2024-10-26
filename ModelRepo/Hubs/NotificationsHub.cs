using Microsoft.AspNetCore.SignalR;

namespace Business.Hubs;

public class NotificationsHub : Hub
{
    public async Task SendNotification(string message)
    {
        await Clients.All.SendAsync("ReceiveNotification", message);
    }
}
