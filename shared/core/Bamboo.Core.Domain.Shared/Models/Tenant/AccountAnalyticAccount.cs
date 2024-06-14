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
public partial class AccountAnalyticAccount: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("plan_id")]
    public Guid? PlanId { get; set; }

    [Column("root_plan_id")]
    public Guid? RootPlanId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

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

    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("AccountAnalytic")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; } = new List<AccountAssetAsset>();

    //[InverseProperty("AccountAnalytic")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategories { get; } = new List<AccountAssetCategory>();

    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudgetLine> CrossoveredBudgetLines { get; } = new List<CrossoveredBudgetLine>();
    
    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("CostsHourAccount")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenters { get; } = new List<MrpWorkcenter>();

    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; } = new List<ProjectProject>();

    //[InverseProperty("AnalyticAccount")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; } = new List<ProjectTask>();

    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; } = new List<AccountBalanceReport>();

    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; } = new List<AccountCommonAccountReport>();

    [ForeignKey("AccountAnalyticAccountId")]
    //[InverseProperty("AccountAnalyticAccounts")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; } = new List<AccountReportGeneralLedger>();
}
