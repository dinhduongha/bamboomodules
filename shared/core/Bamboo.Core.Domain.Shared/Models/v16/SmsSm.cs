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
public partial class SmsSm : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("mail_message_id")]
    public Guid? MailMessageId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("uuid")]
    public string? Uuid { get; set; }

    [Column("number")]
    public string? Number { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("failure_type")]
    public string? FailureType { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("to_delete")]
    public bool? ToDelete { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("mailing_id")]
    public Guid? MailingId { get; set; }

    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SmsSmCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailMessageId")]
    //[InverseProperty("SmsSms")]
    [NotMapped]
    public virtual MailMessage? MailMessage { get; set; }

    [ForeignKey("MailingId")]
    //[InverseProperty("SmsSms")]
    [NotMapped]
    public virtual MailingMailing? Mailing { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("SmsSms")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SmsSmWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    // v16-Compat
    //[InverseProperty("Sms")]
    [NotMapped]
    public virtual ICollection<MailNotification> MailNotifications { get; set; } = new List<MailNotification>();

}
