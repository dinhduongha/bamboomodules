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
//[Index("ParentPath", Name = "account_analytic_plan_parent_path_index")]
public partial class AccountAnalyticPlan: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    // v16-Compat [Column("name")]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    // v16-Compat [Column("default_applicability")]
    [Column("default_applicability", TypeName = "jsonb")]
    public string? DefaultApplicability { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAnalyticPlans")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    //[InverseProperty("Plan")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountPlans { get; set; } = new List<AccountAnalyticAccount>();

    //[InverseProperty("RootPlan")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountRootPlans { get; set; } = new List<AccountAnalyticAccount>();

    //[InverseProperty("AnalyticPlan")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilities { get; set; } = new List<AccountAnalyticApplicability>();

    // v16-Compat
    //[InverseProperty("Plan")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } = new List<AccountAnalyticLine>();
  
    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAnalyticPlanCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticPlan> InverseParent { get; set; } = new List<AccountAnalyticPlan>();

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual AccountAnalyticPlan? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAnalyticPlanWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
