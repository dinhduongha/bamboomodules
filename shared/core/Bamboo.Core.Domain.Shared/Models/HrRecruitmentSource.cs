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

[Table("hr_recruitment_source")]
public partial class HrRecruitmentSource: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("source_id")]
    public Guid? SourceId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("alias_id")]
    public Guid? AliasId { get; set; }

    [Column("medium_id")]
    public Guid? MediumId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AliasId")]
    //[InverseProperty("HrRecruitmentSources")]
    [NotMapped]
    public virtual MailAlias? Alias { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrRecruitmentSourceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JobId")]
    //[InverseProperty("HrRecruitmentSources")]
    [NotMapped]
    public virtual HrJob? Job { get; set; }

    [ForeignKey("MediumId")]
    //[InverseProperty("HrRecruitmentSources")]
    [NotMapped]
    public virtual UtmMedium? Medium { get; set; }

    [ForeignKey("SourceId")]
    //[InverseProperty("HrRecruitmentSources")]
    [NotMapped]
    public virtual UtmSource? Source { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrRecruitmentSourceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
