using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Limilabs.Client.IMAP;
using Limilabs.Mail;
using Limilabs.Mail.MIME;
using System.IO;
using System.Threading;

namespace VerificaXMLOutlook
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var timer = new Timer(GetAttatchments, null, 0, 5000);
            CreateHostBuilder(args).Build().Run();
        }

        private static void GetAttatchments(object o)
        {
            using (Imap imap = new Imap())
            {

                imap.Connect("server-imap");
                imap.UseBestLogin("email", "senha");

                imap.SelectInbox();
                //imap.Idle();
                List<long> uids = imap.Search(Flag.All);
                foreach (long uid in uids)
                {
                    var eml = imap.GetMessageByUID(uid);
                    IMail email = new MailBuilder().CreateFromEml(eml);
                    SaveAttachments(email, @"C:\Users\documents");
                }
                imap.Close();
            }
        }


        private static void SaveAttachments(IMail email, string folder)
        {
            foreach (MimeData attachment in email.Attachments)
            {
                if (attachment.ContentType.ToString().Equals("text/xml"))
                {
                    if (attachment is IMailContainer)
                    {
                        IMail attachedMessage = ((IMailContainer)attachment).Message;
                        SaveAttachments(attachedMessage, folder);
                    }
                    else
                    {
                        attachment.Save(Path.Combine(folder, attachment.SafeFileName));
                    }
                }
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