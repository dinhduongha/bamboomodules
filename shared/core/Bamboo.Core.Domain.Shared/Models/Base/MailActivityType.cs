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

[Table("mail_activity_type")]
//[Index("CreationTime", Name = "mail_activity_type_create_uid_index")]
public partial class MailActivityType: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("delay_count")]
    public long? DelayCount { get; set; }

    [Column("triggered_next_type_id")]
    public long? TriggeredNextTypeId { get; set; }

    [Column("default_user_id")]
    public Guid? DefaultUserId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("delay_unit")]
    public string? DelayUnit { get; set; }

    [Column("delay_from")]
    public string? DelayFrom { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [Column("decoration_type")]
    public string? DecorationType { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("chaining_type")]
    public string? ChainingType { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("summary", TypeName = "jsonb")]
    public string? Summary { get; set; }

    [Column("default_note", TypeName = "jsonb")]
    public string? DefaultNote { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailActivityTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DefaultUserId")]
    //[InverseProperty("MailActivityTypeDefaultUsers")]
    [NotMapped]
    public virtual ResUser? DefaultUser { get; set; }

    [ForeignKey("TriggeredNextTypeId")]
    //[InverseProperty("InverseTriggeredNextType")]
    [NotMapped]
    public virtual MailActivityType? TriggeredNextType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailActivityTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("SaleActivityType")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    //[InverseProperty("ActivityType")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypes { get; } = new List<HrPlanActivityType>();

    //[InverseProperty("TriggeredNextType")]
    [NotMapped]
    public virtual ICollection<MailActivityType> InverseTriggeredNextType { get; } = new List<MailActivityType>();

    //[InverseProperty("ActivityType")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServers { get; } = new List<IrActServer>();

    //[InverseProperty("ActivityType")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityActivityTypes { get; } = new List<MailActivity>();

    //[InverseProperty("PreviousActivityType")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityPreviousActivityTypes { get; } = new List<MailActivity>();

    //[InverseProperty("RecommendedActivityType")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityRecommendedActivityTypes { get; } = new List<MailActivity>();

    //[InverseProperty("MailActivityType")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; } = new List<MailComposeMessage>();

    //[InverseProperty("MailActivityType")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages { get; } = new List<MailMessage>();

    [ForeignKey("RecommendedId")]
    //[InverseProperty("Recommendeds")]
    [NotMapped]
    public virtual ICollection<MailActivityType> Activities { get; } = new List<MailActivityType>();

    [ForeignKey("MailActivityTypeId")]
    //[InverseProperty("MailActivityTypes")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplates { get; } = new List<MailTemplate>();

    [ForeignKey("ActivityId")]
    //[InverseProperty("Activities")]
    [NotMapped]
    public virtual ICollection<MailActivityType> Recommendeds { get; } = new List<MailActivityType>();
}
