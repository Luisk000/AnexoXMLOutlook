using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportXml.Models
{
    public class XmlFileDet
    {
        public int Id { get; set; }
        [ForeignKey("XmlFileId")]
        public XmlFile XmlFile { get; set; }
        public string XmlFileId { get; set; }
        public string nfeProc_NFe_infNFe_det____nItem { get; set; } //propriedade

        public string nfeProc_NFe_infNFe_det_prod_cProd { get; set; }
        //cEAN
        public string nfeProc_NFe_infNFe_det_prod_xProd { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_NCM { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_CFOP { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_uCom { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_qCom { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_vUnCom { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_vProd { get; set; }
        //cEANTrib
        public string nfeProc_NFe_infNFe_det_prod_uTrib { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_qTrib { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_vUnTrib { get; set; }
        public string nfeProc_NFe_infNFe_det_prod_indTot { get; set; }

        public string nfeProc_NFe_infNFe_det_Imposto_ICMS_ICMSN102_orig { get; set; }
        public string nfeProc_NFe_infNFe_det_Imposto_ICMS_ICMSN102_CSOSN { get; set; }
        public string nfeProc_NFe_infNFe_det_Imposto_IPI_cEnq { get; set; }
        public string nfeProc_NFe_infNFe_det_Imposto_IPI_IPINT_CST { get; set; }
        public string nfeProc_NFe_infNFe_det_Imposto_PIS_PISNT_CST { get; set; }
        public string nfeProc_NFe_infNFe_det_Imposto_COFINS_COFINSNT_CST { get; set; }
    }
}
