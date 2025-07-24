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

[Table("mail_scheduled_message")]
public partial class MailScheduledMessage: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("notification_parameters")]
    public string? NotificationParameters { get; set; }

    [Column("is_note")]
    public bool? IsNote { get; set; }

    [Column("scheduled_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduledDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("AuthorId")]
    //[InverseProperty("MailScheduledMessages")]
    [NotMapped]
    public virtual ResPartner? Author { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailScheduledMessageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailScheduledMessageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ScheduledMessageId")]
    //[InverseProperty("ScheduledMessages")]
    [NotMapped]
    public virtual ICollection<IrAttachment> Attachments { get; set; } = new List<IrAttachment>();

    [ForeignKey("MailScheduledMessageId")]
    //[InverseProperty("MailScheduledMessagesNavigation")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } = new List<ResPartner>();
}
