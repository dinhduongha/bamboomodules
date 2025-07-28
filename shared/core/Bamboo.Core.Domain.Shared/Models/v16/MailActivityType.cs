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

// May-Copy-To-Tenants
[Table("mail_activity_type")]
//[Index("CreateUid", Name = "mail_activity_type__create_uid_index")]
//[Index("CreationTime", Name = "mail_activity_type_create_uid_index")]
public partial class MailActivityType : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("delay_count")]
    public long? DelayCount { get; set; }

    [Column("triggered_next_type_id")]
    public Guid? TriggeredNextTypeId { get; set; }

    [Column("default_user_id")]
    public Guid? DefaultUserId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField]
    [Column("summary", TypeName = "jsonb")]
    public string? Summary { get; set; }

    [JsonField]
    [Column("default_note", TypeName = "jsonb")]
    public string? DefaultNote { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("keep_done")]
    public bool? KeepDone { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

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
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } 

    //[InverseProperty("ActivityType")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypes { get; set; } 

    //[InverseProperty("TriggeredNextType")]
    [NotMapped]
    public virtual ICollection<MailActivityType> InverseTriggeredNextType { get; set; } 

    //[InverseProperty("ActivityType")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServers { get; set; } 

    //[InverseProperty("ActivityType")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityActivityTypes { get; set; } 

    //[InverseProperty("PreviousActivityType")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityPreviousActivityTypes { get; set; } 

    //[InverseProperty("RecommendedActivityType")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityRecommendedActivityTypes { get; set; } 

    //[InverseProperty("MailActivityType")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; set; } 

    //[InverseProperty("MailActivityType")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages { get; set; } 

    [ForeignKey("RecommendedId")]
    //[InverseProperty("Recommendeds")]
    [NotMapped]
    public virtual ICollection<MailActivityType> Activities { get; set; } 

    [ForeignKey("MailActivityTypeId")]
    //[InverseProperty("MailActivityTypes")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplates { get; set; } 

    [ForeignKey("ActivityId")]
    //[InverseProperty("Activities")]
    [NotMapped]
    public virtual ICollection<MailActivityType> Recommendeds { get; set; } 
}
