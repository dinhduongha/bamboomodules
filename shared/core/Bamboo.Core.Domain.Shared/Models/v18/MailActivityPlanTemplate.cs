using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("mail_activity_plan_template")]
public partial class MailActivityPlanTemplate: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("plan_id")]
    public Guid? PlanId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("activity_type_id")]
    public Guid? ActivityTypeId { get; set; }

    [Column("delay_count")]
    public long? DelayCount { get; set; }

    [Column("responsible_id")]
    public Guid? ResponsibleId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("delay_unit")]
    public string? DelayUnit { get; set; }

    [Column("delay_from")]
    public string? DelayFrom { get; set; }

    [Column("summary")]
    public string? Summary { get; set; }

    [Column("responsible_type")]
    public string? ResponsibleType { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ActivityTypeId")]
    //[InverseProperty("MailActivityPlanTemplates")]
    [NotMapped]
    public virtual MailActivityType? ActivityType { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailActivityPlanTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PlanId")]
    //[InverseProperty("MailActivityPlanTemplates")]
    [NotMapped]
    public virtual MailActivityPlan? Plan { get; set; }

    [ForeignKey("ResponsibleId")]
    //[InverseProperty("MailActivityPlanTemplateResponsibles")]
    [NotMapped]
    public virtual ResUser? Responsible { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailActivityPlanTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
