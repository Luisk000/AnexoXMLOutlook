using Microsoft.Extensions.Configuration;
using Serilog;

namespace VerificaXMLOutlook
{
    public class LogConfig
    {
        private IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
        public LogConfig()
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

        }
    }
}
