using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("account_analytic_plan")]
//[Index("ParentPath", Name = "account_analytic_plan__parent_path_index")]
public partial class AccountAnalyticPlan
{

    // [Column("name")]
    // public string? Name { get; set; }

    // [Column("default_applicability")]
    // public string? DefaultApplicability { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PlanId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Plan")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

}
