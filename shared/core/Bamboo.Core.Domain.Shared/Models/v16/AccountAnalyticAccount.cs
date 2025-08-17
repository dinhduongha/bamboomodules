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

[Table("account_analytic_account")]
//[Index("Code", Name = "account_analytic_account_code_index")]
public partial class AccountAnalyticAccount: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

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

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("AccountId")]
    [InverseProperty("Account")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many]
    [ForeignKey("AccountAnalyticId")]
    [InverseProperty("AccountAnalytic")]
    public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many]
    [ForeignKey("AccountAnalyticId")]
    [InverseProperty("AccountAnalytic")]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategory { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("AccountAnalyticAccount")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountAnalyticAccountCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("AnalyticAccountId")]
    [InverseProperty("AnalyticAccount")]
    public virtual ICollection<CrossoveredBudgetLines> CrossoveredBudgetLines { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("AccountAnalyticAccount")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many]
    [ForeignKey("AnalyticAccountId")]
    [InverseProperty("AnalyticAccount")]
    public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many]
    [ForeignKey("CostsHourAccountId")]
    [InverseProperty("CostsHourAccount")]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenter { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("AccountAnalyticAccount")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("PlanId")]
    // [InverseProperty("AccountAnalyticAccountPlan")] //Many2one
    public virtual AccountAnalyticPlan? Plan { get; set; }

    // [One2many]
    [ForeignKey("AnalyticAccountId")]
    [InverseProperty("AnalyticAccount")]
    public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many]
    [ForeignKey("AnalyticAccountId")]
    [InverseProperty("AnalyticAccount")]
    public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [Many2one]
    [ForeignKey("RootPlanId")]
    // [InverseProperty("AccountAnalyticAccountRootPlan")] //Many2one
    public virtual AccountAnalyticPlan? RootPlan { get; set; }

    // [One2many]
    [ForeignKey("AnalyticAccountId")]
    [InverseProperty("AnalyticAccount")]
    public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountAnalyticAccountWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticAccountId")]
    // [InverseProperty("AccountAnalyticAccount")]
    // public virtual ICollection<AccountBalanceReport> AccountBalanceReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticAccountId")]
    // [InverseProperty("AccountAnalyticAccount")]
    // public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AccountAnalyticAccountId")]
    // [InverseProperty("AccountAnalyticAccount")]
    // public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedger { get; set; }
}
