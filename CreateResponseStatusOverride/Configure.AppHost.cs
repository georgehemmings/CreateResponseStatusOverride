using Funq;
using ServiceStack;
using CreateResponseStatusOverride.ServiceInterface;

[assembly: HostingStartup(typeof(CreateResponseStatusOverride.AppHost))]

namespace CreateResponseStatusOverride;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public AppHost() : base("CreateResponseStatusOverride", typeof(MyServices).Assembly) {}

    public override void Configure(Container container)
    {
        // Configure ServiceStack only IOC, Config & Plugins
        SetConfig(new HostConfig {
            UseSameSiteCookies = true,
        });
    }

    public override ResponseStatus CreateResponseStatus(Exception ex, object request = null)
    {
        return new ResponseStatus("418", "Overridden CreateResponseStatus");
    }
}
