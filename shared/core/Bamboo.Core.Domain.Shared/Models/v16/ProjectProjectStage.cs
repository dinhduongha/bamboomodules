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

[Table("project_project_stage")]
public partial class ProjectProjectStage: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ProjectProjectStage")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProjectProjectStageCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MailTemplateId")]
    // [InverseProperty("ProjectProjectStage")] //Many2one
    public virtual MailTemplate? MailTemplate { get; set; }

    // [One2many]
    [ForeignKey("StageId")]
    [InverseProperty("Stage")]
    public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [Many2one]
    [ForeignKey("SmsTemplateId")]
    // [InverseProperty("ProjectProjectStage")] //Many2one
    public virtual SmsTemplate? SmsTemplate { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProjectProjectStageWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ProjectProjectStageId")]
    // [InverseProperty("ProjectProjectStage")]
    public virtual ICollection<ProjectProjectStageDeleteWizard> ProjectProjectStageDeleteWizard { get; set; }
}
