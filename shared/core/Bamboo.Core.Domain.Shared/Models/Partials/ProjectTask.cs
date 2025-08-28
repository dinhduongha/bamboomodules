using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Index("DateDeadline", Name = "project_task__date_deadline_index")]
//[Index("DateEnd", Name = "project_task__date_end_index")]
//[Index("DateLastStageUpdate", Name = "project_task__date_last_stage_update_index")]
//[Index("DisplayProjectId", Name = "project_task_display_project_id_index")]
//[Index("IsClosed", Name = "project_task_is_closed_index")]
//[Index("ParentId", Name = "project_task__parent_id_index")]
//[Index("Priority", Name = "project_task__priority_index")]
//[Index("ProjectId", Name = "project_task__project_id_index")]
//[Index("StageId", Name = "project_task__stage_id_index")]
public partial class ProjectTask
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("display_project_id")]
    public Guid? DisplayProjectId { get; set; }

    [Column("ancestor_id")]
    public Guid? AncestorId { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [Column("partner_email")]
    public string? PartnerEmail { get; set; }

    // [Column("partner_phone")]
    // public string? PartnerPhone { get; set; }

    // [Column("email_from")]
    // public string? EmailFrom { get; set; }

    // [Column("date_deadline")]
    // public DateTime? DateDeadline { get; set; }

    [Column("is_closed")]
    public bool? IsClosed { get; set; }

    [Column("is_blocked")]
    public bool? IsBlocked { get; set; }

    [Column("is_analytic_account_id_changed")]
    public bool? IsAnalyticAccountIdChanged { get; set; }

    [Column("planned_hours")]
    public double? PlannedHours { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AncestorTaskId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("AncestorTask")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineAncestorTask { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("AncestorId")]
    public virtual ProjectTask? Ancestor { get; set; }


    // [Many2one]
    [ForeignKey("DisplayProjectId")]
    public virtual ProjectProject? DisplayProject { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AncestorId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Ancestor")] // One2many
    public virtual ICollection<ProjectTask> InverseAncestor { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }
}
