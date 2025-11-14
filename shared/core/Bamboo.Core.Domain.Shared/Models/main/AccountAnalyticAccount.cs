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

[Table("account_analytic_account")]
//[Index("Code", Name = "account_analytic_account__code_index")]
public partial class AccountAnalyticAccount: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("plan_id")]
    public Guid? PlanId { get; set; }

    [Column("root_plan_id")]
    public Guid? RootPlanId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Account")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("XPlan2Id")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("XPlan2")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineXPlan2 { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("XPlan3Id")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("XPlan3")] // One2many
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineXPlan3 { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountAnalyticId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountAnalytic")] // One2many
    public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountAnalyticId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccountAnalytic")] // One2many
    public virtual ICollection<AccountAssetCategory> AccountAssetCategory { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AnalyticAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticAccount")] // One2many
    public virtual ICollection<CrossoveredBudgetLines> CrossoveredBudgetLines { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AnalyticAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticAccount")] // One2many
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AnalyticAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticAccount")] // One2many
    public virtual ICollection<HrPayslipLine> HrPayslipLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AnalyticAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AnalyticAccount")] // One2many
    public virtual ICollection<HrSalaryRule> HrSalaryRule { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PlanId")]
    public virtual AccountAnalyticPlan? Plan { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Account")] // One2many
    public virtual ICollection<ProjectProject> ProjectProjectAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("XPlan2Id")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("XPlan2")] // One2many
    public virtual ICollection<ProjectProject> ProjectProjectXPlan2 { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("XPlan3Id")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("XPlan3")] // One2many
    public virtual ICollection<ProjectProject> ProjectProjectXPlan3 { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RootPlanId")]
    public virtual AccountAnalyticPlan? RootPlan { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticAccountId")] //Many2many // Hidden
    // [InverseProperty("AccountAnalyticAccount")] //Many2many // Hidden
    public virtual ICollection<AccountBalanceReport> AccountBalanceReport { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticAccountId")] //Many2many // Hidden
    // [InverseProperty("AccountAnalyticAccount")] //Many2many // Hidden
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticAccountId")] //Many2many // Hidden
    // [InverseProperty("AccountAnalyticAccount")] //Many2many // Hidden
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedger { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountAnalyticAccountId")] // Many2many // Normal
    // [InverseProperty("AccountAnalyticAccount")] // Many2many // Normal
    public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountAnalyticAccountId")] // Many2many // Normal
    // [InverseProperty("AccountAnalyticAccount")] // Many2many // Normal
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountAnalyticAccountId")] // Many2many // Normal
    // [InverseProperty("AccountAnalyticAccount")] // Many2many // Normal
    public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }
}
