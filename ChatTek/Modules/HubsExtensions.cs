using ChatTek.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ChatTek.Modules
{
    public static class HubsExtensions
    {
        public static IServiceCollection AddHubsSignalR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSignalR();

            return serviceCollection;
        }

        public static IApplicationBuilder ConfigureHubsSignalR(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chathub");
            });

            return app;
        }
    }
}
