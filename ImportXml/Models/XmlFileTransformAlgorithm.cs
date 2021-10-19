using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportXml.Models
{
    public class XmlFileTransformAlgorithm
    {
        public int Id { get; set; }
        [ForeignKey("XmlFileId")]
        public XmlFile XmlFile { get; set; }
        public string XmlFileId { get; set; }
        public string nfeProc_NFe_Signature_SignedInfo_Reference_Transforms_Transform____Algorithm { get; set; } //propriedade
    }
}
