using Microsoft.AspNetCore;
using SelfHelp.API.Extensions;

namespace SelfHelp.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddConfigAndEnvironmentVariables(hostingContext.HostingEnvironment);
                })
                .UseStartup<Startup>();
    }
}