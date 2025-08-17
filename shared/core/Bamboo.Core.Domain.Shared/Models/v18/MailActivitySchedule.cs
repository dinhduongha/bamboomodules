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

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ActivityTypeId")]
    // [InverseProperty("MailActivitySchedule")] //Many2one
    public virtual MailActivityType? ActivityType { get; set; }

    // [Many2one]
    [ForeignKey("ActivityUserId")]
    // [InverseProperty("MailActivityScheduleActivityUser")] //Many2one
    public virtual ResUsers? ActivityUser { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailActivityScheduleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("PlanId")]
    // [InverseProperty("MailActivityScheduleNavigation")] //Many2one
    public virtual MailActivityPlan? Plan { get; set; }

    // [Many2one]
    [ForeignKey("PlanOnDemandUserId")]
    // [InverseProperty("MailActivitySchedulePlanOnDemandUser")] //Many2one
    public virtual ResUsers? PlanOnDemandUser { get; set; }

    // [Many2one]
    [ForeignKey("ResModelId")]
    // [InverseProperty("MailActivitySchedule")] //Many2one
    public virtual IrModel? ResModelNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailActivityScheduleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("MailActivityScheduleId")] //Many2many
    // [InverseProperty("MailActivitySchedule")] //Many2many
    public virtual ICollection<MailActivityPlan> MailActivityPlan { get; set; }
}
