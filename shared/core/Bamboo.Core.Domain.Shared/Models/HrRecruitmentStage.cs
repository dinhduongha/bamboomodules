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

[Table("hr_recruitment_stage")]
public partial class HrRecruitmentStage: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("legend_blocked", TypeName = "jsonb")]
    public string? LegendBlocked { get; set; }

    [Column("legend_done", TypeName = "jsonb")]
    public string? LegendDone { get; set; }

    [Column("legend_normal", TypeName = "jsonb")]
    public string? LegendNormal { get; set; }

    [Column("requirements")]
    public string? Requirements { get; set; }

    [Column("fold")]
    public bool? Fold { get; set; }

    [Column("hired_stage")]
    public bool? HiredStage { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrRecruitmentStageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("HrRecruitmentStages")]
    [NotMapped]
    public virtual MailTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrRecruitmentStageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("LastStage")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicantLastStages { get; } = new List<HrApplicant>();

    //[InverseProperty("Stage")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicantStages { get; } = new List<HrApplicant>();

    [ForeignKey("HrRecruitmentStageId")]
    //[InverseProperty("HrRecruitmentStages")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; } = new List<HrJob>();
}
