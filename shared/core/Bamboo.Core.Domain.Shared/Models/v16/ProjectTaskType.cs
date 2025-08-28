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

    [Column("active")]
    public bool? Active { get; set; }

    [Column("fold")]
    public bool? Fold { get; set; }

    [Column("auto_validation_state")]
    public bool? AutoValidationState { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailTemplateId")]
    public virtual MailTemplate? MailTemplate { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("StageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Stage")] // One2many
    public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("StageId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Stage")] // One2many
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRel { get; set; }

    // [Many2one]
    [ForeignKey("RatingTemplateId")]
    public virtual MailTemplate? RatingTemplate { get; set; }

    // [Many2one]
    [ForeignKey("SmsTemplateId")]
    public virtual SmsTemplate? SmsTemplate { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("TypeId")] //Many2many // Hidden
    // [InverseProperty("Type")] //Many2many // Hidden
    public virtual ICollection<ProjectProject> Project { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProjectTaskTypeId")] //Many2many // Hidden
    // [InverseProperty("ProjectTaskType")] //Many2many // Hidden
    public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizard { get; set; }
}
