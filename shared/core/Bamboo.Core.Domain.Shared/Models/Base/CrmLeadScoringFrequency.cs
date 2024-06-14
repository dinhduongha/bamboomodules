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

[Table("crm_lead_scoring_frequency")]
//[Index("Variable", Name = "crm_lead_scoring_frequency_variable_index")]
public partial class CrmLeadScoringFrequency: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("variable")]
    public string? Variable { get; set; }

    [Column("value")]
    public string? Value { get; set; }

    [Column("won_count")]
    public decimal? WonCount { get; set; }

    [Column("lost_count")]
    public decimal? LostCount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmLeadScoringFrequencyCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("TeamId")]
    //[InverseProperty("CrmLeadScoringFrequencies")]
    [NotMapped]
    public virtual CrmTeam? Team { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmLeadScoringFrequencyWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
