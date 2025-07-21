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
public partial class AccountAnalyticAccount : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("plan_id")]
    public Guid? PlanId { get; set; }

    [Column("root_plan_id")]
    public Guid? RootPlanId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountAnalyticAccountCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    // v16-Compat
    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PlanId")]
    //[InverseProperty("AccountAnalyticAccountPlans")]
    [NotMapped]
    public virtual AccountAnalyticPlan? Plan { get; set; }

    [ForeignKey("RootPlanId")]
    //[InverseProperty("AccountAnalyticAccountRootPlans")]
    [NotMapped]
    public virtual AccountAnalyticPlan? RootPlan { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountAnalyticAccountWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineAccounts { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("XPlan2")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineXPlan2s { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("XPlan3")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineXPlan3s { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("AccountAnalytic")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; set; } = new List<AccountAssetAsset>();

    //[InverseProperty("AccountAnalytic")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategories { get; set; } = new List<AccountAssetCategory>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("AccountAnalytic")]
    //[NotMapped]
    //public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; set; } = new List<AccountAssetAsset>();

    //[InverseProperty("AccountAnalytic")]
    //[NotMapped]
    //public virtual ICollection<AccountAssetCategory> AccountAssetCategories { get; set; } = new List<AccountAssetCategory>();

    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; set; } = new List<AccountBalanceReport>();

    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; set; } = new List<AccountCommonAccountReport>();

    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; set; } = new List<AccountReportGeneralLedger>();

    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudgetLine> CrossoveredBudgetLines { get; set; } = new List<CrossoveredBudgetLine>();


    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; set; } = new List<ProjectProject>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectAccounts { get; set; } = new List<ProjectProject>();

    //[InverseProperty("XPlan2")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectXPlan2s { get; set; } = new List<ProjectProject>();

    //[InverseProperty("XPlan3")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectXPlan3s { get; set; } = new List<ProjectProject>();


    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    // RELATIONS BEGIN - MUST HAVE
    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } = new List<MrpBom>();

    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } = new List<MrpProduction>();

    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    //[InverseProperty("CostsHourAccount")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; set; } = new List<MrpWorkcenter>();
    // RELATIONS END
}
