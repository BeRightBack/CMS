using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Api.Areas.Identity.IdentityHostingStartup))]
namespace Api.Areas.Identity
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