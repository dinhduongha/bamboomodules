

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

namespace Bamboo.Core.Models;

[Module("base")]
[Model("res.user")]
[Table("res_users")]
//[Index("PartnerId", Name = "res_users_partner_id_index")]
//[Index("Login", "WebsiteId", Name = "res_users_login_key", IsUnique = true)]
public partial class ResUser : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("login")]
    public string? Login { get; set; }

    [JsonIgnore]
    [Column("password")]
    public string? Password { get; set; }

    [Column("action_id")]
    public Guid? ActionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("signature")]
    public string? Signature { get; set; }

    [Column("share")]
    public bool? Share { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("totp_secret")]
    public string? TotpSecret { get; set; }

    [Column("tour_enabled")]
    public bool? TourEnabled { get; set; }

    [Column("notification_type")]
    public string? NotificationType { get; set; }

    [Column("odoobot_state")]
    public string? OdoobotState { get; set; }

    [Column("odoobot_failed")]
    public bool? OdoobotFailed { get; set; }

    [Column("sale_team_id")]
    public Guid? SaleTeamId { get; set; }

    [Column("target_sales_won")]
    public long? TargetSalesWon { get; set; }

    [Column("target_sales_done")]
    public long? TargetSalesDone { get; set; }

    [Column("target_sales_invoiced")]
    public long? TargetSalesInvoiced { get; set; }

    [JsonField]
    [Column("property_warehouse_id", TypeName = "jsonb")]
    public string? PropertyWarehouseId { get; set; }

    [Column("last_lunch_location_id")]
    public Guid? LastLunchLocationId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("karma")]
    public long? Karma { get; set; }

    [Column("rank_id")]
    public Guid? RankId { get; set; }

    [Column("next_rank_id")]
    public Guid? NextRankId { get; set; }

    //[InverseProperty("User")]
    [NotMapped]
    public virtual BusPresence? BusPresence { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("InverseCreateU")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastLunchLocationId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual LunchLocation? LastLunchLocation { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ResUsersSetting? ResUsersSettingUser { get; set; }

    [ForeignKey("SaleTeamId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual CrmTeam? SaleTeam { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    /// <summary>
    /// Livechat Username
    /// </summary>
    [Column("livechat_username", TypeName = "character varying")]
    public string? LivechatUsername { get; set; }


    [ForeignKey("LastModifierId")]
    //[InverseProperty("InverseWriteU")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("Uid")]
    [InverseProperty("UidsNavigation")]
    public virtual ICollection<ResGroup> Gids { get; set; } = new List<ResGroup>();

    /// TODO: DISABLE INVERSE COLLECTIONS

    /*
    //[InverseProperty("CreateU")]
    //[NotMapped]
    //public virtual ICollection<ResUser> InverseCreateU { get; set; } = new List<ResUser>();
    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccountCreateUs { get; set; } = new List<AccountAccount>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTagCreateUs { get; set; } = new List<AccountAccountTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTagWriteUs { get; set; } = new List<AccountAccountTag>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplateCreateUs { get; set; } = new List<AccountAccountTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplateWriteUs { get; set; } = new List<AccountAccountTemplate>();

    //[InverseProperty("CreateU")]
    //[NotMapped]
    //[NotMapped]
    public virtual ICollection<AccountAccountType> AccountAccountTypeCreateUs { get; set; } = new List<AccountAccountType>();

    //[InverseProperty("WriteU")]
    //[NotMapped]
    //[NotMapped]
    public virtual ICollection<AccountAccountType> AccountAccountTypeWriteUs { get; set; } = new List<AccountAccountType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccountWriteUs { get; set; } = new List<AccountAccount>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizardCreateUs { get; set; } = new List<AccountAccruedOrdersWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizardWriteUs { get; set; } = new List<AccountAccruedOrdersWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalanceCreateUs { get; set; } = new List<AccountAgedTrialBalance>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalanceWriteUs { get; set; } = new List<AccountAgedTrialBalance>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountCreateUs { get; set; } = new List<AccountAnalyticAccount>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountWriteUs { get; set; } = new List<AccountAnalyticAccount>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilityCreateUs { get; set; } = new List<AccountAnalyticApplicability>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilityWriteUs { get; set; } = new List<AccountAnalyticApplicability>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModelCreateUs { get; set; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModelWriteUs { get; set; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineCreateUs { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineUsers { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineWriteUs { get; set; } = new List<AccountAnalyticLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlanCreateUs { get; set; } = new List<AccountAnalyticPlan>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlanWriteUs { get; set; } = new List<AccountAnalyticPlan>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssetCreateUs { get; set; } = new List<AccountAssetAsset>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssetWriteUs { get; set; } = new List<AccountAssetAsset>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryCreateUs { get; set; } = new List<AccountAssetCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryWriteUs { get; set; } = new List<AccountAssetCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLineCreateUs { get; set; } = new List<AccountAssetDepreciationLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLineWriteUs { get; set; } = new List<AccountAssetDepreciationLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizardCreateUs { get; set; } = new List<AccountAutomaticEntryWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizardWriteUs { get; set; } = new List<AccountAutomaticEntryWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReportCreateUs { get; set; } = new List<AccountBalanceReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReportWriteUs { get; set; } = new List<AccountBalanceReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatementCreateUs { get; set; } = new List<AccountBankStatement>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImport> AccountBankStatementImportCreateUs { get; set; } = new List<AccountBankStatementImport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreationCreateUs { get; set; } = new List<AccountBankStatementImportJournalCreation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreationWriteUs { get; set; } = new List<AccountBankStatementImportJournalCreation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImport> AccountBankStatementImportWriteUs { get; set; } = new List<AccountBankStatementImport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineCreateUs { get; set; } = new List<AccountBankStatementLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineWriteUs { get; set; } = new List<AccountBankStatementLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatementWriteUs { get; set; } = new List<AccountBankStatement>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankbookReport> AccountBankbookReportCreateUs { get; set; } = new List<AccountBankbookReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankbookReport> AccountBankbookReportWriteUs { get; set; } = new List<AccountBankbookReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> AccountBudgetPostCreateUs { get; set; } = new List<AccountBudgetPost>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> AccountBudgetPostWriteUs { get; set; } = new List<AccountBudgetPost>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCashRounding> AccountCashRoundingCreateUs { get; set; } = new List<AccountCashRounding>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCashRounding> AccountCashRoundingWriteUs { get; set; } = new List<AccountCashRounding>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCashbookReport> AccountCashbookReportCreateUs { get; set; } = new List<AccountCashbookReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCashbookReport> AccountCashbookReportWriteUs { get; set; } = new List<AccountCashbookReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateCreateUs { get; set; } = new List<AccountChartTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateWriteUs { get; set; } = new List<AccountChartTemplate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReportCreateUs { get; set; } = new List<AccountCommonAccountReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReportWriteUs { get; set; } = new List<AccountCommonAccountReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReportCreateUs { get; set; } = new List<AccountCommonJournalReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReportWriteUs { get; set; } = new List<AccountCommonJournalReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReportCreateUs { get; set; } = new List<AccountCommonPartnerReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReportWriteUs { get; set; } = new List<AccountCommonPartnerReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCommonReport> AccountCommonReportCreateUs { get; set; } = new List<AccountCommonReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCommonReport> AccountCommonReportWriteUs { get; set; } = new List<AccountCommonReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountDaybookReport> AccountDaybookReportCreateUs { get; set; } = new List<AccountDaybookReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountDaybookReport> AccountDaybookReportWriteUs { get; set; } = new List<AccountDaybookReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountEdiDocument> AccountEdiDocumentCreateUs { get; set; } = new List<AccountEdiDocument>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountEdiDocument> AccountEdiDocumentWriteUs { get; set; } = new List<AccountEdiDocument>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountEdiFormat> AccountEdiFormatCreateUs { get; set; } = new List<AccountEdiFormat>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountEdiFormat> AccountEdiFormatWriteUs { get; set; } = new List<AccountEdiFormat>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> AccountFinancialReportCreateUs { get; set; } = new List<AccountFinancialReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> AccountFinancialReportWriteUs { get; set; } = new List<AccountFinancialReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOpCreateUs { get; set; } = new List<AccountFinancialYearOp>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOpWriteUs { get; set; } = new List<AccountFinancialYearOp>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountCreateUs { get; set; } = new List<AccountFiscalPositionAccount>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateCreateUs { get; set; } = new List<AccountFiscalPositionAccountTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateWriteUs { get; set; } = new List<AccountFiscalPositionAccountTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountWriteUs { get; set; } = new List<AccountFiscalPositionAccount>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositionCreateUs { get; set; } = new List<AccountFiscalPosition>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxCreateUs { get; set; } = new List<AccountFiscalPositionTax>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateCreateUs { get; set; } = new List<AccountFiscalPositionTaxTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateWriteUs { get; set; } = new List<AccountFiscalPositionTaxTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxWriteUs { get; set; } = new List<AccountFiscalPositionTax>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplateCreateUs { get; set; } = new List<AccountFiscalPositionTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplateWriteUs { get; set; } = new List<AccountFiscalPositionTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositionWriteUs { get; set; } = new List<AccountFiscalPosition>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalYear> AccountFiscalYearCreateUs { get; set; } = new List<AccountFiscalYear>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalYear> AccountFiscalYearWriteUs { get; set; } = new List<AccountFiscalYear>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFullReconcile> AccountFullReconcileCreateUs { get; set; } = new List<AccountFullReconcile>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFullReconcile> AccountFullReconcileWriteUs { get; set; } = new List<AccountFullReconcile>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountGroup> AccountGroupCreateUs { get; set; } = new List<AccountGroup>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountGroupTemplate> AccountGroupTemplateCreateUs { get; set; } = new List<AccountGroupTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountGroupTemplate> AccountGroupTemplateWriteUs { get; set; } = new List<AccountGroupTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountGroup> AccountGroupWriteUs { get; set; } = new List<AccountGroup>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountIncoterm> AccountIncotermCreateUs { get; set; } = new List<AccountIncoterm>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountIncoterm> AccountIncotermWriteUs { get; set; } = new List<AccountIncoterm>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSendCreateUs { get; set; } = new List<AccountInvoiceSend>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSendWriteUs { get; set; } = new List<AccountInvoiceSend>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalCreateUs { get; set; } = new List<AccountJournal>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountJournalGroup> AccountJournalGroupCreateUs { get; set; } = new List<AccountJournalGroup>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountJournalGroup> AccountJournalGroupWriteUs { get; set; } = new List<AccountJournalGroup>();

    //[InverseProperty("SaleActivityUser")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalSaleActivityUsers { get; set; } = new List<AccountJournal>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalWriteUs { get; set; } = new List<AccountJournal>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoveCreateUs { get; set; } = new List<AccountMove>();

    //[InverseProperty("InvoiceUser")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoveInvoiceUsers { get; set; } = new List<AccountMove>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineCreateUs { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineWriteUs { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountMoveReversal> AccountMoveReversalCreateUs { get; set; } = new List<AccountMoveReversal>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountMoveReversal> AccountMoveReversalWriteUs { get; set; } = new List<AccountMoveReversal>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoveWriteUs { get; set; } = new List<AccountMove>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreateUs { get; set; } = new List<AccountPartialReconcile>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileWriteUs { get; set; } = new List<AccountPartialReconcile>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentCreateUs { get; set; } = new List<AccountPayment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethod> AccountPaymentMethodCreateUs { get; set; } = new List<AccountPaymentMethod>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLineCreateUs { get; set; } = new List<AccountPaymentMethodLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLineWriteUs { get; set; } = new List<AccountPaymentMethodLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethod> AccountPaymentMethodWriteUs { get; set; } = new List<AccountPaymentMethod>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCreateUs { get; set; } = new List<AccountPaymentRegister>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterWriteUs { get; set; } = new List<AccountPaymentRegister>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTerm> AccountPaymentTermCreateUs { get; set; } = new List<AccountPaymentTerm>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTermLine> AccountPaymentTermLineCreateUs { get; set; } = new List<AccountPaymentTermLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTermLine> AccountPaymentTermLineWriteUs { get; set; } = new List<AccountPaymentTermLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTerm> AccountPaymentTermWriteUs { get; set; } = new List<AccountPaymentTerm>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentWriteUs { get; set; } = new List<AccountPayment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPrintJournal> AccountPrintJournalCreateUs { get; set; } = new List<AccountPrintJournal>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPrintJournal> AccountPrintJournalWriteUs { get; set; } = new List<AccountPrintJournal>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModelCreateUs { get; set; } = new List<AccountReconcileModel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLineCreateUs { get; set; } = new List<AccountReconcileModelLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplateCreateUs { get; set; } = new List<AccountReconcileModelLineTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplateWriteUs { get; set; } = new List<AccountReconcileModelLineTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLineWriteUs { get; set; } = new List<AccountReconcileModelLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappingCreateUs { get; set; } = new List<AccountReconcileModelPartnerMapping>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappingWriteUs { get; set; } = new List<AccountReconcileModelPartnerMapping>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplateCreateUs { get; set; } = new List<AccountReconcileModelTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplateWriteUs { get; set; } = new List<AccountReconcileModelTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModelWriteUs { get; set; } = new List<AccountReconcileModel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplateCreateUs { get; set; } = new List<AccountRecurringTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplateWriteUs { get; set; } = new List<AccountRecurringTemplate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportColumn> AccountReportColumnCreateUs { get; set; } = new List<AccountReportColumn>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportColumn> AccountReportColumnWriteUs { get; set; } = new List<AccountReportColumn>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReport> AccountReportCreateUs { get; set; } = new List<AccountReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportExpression> AccountReportExpressionCreateUs { get; set; } = new List<AccountReportExpression>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportExpression> AccountReportExpressionWriteUs { get; set; } = new List<AccountReportExpression>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValueCreateUs { get; set; } = new List<AccountReportExternalValue>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValueWriteUs { get; set; } = new List<AccountReportExternalValue>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgerCreateUs { get; set; } = new List<AccountReportGeneralLedger>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgerWriteUs { get; set; } = new List<AccountReportGeneralLedger>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportLine> AccountReportLineCreateUs { get; set; } = new List<AccountReportLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportLine> AccountReportLineWriteUs { get; set; } = new List<AccountReportLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgerCreateUs { get; set; } = new List<AccountReportPartnerLedger>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgerWriteUs { get; set; } = new List<AccountReportPartnerLedger>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReport> AccountReportWriteUs { get; set; } = new List<AccountReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountResequenceWizard> AccountResequenceWizardCreateUs { get; set; } = new List<AccountResequenceWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountResequenceWizard> AccountResequenceWizardWriteUs { get; set; } = new List<AccountResequenceWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfigCreateUs { get; set; } = new List<AccountSetupBankManualConfig>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfigWriteUs { get; set; } = new List<AccountSetupBankManualConfig>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxCreateUs { get; set; } = new List<AccountTax>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupCreateUs { get; set; } = new List<AccountTaxGroup>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupWriteUs { get; set; } = new List<AccountTaxGroup>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineCreateUs { get; set; } = new List<AccountTaxRepartitionLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateCreateUs { get; set; } = new List<AccountTaxRepartitionLineTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateWriteUs { get; set; } = new List<AccountTaxRepartitionLineTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineWriteUs { get; set; } = new List<AccountTaxRepartitionLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizardCreateUs { get; set; } = new List<AccountTaxReportWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizardWriteUs { get; set; } = new List<AccountTaxReportWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplateCreateUs { get; set; } = new List<AccountTaxTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplateWriteUs { get; set; } = new List<AccountTaxTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxWriteUs { get; set; } = new List<AccountTax>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBill> AccountTourUploadBillCreateUs { get; set; } = new List<AccountTourUploadBill>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirmCreateUs { get; set; } = new List<AccountTourUploadBillEmailConfirm>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirmWriteUs { get; set; } = new List<AccountTourUploadBillEmailConfirm>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBill> AccountTourUploadBillWriteUs { get; set; } = new List<AccountTourUploadBill>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountUnreconcile> AccountUnreconcileCreateUs { get; set; } = new List<AccountUnreconcile>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountUnreconcile> AccountUnreconcileWriteUs { get; set; } = new List<AccountUnreconcile>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountingReport> AccountingReportCreateUs { get; set; } = new List<AccountingReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountingReport> AccountingReportWriteUs { get; set; } = new List<AccountingReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasonCreateUs { get; set; } = new List<ApplicantGetRefuseReason>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasonWriteUs { get; set; } = new List<ApplicantGetRefuseReason>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMailCreateUs { get; set; } = new List<ApplicantSendMail>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMailWriteUs { get; set; } = new List<ApplicantSendMail>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AssetDepreciationConfirmationWizard> AssetDepreciationConfirmationWizardCreateUs { get; set; } = new List<AssetDepreciationConfirmationWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AssetDepreciationConfirmationWizard> AssetDepreciationConfirmationWizardWriteUs { get; set; } = new List<AssetDepreciationConfirmationWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AssetModify> AssetModifyCreateUs { get; set; } = new List<AssetModify>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AssetModify> AssetModifyWriteUs { get; set; } = new List<AssetModify>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<AuthTotpDevice> AuthTotpDevices { get; set; } = new List<AuthTotpDevice>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AuthTotpWizard> AuthTotpWizardCreateUs { get; set; } = new List<AuthTotpWizard>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<AuthTotpWizard> AuthTotpWizardUsers { get; set; } = new List<AuthTotpWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AuthTotpWizard> AuthTotpWizardWriteUs { get; set; } = new List<AuthTotpWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BarcodeNomenclature> BarcodeNomenclatureCreateUs { get; set; } = new List<BarcodeNomenclature>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BarcodeNomenclature> BarcodeNomenclatureWriteUs { get; set; } = new List<BarcodeNomenclature>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BarcodeRule> BarcodeRuleCreateUs { get; set; } = new List<BarcodeRule>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BarcodeRule> BarcodeRuleWriteUs { get; set; } = new List<BarcodeRule>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseDocumentLayout> BaseDocumentLayoutCreateUs { get; set; } = new List<BaseDocumentLayout>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseDocumentLayout> BaseDocumentLayoutWriteUs { get; set; } = new List<BaseDocumentLayout>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseEnableProfilingWizard> BaseEnableProfilingWizardCreateUs { get; set; } = new List<BaseEnableProfilingWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseEnableProfilingWizard> BaseEnableProfilingWizardWriteUs { get; set; } = new List<BaseEnableProfilingWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportImport> BaseImportImportCreateUs { get; set; } = new List<BaseImportImport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportImport> BaseImportImportWriteUs { get; set; } = new List<BaseImportImport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportMapping> BaseImportMappingCreateUs { get; set; } = new List<BaseImportMapping>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportMapping> BaseImportMappingWriteUs { get; set; } = new List<BaseImportMapping>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsChar> BaseImportTestsModelsCharCreateUs { get; set; } = new List<BaseImportTestsModelsChar>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlyCreateUs { get; set; } = new List<BaseImportTestsModelsCharNoreadonly>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlyWriteUs { get; set; } = new List<BaseImportTestsModelsCharNoreadonly>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlyCreateUs { get; set; } = new List<BaseImportTestsModelsCharReadonly>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlyWriteUs { get; set; } = new List<BaseImportTestsModelsCharReadonly>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequiredCreateUs { get; set; } = new List<BaseImportTestsModelsCharRequired>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequiredWriteUs { get; set; } = new List<BaseImportTestsModelsCharRequired>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharState> BaseImportTestsModelsCharStateCreateUs { get; set; } = new List<BaseImportTestsModelsCharState>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharState> BaseImportTestsModelsCharStateWriteUs { get; set; } = new List<BaseImportTestsModelsCharState>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlyCreateUs { get; set; } = new List<BaseImportTestsModelsCharStillreadonly>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlyWriteUs { get; set; } = new List<BaseImportTestsModelsCharStillreadonly>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsChar> BaseImportTestsModelsCharWriteUs { get; set; } = new List<BaseImportTestsModelsChar>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexCreateUs { get; set; } = new List<BaseImportTestsModelsComplex>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexWriteUs { get; set; } = new List<BaseImportTestsModelsComplex>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloatCreateUs { get; set; } = new List<BaseImportTestsModelsFloat>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloatWriteUs { get; set; } = new List<BaseImportTestsModelsFloat>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2oCreateUs { get; set; } = new List<BaseImportTestsModelsM2o>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelatedCreateUs { get; set; } = new List<BaseImportTestsModelsM2oRelated>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelatedWriteUs { get; set; } = new List<BaseImportTestsModelsM2oRelated>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequiredCreateUs { get; set; } = new List<BaseImportTestsModelsM2oRequired>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelatedCreateUs { get; set; } = new List<BaseImportTestsModelsM2oRequiredRelated>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelatedWriteUs { get; set; } = new List<BaseImportTestsModelsM2oRequiredRelated>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequiredWriteUs { get; set; } = new List<BaseImportTestsModelsM2oRequired>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2oWriteUs { get; set; } = new List<BaseImportTestsModelsM2o>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildCreateUs { get; set; } = new List<BaseImportTestsModelsO2mChild>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildWriteUs { get; set; } = new List<BaseImportTestsModelsO2mChild>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2m> BaseImportTestsModelsO2mCreateUs { get; set; } = new List<BaseImportTestsModelsO2m>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2m> BaseImportTestsModelsO2mWriteUs { get; set; } = new List<BaseImportTestsModelsO2m>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviewCreateUs { get; set; } = new List<BaseImportTestsModelsPreview>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviewWriteUs { get; set; } = new List<BaseImportTestsModelsPreview>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageExport> BaseLanguageExportCreateUs { get; set; } = new List<BaseLanguageExport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageExport> BaseLanguageExportWriteUs { get; set; } = new List<BaseLanguageExport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageImport> BaseLanguageImportCreateUs { get; set; } = new List<BaseLanguageImport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageImport> BaseLanguageImportWriteUs { get; set; } = new List<BaseLanguageImport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageInstall> BaseLanguageInstallCreateUs { get; set; } = new List<BaseLanguageInstall>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageInstall> BaseLanguageInstallWriteUs { get; set; } = new List<BaseLanguageInstall>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestCreateUs { get; set; } = new List<BaseModuleInstallRequest>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestUsers { get; set; } = new List<BaseModuleInstallRequest>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestWriteUs { get; set; } = new List<BaseModuleInstallRequest>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallReview> BaseModuleInstallReviewCreateUs { get; set; } = new List<BaseModuleInstallReview>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallReview> BaseModuleInstallReviewWriteUs { get; set; } = new List<BaseModuleInstallReview>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUninstall> BaseModuleUninstallCreateUs { get; set; } = new List<BaseModuleUninstall>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUninstall> BaseModuleUninstallWriteUs { get; set; } = new List<BaseModuleUninstall>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUpdate> BaseModuleUpdateCreateUs { get; set; } = new List<BaseModuleUpdate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUpdate> BaseModuleUpdateWriteUs { get; set; } = new List<BaseModuleUpdate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUpgrade> BaseModuleUpgradeCreateUs { get; set; } = new List<BaseModuleUpgrade>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUpgrade> BaseModuleUpgradeWriteUs { get; set; } = new List<BaseModuleUpgrade>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardCreateUs { get; set; } = new List<BasePartnerMergeAutomaticWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardWriteUs { get; set; } = new List<BasePartnerMergeAutomaticWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeLine> BasePartnerMergeLineCreateUs { get; set; } = new List<BasePartnerMergeLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeLine> BasePartnerMergeLineWriteUs { get; set; } = new List<BasePartnerMergeLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BusBu> BusBuCreateUs { get; set; } = new List<BusBu>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BusBu> BusBuWriteUs { get; set; } = new List<BusBu>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarAlarm> CalendarAlarmCreateUs { get; set; } = new List<CalendarAlarm>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarAlarm> CalendarAlarmWriteUs { get; set; } = new List<CalendarAlarm>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarAttendee> CalendarAttendeeCreateUs { get; set; } = new List<CalendarAttendee>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarAttendee> CalendarAttendeeWriteUs { get; set; } = new List<CalendarAttendee>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEventCreateUs { get; set; } = new List<CalendarEvent>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarEventType> CalendarEventTypeCreateUs { get; set; } = new List<CalendarEventType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarEventType> CalendarEventTypeWriteUs { get; set; } = new List<CalendarEventType>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEventUsers { get; set; } = new List<CalendarEvent>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEventWriteUs { get; set; } = new List<CalendarEvent>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarFilter> CalendarFilterCreateUs { get; set; } = new List<CalendarFilter>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CalendarFilter> CalendarFilterUsers { get; set; } = new List<CalendarFilter>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarFilter> CalendarFilterWriteUs { get; set; } = new List<CalendarFilter>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarProviderConfig> CalendarProviderConfigCreateUs { get; set; } = new List<CalendarProviderConfig>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarProviderConfig> CalendarProviderConfigWriteUs { get; set; } = new List<CalendarProviderConfig>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarRecurrence> CalendarRecurrenceCreateUs { get; set; } = new List<CalendarRecurrence>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarRecurrence> CalendarRecurrenceWriteUs { get; set; } = new List<CalendarRecurrence>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangeLockDate> ChangeLockDateCreateUs { get; set; } = new List<ChangeLockDate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangeLockDate> ChangeLockDateWriteUs { get; set; } = new List<ChangeLockDate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordOwn> ChangePasswordOwnCreateUs { get; set; } = new List<ChangePasswordOwn>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordOwn> ChangePasswordOwnWriteUs { get; set; } = new List<ChangePasswordOwn>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordUser> ChangePasswordUserCreateUs { get; set; } = new List<ChangePasswordUser>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ChangePasswordUser> ChangePasswordUserUsers { get; set; } = new List<ChangePasswordUser>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordUser> ChangePasswordUserWriteUs { get; set; } = new List<ChangePasswordUser>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordWizard> ChangePasswordWizardCreateUs { get; set; } = new List<ChangePasswordWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordWizard> ChangePasswordWizardWriteUs { get; set; } = new List<ChangePasswordWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangeProductionQty> ChangeProductionQtyCreateUs { get; set; } = new List<ChangeProductionQty>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangeProductionQty> ChangeProductionQtyWriteUs { get; set; } = new List<ChangeProductionQty>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ConfirmStockSm> ConfirmStockSmCreateUs { get; set; } = new List<ConfirmStockSm>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ConfirmStockSm> ConfirmStockSmWriteUs { get; set; } = new List<ConfirmStockSm>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadHelper> CrmIapLeadHelperCreateUs { get; set; } = new List<CrmIapLeadHelper>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadHelper> CrmIapLeadHelperWriteUs { get; set; } = new List<CrmIapLeadHelper>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadIndustry> CrmIapLeadIndustryCreateUs { get; set; } = new List<CrmIapLeadIndustry>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadIndustry> CrmIapLeadIndustryWriteUs { get; set; } = new List<CrmIapLeadIndustry>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestCreateUs { get; set; } = new List<CrmIapLeadMiningRequest>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestUsers { get; set; } = new List<CrmIapLeadMiningRequest>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestWriteUs { get; set; } = new List<CrmIapLeadMiningRequest>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadRole> CrmIapLeadRoleCreateUs { get; set; } = new List<CrmIapLeadRole>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadRole> CrmIapLeadRoleWriteUs { get; set; } = new List<CrmIapLeadRole>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadSeniority> CrmIapLeadSeniorityCreateUs { get; set; } = new List<CrmIapLeadSeniority>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadSeniority> CrmIapLeadSeniorityWriteUs { get; set; } = new List<CrmIapLeadSeniority>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerCreateUs { get; set; } = new List<CrmLead2opportunityPartner>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassCreateUs { get; set; } = new List<CrmLead2opportunityPartnerMass>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassUsers { get; set; } = new List<CrmLead2opportunityPartnerMass>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassWriteUs { get; set; } = new List<CrmLead2opportunityPartnerMass>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerUsers { get; set; } = new List<CrmLead2opportunityPartner>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerWriteUs { get; set; } = new List<CrmLead2opportunityPartner>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeadCreateUs { get; set; } = new List<CrmLead>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLeadLost> CrmLeadLostCreateUs { get; set; } = new List<CrmLeadLost>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLeadLost> CrmLeadLostWriteUs { get; set; } = new List<CrmLeadLost>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLeadPlsUpdate> CrmLeadPlsUpdateCreateUs { get; set; } = new List<CrmLeadPlsUpdate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLeadPlsUpdate> CrmLeadPlsUpdateWriteUs { get; set; } = new List<CrmLeadPlsUpdate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequencyCreateUs { get; set; } = new List<CrmLeadScoringFrequency>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyFieldCreateUs { get; set; } = new List<CrmLeadScoringFrequencyField>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyFieldWriteUs { get; set; } = new List<CrmLeadScoringFrequencyField>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequencyWriteUs { get; set; } = new List<CrmLeadScoringFrequency>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeadUsers { get; set; } = new List<CrmLead>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeadWriteUs { get; set; } = new List<CrmLead>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLostReason> CrmLostReasonCreateUs { get; set; } = new List<CrmLostReason>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLostReason> CrmLostReasonWriteUs { get; set; } = new List<CrmLostReason>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityCreateUs { get; set; } = new List<CrmMergeOpportunity>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityUsers { get; set; } = new List<CrmMergeOpportunity>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityWriteUs { get; set; } = new List<CrmMergeOpportunity>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmQuotationPartner> CrmQuotationPartnerCreateUs { get; set; } = new List<CrmQuotationPartner>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmQuotationPartner> CrmQuotationPartnerWriteUs { get; set; } = new List<CrmQuotationPartner>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmRecurringPlan> CrmRecurringPlanCreateUs { get; set; } = new List<CrmRecurringPlan>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmRecurringPlan> CrmRecurringPlanWriteUs { get; set; } = new List<CrmRecurringPlan>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmStage> CrmStageCreateUs { get; set; } = new List<CrmStage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmStage> CrmStageWriteUs { get; set; } = new List<CrmStage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmTag> CrmTagCreateUs { get; set; } = new List<CrmTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmTag> CrmTagWriteUs { get; set; } = new List<CrmTag>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeamCreateUs { get; set; } = new List<CrmTeam>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMemberCreateUs { get; set; } = new List<CrmTeamMember>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMemberUsers { get; set; } = new List<CrmTeamMember>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMemberWriteUs { get; set; } = new List<CrmTeamMember>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeamUsers { get; set; } = new List<CrmTeam>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeamWriteUs { get; set; } = new List<CrmTeam>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgetCreateUs { get; set; } = new List<CrossoveredBudget>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudgetLine> CrossoveredBudgetLineCreateUs { get; set; } = new List<CrossoveredBudgetLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudgetLine> CrossoveredBudgetLineWriteUs { get; set; } = new List<CrossoveredBudgetLine>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgetUsers { get; set; } = new List<CrossoveredBudget>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgetWriteUs { get; set; } = new List<CrossoveredBudget>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<DecimalPrecision> DecimalPrecisionCreateUs { get; set; } = new List<DecimalPrecision>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<DecimalPrecision> DecimalPrecisionWriteUs { get; set; } = new List<DecimalPrecision>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<DigestDigest> DigestDigestCreateUs { get; set; } = new List<DigestDigest>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<DigestDigest> DigestDigestWriteUs { get; set; } = new List<DigestDigest>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<DigestTip> DigestTipCreateUs { get; set; } = new List<DigestTip>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<DigestTip> DigestTipWriteUs { get; set; } = new List<DigestTip>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FetchmailServer> FetchmailServerCreateUs { get; set; } = new List<FetchmailServer>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FetchmailServer> FetchmailServerWriteUs { get; set; } = new List<FetchmailServer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetServiceType> FleetServiceTypeCreateUs { get; set; } = new List<FleetServiceType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetServiceType> FleetServiceTypeWriteUs { get; set; } = new List<FleetServiceType>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogCreateUs { get; set; } = new List<FleetVehicleAssignationLog>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogWriteUs { get; set; } = new List<FleetVehicleAssignationLog>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleCreateUs { get; set; } = new List<FleetVehicle>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractCreateUs { get; set; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractUsers { get; set; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractWriteUs { get; set; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServiceCreateUs { get; set; } = new List<FleetVehicleLogService>();

    //[InverseProperty("Manager")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServiceManagers { get; set; } = new List<FleetVehicleLogService>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServiceWriteUs { get; set; } = new List<FleetVehicleLogService>();

    //[InverseProperty("Manager")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleManagers { get; set; } = new List<FleetVehicle>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModelBrand> FleetVehicleModelBrandCreateUs { get; set; } = new List<FleetVehicleModelBrand>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModelBrand> FleetVehicleModelBrandWriteUs { get; set; } = new List<FleetVehicleModelBrand>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModelCategory> FleetVehicleModelCategoryCreateUs { get; set; } = new List<FleetVehicleModelCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModelCategory> FleetVehicleModelCategoryWriteUs { get; set; } = new List<FleetVehicleModelCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModel> FleetVehicleModelCreateUs { get; set; } = new List<FleetVehicleModel>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModel> FleetVehicleModelWriteUs { get; set; } = new List<FleetVehicleModel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometerCreateUs { get; set; } = new List<FleetVehicleOdometer>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometerWriteUs { get; set; } = new List<FleetVehicleOdometer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleState> FleetVehicleStateCreateUs { get; set; } = new List<FleetVehicleState>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleState> FleetVehicleStateWriteUs { get; set; } = new List<FleetVehicleState>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleTag> FleetVehicleTagCreateUs { get; set; } = new List<FleetVehicleTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleTag> FleetVehicleTagWriteUs { get; set; } = new List<FleetVehicleTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleWriteUs { get; set; } = new List<FleetVehicle>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FollowupFollowup> FollowupFollowupCreateUs { get; set; } = new List<FollowupFollowup>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FollowupFollowup> FollowupFollowupWriteUs { get; set; } = new List<FollowupFollowup>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FollowupLine> FollowupLineCreateUs { get; set; } = new List<FollowupLine>();

    //[InverseProperty("ManualActionResponsible")]
    [NotMapped]
    public virtual ICollection<FollowupLine> FollowupLineManualActionResponsibles { get; set; } = new List<FollowupLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FollowupLine> FollowupLineWriteUs { get; set; } = new List<FollowupLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FollowupPrint> FollowupPrintCreateUs { get; set; } = new List<FollowupPrint>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FollowupPrint> FollowupPrintWriteUs { get; set; } = new List<FollowupPrint>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FollowupSendingResult> FollowupSendingResultCreateUs { get; set; } = new List<FollowupSendingResult>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FollowupSendingResult> FollowupSendingResultWriteUs { get; set; } = new List<FollowupSendingResult>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrApplicantCategory> HrApplicantCategoryCreateUs { get; set; } = new List<HrApplicantCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrApplicantCategory> HrApplicantCategoryWriteUs { get; set; } = new List<HrApplicantCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicantCreateUs { get; set; } = new List<HrApplicant>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReasonCreateUs { get; set; } = new List<HrApplicantRefuseReason>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReasonWriteUs { get; set; } = new List<HrApplicantRefuseReason>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkillCreateUs { get; set; } = new List<HrApplicantSkill>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkillWriteUs { get; set; } = new List<HrApplicantSkill>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicantUsers { get; set; } = new List<HrApplicant>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicantWriteUs { get; set; } = new List<HrApplicant>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrAttendance> HrAttendanceCreateUs { get; set; } = new List<HrAttendance>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrAttendanceOvertime> HrAttendanceOvertimeCreateUs { get; set; } = new List<HrAttendanceOvertime>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrAttendanceOvertime> HrAttendanceOvertimeWriteUs { get; set; } = new List<HrAttendanceOvertime>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrAttendance> HrAttendanceWriteUs { get; set; } = new List<HrAttendance>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContractCreateUs { get; set; } = new List<HrContract>();

    //[InverseProperty("HrResponsible")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContractHrResponsibles { get; set; } = new List<HrContract>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrContractType> HrContractTypeCreateUs { get; set; } = new List<HrContractType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrContractType> HrContractTypeWriteUs { get; set; } = new List<HrContractType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContractWriteUs { get; set; } = new List<HrContract>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartmentCreateUs { get; set; } = new List<HrDepartment>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartmentWriteUs { get; set; } = new List<HrDepartment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrDepartureReason> HrDepartureReasonCreateUs { get; set; } = new List<HrDepartureReason>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrDepartureReason> HrDepartureReasonWriteUs { get; set; } = new List<HrDepartureReason>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrDepartureWizard> HrDepartureWizardCreateUs { get; set; } = new List<HrDepartureWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrDepartureWizard> HrDepartureWizardWriteUs { get; set; } = new List<HrDepartureWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeCategory> HrEmployeeCategoryCreateUs { get; set; } = new List<HrEmployeeCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeCategory> HrEmployeeCategoryWriteUs { get; set; } = new List<HrEmployeeCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeCreateUs { get; set; } = new List<HrEmployee>();

    //[InverseProperty("ExpenseManager")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeExpenseManagers { get; set; } = new List<HrEmployee>();

    //[InverseProperty("LeaveManager")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeLeaveManagers { get; set; } = new List<HrEmployee>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkillCreateUs { get; set; } = new List<HrEmployeeSkill>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogCreateUs { get; set; } = new List<HrEmployeeSkillLog>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogWriteUs { get; set; } = new List<HrEmployeeSkillLog>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkillWriteUs { get; set; } = new List<HrEmployeeSkill>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeUsers { get; set; } = new List<HrEmployee>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeWriteUs { get; set; } = new List<HrEmployee>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicateCreateUs { get; set; } = new List<HrExpenseApproveDuplicate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicateWriteUs { get; set; } = new List<HrExpenseApproveDuplicate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenseCreateUs { get; set; } = new List<HrExpense>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizardCreateUs { get; set; } = new List<HrExpenseRefuseWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizardWriteUs { get; set; } = new List<HrExpenseRefuseWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetCreateUs { get; set; } = new List<HrExpenseSheet>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetUsers { get; set; } = new List<HrExpenseSheet>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetWriteUs { get; set; } = new List<HrExpenseSheet>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplitCreateUs { get; set; } = new List<HrExpenseSplit>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizardCreateUs { get; set; } = new List<HrExpenseSplitWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizardWriteUs { get; set; } = new List<HrExpenseSplitWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplitWriteUs { get; set; } = new List<HrExpenseSplit>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenseWriteUs { get; set; } = new List<HrExpense>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeaveCreateUs { get; set; } = new List<HrHolidaysCancelLeave>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeaveWriteUs { get; set; } = new List<HrHolidaysCancelLeave>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrHolidaysSummaryEmployee> HrHolidaysSummaryEmployeeCreateUs { get; set; } = new List<HrHolidaysSummaryEmployee>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrHolidaysSummaryEmployee> HrHolidaysSummaryEmployeeWriteUs { get; set; } = new List<HrHolidaysSummaryEmployee>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobCreateUs { get; set; } = new List<HrJob>();

    //[InverseProperty("HrResponsible")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobHrResponsibles { get; set; } = new List<HrJob>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobUsers { get; set; } = new List<HrJob>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobWriteUs { get; set; } = new List<HrJob>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualLevel> HrLeaveAccrualLevelCreateUs { get; set; } = new List<HrLeaveAccrualLevel>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualLevel> HrLeaveAccrualLevelWriteUs { get; set; } = new List<HrLeaveAccrualLevel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlanCreateUs { get; set; } = new List<HrLeaveAccrualPlan>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlanWriteUs { get; set; } = new List<HrLeaveAccrualPlan>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationCreateUs { get; set; } = new List<HrLeaveAllocation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationWriteUs { get; set; } = new List<HrLeaveAllocation>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveCreateUs { get; set; } = new List<HrLeave>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDayCreateUs { get; set; } = new List<HrLeaveStressDay>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDayWriteUs { get; set; } = new List<HrLeaveStressDay>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypeCreateUs { get; set; } = new List<HrLeaveType>();

    //[InverseProperty("Responsible")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypeResponsibles { get; set; } = new List<HrLeaveType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypeWriteUs { get; set; } = new List<HrLeaveType>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveUsers { get; set; } = new List<HrLeave>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveWriteUs { get; set; } = new List<HrLeave>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypeCreateUs { get; set; } = new List<HrPayrollStructureType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypeWriteUs { get; set; } = new List<HrPayrollStructureType>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeCreateUs { get; set; } = new List<HrPlanActivityType>();

    //[InverseProperty("ResponsibleNavigation")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeResponsibleNavigations { get; set; } = new List<HrPlanActivityType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeWriteUs { get; set; } = new List<HrPlanActivityType>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrPlan> HrPlanCreateUs { get; set; } = new List<HrPlan>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrPlanWizard> HrPlanWizardCreateUs { get; set; } = new List<HrPlanWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrPlanWizard> HrPlanWizardWriteUs { get; set; } = new List<HrPlanWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrPlan> HrPlanWriteUs { get; set; } = new List<HrPlan>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentDegree> HrRecruitmentDegreeCreateUs { get; set; } = new List<HrRecruitmentDegree>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentDegree> HrRecruitmentDegreeWriteUs { get; set; } = new List<HrRecruitmentDegree>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSourceCreateUs { get; set; } = new List<HrRecruitmentSource>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSourceWriteUs { get; set; } = new List<HrRecruitmentSource>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStageCreateUs { get; set; } = new List<HrRecruitmentStage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStageWriteUs { get; set; } = new List<HrRecruitmentStage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrResumeLine> HrResumeLineCreateUs { get; set; } = new List<HrResumeLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrResumeLineType> HrResumeLineTypeCreateUs { get; set; } = new List<HrResumeLineType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrResumeLineType> HrResumeLineTypeWriteUs { get; set; } = new List<HrResumeLineType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrResumeLine> HrResumeLineWriteUs { get; set; } = new List<HrResumeLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkillCreateUs { get; set; } = new List<HrSkill>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrSkillLevel> HrSkillLevelCreateUs { get; set; } = new List<HrSkillLevel>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrSkillLevel> HrSkillLevelWriteUs { get; set; } = new List<HrSkillLevel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrSkillType> HrSkillTypeCreateUs { get; set; } = new List<HrSkillType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrSkillType> HrSkillTypeWriteUs { get; set; } = new List<HrSkillType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkillWriteUs { get; set; } = new List<HrSkill>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrWorkLocation> HrWorkLocationCreateUs { get; set; } = new List<HrWorkLocation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrWorkLocation> HrWorkLocationWriteUs { get; set; } = new List<HrWorkLocation>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IapAccount> IapAccountCreateUs { get; set; } = new List<IapAccount>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IapAccount> IapAccountWriteUs { get; set; } = new List<IapAccount>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUser> InverseCreateU { get; set; } = new List<ResUser>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUser> InverseWriteU { get; set; } = new List<ResUser>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActClient> IrActClientCreateUs { get; set; } = new List<IrActClient>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActClient> IrActClientWriteUs { get; set; } = new List<IrActClient>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> IrActReportXmlCreateUs { get; set; } = new List<IrActReportXml>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> IrActReportXmlWriteUs { get; set; } = new List<IrActReportXml>();

    //[InverseProperty("ActivityUser")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerActivityUsers { get; set; } = new List<IrActServer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerCreateUs { get; set; } = new List<IrActServer>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerWriteUs { get; set; } = new List<IrActServer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActUrl> IrActUrlCreateUs { get; set; } = new List<IrActUrl>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActUrl> IrActUrlWriteUs { get; set; } = new List<IrActUrl>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindowCreateUs { get; set; } = new List<IrActWindow>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActWindowView> IrActWindowViewCreateUs { get; set; } = new List<IrActWindowView>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActWindowView> IrActWindowViewWriteUs { get; set; } = new List<IrActWindowView>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindowWriteUs { get; set; } = new List<IrActWindow>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrAction> IrActionCreateUs { get; set; } = new List<IrAction>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrAction> IrActionWriteUs { get; set; } = new List<IrAction>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActionsTodo> IrActionsTodoCreateUs { get; set; } = new List<IrActionsTodo>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActionsTodo> IrActionsTodoWriteUs { get; set; } = new List<IrActionsTodo>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrAsset> IrAssetCreateUs { get; set; } = new List<IrAsset>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrAsset> IrAssetWriteUs { get; set; } = new List<IrAsset>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachmentCreateUs { get; set; } = new List<IrAttachment>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachmentWriteUs { get; set; } = new List<IrAttachment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrConfigParameter> IrConfigParameterCreateUs { get; set; } = new List<IrConfigParameter>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrConfigParameter> IrConfigParameterWriteUs { get; set; } = new List<IrConfigParameter>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrCron> IrCronCreateUs { get; set; } = new List<IrCron>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrCronTrigger> IrCronTriggerCreateUs { get; set; } = new List<IrCronTrigger>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrCronTrigger> IrCronTriggerWriteUs { get; set; } = new List<IrCronTrigger>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<IrCron> IrCronUsers { get; set; } = new List<IrCron>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrCron> IrCronWriteUs { get; set; } = new List<IrCron>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaultCreateUs { get; set; } = new List<IrDefault>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaultUsers { get; set; } = new List<IrDefault>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaultWriteUs { get; set; } = new List<IrDefault>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrDemo> IrDemoCreateUs { get; set; } = new List<IrDemo>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrDemoFailure> IrDemoFailureCreateUs { get; set; } = new List<IrDemoFailure>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrDemoFailureWizard> IrDemoFailureWizardCreateUs { get; set; } = new List<IrDemoFailureWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrDemoFailureWizard> IrDemoFailureWizardWriteUs { get; set; } = new List<IrDemoFailureWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrDemoFailure> IrDemoFailureWriteUs { get; set; } = new List<IrDemoFailure>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrDemo> IrDemoWriteUs { get; set; } = new List<IrDemo>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrExport> IrExportCreateUs { get; set; } = new List<IrExport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrExport> IrExportWriteUs { get; set; } = new List<IrExport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrExportsLine> IrExportsLineCreateUs { get; set; } = new List<IrExportsLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrExportsLine> IrExportsLineWriteUs { get; set; } = new List<IrExportsLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrFilter> IrFilterCreateUs { get; set; } = new List<IrFilter>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<IrFilter> IrFilterUsers { get; set; } = new List<IrFilter>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrFilter> IrFilterWriteUs { get; set; } = new List<IrFilter>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrMailServer> IrMailServerCreateUs { get; set; } = new List<IrMailServer>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrMailServer> IrMailServerWriteUs { get; set; } = new List<IrMailServer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelAccess> IrModelAccessCreateUs { get; set; } = new List<IrModelAccess>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelAccess> IrModelAccessWriteUs { get; set; } = new List<IrModelAccess>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelConstraint> IrModelConstraintCreateUs { get; set; } = new List<IrModelConstraint>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelConstraint> IrModelConstraintWriteUs { get; set; } = new List<IrModelConstraint>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModel> IrModelCreateUs { get; set; } = new List<IrModel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelDatum> IrModelDatumCreateUs { get; set; } = new List<IrModelDatum>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelDatum> IrModelDatumWriteUs { get; set; } = new List<IrModelDatum>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelField> IrModelFieldCreateUs { get; set; } = new List<IrModelField>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelField> IrModelFieldWriteUs { get; set; } = new List<IrModelField>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelFieldsSelection> IrModelFieldsSelectionCreateUs { get; set; } = new List<IrModelFieldsSelection>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelFieldsSelection> IrModelFieldsSelectionWriteUs { get; set; } = new List<IrModelFieldsSelection>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelRelation> IrModelRelationCreateUs { get; set; } = new List<IrModelRelation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelRelation> IrModelRelationWriteUs { get; set; } = new List<IrModelRelation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModel> IrModelWriteUs { get; set; } = new List<IrModel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModuleCategory> IrModuleCategoryCreateUs { get; set; } = new List<IrModuleCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModuleCategory> IrModuleCategoryWriteUs { get; set; } = new List<IrModuleCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModuleModule> IrModuleModuleCreateUs { get; set; } = new List<IrModuleModule>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModuleModuleExclusion> IrModuleModuleExclusionCreateUs { get; set; } = new List<IrModuleModuleExclusion>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModuleModuleExclusion> IrModuleModuleExclusionWriteUs { get; set; } = new List<IrModuleModuleExclusion>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModuleModule> IrModuleModuleWriteUs { get; set; } = new List<IrModuleModule>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrProperty> IrPropertyCreateUs { get; set; } = new List<IrProperty>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrProperty> IrPropertyWriteUs { get; set; } = new List<IrProperty>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrRule> IrRuleCreateUs { get; set; } = new List<IrRule>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrRule> IrRuleWriteUs { get; set; } = new List<IrRule>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrSequence> IrSequenceCreateUs { get; set; } = new List<IrSequence>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrSequenceDateRange> IrSequenceDateRangeCreateUs { get; set; } = new List<IrSequenceDateRange>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrSequenceDateRange> IrSequenceDateRangeWriteUs { get; set; } = new List<IrSequenceDateRange>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrSequence> IrSequenceWriteUs { get; set; } = new List<IrSequence>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrServerObjectLine> IrServerObjectLineCreateUs { get; set; } = new List<IrServerObjectLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrServerObjectLine> IrServerObjectLineWriteUs { get; set; } = new List<IrServerObjectLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrUiMenu> IrUiMenuCreateUs { get; set; } = new List<IrUiMenu>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrUiMenu> IrUiMenuWriteUs { get; set; } = new List<IrUiMenu>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrUiView> IrUiViewCreateUs { get; set; } = new List<IrUiView>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrUiViewCustom> IrUiViewCustomCreateUs { get; set; } = new List<IrUiViewCustom>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<IrUiViewCustom> IrUiViewCustomUsers { get; set; } = new List<IrUiViewCustom>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrUiViewCustom> IrUiViewCustomWriteUs { get; set; } = new List<IrUiViewCustom>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrUiView> IrUiViewWriteUs { get; set; } = new List<IrUiView>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LotLabelLayout> LotLabelLayoutCreateUs { get; set; } = new List<LotLabelLayout>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LotLabelLayout> LotLabelLayoutWriteUs { get; set; } = new List<LotLabelLayout>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchAlert> LunchAlertCreateUs { get; set; } = new List<LunchAlert>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchAlert> LunchAlertWriteUs { get; set; } = new List<LunchAlert>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoveCreateUs { get; set; } = new List<LunchCashmove>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoveUsers { get; set; } = new List<LunchCashmove>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoveWriteUs { get; set; } = new List<LunchCashmove>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchLocation> LunchLocationCreateUs { get; set; } = new List<LunchLocation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchLocation> LunchLocationWriteUs { get; set; } = new List<LunchLocation>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrderCreateUs { get; set; } = new List<LunchOrder>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrderUsers { get; set; } = new List<LunchOrder>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrderWriteUs { get; set; } = new List<LunchOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchProductCategory> LunchProductCategoryCreateUs { get; set; } = new List<LunchProductCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchProductCategory> LunchProductCategoryWriteUs { get; set; } = new List<LunchProductCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchProduct> LunchProductCreateUs { get; set; } = new List<LunchProduct>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchProduct> LunchProductWriteUs { get; set; } = new List<LunchProduct>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSupplierCreateUs { get; set; } = new List<LunchSupplier>();

    //[InverseProperty("Responsible")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSupplierResponsibles { get; set; } = new List<LunchSupplier>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSupplierWriteUs { get; set; } = new List<LunchSupplier>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchTopping> LunchToppingCreateUs { get; set; } = new List<LunchTopping>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchTopping> LunchToppingWriteUs { get; set; } = new List<LunchTopping>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityCreateUs { get; set; } = new List<MailActivity>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailActivityType> MailActivityTypeCreateUs { get; set; } = new List<MailActivityType>();

    //[InverseProperty("DefaultUser")]
    [NotMapped]
    public virtual ICollection<MailActivityType> MailActivityTypeDefaultUsers { get; set; } = new List<MailActivityType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailActivityType> MailActivityTypeWriteUs { get; set; } = new List<MailActivityType>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityUsers { get; set; } = new List<MailActivity>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityWriteUs { get; set; } = new List<MailActivity>();

    //[InverseProperty("AliasUser")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasAliasUsers { get; set; } = new List<MailAlias>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasCreateUs { get; set; } = new List<MailAlias>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasWriteUs { get; set; } = new List<MailAlias>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailBlacklist> MailBlacklistCreateUs { get; set; } = new List<MailBlacklist>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailBlacklistRemove> MailBlacklistRemoveCreateUs { get; set; } = new List<MailBlacklistRemove>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailBlacklistRemove> MailBlacklistRemoveWriteUs { get; set; } = new List<MailBlacklistRemove>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailBlacklist> MailBlacklistWriteUs { get; set; } = new List<MailBlacklist>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannelCreateUs { get; set; } = new List<MailChannel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMemberCreateUs { get; set; } = new List<MailChannelMember>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMemberWriteUs { get; set; } = new List<MailChannelMember>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessionCreateUs { get; set; } = new List<MailChannelRtcSession>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessionWriteUs { get; set; } = new List<MailChannelRtcSession>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannelWriteUs { get; set; } = new List<MailChannel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessageCreateUs { get; set; } = new List<MailComposeMessage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessageWriteUs { get; set; } = new List<MailComposeMessage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailGatewayAllowed> MailGatewayAllowedCreateUs { get; set; } = new List<MailGatewayAllowed>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailGatewayAllowed> MailGatewayAllowedWriteUs { get; set; } = new List<MailGatewayAllowed>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailGuest> MailGuestCreateUs { get; set; } = new List<MailGuest>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailGuest> MailGuestWriteUs { get; set; } = new List<MailGuest>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailIceServer> MailIceServerCreateUs { get; set; } = new List<MailIceServer>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailIceServer> MailIceServerWriteUs { get; set; } = new List<MailIceServer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailLinkPreview> MailLinkPreviewCreateUs { get; set; } = new List<MailLinkPreview>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailLinkPreview> MailLinkPreviewWriteUs { get; set; } = new List<MailLinkPreview>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMailCreateUs { get; set; } = new List<MailMail>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMailWriteUs { get; set; } = new List<MailMail>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessageCreateUs { get; set; } = new List<MailMessage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailMessageSchedule> MailMessageScheduleCreateUs { get; set; } = new List<MailMessageSchedule>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailMessageSchedule> MailMessageScheduleWriteUs { get; set; } = new List<MailMessageSchedule>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailMessageSubtype> MailMessageSubtypeCreateUs { get; set; } = new List<MailMessageSubtype>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailMessageSubtype> MailMessageSubtypeWriteUs { get; set; } = new List<MailMessageSubtype>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessageWriteUs { get; set; } = new List<MailMessage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailResendMessage> MailResendMessageCreateUs { get; set; } = new List<MailResendMessage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailResendMessage> MailResendMessageWriteUs { get; set; } = new List<MailResendMessage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailResendPartner> MailResendPartnerCreateUs { get; set; } = new List<MailResendPartner>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailResendPartner> MailResendPartnerWriteUs { get; set; } = new List<MailResendPartner>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailShortcode> MailShortcodeCreateUs { get; set; } = new List<MailShortcode>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailShortcode> MailShortcodeWriteUs { get; set; } = new List<MailShortcode>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplateCreateUs { get; set; } = new List<MailTemplate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailTemplatePreview> MailTemplatePreviewCreateUs { get; set; } = new List<MailTemplatePreview>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailTemplatePreview> MailTemplatePreviewWriteUs { get; set; } = new List<MailTemplatePreview>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailTemplateReset> MailTemplateResetCreateUs { get; set; } = new List<MailTemplateReset>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailTemplateReset> MailTemplateResetWriteUs { get; set; } = new List<MailTemplateReset>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplateWriteUs { get; set; } = new List<MailTemplate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValueCreateUs { get; set; } = new List<MailTrackingValue>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValueWriteUs { get; set; } = new List<MailTrackingValue>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailWizardInvite> MailWizardInviteCreateUs { get; set; } = new List<MailWizardInvite>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailWizardInvite> MailWizardInviteWriteUs { get; set; } = new List<MailWizardInvite>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryCreateUs { get; set; } = new List<MaintenanceEquipmentCategory>();

    //[InverseProperty("TechnicianUser")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryTechnicianUsers { get; set; } = new List<MaintenanceEquipmentCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryWriteUs { get; set; } = new List<MaintenanceEquipmentCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentCreateUs { get; set; } = new List<MaintenanceEquipment>();

    //[InverseProperty("OwnerUser")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentOwnerUsers { get; set; } = new List<MaintenanceEquipment>();

    //[InverseProperty("TechnicianUser")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentTechnicianUsers { get; set; } = new List<MaintenanceEquipment>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentWriteUs { get; set; } = new List<MaintenanceEquipment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestCreateUs { get; set; } = new List<MaintenanceRequest>();

    //[InverseProperty("OwnerUser")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestOwnerUsers { get; set; } = new List<MaintenanceRequest>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestUsers { get; set; } = new List<MaintenanceRequest>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestWriteUs { get; set; } = new List<MaintenanceRequest>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceStage> MaintenanceStageCreateUs { get; set; } = new List<MaintenanceStage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceStage> MaintenanceStageWriteUs { get; set; } = new List<MaintenanceStage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceTeam> MaintenanceTeamCreateUs { get; set; } = new List<MaintenanceTeam>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceTeam> MaintenanceTeamWriteUs { get; set; } = new List<MaintenanceTeam>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproductCreateUs { get; set; } = new List<MrpBomByproduct>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproductWriteUs { get; set; } = new List<MrpBomByproduct>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBomCreateUs { get; set; } = new List<MrpBom>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLineCreateUs { get; set; } = new List<MrpBomLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLineWriteUs { get; set; } = new List<MrpBomLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBomWriteUs { get; set; } = new List<MrpBom>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarningCreateUs { get; set; } = new List<MrpConsumptionWarning>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLineCreateUs { get; set; } = new List<MrpConsumptionWarningLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLineWriteUs { get; set; } = new List<MrpConsumptionWarningLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarningWriteUs { get; set; } = new List<MrpConsumptionWarning>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpDocument> MrpDocumentCreateUs { get; set; } = new List<MrpDocument>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpDocument> MrpDocumentWriteUs { get; set; } = new List<MrpDocument>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProduction> MrpImmediateProductionCreateUs { get; set; } = new List<MrpImmediateProduction>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLineCreateUs { get; set; } = new List<MrpImmediateProductionLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLineWriteUs { get; set; } = new List<MrpImmediateProductionLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProduction> MrpImmediateProductionWriteUs { get; set; } = new List<MrpImmediateProduction>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorder> MrpProductionBackorderCreateUs { get; set; } = new List<MrpProductionBackorder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLineCreateUs { get; set; } = new List<MrpProductionBackorderLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLineWriteUs { get; set; } = new List<MrpProductionBackorderLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorder> MrpProductionBackorderWriteUs { get; set; } = new List<MrpProductionBackorder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionCreateUs { get; set; } = new List<MrpProduction>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplit> MrpProductionSplitCreateUs { get; set; } = new List<MrpProductionSplit>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineCreateUs { get; set; } = new List<MrpProductionSplitLine>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineUsers { get; set; } = new List<MrpProductionSplitLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineWriteUs { get; set; } = new List<MrpProductionSplitLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitMulti> MrpProductionSplitMultiCreateUs { get; set; } = new List<MrpProductionSplitMulti>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitMulti> MrpProductionSplitMultiWriteUs { get; set; } = new List<MrpProductionSplitMulti>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplit> MrpProductionSplitWriteUs { get; set; } = new List<MrpProductionSplit>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionUsers { get; set; } = new List<MrpProduction>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionWriteUs { get; set; } = new List<MrpProduction>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenterCreateUs { get; set; } = new List<MrpRoutingWorkcenter>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenterWriteUs { get; set; } = new List<MrpRoutingWorkcenter>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuildCreateUs { get; set; } = new List<MrpUnbuild>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuildWriteUs { get; set; } = new List<MrpUnbuild>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacityCreateUs { get; set; } = new List<MrpWorkcenterCapacity>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacityWriteUs { get; set; } = new List<MrpWorkcenterCapacity>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenterCreateUs { get; set; } = new List<MrpWorkcenter>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityCreateUs { get; set; } = new List<MrpWorkcenterProductivity>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivityLoss> MrpWorkcenterProductivityLossCreateUs { get; set; } = new List<MrpWorkcenterProductivityLoss>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivityLossType> MrpWorkcenterProductivityLossTypeCreateUs { get; set; } = new List<MrpWorkcenterProductivityLossType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivityLossType> MrpWorkcenterProductivityLossTypeWriteUs { get; set; } = new List<MrpWorkcenterProductivityLossType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivityLoss> MrpWorkcenterProductivityLossWriteUs { get; set; } = new List<MrpWorkcenterProductivityLoss>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityUsers { get; set; } = new List<MrpWorkcenterProductivity>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityWriteUs { get; set; } = new List<MrpWorkcenterProductivity>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterTag> MrpWorkcenterTagCreateUs { get; set; } = new List<MrpWorkcenterTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterTag> MrpWorkcenterTagWriteUs { get; set; } = new List<MrpWorkcenterTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenterWriteUs { get; set; } = new List<MrpWorkcenter>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorderCreateUs { get; set; } = new List<MrpWorkorder>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorderWriteUs { get; set; } = new List<MrpWorkorder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNoteCreateUs { get; set; } = new List<NoteNote>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNoteUsers { get; set; } = new List<NoteNote>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNoteWriteUs { get; set; } = new List<NoteNote>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<NoteStage> NoteStageCreateUs { get; set; } = new List<NoteStage>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<NoteStage> NoteStageUsers { get; set; } = new List<NoteStage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<NoteStage> NoteStageWriteUs { get; set; } = new List<NoteStage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<NoteTag> NoteTagCreateUs { get; set; } = new List<NoteTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<NoteTag> NoteTagWriteUs { get; set; } = new List<NoteTag>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentIcon> PaymentIconCreateUs { get; set; } = new List<PaymentIcon>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentIcon> PaymentIconWriteUs { get; set; } = new List<PaymentIcon>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizardCreateUs { get; set; } = new List<PaymentLinkWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizardWriteUs { get; set; } = new List<PaymentLinkWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviderCreateUs { get; set; } = new List<PaymentProvider>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentProviderOnboardingWizard> PaymentProviderOnboardingWizardCreateUs { get; set; } = new List<PaymentProviderOnboardingWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentProviderOnboardingWizard> PaymentProviderOnboardingWizardWriteUs { get; set; } = new List<PaymentProviderOnboardingWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviderWriteUs { get; set; } = new List<PaymentProvider>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentRefundWizard> PaymentRefundWizardCreateUs { get; set; } = new List<PaymentRefundWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentRefundWizard> PaymentRefundWizardWriteUs { get; set; } = new List<PaymentRefundWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokenCreateUs { get; set; } = new List<PaymentToken>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokenWriteUs { get; set; } = new List<PaymentToken>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactionCreateUs { get; set; } = new List<PaymentTransaction>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactionWriteUs { get; set; } = new List<PaymentTransaction>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklist> PhoneBlacklistCreateUs { get; set; } = new List<PhoneBlacklist>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklistRemove> PhoneBlacklistRemoveCreateUs { get; set; } = new List<PhoneBlacklistRemove>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklistRemove> PhoneBlacklistRemoveWriteUs { get; set; } = new List<PhoneBlacklistRemove>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklist> PhoneBlacklistWriteUs { get; set; } = new List<PhoneBlacklist>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PickingLabelType> PickingLabelTypeCreateUs { get; set; } = new List<PickingLabelType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PickingLabelType> PickingLabelTypeWriteUs { get; set; } = new List<PickingLabelType>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PortalShare> PortalShareCreateUs { get; set; } = new List<PortalShare>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PortalShare> PortalShareWriteUs { get; set; } = new List<PortalShare>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PortalWizard> PortalWizardCreateUs { get; set; } = new List<PortalWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PortalWizardUser> PortalWizardUserCreateUs { get; set; } = new List<PortalWizardUser>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PortalWizardUser> PortalWizardUserWriteUs { get; set; } = new List<PortalWizardUser>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PortalWizard> PortalWizardWriteUs { get; set; } = new List<PortalWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosBill> PosBillCreateUs { get; set; } = new List<PosBill>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosBill> PosBillWriteUs { get; set; } = new List<PosBill>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosCategory> PosCategoryCreateUs { get; set; } = new List<PosCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosCategory> PosCategoryWriteUs { get; set; } = new List<PosCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizardCreateUs { get; set; } = new List<PosCloseSessionWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizardWriteUs { get; set; } = new List<PosCloseSessionWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigCreateUs { get; set; } = new List<PosConfig>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigWriteUs { get; set; } = new List<PosConfig>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosDetailsWizard> PosDetailsWizardCreateUs { get; set; } = new List<PosDetailsWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosDetailsWizard> PosDetailsWizardWriteUs { get; set; } = new List<PosDetailsWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosMakePayment> PosMakePaymentCreateUs { get; set; } = new List<PosMakePayment>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosMakePayment> PosMakePaymentWriteUs { get; set; } = new List<PosMakePayment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrderCreateUs { get; set; } = new List<PosOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLineCreateUs { get; set; } = new List<PosOrderLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLineWriteUs { get; set; } = new List<PosOrderLine>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrderUsers { get; set; } = new List<PosOrder>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrderWriteUs { get; set; } = new List<PosOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosPackOperationLot> PosPackOperationLotCreateUs { get; set; } = new List<PosPackOperationLot>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosPackOperationLot> PosPackOperationLotWriteUs { get; set; } = new List<PosPackOperationLot>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPaymentCreateUs { get; set; } = new List<PosPayment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodCreateUs { get; set; } = new List<PosPaymentMethod>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodWriteUs { get; set; } = new List<PosPaymentMethod>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPaymentWriteUs { get; set; } = new List<PosPayment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosSessionCheckProductWizard> PosSessionCheckProductWizardCreateUs { get; set; } = new List<PosSessionCheckProductWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosSessionCheckProductWizard> PosSessionCheckProductWizardWriteUs { get; set; } = new List<PosSessionCheckProductWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessionCreateUs { get; set; } = new List<PosSession>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessionUsers { get; set; } = new List<PosSession>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessionWriteUs { get; set; } = new List<PosSession>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PrivacyLog> PrivacyLogCreateUs { get; set; } = new List<PrivacyLog>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<PrivacyLog> PrivacyLogUsers { get; set; } = new List<PrivacyLog>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PrivacyLog> PrivacyLogWriteUs { get; set; } = new List<PrivacyLog>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizard> PrivacyLookupWizardCreateUs { get; set; } = new List<PrivacyLookupWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLineCreateUs { get; set; } = new List<PrivacyLookupWizardLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLineWriteUs { get; set; } = new List<PrivacyLookupWizardLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizard> PrivacyLookupWizardWriteUs { get; set; } = new List<PrivacyLookupWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProcurementGroup> ProcurementGroupCreateUs { get; set; } = new List<ProcurementGroup>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProcurementGroup> ProcurementGroupWriteUs { get; set; } = new List<ProcurementGroup>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductAttribute> ProductAttributeCreateUs { get; set; } = new List<ProductAttribute>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValueCreateUs { get; set; } = new List<ProductAttributeCustomValue>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValueWriteUs { get; set; } = new List<ProductAttributeCustomValue>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductAttributeValue> ProductAttributeValueCreateUs { get; set; } = new List<ProductAttributeValue>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductAttributeValue> ProductAttributeValueWriteUs { get; set; } = new List<ProductAttributeValue>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductAttribute> ProductAttributeWriteUs { get; set; } = new List<ProductAttribute>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductCategory> ProductCategoryCreateUs { get; set; } = new List<ProductCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductCategory> ProductCategoryWriteUs { get; set; } = new List<ProductCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductImage> ProductImageCreateUs { get; set; } = new List<ProductImage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductImage> ProductImageWriteUs { get; set; } = new List<ProductImage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayoutCreateUs { get; set; } = new List<ProductLabelLayout>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayoutWriteUs { get; set; } = new List<ProductLabelLayout>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagingCreateUs { get; set; } = new List<ProductPackaging>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagingWriteUs { get; set; } = new List<ProductPackaging>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelistCreateUs { get; set; } = new List<ProductPricelist>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemCreateUs { get; set; } = new List<ProductPricelistItem>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemWriteUs { get; set; } = new List<ProductPricelistItem>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelistWriteUs { get; set; } = new List<ProductPricelist>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProductCreateUs { get; set; } = new List<ProductProduct>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProductWriteUs { get; set; } = new List<ProductProduct>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductPublicCategory> ProductPublicCategoryCreateUs { get; set; } = new List<ProductPublicCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductPublicCategory> ProductPublicCategoryWriteUs { get; set; } = new List<ProductPublicCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductRemoval> ProductRemovalCreateUs { get; set; } = new List<ProductRemoval>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductRemoval> ProductRemovalWriteUs { get; set; } = new List<ProductRemoval>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishCreateUs { get; set; } = new List<ProductReplenish>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishWriteUs { get; set; } = new List<ProductReplenish>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductRibbon> ProductRibbonCreateUs { get; set; } = new List<ProductRibbon>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductRibbon> ProductRibbonWriteUs { get; set; } = new List<ProductRibbon>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfoCreateUs { get; set; } = new List<ProductSupplierinfo>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfoWriteUs { get; set; } = new List<ProductSupplierinfo>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTagCreateUs { get; set; } = new List<ProductTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTagWriteUs { get; set; } = new List<ProductTag>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionCreateUs { get; set; } = new List<ProductTemplateAttributeExclusion>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionWriteUs { get; set; } = new List<ProductTemplateAttributeExclusion>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLineCreateUs { get; set; } = new List<ProductTemplateAttributeLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLineWriteUs { get; set; } = new List<ProductTemplateAttributeLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValueCreateUs { get; set; } = new List<ProductTemplateAttributeValue>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValueWriteUs { get; set; } = new List<ProductTemplateAttributeValue>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateCreateUs { get; set; } = new List<ProductTemplate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateWriteUs { get; set; } = new List<ProductTemplate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectCollaborator> ProjectCollaboratorCreateUs { get; set; } = new List<ProjectCollaborator>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectCollaborator> ProjectCollaboratorWriteUs { get; set; } = new List<ProjectCollaborator>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectMilestone> ProjectMilestoneCreateUs { get; set; } = new List<ProjectMilestone>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectMilestone> ProjectMilestoneWriteUs { get; set; } = new List<ProjectMilestone>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectCreateUs { get; set; } = new List<ProjectProject>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStageCreateUs { get; set; } = new List<ProjectProjectStage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStageWriteUs { get; set; } = new List<ProjectProjectStage>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectUsers { get; set; } = new List<ProjectProject>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectWriteUs { get; set; } = new List<ProjectProject>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectShareWizard> ProjectShareWizardCreateUs { get; set; } = new List<ProjectShareWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectShareWizard> ProjectShareWizardWriteUs { get; set; } = new List<ProjectShareWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTag> ProjectTagCreateUs { get; set; } = new List<ProjectTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTag> ProjectTagWriteUs { get; set; } = new List<ProjectTag>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskCreateUs { get; set; } = new List<ProjectTask>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskRecurrence> ProjectTaskRecurrenceCreateUs { get; set; } = new List<ProjectTaskRecurrence>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskRecurrence> ProjectTaskRecurrenceWriteUs { get; set; } = new List<ProjectTaskRecurrence>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeCreateUs { get; set; } = new List<ProjectTaskType>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizardCreateUs { get; set; } = new List<ProjectTaskTypeDeleteWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizardWriteUs { get; set; } = new List<ProjectTaskTypeDeleteWizard>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeUsers { get; set; } = new List<ProjectTaskType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeWriteUs { get; set; } = new List<ProjectTaskType>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelCreateUs { get; set; } = new List<ProjectTaskUserRel>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelUsers { get; set; } = new List<ProjectTaskUserRel>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelWriteUs { get; set; } = new List<ProjectTaskUserRel>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskWriteUs { get; set; } = new List<ProjectTask>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdateCreateUs { get; set; } = new List<ProjectUpdate>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdateUsers { get; set; } = new List<ProjectUpdate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdateWriteUs { get; set; } = new List<ProjectUpdate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderCreateUs { get; set; } = new List<PurchaseOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLineCreateUs { get; set; } = new List<PurchaseOrderLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLineWriteUs { get; set; } = new List<PurchaseOrderLine>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderUsers { get; set; } = new List<PurchaseOrder>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderWriteUs { get; set; } = new List<PurchaseOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingCreateUs { get; set; } = new List<RatingRating>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingWriteUs { get; set; } = new List<RatingRating>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPaymentCreateUs { get; set; } = new List<RecurringPayment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLineCreateUs { get; set; } = new List<RecurringPaymentLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLineWriteUs { get; set; } = new List<RecurringPaymentLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPaymentWriteUs { get; set; } = new List<RecurringPayment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFeeCreateUs { get; set; } = new List<RepairFee>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFeeWriteUs { get; set; } = new List<RepairFee>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLineCreateUs { get; set; } = new List<RepairLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLineWriteUs { get; set; } = new List<RepairLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderCreateUs { get; set; } = new List<RepairOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairOrderMakeInvoice> RepairOrderMakeInvoiceCreateUs { get; set; } = new List<RepairOrderMakeInvoice>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairOrderMakeInvoice> RepairOrderMakeInvoiceWriteUs { get; set; } = new List<RepairOrderMakeInvoice>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderUsers { get; set; } = new List<RepairOrder>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderWriteUs { get; set; } = new List<RepairOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairTag> RepairTagCreateUs { get; set; } = new List<RepairTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairTag> RepairTagWriteUs { get; set; } = new List<RepairTag>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ReportLayout> ReportLayoutCreateUs { get; set; } = new List<ReportLayout>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ReportLayout> ReportLayoutWriteUs { get; set; } = new List<ReportLayout>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ReportPaperformat> ReportPaperformatCreateUs { get; set; } = new List<ReportPaperformat>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ReportPaperformat> ReportPaperformatWriteUs { get; set; } = new List<ReportPaperformat>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResBank> ResBankCreateUs { get; set; } = new List<ResBank>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResBank> ResBankWriteUs { get; set; } = new List<ResBank>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyCreateUs { get; set; } = new List<ResCompany>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyWriteUs { get; set; } = new List<ResCompany>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResConfig> ResConfigCreateUs { get; set; } = new List<ResConfig>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResConfigInstaller> ResConfigInstallerCreateUs { get; set; } = new List<ResConfigInstaller>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResConfigInstaller> ResConfigInstallerWriteUs { get; set; } = new List<ResConfigInstaller>();

    //[InverseProperty("AuthSignupTemplateUser")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingAuthSignupTemplateUsers { get; set; } = new List<ResConfigSetting>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingCreateUs { get; set; } = new List<ResConfigSetting>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingWriteUs { get; set; } = new List<ResConfigSetting>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResConfig> ResConfigWriteUs { get; set; } = new List<ResConfig>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountryCreateUs { get; set; } = new List<ResCountry>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCountryGroup> ResCountryGroupCreateUs { get; set; } = new List<ResCountryGroup>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCountryGroup> ResCountryGroupWriteUs { get; set; } = new List<ResCountryGroup>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCountryState> ResCountryStateCreateUs { get; set; } = new List<ResCountryState>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCountryState> ResCountryStateWriteUs { get; set; } = new List<ResCountryState>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountryWriteUs { get; set; } = new List<ResCountry>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCurrency> ResCurrencyCreateUs { get; set; } = new List<ResCurrency>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRateCreateUs { get; set; } = new List<ResCurrencyRate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRateWriteUs { get; set; } = new List<ResCurrencyRate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCurrency> ResCurrencyWriteUs { get; set; } = new List<ResCurrency>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroupCreateUs { get; set; } = new List<ResGroup>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroupWriteUs { get; set; } = new List<ResGroup>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResLang> ResLangCreateUs { get; set; } = new List<ResLang>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResLang> ResLangWriteUs { get; set; } = new List<ResLang>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncCreateUs { get; set; } = new List<ResPartnerAutocompleteSync>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncWriteUs { get; set; } = new List<ResPartnerAutocompleteSync>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBankCreateUs { get; set; } = new List<ResPartnerBank>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBankWriteUs { get; set; } = new List<ResPartnerBank>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> ResPartnerCategoryCreateUs { get; set; } = new List<ResPartnerCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> ResPartnerCategoryWriteUs { get; set; } = new List<ResPartnerCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnerCreateUs { get; set; } = new List<ResPartner>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerIndustry> ResPartnerIndustryCreateUs { get; set; } = new List<ResPartnerIndustry>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerIndustry> ResPartnerIndustryWriteUs { get; set; } = new List<ResPartnerIndustry>();

    //[InverseProperty("PaymentResponsible")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnerPaymentResponsibles { get; set; } = new List<ResPartner>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerTitle> ResPartnerTitleCreateUs { get; set; } = new List<ResPartnerTitle>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerTitle> ResPartnerTitleWriteUs { get; set; } = new List<ResPartnerTitle>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnerUsers { get; set; } = new List<ResPartner>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnerWriteUs { get; set; } = new List<ResPartner>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ResUsersApikey> ResUsersApikeys { get; set; } = new List<ResUsersApikey>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersApikeysDescription> ResUsersApikeysDescriptionCreateUs { get; set; } = new List<ResUsersApikeysDescription>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersApikeysDescription> ResUsersApikeysDescriptionWriteUs { get; set; } = new List<ResUsersApikeysDescription>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersDeletion> ResUsersDeletionCreateUs { get; set; } = new List<ResUsersDeletion>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ResUsersDeletion> ResUsersDeletionUsers { get; set; } = new List<ResUsersDeletion>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersDeletion> ResUsersDeletionWriteUs { get; set; } = new List<ResUsersDeletion>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersIdentitycheck> ResUsersIdentitycheckCreateUs { get; set; } = new List<ResUsersIdentitycheck>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersIdentitycheck> ResUsersIdentitycheckWriteUs { get; set; } = new List<ResUsersIdentitycheck>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersLog> ResUsersLogCreateUs { get; set; } = new List<ResUsersLog>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersLog> ResUsersLogWriteUs { get; set; } = new List<ResUsersLog>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersSetting> ResUsersSettingCreateUs { get; set; } = new List<ResUsersSetting>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersSetting> ResUsersSettingWriteUs { get; set; } = new List<ResUsersSetting>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolume> ResUsersSettingsVolumeCreateUs { get; set; } = new List<ResUsersSettingsVolume>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolume> ResUsersSettingsVolumeWriteUs { get; set; } = new List<ResUsersSettingsVolume>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardCreateUs { get; set; } = new List<ResetViewArchWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardWriteUs { get; set; } = new List<ResetViewArchWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendanceCreateUs { get; set; } = new List<ResourceCalendarAttendance>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendanceWriteUs { get; set; } = new List<ResourceCalendarAttendance>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendar> ResourceCalendarCreateUs { get; set; } = new List<ResourceCalendar>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeafCreateUs { get; set; } = new List<ResourceCalendarLeaf>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeafWriteUs { get; set; } = new List<ResourceCalendarLeaf>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendar> ResourceCalendarWriteUs { get; set; } = new List<ResourceCalendar>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResourceCreateUs { get; set; } = new List<ResourceResource>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResourceUsers { get; set; } = new List<ResourceResource>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResourceWriteUs { get; set; } = new List<ResourceResource>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvCreateUs { get; set; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvWriteUs { get; set; } = new List<SaleAdvancePaymentInv>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancelCreateUs { get; set; } = new List<SaleOrderCancel>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancelWriteUs { get; set; } = new List<SaleOrderCancel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderCreateUs { get; set; } = new List<SaleOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLineCreateUs { get; set; } = new List<SaleOrderLine>();

    //[InverseProperty("Salesman")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLineSalesmen { get; set; } = new List<SaleOrderLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLineWriteUs { get; set; } = new List<SaleOrderLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptionCreateUs { get; set; } = new List<SaleOrderOption>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptionWriteUs { get; set; } = new List<SaleOrderOption>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplateCreateUs { get; set; } = new List<SaleOrderTemplate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLineCreateUs { get; set; } = new List<SaleOrderTemplateLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLineWriteUs { get; set; } = new List<SaleOrderTemplateLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptionCreateUs { get; set; } = new List<SaleOrderTemplateOption>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptionWriteUs { get; set; } = new List<SaleOrderTemplateOption>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplateWriteUs { get; set; } = new List<SaleOrderTemplate>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderUsers { get; set; } = new List<SaleOrder>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderWriteUs { get; set; } = new List<SaleOrder>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SalePaymentProviderOnboardingWizard> SalePaymentProviderOnboardingWizardCreateUs { get; set; } = new List<SalePaymentProviderOnboardingWizard>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SalePaymentProviderOnboardingWizard> SalePaymentProviderOnboardingWizardWriteUs { get; set; } = new List<SalePaymentProviderOnboardingWizard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsComposer> SmsComposerCreateUs { get; set; } = new List<SmsComposer>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsComposer> SmsComposerWriteUs { get; set; } = new List<SmsComposer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsResend> SmsResendCreateUs { get; set; } = new List<SmsResend>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsResendRecipient> SmsResendRecipientCreateUs { get; set; } = new List<SmsResendRecipient>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsResendRecipient> SmsResendRecipientWriteUs { get; set; } = new List<SmsResendRecipient>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsResend> SmsResendWriteUs { get; set; } = new List<SmsResend>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsSm> SmsSmCreateUs { get; set; } = new List<SmsSm>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsSm> SmsSmWriteUs { get; set; } = new List<SmsSm>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsTemplate> SmsTemplateCreateUs { get; set; } = new List<SmsTemplate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsTemplatePreview> SmsTemplatePreviewCreateUs { get; set; } = new List<SmsTemplatePreview>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsTemplatePreview> SmsTemplatePreviewWriteUs { get; set; } = new List<SmsTemplatePreview>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsTemplateReset> SmsTemplateResetCreateUs { get; set; } = new List<SmsTemplateReset>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsTemplateReset> SmsTemplateResetWriteUs { get; set; } = new List<SmsTemplateReset>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsTemplate> SmsTemplateWriteUs { get; set; } = new List<SmsTemplate>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoiceCreateUs { get; set; } = new List<SnailmailConfirmInvoice>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoiceWriteUs { get; set; } = new List<SnailmailConfirmInvoice>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetterCreateUs { get; set; } = new List<SnailmailLetter>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatErrorCreateUs { get; set; } = new List<SnailmailLetterFormatError>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatErrorWriteUs { get; set; } = new List<SnailmailLetterFormatError>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFieldCreateUs { get; set; } = new List<SnailmailLetterMissingRequiredField>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFieldWriteUs { get; set; } = new List<SnailmailLetterMissingRequiredField>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetterUsers { get; set; } = new List<SnailmailLetter>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetterWriteUs { get; set; } = new List<SnailmailLetter>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboardCreateUs { get; set; } = new List<SpreadsheetDashboard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboardGroup> SpreadsheetDashboardGroupCreateUs { get; set; } = new List<SpreadsheetDashboardGroup>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboardGroup> SpreadsheetDashboardGroupWriteUs { get; set; } = new List<SpreadsheetDashboardGroup>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboardWriteUs { get; set; } = new List<SpreadsheetDashboard>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockAssignSerial> StockAssignSerialCreateUs { get; set; } = new List<StockAssignSerial>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockAssignSerial> StockAssignSerialWriteUs { get; set; } = new List<StockAssignSerial>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmationCreateUs { get; set; } = new List<StockBackorderConfirmation>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLineCreateUs { get; set; } = new List<StockBackorderConfirmationLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLineWriteUs { get; set; } = new List<StockBackorderConfirmationLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmationWriteUs { get; set; } = new List<StockBackorderConfirmation>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockChangeProductQty> StockChangeProductQtyCreateUs { get; set; } = new List<StockChangeProductQty>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockChangeProductQty> StockChangeProductQtyWriteUs { get; set; } = new List<StockChangeProductQty>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransfer> StockImmediateTransferCreateUs { get; set; } = new List<StockImmediateTransfer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLineCreateUs { get; set; } = new List<StockImmediateTransferLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLineWriteUs { get; set; } = new List<StockImmediateTransferLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransfer> StockImmediateTransferWriteUs { get; set; } = new List<StockImmediateTransfer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockInventoryAdjustmentName> StockInventoryAdjustmentNameCreateUs { get; set; } = new List<StockInventoryAdjustmentName>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockInventoryAdjustmentName> StockInventoryAdjustmentNameWriteUs { get; set; } = new List<StockInventoryAdjustmentName>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockInventoryConflict> StockInventoryConflictCreateUs { get; set; } = new List<StockInventoryConflict>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockInventoryConflict> StockInventoryConflictWriteUs { get; set; } = new List<StockInventoryConflict>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockInventoryWarning> StockInventoryWarningCreateUs { get; set; } = new List<StockInventoryWarning>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockInventoryWarning> StockInventoryWarningWriteUs { get; set; } = new List<StockInventoryWarning>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationCreateUs { get; set; } = new List<StockLocation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationWriteUs { get; set; } = new List<StockLocation>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLotCreateUs { get; set; } = new List<StockLot>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLotWriteUs { get; set; } = new List<StockLot>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveCreateUs { get; set; } = new List<StockMove>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLineCreateUs { get; set; } = new List<StockMoveLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLineWriteUs { get; set; } = new List<StockMoveLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveWriteUs { get; set; } = new List<StockMove>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnoozeCreateUs { get; set; } = new List<StockOrderpointSnooze>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnoozeWriteUs { get; set; } = new List<StockOrderpointSnooze>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPackageDestination> StockPackageDestinationCreateUs { get; set; } = new List<StockPackageDestination>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPackageDestination> StockPackageDestinationWriteUs { get; set; } = new List<StockPackageDestination>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPackageLevel> StockPackageLevelCreateUs { get; set; } = new List<StockPackageLevel>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPackageLevel> StockPackageLevelWriteUs { get; set; } = new List<StockPackageLevel>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPackageType> StockPackageTypeCreateUs { get; set; } = new List<StockPackageType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPackageType> StockPackageTypeWriteUs { get; set; } = new List<StockPackageType>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingCreateUs { get; set; } = new List<StockPicking>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypeCreateUs { get; set; } = new List<StockPickingType>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypeWriteUs { get; set; } = new List<StockPickingType>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingUsers { get; set; } = new List<StockPicking>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingWriteUs { get; set; } = new List<StockPicking>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRuleCreateUs { get; set; } = new List<StockPutawayRule>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRuleWriteUs { get; set; } = new List<StockPutawayRule>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuantCreateUs { get; set; } = new List<StockQuant>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockQuantPackage> StockQuantPackageCreateUs { get; set; } = new List<StockQuantPackage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockQuantPackage> StockQuantPackageWriteUs { get; set; } = new List<StockQuantPackage>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuantUsers { get; set; } = new List<StockQuant>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuantWriteUs { get; set; } = new List<StockQuant>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockQuantityHistory> StockQuantityHistoryCreateUs { get; set; } = new List<StockQuantityHistory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockQuantityHistory> StockQuantityHistoryWriteUs { get; set; } = new List<StockQuantityHistory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfoCreateUs { get; set; } = new List<StockReplenishmentInfo>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfoWriteUs { get; set; } = new List<StockReplenishmentInfo>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptionCreateUs { get; set; } = new List<StockReplenishmentOption>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptionWriteUs { get; set; } = new List<StockReplenishmentOption>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockRequestCount> StockRequestCountCreateUs { get; set; } = new List<StockRequestCount>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<StockRequestCount> StockRequestCountUsers { get; set; } = new List<StockRequestCount>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockRequestCount> StockRequestCountWriteUs { get; set; } = new List<StockRequestCount>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockReturnPicking> StockReturnPickingCreateUs { get; set; } = new List<StockReturnPicking>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLineCreateUs { get; set; } = new List<StockReturnPickingLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLineWriteUs { get; set; } = new List<StockReturnPickingLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockReturnPicking> StockReturnPickingWriteUs { get; set; } = new List<StockReturnPicking>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockRoute> StockRouteCreateUs { get; set; } = new List<StockRoute>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockRoute> StockRouteWriteUs { get; set; } = new List<StockRoute>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRuleCreateUs { get; set; } = new List<StockRule>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRuleWriteUs { get; set; } = new List<StockRule>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReportCreateUs { get; set; } = new List<StockRulesReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReportWriteUs { get; set; } = new List<StockRulesReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockSchedulerCompute> StockSchedulerComputeCreateUs { get; set; } = new List<StockSchedulerCompute>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockSchedulerCompute> StockSchedulerComputeWriteUs { get; set; } = new List<StockSchedulerCompute>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScrapCreateUs { get; set; } = new List<StockScrap>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScrapWriteUs { get; set; } = new List<StockScrap>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacityCreateUs { get; set; } = new List<StockStorageCategoryCapacity>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacityWriteUs { get; set; } = new List<StockStorageCategoryCapacity>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockStorageCategory> StockStorageCategoryCreateUs { get; set; } = new List<StockStorageCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockStorageCategory> StockStorageCategoryWriteUs { get; set; } = new List<StockStorageCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockTraceabilityReport> StockTraceabilityReportCreateUs { get; set; } = new List<StockTraceabilityReport>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockTraceabilityReport> StockTraceabilityReportWriteUs { get; set; } = new List<StockTraceabilityReport>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmationCreateUs { get; set; } = new List<StockTrackConfirmation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmationWriteUs { get; set; } = new List<StockTrackConfirmation>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockTrackLine> StockTrackLineCreateUs { get; set; } = new List<StockTrackLine>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockTrackLine> StockTrackLineWriteUs { get; set; } = new List<StockTrackLine>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayerCreateUs { get; set; } = new List<StockValuationLayer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluationCreateUs { get; set; } = new List<StockValuationLayerRevaluation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluationWriteUs { get; set; } = new List<StockValuationLayerRevaluation>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayerWriteUs { get; set; } = new List<StockValuationLayer>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseCreateUs { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointCreateUs { get; set; } = new List<StockWarehouseOrderpoint>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointWriteUs { get; set; } = new List<StockWarehouseOrderpoint>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseWriteUs { get; set; } = new List<StockWarehouse>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairCreateUs { get; set; } = new List<StockWarnInsufficientQtyRepair>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairWriteUs { get; set; } = new List<StockWarnInsufficientQtyRepair>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrapCreateUs { get; set; } = new List<StockWarnInsufficientQtyScrap>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrapWriteUs { get; set; } = new List<StockWarnInsufficientQtyScrap>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuildCreateUs { get; set; } = new List<StockWarnInsufficientQtyUnbuild>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuildWriteUs { get; set; } = new List<StockWarnInsufficientQtyUnbuild>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeIrAsset> ThemeIrAssetCreateUs { get; set; } = new List<ThemeIrAsset>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeIrAsset> ThemeIrAssetWriteUs { get; set; } = new List<ThemeIrAsset>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeIrAttachment> ThemeIrAttachmentCreateUs { get; set; } = new List<ThemeIrAttachment>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeIrAttachment> ThemeIrAttachmentWriteUs { get; set; } = new List<ThemeIrAttachment>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeIrUiView> ThemeIrUiViewCreateUs { get; set; } = new List<ThemeIrUiView>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeIrUiView> ThemeIrUiViewWriteUs { get; set; } = new List<ThemeIrUiView>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeWebsiteMenu> ThemeWebsiteMenuCreateUs { get; set; } = new List<ThemeWebsiteMenu>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeWebsiteMenu> ThemeWebsiteMenuWriteUs { get; set; } = new List<ThemeWebsiteMenu>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeWebsitePage> ThemeWebsitePageCreateUs { get; set; } = new List<ThemeWebsitePage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeWebsitePage> ThemeWebsitePageWriteUs { get; set; } = new List<ThemeWebsitePage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UomCategory> UomCategoryCreateUs { get; set; } = new List<UomCategory>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UomCategory> UomCategoryWriteUs { get; set; } = new List<UomCategory>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UomUom> UomUomCreateUs { get; set; } = new List<UomUom>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UomUom> UomUomWriteUs { get; set; } = new List<UomUom>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaignCreateUs { get; set; } = new List<UtmCampaign>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaignUsers { get; set; } = new List<UtmCampaign>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaignWriteUs { get; set; } = new List<UtmCampaign>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmMedium> UtmMediumCreateUs { get; set; } = new List<UtmMedium>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmMedium> UtmMediumWriteUs { get; set; } = new List<UtmMedium>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmSource> UtmSourceCreateUs { get; set; } = new List<UtmSource>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmSource> UtmSourceWriteUs { get; set; } = new List<UtmSource>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmStage> UtmStageCreateUs { get; set; } = new List<UtmStage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmStage> UtmStageWriteUs { get; set; } = new List<UtmStage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmTag> UtmTagCreateUs { get; set; } = new List<UtmTag>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmTag> UtmTagWriteUs { get; set; } = new List<UtmTag>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ValidateAccountMove> ValidateAccountMoveCreateUs { get; set; } = new List<ValidateAccountMove>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ValidateAccountMove> ValidateAccountMoveWriteUs { get; set; } = new List<ValidateAccountMove>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebEditorConverterTest> WebEditorConverterTestCreateUs { get; set; } = new List<WebEditorConverterTest>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebEditorConverterTestSub> WebEditorConverterTestSubCreateUs { get; set; } = new List<WebEditorConverterTestSub>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebEditorConverterTestSub> WebEditorConverterTestSubWriteUs { get; set; } = new List<WebEditorConverterTestSub>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebEditorConverterTest> WebEditorConverterTestWriteUs { get; set; } = new List<WebEditorConverterTest>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<WebTourTour> WebTourTours { get; set; } = new List<WebTourTour>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteBaseUnit> WebsiteBaseUnitCreateUs { get; set; } = new List<WebsiteBaseUnit>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteBaseUnit> WebsiteBaseUnitWriteUs { get; set; } = new List<WebsiteBaseUnit>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeatureCreateUs { get; set; } = new List<WebsiteConfiguratorFeature>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeatureWriteUs { get; set; } = new List<WebsiteConfiguratorFeature>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteCreateUs { get; set; } = new List<Website>();

    //[InverseProperty("CrmDefaultUser")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteCrmDefaultUsers { get; set; } = new List<Website>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> WebsiteMenuCreateUs { get; set; } = new List<WebsiteMenu>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> WebsiteMenuWriteUs { get; set; } = new List<WebsiteMenu>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsitePage> WebsitePageCreateUs { get; set; } = new List<WebsitePage>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsitePage> WebsitePageWriteUs { get; set; } = new List<WebsitePage>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteRewrite> WebsiteRewriteCreateUs { get; set; } = new List<WebsiteRewrite>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteRewrite> WebsiteRewriteWriteUs { get; set; } = new List<WebsiteRewrite>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteRobot> WebsiteRobotCreateUs { get; set; } = new List<WebsiteRobot>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteRobot> WebsiteRobotWriteUs { get; set; } = new List<WebsiteRobot>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteRoute> WebsiteRouteCreateUs { get; set; } = new List<WebsiteRoute>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteRoute> WebsiteRouteWriteUs { get; set; } = new List<WebsiteRoute>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraFieldCreateUs { get; set; } = new List<WebsiteSaleExtraField>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraFieldWriteUs { get; set; } = new List<WebsiteSaleExtraField>();

    //[InverseProperty("Salesperson")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteSalespeople { get; set; } = new List<Website>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilterCreateUs { get; set; } = new List<WebsiteSnippetFilter>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilterWriteUs { get; set; } = new List<WebsiteSnippetFilter>();

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteUsers { get; set; } = new List<Website>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitorCreateUs { get; set; } = new List<WebsiteVisitor>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitorWriteUs { get; set; } = new List<WebsiteVisitor>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteWriteUs { get; set; } = new List<Website>();

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WizardIrModelMenuCreate> WizardIrModelMenuCreateCreateUs { get; set; } = new List<WizardIrModelMenuCreate>();

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WizardIrModelMenuCreate> WizardIrModelMenuCreateWriteUs { get; set; } = new List<WizardIrModelMenuCreate>();

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<ResCompany> Cids { get; set; } = new List<ResCompany>();

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMasses { get; set; } = new List<CrmLead2opportunityPartnerMass>();

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<DigestDigest> DigestDigests { get; set; } = new List<DigestDigest>();

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<DigestTip> DigestTips { get; set; } = new List<DigestTip>();

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } = new List<HrApplicant>();

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } = new List<HrJob>();

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsersNavigation")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobsNavigation { get; set; } = new List<HrJob>();

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<HrJob> Jobs { get; set; } = new List<HrJob>();

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<MaintenanceTeam> MaintenanceTeams { get; set; } = new List<MaintenanceTeam>();

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<LunchProduct> Products { get; set; } = new List<LunchProduct>();

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<ProjectProject> Projects { get; set; } = new List<ProjectProject>();

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<CrmTeam> Teams { get; set; } = new List<CrmTeam>();
    */
}
