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
//[Index("UserId", Name = "project_task_type_user_id_index")]
public partial class ProjectTaskType: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("rating_template_id")]
    public Guid? RatingTemplateId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("legend_blocked", TypeName = "jsonb")]
    public string? LegendBlocked { get; set; }

    [Column("legend_done", TypeName = "jsonb")]
    public string? LegendDone { get; set; }

    [Column("legend_normal", TypeName = "jsonb")]
    public string? LegendNormal { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("fold")]
    public bool? Fold { get; set; }

    [Column("auto_validation_kanban_state")]
    public bool? AutoValidationKanbanState { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProjectTaskTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailTemplateId")]
    //[InverseProperty("ProjectTaskTypeMailTemplates")]
    [NotMapped]
    public virtual MailTemplate? MailTemplate { get; set; }

    [ForeignKey("RatingTemplateId")]
    //[InverseProperty("ProjectTaskTypeRatingTemplates")]
    [NotMapped]
    public virtual MailTemplate? RatingTemplate { get; set; }

    [ForeignKey("SmsTemplateId")]
    //[InverseProperty("ProjectTaskTypes")]
    [NotMapped]
    public virtual SmsTemplate? SmsTemplate { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("ProjectTaskTypeUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProjectTaskTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Stage")]
    [NotMapped]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRels { get; } = new List<ProjectTaskUserRel>();

    //[InverseProperty("Stage")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; } = new List<ProjectTask>();

    [ForeignKey("ProjectTaskTypeId")]
    //[InverseProperty("ProjectTaskTypes")]
    [NotMapped]
    public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizards { get; } = new List<ProjectTaskTypeDeleteWizard>();

    [ForeignKey("TypeId")]
    //[InverseProperty("Types")]
    [NotMapped]
    public virtual ICollection<ProjectProject> Projects { get; } = new List<ProjectProject>();
}
