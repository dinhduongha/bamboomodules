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
public partial class CrmLeadScoringFrequency: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("variable")]
    public string? Variable { get; set; }

    [Column("value")]
    public string? Value { get; set; }

    [Column("won_count")]
    public decimal? WonCount { get; set; }

    [Column("lost_count")]
    public decimal? LostCount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CrmLeadScoringFrequencyCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("TeamId")]
    // [InverseProperty("CrmLeadScoringFrequency")] //Many2one
    public virtual CrmTeam? Team { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CrmLeadScoringFrequencyWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
