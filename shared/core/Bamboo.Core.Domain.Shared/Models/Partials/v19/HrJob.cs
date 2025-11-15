using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class HrJob
{
    [Column("expected_degree")]
    public Guid? ExpectedDegree { get; set; }

    [Column("is_seo_optimized")]
    public bool? IsSeoOptimized { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ExpectedDegree")]
    public virtual HrRecruitmentDegree? ExpectedDegreeNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("JobId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Job")] // One2many
    public virtual ICollection<HrJobSkill> HrJobSkill { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("JobId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Job")] // One2many
    // public virtual ICollection<HrRecruitmentSource> HrRecruitmentSource { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("JobId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Job")] // One2many
    public virtual ICollection<HrVersion> HrVersion { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrJobId")] //Many2many // Hidden
    // [InverseProperty("HrJob")] //Many2many // Hidden
    public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDay { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrJobId")] //Many2many // Hidden
    // [InverseProperty("HrJob")] //Many2many // Hidden
    public virtual ICollection<JobAddApplicants> JobAddApplicants { get; set; }

}