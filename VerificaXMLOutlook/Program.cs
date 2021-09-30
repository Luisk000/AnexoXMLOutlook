using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Limilabs.Client.IMAP;
using Limilabs.Mail;
using Limilabs.Mail.MIME;
using System.IO;
using System.Timers;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System;

namespace VerificaXMLOutlook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VerificationTimer(true, 5000);
            CreateHostBuilder(args).Build().Run();
        }


        private static void VerificationTimer(bool active, double interval)
        {
            if (active == true)
            {
                Timer time = new Timer();
                time.Interval = interval;
                time.Elapsed += new ElapsedEventHandler(GetAttatchments);
                time.Start();
                GetAttatchments(time, null);
            }
        }


        private static void GetAttatchments(object o, ElapsedEventArgs e)
        {
            using (Imap imap = new Imap())
            {
                imap.Connect("server-IMAP");
                imap.UseBestLogin("email-oulook", "senha");

                imap.SelectInbox();
                //imap.Idle();
                List<long> uids = imap.Search(Flag.Unseen);
                foreach (long uid in uids)
                {
                    var eml = imap.GetMessageByUID(uid);
                    IMail email = new MailBuilder().CreateFromEml(eml);
                    SaveAttachments(email, @"C:\Source");
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
                        VerifyXML(attachment.FileName.ToString());
                    }
                }
            }
        }


        private static void VerifyXML(string xmlName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(xmlName);
            SignedXml signedXml = new SignedXml(xmlDoc);
            XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Signature");
            XmlNodeList certificates = xmlDoc.GetElementsByTagName("X509Certificate");
            X509Certificate2 dcert2 = new X509Certificate2(Convert.FromBase64String(certificates[0].InnerText));
            foreach (XmlElement element in nodeList)
            {
                signedXml.LoadXml(element);
                bool passes = signedXml.CheckSignature(dcert2, true);
                string sourceFile = @"C:\Source\" + xmlName;
                if (passes == true)
                {
                    string destinationFile = @"C:\Users\documents\Aprovado\" + xmlName;
                    File.Move(sourceFile, destinationFile);
                }
                else
                {
                    string destinationFile = @"C:\Users\documents\Reprovado\" + xmlName;
                    File.Move(sourceFile, destinationFile);
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
