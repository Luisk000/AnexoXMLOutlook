using Microsoft.Extensions.Configuration;
using System.Timers;

namespace GetXml
{
    public class DataRepository
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("loginsettings.json", optional: false, reloadOnChange: true).Build();

        protected readonly Timer time = new Timer();

        protected string folderPendente = configuration.GetSection("FolderLocations:folderPendente").Value;
        protected string folderAprovado = configuration.GetSection("FolderLocations:folderAprovado").Value;
        protected string folderSemCertificado = configuration.GetSection("FolderLocations:folderSemCertificado").Value;
        protected string folderCertificadoInvalido = configuration.GetSection("FolderLocations:folderCertificadoInvalido").Value;
        protected string serverImap = configuration.GetSection("ImapConnection:serverImap").Value;
        protected string email = configuration.GetSection("ImapConnection:email").Value;
        protected string senha = configuration.GetSection("ImapConnection:senha").Value;
    }
}
