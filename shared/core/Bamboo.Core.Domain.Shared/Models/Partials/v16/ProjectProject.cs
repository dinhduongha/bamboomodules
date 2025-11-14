using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("project_project")]
//[Index("Date", Name = "project_project__date_index")]
//[Index("StageId", Name = "project_project__stage_id_index")]
public partial class ProjectProject
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("partner_email")]
    public string? PartnerEmail { get; set; }

    [Column("partner_phone")]
    public string? PartnerPhone { get; set; }

    [Column("allow_subtasks")]
    public bool? AllowSubtasks { get; set; }

    [Column("allow_recurring_tasks")]
    public bool? AllowRecurringTasks { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProjectId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Project")] // One2many
    public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrder { get; set; }

    // v16-Compat
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProjectId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Project")] // One2many
    // public virtual ICollection<ProjectMilestone> ProjectMilestone { get; set; }

    // v16-Compat
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProjectId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Project")] // One2many
    // public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMap { get; set; }

    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DisplayProjectId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("DisplayProject")] // One2many
    public virtual ICollection<ProjectTask> ProjectTaskDisplayProject { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProjectId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Project")] // One2many
    public virtual ICollection<ProjectTask> ProjectTaskProject { get; set; }

    // v16-Compat
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProjectId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Project")] // One2many
    // public virtual ICollection<ProjectUpdate> ProjectUpdate { get; set; }

    // v16-Compat
    // [Many2many] // Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProjectId")] //Many2many // Hidden
    // [InverseProperty("Project")] //Many2many // Hidden
    // public virtual ICollection<ProjectTaskType> Type { get; set; }
}
