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

[Table("mailing_trace")]
//[Index("MassMailingId", Name = "mailing_trace__mass_mailing_id_index")]
public partial class MailingTrace: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("mail_mail_id")]
    public Guid? MailMailId { get; set; }

    [Column("mail_mail_id_int")]
    public Guid? MailMailIdInt { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("mass_mailing_id")]
    public Guid? MassMailingId { get; set; }

    [Column("campaign_id")]
    public Guid? CampaignId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("trace_type")]
    public string? TraceType { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("message_id")]
    public string? MessageId { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("trace_status")]
    public string? TraceStatus { get; set; }

    [Column("failure_type")]
    public string? FailureType { get; set; }

    [Column("failure_reason")]
    public string? FailureReason { get; set; }

    [Column("sent_datetime", TypeName = "timestamp without time zone")]
    public DateTime? SentDatetime { get; set; }

    [Column("open_datetime", TypeName = "timestamp without time zone")]
    public DateTime? OpenDatetime { get; set; }

    [Column("reply_datetime", TypeName = "timestamp without time zone")]
    public DateTime? ReplyDatetime { get; set; }

    [Column("links_click_datetime", TypeName = "timestamp without time zone")]
    public DateTime? LinksClickDatetime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sms_id_int")]
    public Guid? SmsIdInt { get; set; }

    [Column("sms_number")]
    public string? SmsNumber { get; set; }

    [Column("sms_code")]
    public string? SmsCode { get; set; }

    // [Many2one]
    [ForeignKey("CampaignId")]
    public virtual UtmCampaign? Campaign { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailingTraceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailingTrace")] // One2many
    public virtual ICollection<LinkTrackerClick> LinkTrackerClick { get; set; }

    // [Many2one]
    [ForeignKey("MailMailId")]
    public virtual MailMail? MailMail { get; set; }

    // [Many2one]
    [ForeignKey("MassMailingId")]
    public virtual MailingMailing? MassMailing { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MailingTraceId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MailingTrace")] // One2many
    public virtual ICollection<SmsTracker> SmsTracker { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
