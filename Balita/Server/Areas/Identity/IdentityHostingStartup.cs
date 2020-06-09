using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Balita.Server.Areas.Identity.IdentityHostingStartup))]
namespace Balita.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}