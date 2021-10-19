using Microsoft.Extensions.Configuration;
using Serilog;

namespace LogConfigure
{
    public class SerilogConfig
    {
        private IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("serilogsettings.json", optional: false, reloadOnChange: true).Build();
        public void Config()
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

        }
    }
}
