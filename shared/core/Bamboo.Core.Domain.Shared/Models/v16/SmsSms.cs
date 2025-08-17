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

[Table("sms_sms")]
//[Index("MailMessageId", Name = "sms_sms_mail_message_id_index")]
public partial class SmsSms: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("number")]
    public string? Number { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("failure_type")]
    public string? FailureType { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("mailing_id")]
    public Guid? MailingId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SmsSmsCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailMessageId")]
    // [InverseProperty("SmsSms")] //Many2one
    public virtual MailMessage? MailMessage { get; set; }

    // [One2many]
    [ForeignKey("SmsId")]
    [InverseProperty("Sms")]
    public virtual ICollection<MailNotification> MailNotification { get; set; }

    // [Many2one]
    [ForeignKey("MailingId")]
    // [InverseProperty("SmsSms")] //Many2one
    public virtual MailingMailing? Mailing { get; set; }

    // [One2many]
    [ForeignKey("SmsSmsId")]
    [InverseProperty("SmsSms")]
    public virtual ICollection<MailingTrace> MailingTrace { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("SmsSms")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SmsSmsWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
