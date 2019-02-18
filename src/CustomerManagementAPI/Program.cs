using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Serilog;
using System.IO;

namespace Pitstop.CustomerManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseApplicationInsights()
                .UseKestrel()
                .UseSerilog()
                .UseHealthChecks("/hc")
                .UseUrls(urls: "http://*:5100")
                .UseStartup<Startup>();

    }
}
