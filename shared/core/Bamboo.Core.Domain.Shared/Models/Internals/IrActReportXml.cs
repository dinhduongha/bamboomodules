using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Module("base")]
[Table("ir_act_report_xml")]
//[Index("Path", Name = "ir_act_report_xml_path_unique", IsUnique = true)]
public partial class IrActReportXml: FullAuditedEntity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("binding_model_id")]
    public Guid? BindingModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("path")]
    public string? Path { get; set; }

    [Column("binding_type")]
    public string? BindingType { get; set; }

    [Column("binding_view_types")]
    public string? BindingViewTypes { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Help { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("paperformat_id")]
    public Guid? PaperformatId { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("report_type")]
    public string? ReportType { get; set; }

    [Column("report_name")]
    public string? ReportName { get; set; }

    [Column("report_file")]
    public string? ReportFile { get; set; }

    [Column("attachment")]
    public string? Attachment { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [JsonField]
    [Column("print_report_name", TypeName = "jsonb")]
    public string? PrintReportName { get; set; }

    [Column("multi")]
    public bool? Multi { get; set; }

    [Column("attachment_use")]
    public bool? AttachmentUse { get; set; }

    [Column("is_invoice_report")]
    public bool? IsInvoiceReport { get; set; }

    [ForeignKey("BindingModelId")]
    //[InverseProperty("IrActReportXmls")]
    [NotMapped]
    public virtual IrModel? BindingModel { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrActReportXmlCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PaperformatId")]
    //[InverseProperty("IrActReportXmls")]
    [NotMapped]
    public virtual ReportPaperformat? Paperformat { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrActReportXmlWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("PdfReport")]
    [NotMapped]
    public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizards { get; set; } 

    //[InverseProperty("InvoiceTemplatePdfReport")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } 

    //[InverseProperty("ReportTemplateNavigation")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; set; } 

    [ForeignKey("Uid")]
    //[InverseProperty("Uids")]
    [NotMapped]
    public virtual ICollection<ResGroup> Gids { get; set; } 

    // TODO: v16-Compat
    //[InverseProperty("ReportTemplateNavigation")]
    //[NotMapped]
    //public virtual ICollection<MailTemplate> MailTemplates { get; } 

    [ForeignKey("IrActionsReportId")]
    //[InverseProperty("IrActionsReports")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplates { get; set; } 
}
