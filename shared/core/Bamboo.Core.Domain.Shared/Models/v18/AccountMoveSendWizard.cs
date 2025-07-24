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

[Table("account_move_send_wizard")]
public partial class AccountMoveSendWizard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("pdf_report_id")]
    public Guid? PdfReportId { get; set; }

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("mail_subject")]
    public string? MailSubject { get; set; }

    [JsonField]
    [Column("sending_method_checkboxes", TypeName = "jsonb")]
    public string? SendingMethodCheckboxes { get; set; }

    [JsonField]
    [Column("extra_edi_checkboxes", TypeName = "jsonb")]
    public string? ExtraEdiCheckboxes { get; set; }

    [JsonField]
    [Column("mail_attachments_widget", TypeName = "jsonb")]
    public string? MailAttachmentsWidget { get; set; }

    [Column("mail_body")]
    public string? MailBody { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountMoveSendWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailTemplateId")]
    //[InverseProperty("AccountMoveSendWizards")]
    [NotMapped]
    public virtual MailTemplate? MailTemplate { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("AccountMoveSendWizards")]
    [NotMapped]
    public virtual AccountMove? Move { get; set; }

    [ForeignKey("PdfReportId")]
    //[InverseProperty("AccountMoveSendWizards")]
    [NotMapped]
    public virtual IrActReportXml? PdfReport { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountMoveSendWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("AccountMoveSendWizardId")]
    //[InverseProperty("AccountMoveSendWizards")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } = new List<ResPartner>();
}
