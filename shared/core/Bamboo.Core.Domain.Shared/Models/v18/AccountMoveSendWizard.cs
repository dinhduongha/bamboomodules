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

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("pdf_report_id")]
    public Guid? PdfReportId { get; set; }

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountMoveSendWizardCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailTemplateId")]
    // [InverseProperty("AccountMoveSendWizard")] //Many2one
    public virtual MailTemplate? MailTemplate { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    // [InverseProperty("AccountMoveSendWizard")] //Many2one
    public virtual AccountMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("PdfReportId")]
    // [InverseProperty("AccountMoveSendWizard")] //Many2one
    public virtual IrActReportXml? PdfReport { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountMoveSendWizardWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountMoveSendWizardId")] //Many2many
    // [InverseProperty("AccountMoveSendWizard")] //Many2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }
}
