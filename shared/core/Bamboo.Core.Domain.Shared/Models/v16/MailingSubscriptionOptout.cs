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

[Table("mailing_subscription_optout")]
public partial class MailingSubscriptionOptout: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("is_feedback")]
    public bool? IsFeedback { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingSubscriptionOptoutCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("OptOutReason")]
    [NotMapped]
    public virtual ICollection<MailBlacklist> MailBlacklists { get; set; } = new List<MailBlacklist>();

    //[InverseProperty("OptOutReason")]
    [NotMapped]
    public virtual ICollection<MailingSubscription> MailingSubscriptions { get; set; } = new List<MailingSubscription>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingSubscriptionOptoutWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
