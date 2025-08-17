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

[Table("project_task")]
//[Index("DateDeadline", Name = "project_task_date_deadline_index")]
//[Index("DateEnd", Name = "project_task_date_end_index")]
//[Index("DateLastStageUpdate", Name = "project_task_date_last_stage_update_index")]
//[Index("DisplayProjectId", Name = "project_task_display_project_id_index")]
//[Index("IsClosed", Name = "project_task_is_closed_index")]
//[Index("ParentId", Name = "project_task_parent_id_index")]
//[Index("Priority", Name = "project_task_priority_index")]
//[Index("ProjectId", Name = "project_task_project_id_index")]
//[Index("StageId", Name = "project_task_stage_id_index")]
public partial class ProjectTask: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("display_project_id")]
    public Guid? DisplayProjectId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("displayed_image_id")]
    public Guid? DisplayedImageId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("ancestor_id")]
    public Guid? AncestorId { get; set; }

    [Column("milestone_id")]
    public Guid? MilestoneId { get; set; }

    [Column("recurrence_id")]
    public Guid? RecurrenceId { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [Column("partner_email")]
    public string? PartnerEmail { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("date_deadline")]
    public DateTime? DateDeadline { get; set; }

    [JsonField]
    [Column("task_properties", TypeName = "jsonb")]
    public string? TaskProperties { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("working_hours_open")]
    public decimal? WorkingHoursOpen { get; set; }

    [Column("working_hours_close")]
    public decimal? WorkingHoursClose { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_closed")]
    public bool? IsClosed { get; set; }

    [Column("is_blocked")]
    public bool? IsBlocked { get; set; }

    [Column("recurring_task")]
    public bool? RecurringTask { get; set; }

    [Column("is_analytic_account_id_changed")]
    public bool? IsAnalyticAccountIdChanged { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("date_assign", TypeName = "timestamp without time zone")]
    public DateTime? DateAssign { get; set; }

    [Column("date_last_stage_update", TypeName = "timestamp without time zone")]
    public DateTime? DateLastStageUpdate { get; set; }

    [Column("rating_last_value")]
    public double? RatingLastValue { get; set; }

    [Column("planned_hours")]
    public double? PlannedHours { get; set; }

    [Column("working_days_open")]
    public double? WorkingDaysOpen { get; set; }

    [Column("working_days_close")]
    public double? WorkingDaysClose { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("remaining_hours")]
    public double? RemainingHours { get; set; }

    [Column("effective_hours")]
    public double? EffectiveHours { get; set; }

    [Column("total_hours_spent")]
    public double? TotalHoursSpent { get; set; }

    [Column("progress")]
    public double? Progress { get; set; }

    [Column("overtime")]
    public double? Overtime { get; set; }

    [Column("subtask_effective_hours")]
    public double? SubtaskEffectiveHours { get; set; }

    // [One2many]
    [ForeignKey("AncestorTaskId")]
    [InverseProperty("AncestorTask")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineAncestorTask { get; set; }

    // [One2many]
    [ForeignKey("TaskId")]
    [InverseProperty("Task")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineTask { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    // [InverseProperty("ProjectTask")] //Many2one
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("AncestorId")]
    // [InverseProperty("InverseAncestor")] //Many2one
    public virtual ProjectTask? Ancestor { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ProjectTask")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProjectTaskCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DisplayProjectId")]
    // [InverseProperty("ProjectTaskDisplayProject")] //Many2one
    public virtual ProjectProject? DisplayProject { get; set; }

    // [Many2one]
    [ForeignKey("DisplayedImageId")]
    // [InverseProperty("ProjectTaskDisplayedImage")] //Many2one
    public virtual IrAttachment? DisplayedImage { get; set; }

    // [One2many]
    [ForeignKey("TimesheetTaskId")]
    [InverseProperty("TimesheetTask")]
    public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many]
    [ForeignKey("AncestorId")]
    [InverseProperty("Ancestor")]
    public virtual ICollection<ProjectTask> InverseAncestor { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<ProjectTask> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("ProjectTaskMessageMainAttachment")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("MilestoneId")]
    // [InverseProperty("ProjectTask")] //Many2one
    public virtual ProjectMilestone? Milestone { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual ProjectTask? Parent { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("ProjectTask")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("ProjectId")]
    // [InverseProperty("ProjectTaskProject")] //Many2one
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [ForeignKey("TaskId")]
    [InverseProperty("Task")]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRel { get; set; }

    // [Many2one]
    [ForeignKey("RecurrenceId")]
    // [InverseProperty("ProjectTask")] //Many2one
    public virtual ProjectTaskRecurrence? Recurrence { get; set; }

    // [One2many]
    [ForeignKey("LeaveTimesheetTaskId")]
    [InverseProperty("LeaveTimesheetTask")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [ForeignKey("SaleLineId")]
    // [InverseProperty("ProjectTask")] //Many2one
    public virtual SaleOrderLine? SaleLine { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderId")]
    // [InverseProperty("ProjectTask")] //Many2one
    public virtual SaleOrder? SaleOrder { get; set; }

    // [One2many]
    [ForeignKey("TaskId")]
    [InverseProperty("Task")]
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("StageId")]
    // [InverseProperty("ProjectTask")] //Many2one
    public virtual ProjectTaskType? Stage { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProjectTaskWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("TaskId")] //Many2many
    // [InverseProperty("Task")] //Many2many
    public virtual ICollection<ProjectTask> DependsOn { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ProjectTaskId")] //Many2many
    // [InverseProperty("ProjectTask")] //Many2many
    public virtual ICollection<ProjectTags> ProjectTags { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("DependsOnId")] //Many2many
    // [InverseProperty("DependsOn")] //Many2many
    public virtual ICollection<ProjectTask> Task { get; set; }
}
