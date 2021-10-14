using System;
using System.Diagnostics;
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
        public static void Main(string[] args)
        {
            //try
            //{
            new LogConfig();
            new GetXmlEmail();
            new ImportXmlSql();
            Log.Information("Inicializou com sucesso!");
            CreateHostBuilder(args).Build().Run();
            //}
            //catch (Exception ex)
            //{
            //    EventLog eLog = new EventLog("Application");
            //    eLog.Source = "Application";
            //    eLog.WriteEntry("OCORREU UMA FALHA: " + ex.ToString(), EventLogEntryType.Error);
            //    Log.Fatal(ex, "Algo deu errado");
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                });
    }
}
