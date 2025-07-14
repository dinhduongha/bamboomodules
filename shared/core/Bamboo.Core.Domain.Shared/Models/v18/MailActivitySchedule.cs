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

[Table("mail_activity_schedule")]
public partial class MailActivitySchedule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("res_model_id")]
    public Guid? ResModelId { get; set; }

    [Column("plan_id")]
    public Guid? PlanId { get; set; }

    [Column("plan_on_demand_user_id")]
    public Guid? PlanOnDemandUserId { get; set; }

    [Column("activity_type_id")]
    public Guid? ActivityTypeId { get; set; }

    [Column("activity_user_id")]
    public Guid? ActivityUserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("summary")]
    public string? Summary { get; set; }

    [Column("plan_date")]
    public DateTime? PlanDate { get; set; }

    [Column("date_deadline")]
    public DateTime? DateDeadline { get; set; }

    [Column("res_ids")]
    public string? ResIds { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ActivityTypeId")]
    //[InverseProperty("MailActivitySchedules")]
    [NotMapped]
    public virtual MailActivityType? ActivityType { get; set; }

    [ForeignKey("ActivityUserId")]
    //[InverseProperty("MailActivityScheduleActivityUsers")]
    [NotMapped]
    public virtual ResUser? ActivityUser { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailActivityScheduleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PlanId")]
    //[InverseProperty("MailActivitySchedulesNavigation")]
    [NotMapped]
    public virtual MailActivityPlan? Plan { get; set; }

    [ForeignKey("PlanOnDemandUserId")]
    //[InverseProperty("MailActivitySchedulePlanOnDemandUsers")]
    [NotMapped]
    public virtual ResUser? PlanOnDemandUser { get; set; }

    [ForeignKey("ResModelId")]
    //[InverseProperty("MailActivitySchedules")]
    [NotMapped]
    public virtual IrModel? ResModelNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailActivityScheduleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("MailActivityScheduleId")]
    //[InverseProperty("MailActivitySchedules")]
    [NotMapped]
    public virtual ICollection<MailActivityPlan> MailActivityPlans { get; set; } = new List<MailActivityPlan>();
}
