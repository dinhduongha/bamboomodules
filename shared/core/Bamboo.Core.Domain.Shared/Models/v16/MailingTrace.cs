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
public partial class MailingTrace: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sms_sms_id")]
    public Guid? SmsSmsId { get; set; }

    [Column("sms_id_int")]
    public Guid? SmsSmsIdInt { get; set; }

    [Column("sms_number")]
    public string? SmsNumber { get; set; }

    [Column("sms_code")]
    public string? SmsCode { get; set; }

    [ForeignKey("CampaignId")]
    //[InverseProperty("MailingTraces")]
    [NotMapped]
    public virtual UtmCampaign? Campaign { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingTraceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("MailingTrace")]
    [NotMapped]
    public virtual ICollection<LinkTrackerClick> LinkTrackerClicks { get; set; } 

    [ForeignKey("MailMailId")]
    //[InverseProperty("MailingTraces")]
    [NotMapped]
    public virtual MailMail? MailMail { get; set; }

    [ForeignKey("MassMailingId")]
    //[InverseProperty("MailingTraces")]
    [NotMapped]
    public virtual MailingMailing? MassMailing { get; set; }

    [ForeignKey("SmsSmsId")] 
    //[InverseProperty("MailingTraces")]
    [NotMapped]
    public virtual SmsSms? SmsSms { get; set; }

    //[InverseProperty("MailingTrace")]
    [NotMapped]
    public virtual ICollection<SmsTracker> SmsTrackers { get; set; } 

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingTraceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
