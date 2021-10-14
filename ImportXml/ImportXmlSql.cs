using ImportXml.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ImportXml
{
    public class ImportXmlSql
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("filesettings.json", optional: false, reloadOnChange: true).Build();

        private static string folder = configuration.GetSection("folder").Value;

        private readonly XmlDbContext context = new XmlDbContext();


        public ImportXmlSql()
        {
            string[] arquivos = Directory.GetFiles(folder);
            foreach (string arq in arquivos)
            {
                Console.WriteLine("Arquivo " + arq + "\n");
                XmlTextReader reader = new XmlTextReader(arq);
                XmlFile xml = new XmlFile();

                xml.XmlName = arq.Split('\\')[6];
                while (reader.Read())
                {                   
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "nfeProc")
                    {
                        xml.nfeProc____versao = reader.GetAttribute("versao");
                        xml.nfeProc____xmlns = reader.GetAttribute("xmlns");

                        if (reader.ReadToDescendant("NFe"))
                        {
                            if (reader.ReadToDescendant("infNFe"))
                            {
                                xml.nfeProc_Nfe_infNFe____versao = reader.GetAttribute("versao");
                                xml.nfeProc_NFe_infNFe_____Id = reader.GetAttribute("Id");

                                bool exists = context.Files.SingleOrDefault(f => f.nfeProc_NFe_infNFe_____Id == xml.nfeProc_NFe_infNFe_____Id) != null;
                                if (exists)
                                    break;

                                context.Files.Add(xml);
                                context.SaveChanges();

                                if (reader.ReadToDescendant("ide"))
                                {
                                    if (reader.ReadToDescendant("cUF"))
                                        xml.nfeProc_NFe_infNFe_ide_cUF = reader.ReadInnerXml();

                                    if (reader.Name == "cNF")
                                        xml.nfeProc_NFe_infNFe_ide_cNF = reader.ReadInnerXml();

                                    if (reader.Name == "natOp")
                                        xml.nfeProc_NFe_infNFe_ide_natOp = reader.ReadInnerXml();

                                    if (reader.Name == "indPag")
                                        xml.nfeProc_NFe_infNFe_ide_indPag = reader.ReadInnerXml();                                  

                                    if (reader.Name == "mod")
                                        xml.nfeProc_NFe_infNFe_ide_mod = reader.ReadInnerXml();

                                    if (reader.Name == "serie")
                                        xml.nfeProc_NFe_infNFe_ide_serie = reader.ReadInnerXml();

                                    if (reader.Name == "nNF")
                                        xml.nfeProc_NFe_infNFe_ide_nNF = reader.ReadInnerXml();

                                    if (reader.Name == "dhEmi")
                                        xml.nfeProc_NFe_infNFe_ide_dhEmi = reader.ReadInnerXml();

                                    if (reader.Name == "dhSaiEnt")
                                        xml.nfeProc_NFe_infNFe_ide_dhSaiEnt = reader.ReadInnerXml();                                    

                                    if (reader.Name == "tpNF")
                                        xml.nfeProc_NFe_infNFe_ide_tpNF = reader.ReadInnerXml();

                                    if (reader.Name == "idDest")
                                        xml.nfeProc_NFe_infNFe_ide_idDest = reader.ReadInnerXml();

                                    if (reader.Name == "cMunFG")
                                        xml.nfeProc_NFe_infNFe_ide_cMunFG = reader.ReadInnerXml();

                                    if (reader.Name == "tpImp")
                                        xml.nfeProc_NFe_infNFe_ide_tpImp = reader.ReadInnerXml();

                                    if (reader.Name == "tpEmis")
                                        xml.nfeProc_NFe_infNFe_ide_tpEmis = reader.ReadInnerXml();

                                    if (reader.Name == "cDV")
                                        xml.nfeProc_NFe_infNFe_ide_cDV = reader.ReadInnerXml();

                                    if (reader.Name == "tpAmb")
                                        xml.nfeProc_NFe_infNFe_ide_tpAmb = reader.ReadInnerXml();

                                    if (reader.Name == "finNFe")
                                        xml.nfeProc_NFe_infNFe_ide_finNFe = reader.ReadInnerXml();

                                    if (reader.Name == "indFinal")
                                        xml.nfeProc_NFe_infNFe_ide_indFinal = reader.ReadInnerXml();

                                    if (reader.Name == "indPres")
                                        xml.nfeProc_NFe_infNFe_ide_indPres = reader.ReadInnerXml();

                                    if (reader.Name == "indIntermed")
                                        xml.nfeProc_NFe_infNFe_ide_indIntermed = reader.ReadInnerXml();
                                 
                                    if (reader.Name == "procEmi")
                                        xml.nfeProc_NFe_infNFe_ide_procEmi = reader.ReadInnerXml();

                                    if (reader.Name == "verProc")
                                        xml.nfeProc_NFe_infNFe_ide_verProc = reader.ReadInnerXml();
                                }

                                if (reader.ReadToNextSibling("emit"))
                                {
                                    if (reader.ReadToDescendant("CNPJ"))
                                        xml.nfeProc_NFe_infNFe_emit_CNPJ = reader.ReadInnerXml();

                                    if (reader.Name == "xNome")
                                        xml.nfeProc_NFe_infNFe_emit_xNome = reader.ReadInnerXml();

                                    if (reader.Name == "xFant")
                                        xml.nfeProc_NFe_infNFe_emit_xFant = reader.ReadInnerXml();

                                    if (reader.Name == "enderEmit")
                                    {
                                        if (reader.ReadToDescendant("xLgr"))
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_xLgr = reader.ReadInnerXml();

                                        if (reader.Name == "nro")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_nro = reader.ReadInnerXml();

                                        if (reader.Name == "xBairro")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_xBairro = reader.ReadInnerXml();

                                        if (reader.Name == "cMun")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_cMun = reader.ReadInnerXml();

                                        if (reader.Name == "xMun")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_xMun = reader.ReadInnerXml();

                                        if (reader.Name == "UF")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_UF = reader.ReadInnerXml();

                                        if (reader.Name == "CEP")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_CEP = reader.ReadInnerXml();

                                        if (reader.Name == "cPais")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_cPais = reader.ReadInnerXml();

                                        if (reader.Name == "xPais")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_xPais = reader.ReadInnerXml();

                                        if (reader.Name == "fone")
                                            xml.nfeProc_NFe_infNFe_emit_enderEmit_fone = reader.ReadInnerXml();
                                    }

                                    if (reader.ReadToNextSibling("IE"))
                                        xml.nfeProc_NFe_infNFe_emit_IE = reader.ReadInnerXml();

                                    if (reader.Name == "IM")
                                        xml.nfeProc_NFe_infNFe_emit_IM = reader.ReadInnerXml();

                                    if (reader.Name == "CNAE")
                                        xml.nfeProc_NFe_infNFe_emit_CNAE = reader.ReadInnerXml();

                                    if (reader.Name == "CRT")
                                        xml.nfeProc_NFe_infNFe_emit_CRT = reader.ReadInnerXml();
                                }

                                if (reader.ReadToNextSibling("dest"))
                                {
                                    if (reader.ReadToDescendant("CNPJ"))
                                        xml.nfeProc_NFe_infNFe_dest_CNPJ = reader.ReadInnerXml();

                                    if (reader.Name == "xNome")
                                        xml.nfeProc_NFe_infNFe_dest_xNome = reader.ReadInnerXml();

                                    if (reader.Name == "enderDest")
                                    {
                                        if (reader.ReadToDescendant("xLgr"))
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_xLgr = reader.ReadInnerXml();

                                        if (reader.Name == "nro")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_xCpl = reader.ReadInnerXml();

                                        if (reader.Name == "xCpl")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_nro = reader.ReadInnerXml();

                                        if (reader.Name == "xBairro")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_xBairro = reader.ReadInnerXml();

                                        if (reader.Name == "cMun")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_cMun = reader.ReadInnerXml();

                                        if (reader.Name == "xMun")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_xMun = reader.ReadInnerXml();

                                        if (reader.Name == "UF")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_UF = reader.ReadInnerXml();

                                        if (reader.Name == "CEP")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_CEP = reader.ReadInnerXml();

                                        if (reader.Name == "cPais")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_cPais = reader.ReadInnerXml();

                                        if (reader.Name == "xPais")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_xPais = reader.ReadInnerXml();

                                        if (reader.Name == "fone")
                                            xml.nfeProc_NFe_infNFe_dest_enderDest_fone = reader.ReadInnerXml();
                                    }

                                    if (reader.ReadToNextSibling("indIEDest"))
                                        xml.nfeProc_NFe_infNFe_dest_indIEDest = reader.ReadInnerXml();

                                    if (reader.Name == "IE")
                                        xml.nfeProc_NFe_infNFe_dest_IE = reader.ReadInnerXml();

                                    if (reader.Name == "email")
                                        xml.nfeProc_NFe_infNFe_dest_email = reader.ReadInnerXml();
                                }                               

                                int item = 5;
                                for (int i = 0; i < item; i++)
                                {
                                    XmlFileDet xmlDet = new XmlFileDet();
                                    if (reader.ReadToNextSibling("det"))
                                    {
                                        item = Int32.Parse(reader.GetAttribute("nItem"));
                                        xmlDet.nfeProc_NFe_infNFe_det____nItem = item.ToString();
                                        if (item == 1) item++;

                                        if (reader.ReadToDescendant("prod"))
                                        {
                                            if (reader.ReadToDescendant("cProd"))
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_cProd = reader.ReadInnerXml();

                                            reader.Skip();

                                            if (reader.Name == "xProd")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_xProd = reader.ReadInnerXml();

                                            if (reader.Name == "NCM")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_NCM = reader.ReadInnerXml();

                                            if (reader.Name == "CFOP")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_CFOP = reader.ReadInnerXml();

                                            if (reader.Name == "uCom")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_uCom = reader.ReadInnerXml();

                                            if (reader.Name == "qCom")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_qCom = reader.ReadInnerXml();

                                            if (reader.Name == "vUnCom")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_vUnCom = reader.ReadInnerXml();

                                            if (reader.Name == "vProd")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_vProd = reader.ReadInnerXml();

                                            reader.Skip();

                                            if (reader.Name == "uTrib")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_uTrib = reader.ReadInnerXml();

                                            if (reader.Name == "qTrib")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_qTrib = reader.ReadInnerXml();

                                            if (reader.Name == "vUnTrib")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_vUnTrib = reader.ReadInnerXml();

                                            if (reader.Name == "indTot")
                                                xmlDet.nfeProc_NFe_infNFe_det_prod_indTot = reader.ReadInnerXml();
                                        }

                                        if (reader.ReadToNextSibling("imposto"))
                                        {
                                            if (reader.ReadToDescendant("ICMS"))
                                                if (reader.ReadToDescendant("ICMSSN102"))
                                                {
                                                    if (reader.ReadToDescendant("orig"))
                                                        xmlDet.nfeProc_NFe_infNFe_det_Imposto_ICMS_ICMSN102_orig = reader.ReadInnerXml();

                                                    if (reader.Name == "CSOSN")
                                                        xmlDet.nfeProc_NFe_infNFe_det_Imposto_ICMS_ICMSN102_CSOSN = reader.ReadInnerXml();
                                                }

                                            reader.Skip();

                                            if (reader.ReadToNextSibling("IPI"))
                                            {
                                                if (reader.ReadToDescendant("cEnq"))
                                                    xmlDet.nfeProc_NFe_infNFe_det_Imposto_IPI_cEnq = reader.ReadInnerXml();

                                                if (reader.Name == "IPINT")
                                                    if (reader.ReadToDescendant("CST"))
                                                        xmlDet.nfeProc_NFe_infNFe_det_Imposto_IPI_IPINT_CST = reader.ReadInnerXml();
                                            }

                                            reader.Skip();

                                            if (reader.ReadToNextSibling("PIS"))
                                                if (reader.ReadToDescendant("PISNT"))
                                                    if (reader.ReadToDescendant("CST"))
                                                        xmlDet.nfeProc_NFe_infNFe_det_Imposto_PIS_PISNT_CST = reader.ReadInnerXml();

                                            reader.Skip();

                                            if (reader.ReadToNextSibling("COFINS"))
                                                if (reader.ReadToDescendant("COFINSNT"))
                                                    if (reader.ReadToDescendant("CST"))
                                                        xmlDet.nfeProc_NFe_infNFe_det_Imposto_COFINS_COFINSNT_CST = reader.ReadInnerXml();

                                            reader.Skip();
                                            reader.Skip();
                                            reader.Skip();
                                        }
                                    }
                                    xmlDet.XmlFileId = xml.nfeProc_NFe_infNFe_____Id;
                                    context.Dets.Add(xmlDet);
                                    context.SaveChanges();
                                }

                                if (reader.ReadToNextSibling("total"))
                                    if (reader.ReadToDescendant("ICMSTot"))
                                    {
                                        if (reader.ReadToDescendant("vBC"))
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vBC = reader.ReadInnerXml();

                                        if (reader.Name == "vICMS")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vICMS = reader.ReadInnerXml();

                                        if (reader.Name == "vICMSDeson")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vICMSDeson = reader.ReadInnerXml();

                                        if (reader.Name == "vFCPUFDest")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vFCPUFDest = reader.ReadInnerXml();

                                        if (reader.Name == "vICMSUFDest")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vICMSUFDest = reader.ReadInnerXml();

                                        if (reader.Name == "vICMSUFRemet")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vICMSUFRemet = reader.ReadInnerXml();

                                        if (reader.Name == "vFCP")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vFCP = reader.ReadInnerXml();

                                        if (reader.Name == "vBCST")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vBCST = reader.ReadInnerXml();

                                        if (reader.Name == "vST")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vST = reader.ReadInnerXml();

                                        if (reader.Name == "vFCPST")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vFCPST = reader.ReadInnerXml();

                                        if (reader.Name == "vFCPSTRet")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vFCPSTRet = reader.ReadInnerXml();

                                        if (reader.Name == "vProd")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vProd = reader.ReadInnerXml();

                                        if (reader.Name == "vFrete")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vFrete = reader.ReadInnerXml();

                                        if (reader.Name == "vSeg")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vSeg = reader.ReadInnerXml();

                                        if (reader.Name == "vDesc")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vDesc = reader.ReadInnerXml();

                                        if (reader.Name == "vII")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vII = reader.ReadInnerXml();

                                        if (reader.Name == "vIPI")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vIPI = reader.ReadInnerXml();

                                        if (reader.Name == "vIPIDevol")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vIPIDevol = reader.ReadInnerXml();

                                        if (reader.Name == "vPIS")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vPIS = reader.ReadInnerXml();

                                        if (reader.Name == "vCOFINS")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vCOFINS = reader.ReadInnerXml();

                                        if (reader.Name == "vOutro")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vOutro = reader.ReadInnerXml();

                                        if (reader.Name == "vNF")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vNF = reader.ReadInnerXml();

                                        if (reader.Name == "vTotTrib")
                                            xml.nfeProc_NFe_infNFe_total_ICMSTot_vTotTrib = reader.ReadInnerXml();

                                        reader.Skip();
                                    }

                                if (reader.ReadToNextSibling("transp"))
                                    if (reader.ReadToDescendant("modFrete"))
                                        xml.nfeProc_NFe_infNFe_transp_modFrete = reader.ReadInnerXml();

                                if (reader.ReadToNextSibling("pag"))
                                    if (reader.ReadToDescendant("detPag"))
                                    {
                                        if (reader.ReadToDescendant("indPag"))
                                            xml.nfeProc_NFe_infNFe_pag_detPag_indPag = reader.ReadInnerXml();

                                        if (reader.Name == "tPag")
                                            xml.nfeProc_NFe_infNFe_pag_detPag_tPag = reader.ReadInnerXml();

                                        if (reader.Name == "vPag")
                                            xml.nfeProc_NFe_infNFe_pag_detPag_vPag = reader.ReadInnerXml();
                                    }
                                context.Files.Update(xml);
                                context.SaveChanges();
                            }
                        }                       
                    }                   
                }                          
            }                
        }
    }            
}






//while (reader.Read())
//{
//    switch (reader.NodeType)
//    {
//        case XmlNodeType.Element:
//            Console.Write("<" + reader.Name);
//            while (reader.MoveToNextAttribute())
//                Console.Write(" " + reader.Name + "='" + reader.Value + "'");
//            Console.Write(">");
//            Console.WriteLine(">");
//            break;
//        case XmlNodeType.Text:
//            Console.WriteLine(reader.Value);
//            break;
//        case XmlNodeType.EndElement:
//            Console.Write("</" + reader.Name);
//            Console.WriteLine(">");
//            break;
//    }
//}
//Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");