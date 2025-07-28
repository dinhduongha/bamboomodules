

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
    public virtual ICollection<ResGroup> Gids { get; set; } 

    /// TODO: DISABLE INVERSE COLLECTIONS

    /*
    //[InverseProperty("CreateU")]
    //[NotMapped]
    //public virtual ICollection<ResUser> InverseCreateU { get; set; } 
    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccountCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAccountTag> AccountAccountTagWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    //[NotMapped]
    //[NotMapped]
    public virtual ICollection<AccountAccountType> AccountAccountTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    //[NotMapped]
    //[NotMapped]
    public virtual ICollection<AccountAccountType> AccountAccountTypeWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccountWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalanceCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalanceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilityCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilityWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModelCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlanCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlanWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssetCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssetWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatementCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImport> AccountBankStatementImportCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreationWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImport> AccountBankStatementImportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatementWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBankbookReport> AccountBankbookReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBankbookReport> AccountBankbookReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> AccountBudgetPostCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountBudgetPost> AccountBudgetPostWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCashRounding> AccountCashRoundingCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCashRounding> AccountCashRoundingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCashbookReport> AccountCashbookReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCashbookReport> AccountCashbookReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountChartTemplate> AccountChartTemplateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountCommonReport> AccountCommonReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountCommonReport> AccountCommonReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountDaybookReport> AccountDaybookReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountDaybookReport> AccountDaybookReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountEdiDocument> AccountEdiDocumentCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountEdiDocument> AccountEdiDocumentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountEdiFormat> AccountEdiFormatCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountEdiFormat> AccountEdiFormatWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> AccountFinancialReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFinancialReport> AccountFinancialReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOpCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOpWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositionCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalPosition> AccountFiscalPositionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalYear> AccountFiscalYearCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFiscalYear> AccountFiscalYearWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountFullReconcile> AccountFullReconcileCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountFullReconcile> AccountFullReconcileWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountGroup> AccountGroupCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountGroupTemplate> AccountGroupTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountGroupTemplate> AccountGroupTemplateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountGroup> AccountGroupWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountIncoterm> AccountIncotermCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountIncoterm> AccountIncotermWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSendCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSendWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountJournalGroup> AccountJournalGroupCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountJournalGroup> AccountJournalGroupWriteUs { get; set; } 

    //[InverseProperty("SaleActivityUser")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalSaleActivityUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournalWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoveCreateUs { get; set; } 

    //[InverseProperty("InvoiceUser")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoveInvoiceUsers { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountMoveReversal> AccountMoveReversalCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountMoveReversal> AccountMoveReversalWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoveWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethod> AccountPaymentMethodCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentMethod> AccountPaymentMethodWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTerm> AccountPaymentTermCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTermLine> AccountPaymentTermLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTermLine> AccountPaymentTermLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPaymentTerm> AccountPaymentTermWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPaymentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountPrintJournal> AccountPrintJournalCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountPrintJournal> AccountPrintJournalWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModelCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLineCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappingCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportColumn> AccountReportColumnCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportColumn> AccountReportColumnWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReport> AccountReportCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportExpression> AccountReportExpressionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportExpression> AccountReportExpressionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValueCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportExternalValue> AccountReportExternalValueWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportLine> AccountReportLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportLine> AccountReportLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgerWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountReport> AccountReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountResequenceWizard> AccountResequenceWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountResequenceWizard> AccountResequenceWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfigCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfigWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxGroup> AccountTaxGroupWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTaxTemplate> AccountTaxTemplateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTax> AccountTaxWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBill> AccountTourUploadBillCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirmCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirmWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBill> AccountTourUploadBillWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountUnreconcile> AccountUnreconcileCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountUnreconcile> AccountUnreconcileWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AccountingReport> AccountingReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AccountingReport> AccountingReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasonCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasonWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMailCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMailWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AssetDepreciationConfirmationWizard> AssetDepreciationConfirmationWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AssetDepreciationConfirmationWizard> AssetDepreciationConfirmationWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AssetModify> AssetModifyCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AssetModify> AssetModifyWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<AuthTotpDevice> AuthTotpDevices { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<AuthTotpWizard> AuthTotpWizardCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<AuthTotpWizard> AuthTotpWizardUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<AuthTotpWizard> AuthTotpWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BarcodeNomenclature> BarcodeNomenclatureCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BarcodeNomenclature> BarcodeNomenclatureWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BarcodeRule> BarcodeRuleCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BarcodeRule> BarcodeRuleWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseDocumentLayout> BaseDocumentLayoutCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseDocumentLayout> BaseDocumentLayoutWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseEnableProfilingWizard> BaseEnableProfilingWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseEnableProfilingWizard> BaseEnableProfilingWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportImport> BaseImportImportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportImport> BaseImportImportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportMapping> BaseImportMappingCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportMapping> BaseImportMappingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsChar> BaseImportTestsModelsCharCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlyCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlyWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlyCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlyWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequiredCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequiredWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharState> BaseImportTestsModelsCharStateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharState> BaseImportTestsModelsCharStateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlyCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlyWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsChar> BaseImportTestsModelsCharWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloatCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloatWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2oCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelatedCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelatedWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequiredCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelatedCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelatedWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequiredWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2oWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2m> BaseImportTestsModelsO2mCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsO2m> BaseImportTestsModelsO2mWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviewCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviewWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageExport> BaseLanguageExportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageExport> BaseLanguageExportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageImport> BaseLanguageImportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageImport> BaseLanguageImportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageInstall> BaseLanguageInstallCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseLanguageInstall> BaseLanguageInstallWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallReview> BaseModuleInstallReviewCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleInstallReview> BaseModuleInstallReviewWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUninstall> BaseModuleUninstallCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUninstall> BaseModuleUninstallWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUpdate> BaseModuleUpdateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUpdate> BaseModuleUpdateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUpgrade> BaseModuleUpgradeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BaseModuleUpgrade> BaseModuleUpgradeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeLine> BasePartnerMergeLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeLine> BasePartnerMergeLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<BusBu> BusBuCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<BusBu> BusBuWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarAlarm> CalendarAlarmCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarAlarm> CalendarAlarmWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarAttendee> CalendarAttendeeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarAttendee> CalendarAttendeeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEventCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarEventType> CalendarEventTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarEventType> CalendarEventTypeWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEventUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEventWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarFilter> CalendarFilterCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CalendarFilter> CalendarFilterUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarFilter> CalendarFilterWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarProviderConfig> CalendarProviderConfigCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarProviderConfig> CalendarProviderConfigWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CalendarRecurrence> CalendarRecurrenceCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CalendarRecurrence> CalendarRecurrenceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangeLockDate> ChangeLockDateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangeLockDate> ChangeLockDateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordOwn> ChangePasswordOwnCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordOwn> ChangePasswordOwnWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordUser> ChangePasswordUserCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ChangePasswordUser> ChangePasswordUserUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordUser> ChangePasswordUserWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordWizard> ChangePasswordWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangePasswordWizard> ChangePasswordWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ChangeProductionQty> ChangeProductionQtyCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ChangeProductionQty> ChangeProductionQtyWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ConfirmStockSm> ConfirmStockSmCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ConfirmStockSm> ConfirmStockSmWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadHelper> CrmIapLeadHelperCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadHelper> CrmIapLeadHelperWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadIndustry> CrmIapLeadIndustryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadIndustry> CrmIapLeadIndustryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadRole> CrmIapLeadRoleCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadRole> CrmIapLeadRoleWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadSeniority> CrmIapLeadSeniorityCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmIapLeadSeniority> CrmIapLeadSeniorityWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeadCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLeadLost> CrmLeadLostCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLeadLost> CrmLeadLostWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLeadPlsUpdate> CrmLeadPlsUpdateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLeadPlsUpdate> CrmLeadPlsUpdateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequencyCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyFieldCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyFieldWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequencyWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeadUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeadWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmLostReason> CrmLostReasonCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmLostReason> CrmLostReasonWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmQuotationPartner> CrmQuotationPartnerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmQuotationPartner> CrmQuotationPartnerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmRecurringPlan> CrmRecurringPlanCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmRecurringPlan> CrmRecurringPlanWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmStage> CrmStageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmStage> CrmStageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmTag> CrmTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmTag> CrmTagWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeamCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMemberCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMemberUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMemberWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeamUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeamWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgetCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudgetLine> CrossoveredBudgetLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudgetLine> CrossoveredBudgetLineWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgetUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgetWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<DecimalPrecision> DecimalPrecisionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<DecimalPrecision> DecimalPrecisionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<DigestDigest> DigestDigestCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<DigestDigest> DigestDigestWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<DigestTip> DigestTipCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<DigestTip> DigestTipWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FetchmailServer> FetchmailServerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FetchmailServer> FetchmailServerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetServiceType> FleetServiceTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetServiceType> FleetServiceTypeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServiceCreateUs { get; set; } 

    //[InverseProperty("Manager")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServiceManagers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServiceWriteUs { get; set; } 

    //[InverseProperty("Manager")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleManagers { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModelBrand> FleetVehicleModelBrandCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModelBrand> FleetVehicleModelBrandWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModelCategory> FleetVehicleModelCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModelCategory> FleetVehicleModelCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModel> FleetVehicleModelCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModel> FleetVehicleModelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleState> FleetVehicleStateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleState> FleetVehicleStateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleTag> FleetVehicleTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicleTag> FleetVehicleTagWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FollowupFollowup> FollowupFollowupCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FollowupFollowup> FollowupFollowupWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FollowupLine> FollowupLineCreateUs { get; set; } 

    //[InverseProperty("ManualActionResponsible")]
    [NotMapped]
    public virtual ICollection<FollowupLine> FollowupLineManualActionResponsibles { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FollowupLine> FollowupLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FollowupPrint> FollowupPrintCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FollowupPrint> FollowupPrintWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<FollowupSendingResult> FollowupSendingResultCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<FollowupSendingResult> FollowupSendingResultWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrApplicantCategory> HrApplicantCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrApplicantCategory> HrApplicantCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicantCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReasonCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReasonWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkillCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrApplicantSkill> HrApplicantSkillWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicantUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicantWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrAttendance> HrAttendanceCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrAttendanceOvertime> HrAttendanceOvertimeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrAttendanceOvertime> HrAttendanceOvertimeWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrAttendance> HrAttendanceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContractCreateUs { get; set; } 

    //[InverseProperty("HrResponsible")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContractHrResponsibles { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrContractType> HrContractTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrContractType> HrContractTypeWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContractWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartmentCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartmentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrDepartureReason> HrDepartureReasonCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrDepartureReason> HrDepartureReasonWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrDepartureWizard> HrDepartureWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrDepartureWizard> HrDepartureWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeCategory> HrEmployeeCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeCategory> HrEmployeeCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeCreateUs { get; set; } 

    //[InverseProperty("ExpenseManager")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeExpenseManagers { get; set; } 

    //[InverseProperty("LeaveManager")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeLeaveManagers { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkillCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkillWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenseCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheetWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplitCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizardWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplitWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenseWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeaveCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeaveWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrHolidaysSummaryEmployee> HrHolidaysSummaryEmployeeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrHolidaysSummaryEmployee> HrHolidaysSummaryEmployeeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobCreateUs { get; set; } 

    //[InverseProperty("HrResponsible")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobHrResponsibles { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualLevel> HrLeaveAccrualLevelCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualLevel> HrLeaveAccrualLevelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlanCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlanWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDayCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveStressDay> HrLeaveStressDayWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypeCreateUs { get; set; } 

    //[InverseProperty("Responsible")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypeResponsibles { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypeWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeCreateUs { get; set; } 

    //[InverseProperty("ResponsibleNavigation")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeResponsibleNavigations { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrPlan> HrPlanCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrPlanWizard> HrPlanWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrPlanWizard> HrPlanWizardWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrPlan> HrPlanWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentDegree> HrRecruitmentDegreeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentDegree> HrRecruitmentDegreeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSourceCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentSource> HrRecruitmentSourceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrRecruitmentStage> HrRecruitmentStageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrResumeLine> HrResumeLineCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrResumeLineType> HrResumeLineTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrResumeLineType> HrResumeLineTypeWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrResumeLine> HrResumeLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkillCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrSkillLevel> HrSkillLevelCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrSkillLevel> HrSkillLevelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrSkillType> HrSkillTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrSkillType> HrSkillTypeWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkillWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<HrWorkLocation> HrWorkLocationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<HrWorkLocation> HrWorkLocationWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IapAccount> IapAccountCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IapAccount> IapAccountWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUser> InverseCreateU { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUser> InverseWriteU { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActClient> IrActClientCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActClient> IrActClientWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> IrActReportXmlCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> IrActReportXmlWriteUs { get; set; } 

    //[InverseProperty("ActivityUser")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerActivityUsers { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActUrl> IrActUrlCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActUrl> IrActUrlWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindowCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActWindowView> IrActWindowViewCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActWindowView> IrActWindowViewWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindowWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrAction> IrActionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrAction> IrActionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrActionsTodo> IrActionsTodoCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrActionsTodo> IrActionsTodoWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrAsset> IrAssetCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrAsset> IrAssetWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachmentCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachmentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrConfigParameter> IrConfigParameterCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrConfigParameter> IrConfigParameterWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrCron> IrCronCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrCronTrigger> IrCronTriggerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrCronTrigger> IrCronTriggerWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<IrCron> IrCronUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrCron> IrCronWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaultCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaultUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaultWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrDemo> IrDemoCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrDemoFailure> IrDemoFailureCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrDemoFailureWizard> IrDemoFailureWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrDemoFailureWizard> IrDemoFailureWizardWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrDemoFailure> IrDemoFailureWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrDemo> IrDemoWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrExport> IrExportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrExport> IrExportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrExportsLine> IrExportsLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrExportsLine> IrExportsLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrFilter> IrFilterCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<IrFilter> IrFilterUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrFilter> IrFilterWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrMailServer> IrMailServerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrMailServer> IrMailServerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelAccess> IrModelAccessCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelAccess> IrModelAccessWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelConstraint> IrModelConstraintCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelConstraint> IrModelConstraintWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModel> IrModelCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelDatum> IrModelDatumCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelDatum> IrModelDatumWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelField> IrModelFieldCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelField> IrModelFieldWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelFieldsSelection> IrModelFieldsSelectionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelFieldsSelection> IrModelFieldsSelectionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModelRelation> IrModelRelationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModelRelation> IrModelRelationWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModel> IrModelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModuleCategory> IrModuleCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModuleCategory> IrModuleCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModuleModule> IrModuleModuleCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrModuleModuleExclusion> IrModuleModuleExclusionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModuleModuleExclusion> IrModuleModuleExclusionWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrModuleModule> IrModuleModuleWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrProperty> IrPropertyCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrProperty> IrPropertyWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrRule> IrRuleCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrRule> IrRuleWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrSequence> IrSequenceCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrSequenceDateRange> IrSequenceDateRangeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrSequenceDateRange> IrSequenceDateRangeWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrSequence> IrSequenceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrServerObjectLine> IrServerObjectLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrServerObjectLine> IrServerObjectLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrUiMenu> IrUiMenuCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrUiMenu> IrUiMenuWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrUiView> IrUiViewCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<IrUiViewCustom> IrUiViewCustomCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<IrUiViewCustom> IrUiViewCustomUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrUiViewCustom> IrUiViewCustomWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<IrUiView> IrUiViewWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LotLabelLayout> LotLabelLayoutCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LotLabelLayout> LotLabelLayoutWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchAlert> LunchAlertCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchAlert> LunchAlertWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoveCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoveUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchCashmove> LunchCashmoveWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchLocation> LunchLocationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchLocation> LunchLocationWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrderCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrderUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrderWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchProductCategory> LunchProductCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchProductCategory> LunchProductCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchProduct> LunchProductCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchProduct> LunchProductWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSupplierCreateUs { get; set; } 

    //[InverseProperty("Responsible")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSupplierResponsibles { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSupplierWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<LunchTopping> LunchToppingCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<LunchTopping> LunchToppingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailActivityType> MailActivityTypeCreateUs { get; set; } 

    //[InverseProperty("DefaultUser")]
    [NotMapped]
    public virtual ICollection<MailActivityType> MailActivityTypeDefaultUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailActivityType> MailActivityTypeWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivityWriteUs { get; set; } 

    //[InverseProperty("AliasUser")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasAliasUsers { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailAlias> MailAliasWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailBlacklist> MailBlacklistCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailBlacklistRemove> MailBlacklistRemoveCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailBlacklistRemove> MailBlacklistRemoveWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailBlacklist> MailBlacklistWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannelCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMemberCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMemberWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessionWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailGatewayAllowed> MailGatewayAllowedCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailGatewayAllowed> MailGatewayAllowedWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailGuest> MailGuestCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailGuest> MailGuestWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailIceServer> MailIceServerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailIceServer> MailIceServerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailLinkPreview> MailLinkPreviewCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailLinkPreview> MailLinkPreviewWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMailCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMailWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessageCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailMessageSchedule> MailMessageScheduleCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailMessageSchedule> MailMessageScheduleWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailMessageSubtype> MailMessageSubtypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailMessageSubtype> MailMessageSubtypeWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailResendMessage> MailResendMessageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailResendMessage> MailResendMessageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailResendPartner> MailResendPartnerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailResendPartner> MailResendPartnerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailShortcode> MailShortcodeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailShortcode> MailShortcodeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplateCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailTemplatePreview> MailTemplatePreviewCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailTemplatePreview> MailTemplatePreviewWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailTemplateReset> MailTemplateResetCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailTemplateReset> MailTemplateResetWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailTemplate> MailTemplateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValueCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValueWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MailWizardInvite> MailWizardInviteCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MailWizardInvite> MailWizardInviteWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryCreateUs { get; set; } 

    //[InverseProperty("TechnicianUser")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryTechnicianUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentCreateUs { get; set; } 

    //[InverseProperty("OwnerUser")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentOwnerUsers { get; set; } 

    //[InverseProperty("TechnicianUser")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentTechnicianUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestCreateUs { get; set; } 

    //[InverseProperty("OwnerUser")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestOwnerUsers { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequestWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceStage> MaintenanceStageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceStage> MaintenanceStageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MaintenanceTeam> MaintenanceTeamCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MaintenanceTeam> MaintenanceTeamWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproductCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpBomByproduct> MrpBomByproductWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBomCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpBomLine> MrpBomLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBomWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarningCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarningWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpDocument> MrpDocumentCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpDocument> MrpDocumentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProduction> MrpImmediateProductionCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpImmediateProduction> MrpImmediateProductionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorder> MrpProductionBackorderCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionBackorder> MrpProductionBackorderWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplit> MrpProductionSplitCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitMulti> MrpProductionSplitMultiCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplitMulti> MrpProductionSplitMultiWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProductionSplit> MrpProductionSplitWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenterCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenterWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuildCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuildWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacityCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacityWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenterCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivityLoss> MrpWorkcenterProductivityLossCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivityLossType> MrpWorkcenterProductivityLossTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivityLossType> MrpWorkcenterProductivityLossTypeWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivityLoss> MrpWorkcenterProductivityLossWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterTag> MrpWorkcenterTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterTag> MrpWorkcenterTagWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> MrpWorkcenterWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorderCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorderWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNoteCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNoteUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNoteWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<NoteStage> NoteStageCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<NoteStage> NoteStageUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<NoteStage> NoteStageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<NoteTag> NoteTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<NoteTag> NoteTagWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentIcon> PaymentIconCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentIcon> PaymentIconWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviderCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentProviderOnboardingWizard> PaymentProviderOnboardingWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentProviderOnboardingWizard> PaymentProviderOnboardingWizardWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviderWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentRefundWizard> PaymentRefundWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentRefundWizard> PaymentRefundWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokenCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokenWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklist> PhoneBlacklistCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklistRemove> PhoneBlacklistRemoveCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklistRemove> PhoneBlacklistRemoveWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklist> PhoneBlacklistWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PickingLabelType> PickingLabelTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PickingLabelType> PickingLabelTypeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PortalShare> PortalShareCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PortalShare> PortalShareWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PortalWizard> PortalWizardCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PortalWizardUser> PortalWizardUserCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PortalWizardUser> PortalWizardUserWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PortalWizard> PortalWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosBill> PosBillCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosBill> PosBillWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosCategory> PosCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosCategory> PosCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosDetailsWizard> PosDetailsWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosDetailsWizard> PosDetailsWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosMakePayment> PosMakePaymentCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosMakePayment> PosMakePaymentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrderCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLineWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrderUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrderWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosPackOperationLot> PosPackOperationLotCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosPackOperationLot> PosPackOperationLotWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPaymentCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosPaymentMethod> PosPaymentMethodWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPaymentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosSessionCheckProductWizard> PosSessionCheckProductWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosSessionCheckProductWizard> PosSessionCheckProductWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessionCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessionUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PrivacyLog> PrivacyLogCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<PrivacyLog> PrivacyLogUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PrivacyLog> PrivacyLogWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizard> PrivacyLookupWizardCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PrivacyLookupWizard> PrivacyLookupWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProcurementGroup> ProcurementGroupCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProcurementGroup> ProcurementGroupWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductAttribute> ProductAttributeCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValueCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValueWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductAttributeValue> ProductAttributeValueCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductAttributeValue> ProductAttributeValueWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductAttribute> ProductAttributeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductCategory> ProductCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductCategory> ProductCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductImage> ProductImageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductImage> ProductImageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayoutCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductLabelLayout> ProductLabelLayoutWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagingCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductPackaging> ProductPackagingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelistCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductPricelistItem> ProductPricelistItemWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelistWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProductCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProductWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductPublicCategory> ProductPublicCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductPublicCategory> ProductPublicCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductRemoval> ProductRemovalCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductRemoval> ProductRemovalWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductReplenish> ProductReplenishWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductRibbon> ProductRibbonCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductRibbon> ProductRibbonWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfoCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfoWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTagWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValueCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValueWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectCollaborator> ProjectCollaboratorCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectCollaborator> ProjectCollaboratorWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectMilestone> ProjectMilestoneCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectMilestone> ProjectMilestoneWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectProjectStage> ProjectProjectStageWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjectWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectShareWizard> ProjectShareWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectShareWizard> ProjectShareWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTag> ProjectTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTag> ProjectTagWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskRecurrence> ProjectTaskRecurrenceCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskRecurrence> ProjectTaskRecurrenceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizardWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskType> ProjectTaskTypeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdateCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdateUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLineWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPaymentCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPaymentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFeeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairFee> RepairFeeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairLine> RepairLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairOrderMakeInvoice> RepairOrderMakeInvoiceCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairOrderMakeInvoice> RepairOrderMakeInvoiceWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<RepairTag> RepairTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<RepairTag> RepairTagWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ReportLayout> ReportLayoutCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ReportLayout> ReportLayoutWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ReportPaperformat> ReportPaperformatCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ReportPaperformat> ReportPaperformatWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResBank> ResBankCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResBank> ResBankWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanyWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResConfig> ResConfigCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResConfigInstaller> ResConfigInstallerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResConfigInstaller> ResConfigInstallerWriteUs { get; set; } 

    //[InverseProperty("AuthSignupTemplateUser")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingAuthSignupTemplateUsers { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResConfig> ResConfigWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountryCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCountryGroup> ResCountryGroupCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCountryGroup> ResCountryGroupWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCountryState> ResCountryStateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCountryState> ResCountryStateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCurrency> ResCurrencyCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCurrencyRate> ResCurrencyRateWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResCurrency> ResCurrencyWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroupCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroupWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResLang> ResLangCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResLang> ResLangWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBankCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBankWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> ResPartnerCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> ResPartnerCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnerCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerIndustry> ResPartnerIndustryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerIndustry> ResPartnerIndustryWriteUs { get; set; } 

    //[InverseProperty("PaymentResponsible")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnerPaymentResponsibles { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResPartnerTitle> ResPartnerTitleCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartnerTitle> ResPartnerTitleWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnerUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartnerWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ResUsersApikey> ResUsersApikeys { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersApikeysDescription> ResUsersApikeysDescriptionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersApikeysDescription> ResUsersApikeysDescriptionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersDeletion> ResUsersDeletionCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ResUsersDeletion> ResUsersDeletionUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersDeletion> ResUsersDeletionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersIdentitycheck> ResUsersIdentitycheckCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersIdentitycheck> ResUsersIdentitycheckWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersLog> ResUsersLogCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersLog> ResUsersLogWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersSetting> ResUsersSettingCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersSetting> ResUsersSettingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolume> ResUsersSettingsVolumeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolume> ResUsersSettingsVolumeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendanceCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendanceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendar> ResourceCalendarCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeafCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendarLeaf> ResourceCalendarLeafWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResourceCalendar> ResourceCalendarWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResourceCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResourceUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ResourceResource> ResourceResourceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancelCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLineCreateUs { get; set; } 

    //[InverseProperty("Salesman")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLineSalesmen { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderOption> SaleOrderOptionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplateCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptionWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrderTemplate> SaleOrderTemplateWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SalePaymentProviderOnboardingWizard> SalePaymentProviderOnboardingWizardCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SalePaymentProviderOnboardingWizard> SalePaymentProviderOnboardingWizardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsComposer> SmsComposerCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsComposer> SmsComposerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsResend> SmsResendCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsResendRecipient> SmsResendRecipientCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsResendRecipient> SmsResendRecipientWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsResend> SmsResendWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsSm> SmsSmCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsSm> SmsSmWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsTemplate> SmsTemplateCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsTemplatePreview> SmsTemplatePreviewCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsTemplatePreview> SmsTemplatePreviewWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SmsTemplateReset> SmsTemplateResetCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsTemplateReset> SmsTemplateResetWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SmsTemplate> SmsTemplateWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoiceCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoiceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetterCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatErrorCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatErrorWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFieldCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFieldWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetterUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetterWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboardCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboardGroup> SpreadsheetDashboardGroupCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboardGroup> SpreadsheetDashboardGroupWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboardWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockAssignSerial> StockAssignSerialCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockAssignSerial> StockAssignSerialWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmationCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmationWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockChangeProductQty> StockChangeProductQtyCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockChangeProductQty> StockChangeProductQtyWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransfer> StockImmediateTransferCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockImmediateTransfer> StockImmediateTransferWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockInventoryAdjustmentName> StockInventoryAdjustmentNameCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockInventoryAdjustmentName> StockInventoryAdjustmentNameWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockInventoryConflict> StockInventoryConflictCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockInventoryConflict> StockInventoryConflictWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockInventoryWarning> StockInventoryWarningCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockInventoryWarning> StockInventoryWarningWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockLocation> StockLocationWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLotCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLotWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnoozeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnoozeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPackageDestination> StockPackageDestinationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPackageDestination> StockPackageDestinationWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPackageLevel> StockPackageLevelCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPackageLevel> StockPackageLevelWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPackageType> StockPackageTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPackageType> StockPackageTypeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPickingType> StockPickingTypeWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRuleCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockPutawayRule> StockPutawayRuleWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuantCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockQuantPackage> StockQuantPackageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockQuantPackage> StockQuantPackageWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuantUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuantWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockQuantityHistory> StockQuantityHistoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockQuantityHistory> StockQuantityHistoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfoCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfoWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptionCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptionWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockRequestCount> StockRequestCountCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<StockRequestCount> StockRequestCountUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockRequestCount> StockRequestCountWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockReturnPicking> StockReturnPickingCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockReturnPickingLine> StockReturnPickingLineWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockReturnPicking> StockReturnPickingWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockRoute> StockRouteCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockRoute> StockRouteWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRuleCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRuleWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockRulesReport> StockRulesReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockSchedulerCompute> StockSchedulerComputeCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockSchedulerCompute> StockSchedulerComputeWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScrapCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScrapWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacityCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacityWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockStorageCategory> StockStorageCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockStorageCategory> StockStorageCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockTraceabilityReport> StockTraceabilityReportCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockTraceabilityReport> StockTraceabilityReportWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockTrackConfirmation> StockTrackConfirmationWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockTrackLine> StockTrackLineCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockTrackLine> StockTrackLineWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayerCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluationCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluationWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockValuationLayer> StockValuationLayerWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouseWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrapCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrapWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuildCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuildWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeIrAsset> ThemeIrAssetCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeIrAsset> ThemeIrAssetWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeIrAttachment> ThemeIrAttachmentCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeIrAttachment> ThemeIrAttachmentWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeIrUiView> ThemeIrUiViewCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeIrUiView> ThemeIrUiViewWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeWebsiteMenu> ThemeWebsiteMenuCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeWebsiteMenu> ThemeWebsiteMenuWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ThemeWebsitePage> ThemeWebsitePageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ThemeWebsitePage> ThemeWebsitePageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UomCategory> UomCategoryCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UomCategory> UomCategoryWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UomUom> UomUomCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UomUom> UomUomWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaignCreateUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaignUsers { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmCampaign> UtmCampaignWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmMedium> UtmMediumCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmMedium> UtmMediumWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmSource> UtmSourceCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmSource> UtmSourceWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmStage> UtmStageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmStage> UtmStageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<UtmTag> UtmTagCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<UtmTag> UtmTagWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<ValidateAccountMove> ValidateAccountMoveCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<ValidateAccountMove> ValidateAccountMoveWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebEditorConverterTest> WebEditorConverterTestCreateUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebEditorConverterTestSub> WebEditorConverterTestSubCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebEditorConverterTestSub> WebEditorConverterTestSubWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebEditorConverterTest> WebEditorConverterTestWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<WebTourTour> WebTourTours { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteBaseUnit> WebsiteBaseUnitCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteBaseUnit> WebsiteBaseUnitWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeatureCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeatureWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteCreateUs { get; set; } 

    //[InverseProperty("CrmDefaultUser")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteCrmDefaultUsers { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> WebsiteMenuCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> WebsiteMenuWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsitePage> WebsitePageCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsitePage> WebsitePageWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteRewrite> WebsiteRewriteCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteRewrite> WebsiteRewriteWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteRobot> WebsiteRobotCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteRobot> WebsiteRobotWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteRoute> WebsiteRouteCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteRoute> WebsiteRouteWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraFieldCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraFieldWriteUs { get; set; } 

    //[InverseProperty("Salesperson")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteSalespeople { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilterCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilterWriteUs { get; set; } 

    //[InverseProperty("User")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteUsers { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitorCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitorWriteUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<Website> WebsiteWriteUs { get; set; } 

    //[InverseProperty("CreateU")]
    [NotMapped]
    public virtual ICollection<WizardIrModelMenuCreate> WizardIrModelMenuCreateCreateUs { get; set; } 

    //[InverseProperty("WriteU")]
    [NotMapped]
    public virtual ICollection<WizardIrModelMenuCreate> WizardIrModelMenuCreateWriteUs { get; set; } 

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<ResCompany> Cids { get; set; } 

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMasses { get; set; } 

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<DigestDigest> DigestDigests { get; set; } 

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<DigestTip> DigestTips { get; set; } 

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } 

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } 

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsersNavigation")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobsNavigation { get; set; } 

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<HrJob> Jobs { get; set; } 

    [ForeignKey("ResUsersId")]
    //[InverseProperty("ResUsers")]
    [NotMapped]
    public virtual ICollection<MaintenanceTeam> MaintenanceTeams { get; set; } 

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<LunchProduct> Products { get; set; } 

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<ProjectProject> Projects { get; set; } 

    [ForeignKey("UserId")]
    //[InverseProperty("Users")]
    [NotMapped]
    public virtual ICollection<CrmTeam> Teams { get; set; } 
    */
}
