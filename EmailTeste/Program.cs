using System;
using System.Diagnostics;
using System.Timers;
using GetXml;
using ImportXml;
using LogConfigure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace VerificaXmlOutlook
{
    public class Program
    {
        private static GetXmlEmail getXml = new GetXmlEmail();
        private static ImportXmlSql import = new ImportXmlSql();
        private static SerilogConfig log = new SerilogConfig();
        private static Timer time = new Timer();

        public static void Main(string[] args)
        {
            try
            {
                log.Config();

            Log.Information("Inicializou o EmailTeste com sucesso!");
            Log.Debug("Configurando o Timer...");

            time.Interval = 5000;
            time.AutoReset = true;
            time.Start();

            time.Elapsed += new ElapsedEventHandler(ProcessarTimer);

        }
            catch (Exception ex)
            {
                EventLog eLog = new EventLog("Application");
        eLog.Source = "Application";
                eLog.WriteEntry("OCORREU UMA FALHA: " + ex.ToString(), EventLogEntryType.Error);
                Log.Fatal(ex, "Algo deu errado");
            }

    CreateHostBuilder(args).Build().Run();
        }

        private static void ProcessarTimer(object sender, ElapsedEventArgs e)
        {
            time.Stop();
            getXml.Process();
            import.Import();
            time.Start();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                });
    }
}
