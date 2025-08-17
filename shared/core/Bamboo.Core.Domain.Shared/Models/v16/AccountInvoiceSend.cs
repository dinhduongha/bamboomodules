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

[Table("account_invoice_send")]
public partial class AccountInvoiceSend: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("composer_id")]
    public Guid? ComposerId { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("is_email")]
    public bool? IsEmail { get; set; }

    [Column("is_print")]
    public bool? IsPrint { get; set; }

    [Column("printed")]
    public bool? Printed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("snailmail_is_letter")]
    public bool? SnailmailIsLetter { get; set; }

    // [Many2one]
    [ForeignKey("ComposerId")]
    // [InverseProperty("AccountInvoiceSend")] //Many2one
    public virtual MailComposeMessage? Composer { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountInvoiceSendCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("InvoiceSendId")]
    [InverseProperty("InvoiceSend")]
    public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoice { get; set; }

    // [Many2one]
    [ForeignKey("TemplateId")]
    // [InverseProperty("AccountInvoiceSend")] //Many2one
    public virtual MailTemplate? Template { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountInvoiceSendWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountInvoiceSendId")] //Many2many
    // [InverseProperty("AccountInvoiceSend")] //Many2many
    public virtual ICollection<AccountMove> AccountMove { get; set; }
}
