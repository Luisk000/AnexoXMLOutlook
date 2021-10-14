﻿// <auto-generated />
using ImportXml.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImportXml.Migrations
{
    [DbContext(typeof(XmlDbContext))]
    partial class XmlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImportXml.Models.XmlFile", b =>
                {
                    b.Property<string>("nfeProc_NFe_infNFe_____Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("XmlName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_Signature_KeyInfo_X509Data_X509Certificate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_Signature_SignatureValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_Signature_SignedInfo_CanonicalizationMethod____Algorithm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_Signature_SignedInfo_Reference_DigestMethod____Algorithm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_Signature_SignedInfo_Reference_DigestValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_Signature_SignedInfo_Reference____URI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_Signature_SignedInfo_SignatureMethod____Algorithm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_Signature____xmlns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_IE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_UF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_cMun")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_cPais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_fone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_nro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_xBairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_xCpl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_xLgr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_xMun")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_enderDest_xPais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_indIEDest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_dest_xNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_CNAE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_CRT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_IE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_IM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_UF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_cMun")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_cPais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_fone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_nro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_xBairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_xLgr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_xMun")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_enderEmit_xPais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_xFant")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_emit_xNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_cDV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_cMunFG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_cNF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_cUF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_dhEmi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_dhSaiEnt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_finNFe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_idDest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_indFinal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_indIntermed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_indPag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_indPres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_mod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_nNF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_natOp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_procEmi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_serie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_tpAmb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_tpEmis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_tpImp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_tpNF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_ide_verProc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_infAdic_infCpl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_infRespTec_CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_infRespTec_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_infRespTec_fone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_infRespTec_xContato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_pag_detPag_indPag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_pag_detPag_tPag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_pag_detPag_vPag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vBC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vBCST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vCOFINS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vFCP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vFCPST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vFCPSTRet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vFCPUFDest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vFrete")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vICMS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vICMSDeson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vICMSUFDest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vICMSUFRemet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vII")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vIPI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vIPIDevol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vNF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vOutro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vPIS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vProd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vSeg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_total_ICMSTot_vTotTrib")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_transp_modFrete")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_Nfe_infNFe____versao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc____versao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc____xmlns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe____versao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe_infProt_cStat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe_infProt_chNFe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe_infProt_dhRecbto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe_infProt_digVal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe_infProt_nProt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe_infProt_tpAmb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe_infProt_verAplic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_protNFe_infProt_xMotivo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nfeProc_NFe_infNFe_____Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ImportXml.Models.XmlFileDet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("XmlFileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_Imposto_COFINS_COFINSNT_CST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_Imposto_ICMS_ICMSN102_CSOSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_Imposto_ICMS_ICMSN102_orig")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_Imposto_IPI_IPINT_CST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_Imposto_IPI_cEnq")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_Imposto_PIS_PISNT_CST")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det____nItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_CFOP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_NCM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_cProd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_indTot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_qCom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_qTrib")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_uCom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_uTrib")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_vProd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_vUnCom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_vUnTrib")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nfeProc_NFe_infNFe_det_prod_xProd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("XmlFileId");

                    b.ToTable("Dets");
                });

            modelBuilder.Entity("ImportXml.Models.XmlFileTransformAlgorithm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nfeProc_NFe_Signature_SignedInfo_Reference_Transforms_Transform____Algorithm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Algorithms");
                });

            modelBuilder.Entity("ImportXml.Models.XmlFileDet", b =>
                {
                    b.HasOne("ImportXml.Models.XmlFile", "XmlFile")
                        .WithMany()
                        .HasForeignKey("XmlFileId");

                    b.Navigation("XmlFile");
                });
#pragma warning restore 612, 618
        }
    }
}