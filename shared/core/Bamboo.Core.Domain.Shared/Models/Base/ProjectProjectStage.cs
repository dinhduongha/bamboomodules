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
public partial class ProjectProjectStage: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("mail_template_id")]
    public Guid? MailTemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("fold")]
    public bool? Fold { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sms_template_id")]
    public Guid? SmsTemplateId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProjectProjectStageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MailTemplateId")]
    //[InverseProperty("ProjectProjectStages")]
    [NotMapped]
    public virtual MailTemplate? MailTemplate { get; set; }

    [ForeignKey("SmsTemplateId")]
    //[InverseProperty("ProjectProjectStages")]
    [NotMapped]
    public virtual SmsTemplate? SmsTemplate { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProjectProjectStageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Stage")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; } = new List<ProjectProject>();

}
