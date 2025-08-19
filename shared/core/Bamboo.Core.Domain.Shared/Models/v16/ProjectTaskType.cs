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

[Table("project_task_type")]
//[Index("UserId", Name = "project_task_type__user_id_index")]
public partial class ProjectTaskType: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("rating_template_id")]
    public Guid? RatingTemplateId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [JsonField]
    [Column("legend_blocked", TypeName = "jsonb")]
    public string? LegendBlocked { get; set; }

    [JsonField]
    [Column("legend_done", TypeName = "jsonb")]
    public string? LegendDone { get; set; }

    [JsonField]
    [Column("legend_normal", TypeName = "jsonb")]
    public string? LegendNormal { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("fold")]
    public bool? Fold { get; set; }

    [Column("auto_validation_state")]
    public bool? AutoValidationState { get; set; }

    [Column("auto_validation_kanban_state")]
    public bool? AutoValidationKanbanState { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProjectTaskTypeCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailTemplateId")]
    // [InverseProperty("ProjectTaskTypeMailTemplate")] //Many2one
    public virtual MailTemplate? MailTemplate { get; set; }

    // [One2many]
    [ForeignKey("StageId")]
    [InverseProperty("Stage")]
    public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many]
    [ForeignKey("StageId")]
    [InverseProperty("Stage")]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRel { get; set; }

    // [Many2one]
    [ForeignKey("RatingTemplateId")]
    // [InverseProperty("ProjectTaskTypeRatingTemplate")] //Many2one
    public virtual MailTemplate? RatingTemplate { get; set; }

    // [Many2one]
    [ForeignKey("SmsTemplateId")]
    // [InverseProperty("ProjectTaskType")] //Many2one
    public virtual SmsTemplate? SmsTemplate { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("ProjectTaskTypeUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProjectTaskTypeWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TypeId")]
    // [InverseProperty("Type")]
    public virtual ICollection<ProjectProject> Project { get; set; }

    // v16-Compat
    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("TypeId")] //Many2many
    // [InverseProperty("Type")] //Many2many
    //public virtual ICollection<ProjectProject> Project { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProjectTaskTypeId")]
    // [InverseProperty("ProjectTaskType")]
    public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizard { get; set; }
}
