using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Diagnostics;

namespace VerificaXMLOutlook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                new LogConfig();
                new GetXmlEmail();
                Log.Information("Inicializou o EmailTeste com sucesso!");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                EventLog eLog = new EventLog("Application");
                eLog.Source = "Application";
                eLog.WriteEntry("OCORREU UMA FALHA: " + ex.ToString(), EventLogEntryType.Error);
                Log.Fatal(ex, "Algo deu errado");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
