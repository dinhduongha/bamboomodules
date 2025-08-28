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

[Table("account_analytic_plan")]
//[Index("ParentPath", Name = "account_analytic_plan__parent_path_index")]
public partial class AccountAnalyticPlan: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("default_applicability", TypeName = "jsonb")]
    public string? DefaultApplicability { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PlanId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Plan")] // One2many
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountPlan { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("RootPlanId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RootPlan")] // One2many
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountRootPlan { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("AnalyticPlanId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticPlan")] // One2many
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicability { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<AccountAnalyticPlan> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    public virtual AccountAnalyticPlan? Parent { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
