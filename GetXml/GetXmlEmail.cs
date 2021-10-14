using Limilabs.Client.IMAP;
using Limilabs.Mail;
using Limilabs.Mail.MIME;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Timers;
using System.Xml;

namespace GetXml
{
    public class GetXmlEmail : DataRepository   
    {
        public GetXmlEmail()
        {
            VerificationTimer(true, 5000);
        }

        private void VerificationTimer(bool active, double interval)
        {
            if (active == true)
            {
                time.Interval = interval;
                time.Elapsed += new ElapsedEventHandler(ValidateFolder);
                time.Elapsed += new ElapsedEventHandler(GetAttatchments);
                time.Start();
            }
            else
            {
                ValidateFolder(time, null);
                GetAttatchments(time, null);
                Serilog.Log.Warning("O timer está desativado");
            }
        }

        private void ValidateFolder(object o, ElapsedEventArgs e)
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

        private void GetAttatchments(object o, ElapsedEventArgs e)
        {
            time.Stop();

            try
            {
                using (Imap imap = new Imap())
                {
                    imap.Connect(serverImap);
                    imap.UseBestLogin(email, senha);

                    imap.SelectInbox();
                    List<long> uids = imap.Search(Flag.All);
                    foreach (long uid in uids)
                    {
                        var eml = imap.GetMessageByUID(uid);
                        IMail mail = new MailBuilder().CreateFromEml(eml);

                        SaveAttachments(mail, folderPendente);
                    }
                    imap.Close();
                }
                time.Start();
            }
            catch (Exception ex)
            {
                Serilog.Log.Fatal(ex, "Falha ao conectar com server Imap");
            }
        }


        private void SaveAttachments(IMail email, string folder)
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


        private void VerifyXML(string xmlName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(xmlName);

            try
            {
                SignedXml signedXml = new SignedXml(xmlDoc);
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("Signature");
                XmlNodeList certificates509 = xmlDoc.GetElementsByTagName("X509Certificate");

                string sourceFile = Path.Combine(folderPendente, xmlName);

                if (certificates509.Count > 0)
                {
                    try
                    {
                        X509Certificate2 dcert2 = new X509Certificate2(Convert.FromBase64String(certificates509[0].InnerText));

                        foreach (XmlElement element in nodeList)
                        {
                            signedXml.LoadXml(element);
                            bool passes = signedXml.CheckSignature(dcert2, true);
                            bool validKey = signedXml.CheckSignature(dcert2.PublicKey.Key);

                            if (passes == true && validKey == true)
                            {
                                string destinationFile = Path.Combine(folderAprovado, Path.GetFileName(xmlName));
                                try
                                {
                                    File.Move(sourceFile, destinationFile);
                                    Serilog.Log.Information("Arquivo XML autêntico recebido");

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
                                    Serilog.Log.Warning("Arquivo XML com certificado inválido recebido");
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
                            Serilog.Log.Warning("Arquivo XML com certificado inválido recebido");
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
                        Serilog.Log.Warning("Arquivo XML sem certificado recebido");
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
    }
}
