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

[Table("crm_reveal_view")]
//[Index("CreateDate", Name = "crm_reveal_view_create_date_index")]
//[Index("RevealRuleId", "RevealIp", Name = "crm_reveal_view_ip_rule_id", IsUnique = true)]
//[Index("RevealState", Name = "crm_reveal_view_reveal_state_index")]
//[Index("RevealState", "CreateDate", Name = "crm_reveal_view_state_create_date")]
public partial class CrmRevealView: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("reveal_rule_id")]
    public Guid? RevealRuleId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("reveal_ip")]
    public string? RevealIp { get; set; }

    [Column("reveal_state")]
    public string? RevealState { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CrmRevealViewCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("RevealRuleId")]
    // [InverseProperty("CrmRevealView")] //Many2one
    public virtual CrmRevealRule? RevealRule { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CrmRevealViewWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
