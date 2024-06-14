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
public partial class ProjectTask: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("stage_id")]
    public long? StageId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("display_project_id")]
    public Guid? DisplayProjectId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [ForeignKey("AnalyticAccountId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    [ForeignKey("AncestorId")]
    //[InverseProperty("InverseAncestor")]
    [NotMapped]
    public virtual ProjectTask? Ancestor { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProjectTaskCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DisplayProjectId")]
    //[InverseProperty("ProjectTaskDisplayProjects")]
    [NotMapped]
    public virtual ProjectProject? DisplayProject { get; set; }

    [ForeignKey("DisplayedImageId")]
    //[InverseProperty("ProjectTaskDisplayedImages")]
    [NotMapped]
    public virtual IrAttachment? DisplayedImage { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("ProjectTaskMessageMainAttachments")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("MilestoneId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual ProjectMilestone? Milestone { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual ProjectTask? Parent { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("ProjectId")]
    //[InverseProperty("ProjectTaskProjects")]
    [NotMapped]
    public virtual ProjectProject? Project { get; set; }

    [ForeignKey("RecurrenceId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual ProjectTaskRecurrence? Recurrence { get; set; }

    [ForeignKey("SaleLineId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual SaleOrderLine? SaleLine { get; set; }

    [ForeignKey("SaleOrderId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual SaleOrder? SaleOrder { get; set; }

    [ForeignKey("StageId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual ProjectTaskType? Stage { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProjectTaskWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Ancestor")]
    [NotMapped]
    public virtual ICollection<ProjectTask> InverseAncestor { get; } = new List<ProjectTask>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ProjectTask> InverseParent { get; } = new List<ProjectTask>();

    //[InverseProperty("Task")]
    [NotMapped]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRels { get; } = new List<ProjectTaskUserRel>();

    //[InverseProperty("Task")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

    [ForeignKey("TaskId")]
    //[InverseProperty("Tasks")]
    [NotMapped]
    public virtual ICollection<ProjectTask> DependsOns { get; } = new List<ProjectTask>();

    [ForeignKey("ProjectTaskId")]
    //[InverseProperty("ProjectTasks")]
    [NotMapped]
    public virtual ICollection<ProjectTag> ProjectTags { get; } = new List<ProjectTag>();

    [ForeignKey("DependsOnId")]
    //[InverseProperty("DependsOns")]
    [NotMapped]
    public virtual ICollection<ProjectTask> Tasks { get; } = new List<ProjectTask>();
}
