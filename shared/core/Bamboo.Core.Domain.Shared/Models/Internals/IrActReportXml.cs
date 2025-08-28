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

[Table("ir_act_report_xml")]
//[Index("Path", Name = "ir_act_report_xml_path_unique", IsUnique = true)]
public partial class IrActReportXml: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("binding_model_id")]
    public Guid? BindingModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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
    public string? Name { get; set; }

    [JsonField]
    [Column("help", TypeName = "jsonb")]
    public string? Help { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

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

    // [One2many]
    // [One2many] [ForeignKey("PdfReportId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PdfReport")] // One2many
    public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizard { get; set; }

    // [Many2one]
    [ForeignKey("BindingModelId")]
    public virtual IrModel? BindingModel { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PosReportPrintId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosReportPrint")] // One2many
    public virtual ICollection<LoyaltyMail> LoyaltyMail { get; set; }

    // [Many2one]
    [ForeignKey("PaperformatId")]
    public virtual ReportPaperformat? Paperformat { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("InvoiceTemplatePdfReportId")]
    [NotMapped] // One2many // Peer relationship (ResPartner) is commented out
    // [InverseProperty("InvoiceTemplatePdfReport")] // One2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ReportTemplate")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ReportTemplateNavigation")] // One2many
    public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("Uid")] // Many2many // Normal
    // [InverseProperty("Uid")] // Many2many // Normal
    public virtual ICollection<ResGroups> Gid { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrActionsReportId")] //Many2many // Hidden
    // [InverseProperty("IrActionsReport")] //Many2many // Hidden
    public virtual ICollection<MailTemplate> MailTemplate { get; set; }
}
