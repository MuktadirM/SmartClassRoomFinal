
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Presentation.WPF.HostBuilders
{
    /// <summary>
    /// Class AddConfigurationHostBuilderExtensions
    /// Write your documentation here
    /// </summary>
    public static class AddConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("appsettings.json");
                c.AddEnvironmentVariables();
            });

            return host;
        }
    }
}