using Microsoft.Extensions.Configuration;
using Serilog;

namespace LogConfigure
{
    public class LogConfig
    {
        private IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("serilogsettings.json", optional: false, reloadOnChange: true).Build();
        public LogConfig()
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

        }
    }

}
