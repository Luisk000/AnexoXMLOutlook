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
        static Timer time = new Timer();
        static string folderPendente = @"C:\Users\ \Desktop\TesteEmail\Pendente";
        static string folderAprovado = @"C:\Users\ \Desktop\TesteEmail\Aprovado";
        static string folderSemCertificado = @"C:\Users\\ Desktop\TesteEmail\SemCertificado";
        static string folderCertificadoInvalido = @"C:\Users\ \Desktop\TesteEmail\CertificadoInvalido";


        public static void Main(string[] args)
        {
            ValidarPastas();



            VerificationTimer(true, 5000);

            CreateHostBuilder(args).Build().Run();
        }

        private static void ValidarPastas()
        {

            if (!Directory.Exists(folderPendente))
                Directory.CreateDirectory(folderPendente);

            if (!Directory.Exists(folderAprovado))
                Directory.CreateDirectory(folderAprovado);

            if (!Directory.Exists(folderSemCertificado))
                Directory.CreateDirectory(folderSemCertificado);

            if (!Directory.Exists(folderCertificadoInvalido))
                Directory.CreateDirectory(folderCertificadoInvalido);

        }

        private static void VerificationTimer(bool active, double interval)
        {
            if (active == true)
            {

                time.Interval = interval;
                time.Elapsed += new ElapsedEventHandler(GetAttatchments);

                time.Start();
                //                GetAttatchments(time, null);
            }
        }


        private static void GetAttatchments(object o, ElapsedEventArgs e)
        {
            time.Stop();

            try
            {

                using (Imap imap = new Imap())
                {
                    imap.Connect("server-IMAP");
                    imap.UseBestLogin("email-outlook", "senha");

                    imap.SelectInbox();
                    //imap.Idle();
                    List<long> uids = imap.Search(Flag.Unseen);
                    foreach (long uid in uids)
                    {
                        var eml = imap.GetMessageByUID(uid);
                        IMail email = new MailBuilder().CreateFromEml(eml);

                        SaveAttachments(email, folderPendente);
                    }
                    imap.Close();
                }
            }
            finally
            {

                time.Start();

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

                    VerifyXML(Path.Combine(folder, attachment.SafeFileName));
                }
            }
        }


        private static void VerifyXML(string xmlName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;

            xmlDoc.Load(xmlName);

            try
            {
                SignedXml signedXml = new SignedXml(xmlDoc);
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Signature");
                XmlNodeList certificates = xmlDoc.GetElementsByTagName("X509Certificate");

                string sourceFile = Path.Combine(folderPendente, xmlName);

                if (certificates.Count > 0)
                {
                    try
                    {
                        X509Certificate2 dcert2 = new X509Certificate2(Convert.FromBase64String(certificates[0].InnerText));
                        foreach (XmlElement element in nodeList)
                        {
                            signedXml.LoadXml(element);
                            bool passes = signedXml.CheckSignature(dcert2, true);

                            if (passes == true)
                            {
                                string destinationFile = Path.Combine(folderAprovado, Path.GetFileName(xmlName));
                                try
                                {
                                    File.Move(sourceFile, destinationFile);
                                }
                                catch
                                {
                                    File.Delete(sourceFile);
                                }

                            }

                            else
                            {
                                string destinationFile = Path.Combine(folderCertificadoInvalido, Path.GetFileName(xmlName));
                                try
                                {
                                    File.Move(sourceFile, destinationFile);
                                }
                                catch
                                {
                                    File.Delete(sourceFile);
                                }
                            }

                        }
                    }
                    catch
                    {
                        string destinationFile = Path.Combine(folderCertificadoInvalido, Path.GetFileName(xmlName));
                        try
                        {
                            File.Move(sourceFile, destinationFile);
                        }
                        catch
                        {
                            File.Delete(sourceFile);
                        }
                    }
                }
                else
                {
                    string destinationFile = Path.Combine(folderSemCertificado, Path.GetFileName(xmlName));
                    try
                    {
                        File.Move(sourceFile, destinationFile);
                    }
                    catch
                    {
                        File.Delete(sourceFile);
                    }
                }


            }
            finally
            {
                xmlDoc = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
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
