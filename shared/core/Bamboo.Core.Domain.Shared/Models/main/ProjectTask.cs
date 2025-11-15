using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("project_task")]
//[Index("CreateDate", Name = "project_task__create_date_index")]
//[Index("DateDeadline", Name = "project_task__date_deadline_index")]
//[Index("DateEnd", Name = "project_task__date_end_index")]
//[Index("DateLastStageUpdate", Name = "project_task__date_last_stage_update_index")]
//[Index("ParentId", Name = "project_task__parent_id_index")]
//[Index("Priority", Name = "project_task__priority_index")]
//[Index("ProjectId", Name = "project_task__project_id_index")]
//[Index("StageId", Name = "project_task__stage_id_index")]
//[Index("State", Name = "project_task__state_index")]
public partial class ProjectTask : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("displayed_image_id")]
    public Guid? DisplayedImageId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("milestone_id")]
    public Guid? MilestoneId { get; set; }

    [Column("recurrence_id")]
    public Guid? RecurrenceId { get; set; }

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

    [Column("state")]
    public string? State { get; set; }

    [JsonField] // HtmlFieldHistory
    [Column("html_field_history", TypeName = "jsonb")]
    public JsonElement? HtmlFieldHistory { get; set; }

    [JsonField] // TaskProperties
    [Column("task_properties", TypeName = "jsonb")]
    public JsonElement? TaskProperties { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("working_hours_open")]
    public decimal? WorkingHoursOpen { get; set; }

    [Column("working_hours_close")]
    public decimal? WorkingHoursClose { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("display_in_project")]
    public bool? DisplayInProject { get; set; }

    [Column("recurring_task")]
    public bool? RecurringTask { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("date_end", TypeName = "timestamp without time zone")]
    public DateTime? DateEnd { get; set; }

    [Column("date_assign", TypeName = "timestamp without time zone")]
    public DateTime? DateAssign { get; set; }

    [Column("date_deadline", TypeName = "timestamp without time zone")]
    public DateTime? DateDeadline { get; set; }

    [Column("date_last_stage_update", TypeName = "timestamp without time zone")]
    public DateTime? DateLastStageUpdate { get; set; }

    [Column("rating_last_value")]
    public double? RatingLastValue { get; set; }

    [Column("allocated_hours")]
    public double? AllocatedHours { get; set; }

    [Column("working_days_open")]
    public double? WorkingDaysOpen { get; set; }

    [Column("working_days_close")]
    public double? WorkingDaysClose { get; set; }

    [Column("sale_order_id")]
    public Guid? SaleOrderId { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("email_from")]
    public string? EmailFrom { get; set; }

    [Column("partner_name")]
    public string? PartnerName { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("partner_company_name")]
    public string? PartnerCompanyName { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentTaskId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentTask")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineParentTask { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TaskId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Task")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineTask { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DisplayedImageId")]
    public virtual IrAttachment? DisplayedImage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TimesheetTaskId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TimesheetTask")] // One2many
    public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<ProjectTask> InverseParent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MilestoneId")]
    public virtual ProjectMilestone? Milestone { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual ProjectTask? Parent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProjectId")]
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TaskId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Task")] // One2many
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRel { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RecurrenceId")]
    public virtual ProjectTaskRecurrence? Recurrence { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LeaveTimesheetTaskId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("LeaveTimesheetTask")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleLineId")]
    public virtual SaleOrderLine? SaleLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SaleOrderId")]
    public virtual SaleOrder? SaleOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TaskId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Task")] // One2many
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StageId")]
    public virtual ProjectTaskType? Stage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("TaskId")] // Many2many // Normal
    // [InverseProperty("Task")] // Many2many // Normal
    public virtual ICollection<ProjectTask> DependsOn { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProjectTaskId")] // Many2many // Normal
    // [InverseProperty("ProjectTask")] // Many2many // Normal
    public virtual ICollection<ProjectTags> ProjectTags { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("DependsOnId")] // Many2many // Normal
    // [InverseProperty("DependsOn")] // Many2many // Normal
    public virtual ICollection<ProjectTask> Task { get; set; }
}
