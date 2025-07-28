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

[Table("event_mail")]
public partial class EventMail: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("interval_nbr")]
    public long? IntervalNbr { get; set; }

    [Column("last_registration_id")]
    public Guid? LastRegistrationId { get; set; }

    [Column("mail_count_done")]
    public long? MailCountDone { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("notification_type")]
    public string? NotificationType { get; set; }

    [Column("interval_unit")]
    public string? IntervalUnit { get; set; }

    [Column("interval_type")]
    public string? IntervalType { get; set; }

    [Column("template_ref")]
    public string? TemplateRef { get; set; }

    [Column("mail_done")]
    public bool? MailDone { get; set; }

    [Column("scheduled_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduledDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventMailCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EventId")]
    //[InverseProperty("EventMails")]
    [NotMapped]
    public virtual EventEvent? Event { get; set; }

    //[InverseProperty("Scheduler")]
    [NotMapped]
    public virtual ICollection<EventMailRegistration> EventMailRegistrations { get; set; } 

    [ForeignKey("LastRegistrationId")]
    //[InverseProperty("EventMails")]
    [NotMapped]
    public virtual EventRegistration? LastRegistration { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventMailWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
