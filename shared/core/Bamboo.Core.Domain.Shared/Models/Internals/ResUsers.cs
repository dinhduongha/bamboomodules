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

[Table("res_users")]
//[Index("CreateDate", Name = "res_users__create_date_index")]
//[Index("PartnerId", Name = "res_users__partner_id_index")]
//[Index("GoogleCalendarAccountId", Name = "res_users_google_token_uniq", IsUnique = true)]
//[Index("Login", "WebsiteId", Name = "res_users_login_key", IsUnique = true)]
//[Index("OauthProviderId", "OauthUid", Name = "res_users_uniq_users_oauth_provider_oauth_uid", IsUnique = true)]
public partial class ResUsers: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("login")]
    public string? Login { get; set; }

    [Column("password")]
    public string? Password { get; set; }

    [Column("action_id")]
    public Guid? ActionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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

    [JsonField]
    [Column("property_warehouse_id", TypeName = "jsonb")]
    public string? PropertyWarehouseId { get; set; }

    [Column("target_sales_won")]
    public long? TargetSalesWon { get; set; }

    [Column("target_sales_done")]
    public long? TargetSalesDone { get; set; }

    [Column("target_sales_invoiced")]
    public long? TargetSalesInvoiced { get; set; }

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

    [Column("oauth_provider_id")]
    public Guid? OauthProviderId { get; set; }

    [Column("oauth_uid")]
    public string? OauthUid { get; set; }

    [Column("oauth_access_token")]
    public string? OauthAccessToken { get; set; }

    [Column("livechat_username")]
    public string? LivechatUsername { get; set; }

    [Column("google_calendar_account_id")]
    public Guid? GoogleCalendarAccountId { get; set; }

    [Column("microsoft_calendar_rtoken")]
    public string? MicrosoftCalendarRtoken { get; set; }

    [Column("microsoft_calendar_token")]
    public string? MicrosoftCalendarToken { get; set; }

    [Column("microsoft_calendar_token_validity", TypeName = "timestamp without time zone")]
    public DateTime? MicrosoftCalendarTokenValidity { get; set; }

    [Column("microsoft_calendar_sync_token")]
    public string? MicrosoftCalendarSyncToken { get; set; }

    [Column("microsoft_synchronization_stopped")]
    public bool? MicrosoftSynchronizationStopped { get; set; }

    // [Column("oauth_provider_id")]
    // public Guid? OauthProviderId { get; set; }

    // [Column("oauth_uid")]
    // public string? OauthUid { get; set; }

    // [Column("oauth_access_token")]
    // public string? OauthAccessToken { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAccount> AccountAccountCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAccountTag> AccountAccountTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAccountTag> AccountAccountTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAccountType> AccountAccountTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAccountType> AccountAccountTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAccount> AccountAccountWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAccruedOrdersWizard> AccountAccruedOrdersWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalanceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalanceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccountWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilityCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAnalyticApplicability> AccountAnalyticApplicabilityWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlanCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlanWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAssetAsset> AccountAssetAssetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAssetAsset> AccountAssetAssetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAssetDepreciationLine> AccountAssetDepreciationLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAutomaticEntryWizard> AccountAutomaticEntryWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountAutopostBillsWizard> AccountAutopostBillsWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountAutopostBillsWizard> AccountAutopostBillsWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountBalanceReport> AccountBalanceReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountBalanceReport> AccountBalanceReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountBankStatement> AccountBankStatementCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountBankStatementImport> AccountBankStatementImportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountBankStatementImport> AccountBankStatementImportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountBankStatement> AccountBankStatementWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountBankbookReport> AccountBankbookReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountBankbookReport> AccountBankbookReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountBudgetPost> AccountBudgetPostCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountBudgetPost> AccountBudgetPostWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountCashRounding> AccountCashRoundingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountCashRounding> AccountCashRoundingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountCashbookReport> AccountCashbookReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountCashbookReport> AccountCashbookReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountChartTemplate> AccountChartTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountChartTemplate> AccountChartTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountCommonJournalReport> AccountCommonJournalReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountCommonReport> AccountCommonReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountCommonReport> AccountCommonReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountDaybookReport> AccountDaybookReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountDaybookReport> AccountDaybookReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountDebitNote> AccountDebitNoteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountDebitNote> AccountDebitNoteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountEdiDocument> AccountEdiDocumentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountEdiDocument> AccountEdiDocumentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountEdiFormat> AccountEdiFormatCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountEdiFormat> AccountEdiFormatWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountEdiProxyClientUser> AccountEdiProxyClientUserCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountEdiProxyClientUser> AccountEdiProxyClientUserWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFinancialReport> AccountFinancialReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFinancialReport> AccountFinancialReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOpCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFinancialYearOp> AccountFinancialYearOpWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalPositionAccount> AccountFiscalPositionAccountWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFiscalPosition> AccountFiscalPositionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalPosition> AccountFiscalPositionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFiscalYear> AccountFiscalYearCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalYear> AccountFiscalYearWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFullReconcile> AccountFullReconcileCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFullReconcile> AccountFullReconcileWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountGroup> AccountGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountGroup> AccountGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountIncoterms> AccountIncotermsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountIncoterms> AccountIncotermsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountJournal> AccountJournalCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountJournalGroup> AccountJournalGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountJournalGroup> AccountJournalGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountJournal> AccountJournalWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountLockException> AccountLockExceptionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<AccountLockException> AccountLockExceptionUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountLockException> AccountLockExceptionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountMergeWizard> AccountMergeWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountMergeWizardLine> AccountMergeWizardLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountMergeWizardLine> AccountMergeWizardLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountMergeWizard> AccountMergeWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalPositionTax> AccountFiscalPositionTaxWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountFiscalPosition> AccountFiscalPositionWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountGroupTemplate> AccountGroupTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountGroupTemplate> AccountGroupTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountInvoiceSend> AccountInvoiceSendCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountInvoiceSend> AccountInvoiceSendWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("SaleActivityUserId")]
    // [InverseProperty("SaleActivityUser")]
    // public virtual ICollection<AccountJournal> AccountJournalSaleActivityUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountMove> AccountMoveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("InvoiceUserId")]
    // [InverseProperty("InvoiceUser")]
    // public virtual ICollection<AccountMove> AccountMoveInvoiceUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountMoveReversal> AccountMoveReversalCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountMoveReversal> AccountMoveReversalWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountMoveSendBatchWizard> AccountMoveSendBatchWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountMoveSendBatchWizard> AccountMoveSendBatchWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountMove> AccountMoveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPartialReconcile> AccountPartialReconcileWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPayment> AccountPaymentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPaymentMethod> AccountPaymentMethodCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPaymentMethodLine> AccountPaymentMethodLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPaymentMethod> AccountPaymentMethodWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPaymentTerm> AccountPaymentTermCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPaymentTermLine> AccountPaymentTermLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPaymentTermLine> AccountPaymentTermLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPaymentTerm> AccountPaymentTermWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPayment> AccountPaymentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPeppolService> AccountPeppolServiceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPeppolServiceWizard> AccountPeppolServiceWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPeppolServiceWizard> AccountPeppolServiceWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPeppolService> AccountPeppolServiceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountPrintJournal> AccountPrintJournalCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountPrintJournal> AccountPrintJournalWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReconcileModel> AccountReconcileModelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReconcileModel> AccountReconcileModelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountRecurringTemplate> AccountRecurringTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReportColumn> AccountReportColumnCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReportColumn> AccountReportColumnWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReport> AccountReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReportExpression> AccountReportExpressionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReportExpression> AccountReportExpressionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReportExternalValue> AccountReportExternalValueCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReportExternalValue> AccountReportExternalValueWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReportLine> AccountReportLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReportLine> AccountReportLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountReport> AccountReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountResequenceWizard> AccountResequenceWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountResequenceWizard> AccountResequenceWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountSecureEntriesWizard> AccountSecureEntriesWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountSecureEntriesWizard> AccountSecureEntriesWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfigCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountSetupBankManualConfig> AccountSetupBankManualConfigWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountTax> AccountTaxCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountTaxGroup> AccountTaxGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountTaxRepartitionLine> AccountTaxRepartitionLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountTaxReportWizard> AccountTaxReportWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountTaxTemplate> AccountTaxTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountTaxTemplate> AccountTaxTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountTax> AccountTaxWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountTourUploadBill> AccountTourUploadBillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirmCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirmWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountTourUploadBill> AccountTourUploadBillWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountUnreconcile> AccountUnreconcileCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountUnreconcile> AccountUnreconcileWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountUpdateTaxTagsWizard> AccountUpdateTaxTagsWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountUpdateTaxTagsWizard> AccountUpdateTaxTagsWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AccountingReport> AccountingReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AccountingReport> AccountingReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasonCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ApplicantGetRefuseReason> ApplicantGetRefuseReasonWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ApplicantSendMail> ApplicantSendMailCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ApplicantSendMail> ApplicantSendMailWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AssetDepreciationConfirmationWizard> AssetDepreciationConfirmationWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AssetDepreciationConfirmationWizard> AssetDepreciationConfirmationWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AssetModify> AssetModifyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AssetModify> AssetModifyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AuthOauthProvider> AuthOauthProviderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AuthOauthProvider> AuthOauthProviderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AuthPasskeyKeyCreate> AuthPasskeyKeyCreateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AuthPasskeyKey> AuthPasskeyKeyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AuthPasskeyKeyCreate> AuthPasskeyKeyCreateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AuthPasskeyKey> AuthPasskeyKeyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<AuthTotpDevice> AuthTotpDevice { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AuthTotpRateLimitLog> AuthTotpRateLimitLogCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<AuthTotpRateLimitLog> AuthTotpRateLimitLogUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AuthTotpRateLimitLog> AuthTotpRateLimitLogWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<AuthTotpWizard> AuthTotpWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<AuthTotpWizard> AuthTotpWizardUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<AuthTotpWizard> AuthTotpWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BarcodeNomenclature> BarcodeNomenclatureCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BarcodeNomenclature> BarcodeNomenclatureWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BarcodeRule> BarcodeRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BarcodeRule> BarcodeRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseAutomation> BaseAutomationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseAutomation> BaseAutomationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseDocumentLayout> BaseDocumentLayoutCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseDocumentLayout> BaseDocumentLayoutWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseEnableProfilingWizard> BaseEnableProfilingWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseEnableProfilingWizard> BaseEnableProfilingWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseGeoProvider> BaseGeoProviderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseGeoProvider> BaseGeoProviderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportImport> BaseImportImportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportImport> BaseImportImportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportMapping> BaseImportMappingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportMapping> BaseImportMappingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportModule> BaseImportModuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportModule> BaseImportModuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseLanguageExport> BaseLanguageExportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseLanguageExport> BaseLanguageExportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseLanguageImport> BaseLanguageImportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseLanguageImport> BaseLanguageImportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseLanguageInstall> BaseLanguageInstallCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseLanguageInstall> BaseLanguageInstallWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseModuleInstallReview> BaseModuleInstallReviewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseModuleInstallReview> BaseModuleInstallReviewWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseModuleUninstall> BaseModuleUninstallCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseModuleUninstall> BaseModuleUninstallWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseModuleUpdate> BaseModuleUpdateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseModuleUpdate> BaseModuleUpdateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseModuleUpgrade> BaseModuleUpgradeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseModuleUpgrade> BaseModuleUpgradeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BasePartnerMergeLine> BasePartnerMergeLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BasePartnerMergeLine> BasePartnerMergeLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BillToPoWizard> BillToPoWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BillToPoWizard> BillToPoWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BlogBlog> BlogBlogCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BlogBlog> BlogBlogWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BlogPost> BlogPostCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BlogPost> BlogPostWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BlogTagCategory> BlogTagCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BlogTagCategory> BlogTagCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BlogTag> BlogTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BlogTag> BlogTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BusBus> BusBusCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BusBus> BusBusWriteU { get; set; }

    // [Many2one]
    // [InverseProperty("User")] //Many2one
    public virtual BusPresence? BusPresence { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CalendarAlarm> CalendarAlarmCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CalendarAlarm> CalendarAlarmWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CalendarAttendee> CalendarAttendeeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CalendarAttendee> CalendarAttendeeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CalendarEvent> CalendarEventCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CalendarEventType> CalendarEventTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CalendarEventType> CalendarEventTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CalendarEvent> CalendarEventUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CalendarEvent> CalendarEventWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CalendarFilters> CalendarFiltersCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CalendarFilters> CalendarFiltersUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CalendarFilters> CalendarFiltersWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CalendarPopoverDeleteWizard> CalendarPopoverDeleteWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CalendarPopoverDeleteWizard> CalendarPopoverDeleteWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CalendarProviderConfig> CalendarProviderConfigCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CalendarProviderConfig> CalendarProviderConfigWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CalendarRecurrence> CalendarRecurrenceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CalendarRecurrence> CalendarRecurrenceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CandidateSendMail> CandidateSendMailCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CandidateSendMail> CandidateSendMailWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CardCampaign> CardCampaignCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CardCampaignTag> CardCampaignTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CardCampaignTag> CardCampaignTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CardCampaign> CardCampaignUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CardCampaign> CardCampaignWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CardCard> CardCardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CardCard> CardCardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CardTemplate> CardTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CardTemplate> CardTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CertificateCertificate> CertificateCertificateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CertificateCertificate> CertificateCertificateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CertificateKey> CertificateKeyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CertificateKey> CertificateKeyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChangeLockDate> ChangeLockDateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChangeLockDate> ChangeLockDateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChangePasswordOwn> ChangePasswordOwnCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChangePasswordOwn> ChangePasswordOwnWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChangePasswordUser> ChangePasswordUserCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ChangePasswordUser> ChangePasswordUserUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChangePasswordUser> ChangePasswordUserWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChangePasswordWizard> ChangePasswordWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChangePasswordWizard> ChangePasswordWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChangeProductionQty> ChangeProductionQtyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChangeProductionQty> ChangeProductionQtyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChatRoom> ChatRoomCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChatRoom> ChatRoomWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChatbotMessage> ChatbotMessageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChatbotMessage> ChatbotMessageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChatbotScriptAnswer> ChatbotScriptAnswerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChatbotScriptAnswer> ChatbotScriptAnswerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChatbotScript> ChatbotScriptCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChatbotScriptStep> ChatbotScriptStepCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChatbotScriptStep> ChatbotScriptStepWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChatbotScript> ChatbotScriptWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChooseDeliveryCarrier> ChooseDeliveryCarrierCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChooseDeliveryCarrier> ChooseDeliveryCarrierWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ChooseDeliveryPackage> ChooseDeliveryPackageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ChooseDeliveryPackage> ChooseDeliveryPackageWriteU { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ResUsers")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ConfirmStockSms> ConfirmStockSmsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ConfirmStockSms> ConfirmStockSmsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CouponShare> CouponShareCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CouponShare> CouponShareWriteU { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("InverseCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmIapLeadHelpers> CrmIapLeadHelpersCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmIapLeadHelpers> CrmIapLeadHelpersWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmIapLeadIndustry> CrmIapLeadIndustryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmIapLeadIndustry> CrmIapLeadIndustryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmIapLeadMiningRequest> CrmIapLeadMiningRequestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmIapLeadRole> CrmIapLeadRoleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmIapLeadRole> CrmIapLeadRoleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmIapLeadSeniority> CrmIapLeadSeniorityCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmIapLeadSeniority> CrmIapLeadSeniorityWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLeadAssignation> CrmLeadAssignationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLeadAssignation> CrmLeadAssignationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLead> CrmLeadCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLeadForwardToPartner> CrmLeadForwardToPartnerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLeadForwardToPartner> CrmLeadForwardToPartnerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLeadLost> CrmLeadLostCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLeadLost> CrmLeadLostWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLeadPlsUpdate> CrmLeadPlsUpdateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLeadPlsUpdate> CrmLeadPlsUpdateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequencyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyFieldCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyFieldWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLeadScoringFrequency> CrmLeadScoringFrequencyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrmLead> CrmLeadUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLead> CrmLeadWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmLostReason> CrmLostReasonCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmLostReason> CrmLostReasonWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmMergeOpportunity> CrmMergeOpportunityWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmQuotationPartner> CrmQuotationPartnerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmQuotationPartner> CrmQuotationPartnerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmRecurringPlan> CrmRecurringPlanCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmRecurringPlan> CrmRecurringPlanWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmRevealRule> CrmRevealRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrmRevealRule> CrmRevealRuleUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmRevealRule> CrmRevealRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmRevealView> CrmRevealViewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmRevealView> CrmRevealViewWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmStage> CrmStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmStage> CrmStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmTag> CrmTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmTag> CrmTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmTeam> CrmTeamCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrmTeamMember> CrmTeamMemberCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrmTeamMember> CrmTeamMemberUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmTeamMember> CrmTeamMemberWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrmTeam> CrmTeamUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrmTeam> CrmTeamWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrossoveredBudget> CrossoveredBudgetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<CrossoveredBudgetLines> CrossoveredBudgetLinesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrossoveredBudgetLines> CrossoveredBudgetLinesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<CrossoveredBudget> CrossoveredBudgetUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<CrossoveredBudget> CrossoveredBudgetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DataRecycleModel> DataRecycleModelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DataRecycleModel> DataRecycleModelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DataRecycleRecord> DataRecycleRecordCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DataRecycleRecord> DataRecycleRecordWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DecimalPrecision> DecimalPrecisionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DecimalPrecision> DecimalPrecisionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DeliveryCarrier> DeliveryCarrierCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DeliveryCarrier> DeliveryCarrierWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DeliveryPriceRule> DeliveryPriceRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DeliveryPriceRule> DeliveryPriceRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DeliveryZipPrefix> DeliveryZipPrefixCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DeliveryZipPrefix> DeliveryZipPrefixWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DigestDigest> DigestDigestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DigestDigest> DigestDigestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DigestTip> DigestTipCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DigestTip> DigestTipWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DiscussChannel> DiscussChannelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DiscussChannelMember> DiscussChannelMemberCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DiscussChannelMember> DiscussChannelMemberWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DiscussChannelRtcSession> DiscussChannelRtcSessionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DiscussChannelRtcSession> DiscussChannelRtcSessionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DiscussChannel> DiscussChannelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DiscussGifFavorite> DiscussGifFavoriteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DiscussGifFavorite> DiscussGifFavoriteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<DiscussVoiceMetadata> DiscussVoiceMetadataCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<DiscussVoiceMetadata> DiscussVoiceMetadataWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventBoothCategory> EventBoothCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventBoothCategory> EventBoothCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventBoothConfigurator> EventBoothConfiguratorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventBoothConfigurator> EventBoothConfiguratorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventBooth> EventBoothCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventBoothRegistration> EventBoothRegistrationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventBoothRegistration> EventBoothRegistrationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventBooth> EventBoothWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventEventConfigurator> EventEventConfiguratorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventEventConfigurator> EventEventConfiguratorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventEvent> EventEventCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventEventTicket> EventEventTicketCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventEventTicket> EventEventTicketWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<EventEvent> EventEventUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventEvent> EventEventWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventLeadRule> EventLeadRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LeadUserId")]
    // [InverseProperty("LeadUser")]
    // public virtual ICollection<EventLeadRule> EventLeadRuleLeadUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventLeadRule> EventLeadRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventMail> EventMailCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventMailRegistration> EventMailRegistrationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventMailRegistration> EventMailRegistrationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventMail> EventMailWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventMeetingRoom> EventMeetingRoomCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventMeetingRoom> EventMeetingRoomWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventQuestionAnswer> EventQuestionAnswerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventQuestionAnswer> EventQuestionAnswerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventQuestion> EventQuestionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventQuestion> EventQuestionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventQuizAnswer> EventQuizAnswerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventQuizAnswer> EventQuizAnswerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventQuiz> EventQuizCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventQuizQuestion> EventQuizQuestionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventQuizQuestion> EventQuizQuestionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventQuiz> EventQuizWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventRegistrationAnswer> EventRegistrationAnswerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventRegistrationAnswer> EventRegistrationAnswerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventRegistration> EventRegistrationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventRegistration> EventRegistrationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventSponsor> EventSponsorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventSponsorType> EventSponsorTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventSponsorType> EventSponsorTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventSponsor> EventSponsorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventStage> EventStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventStage> EventStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTagCategory> EventTagCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTagCategory> EventTagCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTag> EventTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTag> EventTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTrack> EventTrackCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTrackLocation> EventTrackLocationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTrackLocation> EventTrackLocationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTrackStage> EventTrackStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTrackStage> EventTrackStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTrackTagCategory> EventTrackTagCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTrackTagCategory> EventTrackTagCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTrackTag> EventTrackTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTrackTag> EventTrackTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<EventTrack> EventTrackUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTrackVisitor> EventTrackVisitorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTrackVisitor> EventTrackVisitorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTrack> EventTrackWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTypeBooth> EventTypeBoothCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTypeBooth> EventTypeBoothWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventType> EventTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTypeMail> EventTypeMailCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTypeMail> EventTypeMailWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<EventTypeTicket> EventTypeTicketCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventTypeTicket> EventTypeTicketWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<EventType> EventTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FetchmailServer> FetchmailServerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FetchmailServer> FetchmailServerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetServiceType> FleetServiceTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetServiceType> FleetServiceTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicle> FleetVehicleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServicesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ManagerId")]
    // [InverseProperty("Manager")]
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServicesManager { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServicesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ManagerId")]
    // [InverseProperty("Manager")]
    // public virtual ICollection<FleetVehicle> FleetVehicleManager { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleModelBrand> FleetVehicleModelBrandCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleModelBrand> FleetVehicleModelBrandWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleModelCategory> FleetVehicleModelCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleModelCategory> FleetVehicleModelCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleModel> FleetVehicleModelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleModel> FleetVehicleModelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleSendMail> FleetVehicleSendMailCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleSendMail> FleetVehicleSendMailWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleState> FleetVehicleStateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleState> FleetVehicleStateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FleetVehicleTag> FleetVehicleTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicleTag> FleetVehicleTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FleetVehicle> FleetVehicleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FollowupFollowup> FollowupFollowupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FollowupFollowup> FollowupFollowupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FollowupLine> FollowupLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ManualActionResponsibleId")]
    // [InverseProperty("ManualActionResponsible")]
    // public virtual ICollection<FollowupLine> FollowupLineManualActionResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FollowupLine> FollowupLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FollowupPrint> FollowupPrintCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FollowupPrint> FollowupPrintWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<FollowupSendingResults> FollowupSendingResultsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<FollowupSendingResults> FollowupSendingResultsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ForumForum> ForumForumCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ForumForum> ForumForumWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ClosedUid")]
    // [InverseProperty("ClosedU")]
    // public virtual ICollection<ForumPost> ForumPostClosedU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ForumPost> ForumPostCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("FlagUserId")]
    // [InverseProperty("FlagUser")]
    // public virtual ICollection<ForumPost> ForumPostFlagUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ModeratorId")]
    // [InverseProperty("Moderator")]
    // public virtual ICollection<ForumPost> ForumPostModerator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ForumPostReason> ForumPostReasonCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ForumPostReason> ForumPostReasonWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ForumPostVote> ForumPostVoteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("RecipientId")]
    // [InverseProperty("Recipient")]
    // public virtual ICollection<ForumPostVote> ForumPostVoteRecipient { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ForumPostVote> ForumPostVoteUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ForumPostVote> ForumPostVoteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ForumPost> ForumPostWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ForumTag> ForumTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ForumTag> ForumTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationBadge> GamificationBadgeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationBadgeUser> GamificationBadgeUserCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("SenderId")]
    // [InverseProperty("Sender")]
    // public virtual ICollection<GamificationBadgeUser> GamificationBadgeUserSender { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<GamificationBadgeUser> GamificationBadgeUserUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationBadgeUserWizard> GamificationBadgeUserWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<GamificationBadgeUserWizard> GamificationBadgeUserWizardUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationBadgeUserWizard> GamificationBadgeUserWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationBadgeUser> GamificationBadgeUserWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationBadge> GamificationBadgeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationChallenge> GamificationChallengeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationChallengeLine> GamificationChallengeLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationChallengeLine> GamificationChallengeLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ManagerId")]
    // [InverseProperty("Manager")]
    // public virtual ICollection<GamificationChallenge> GamificationChallengeManager { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationChallenge> GamificationChallengeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationGoal> GamificationGoalCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<GamificationGoal> GamificationGoalUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationGoalWizard> GamificationGoalWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationGoalWizard> GamificationGoalWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationGoal> GamificationGoalWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationKarmaRank> GamificationKarmaRankCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationKarmaRank> GamificationKarmaRankWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GamificationKarmaTracking> GamificationKarmaTrackingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<GamificationKarmaTracking> GamificationKarmaTrackingUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GamificationKarmaTracking> GamificationKarmaTrackingWriteU { get; set; }

    // [Many2one]
    [ForeignKey("GoogleCalendarAccountId")]
    // [InverseProperty("ResUsers")] //Many2one
    public virtual GoogleCalendarCredentials? GoogleCalendarAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GoogleCalendarAccountReset> GoogleCalendarAccountResetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<GoogleCalendarAccountReset> GoogleCalendarAccountResetUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GoogleCalendarAccountReset> GoogleCalendarAccountResetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<GoogleCalendarCredentials> GoogleCalendarCredentialsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<GoogleCalendarCredentials> GoogleCalendarCredentialsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HomeworkLocationWizard> HomeworkLocationWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HomeworkLocationWizard> HomeworkLocationWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrApplicantCategory> HrApplicantCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrApplicantCategory> HrApplicantCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrApplicant> HrApplicantCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReasonCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrApplicantRefuseReason> HrApplicantRefuseReasonWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrApplicantSkill> HrApplicantSkillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrApplicantSkill> HrApplicantSkillWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<HrApplicant> HrApplicantUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrApplicant> HrApplicantWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrAttendance> HrAttendanceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrAttendanceOvertime> HrAttendanceOvertimeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrAttendanceOvertime> HrAttendanceOvertimeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrAttendance> HrAttendanceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrCandidate> HrCandidateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrCandidateSkill> HrCandidateSkillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrCandidateSkill> HrCandidateSkillWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<HrCandidate> HrCandidateUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrCandidate> HrCandidateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrContractAdvantageTemplate> HrContractAdvantageTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrContractAdvantageTemplate> HrContractAdvantageTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrContract> HrContractCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("HrResponsibleId")]
    // [InverseProperty("HrResponsible")]
    // public virtual ICollection<HrContract> HrContractHrResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrContractType> HrContractTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrContractType> HrContractTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrContract> HrContractWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrContributionRegister> HrContributionRegisterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrContributionRegister> HrContributionRegisterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrDepartment> HrDepartmentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrDepartment> HrDepartmentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrDepartureReason> HrDepartureReasonCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrDepartureReason> HrDepartureReasonWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrDepartureWizard> HrDepartureWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrDepartureWizard> HrDepartureWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("AttendanceManagerId")]
    // [InverseProperty("AttendanceManager")]
    // public virtual ICollection<HrEmployee> HrEmployeeAttendanceManager { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrEmployeeCategory> HrEmployeeCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrEmployeeCategory> HrEmployeeCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrEmployee> HrEmployeeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrEmployeeCvWizard> HrEmployeeCvWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrEmployeeCvWizard> HrEmployeeCvWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrEmployeeDeleteWizard> HrEmployeeDeleteWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrEmployeeDeleteWizard> HrEmployeeDeleteWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ExpenseManagerId")]
    // [InverseProperty("ExpenseManager")]
    // public virtual ICollection<HrEmployee> HrEmployeeExpenseManager { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LeaveManagerId")]
    // [InverseProperty("LeaveManager")]
    // public virtual ICollection<HrEmployee> HrEmployeeLeaveManager { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrEmployeeLocation> HrEmployeeLocationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrEmployeeLocation> HrEmployeeLocationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrEmployeeSkill> HrEmployeeSkillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrEmployeeSkill> HrEmployeeSkillWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<HrEmployee> HrEmployeeUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrEmployee> HrEmployeeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrExpenseApproveDuplicate> HrExpenseApproveDuplicateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrExpense> HrExpenseCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrExpenseRefuseWizard> HrExpenseRefuseWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheetUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplitCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrExpenseSplitWizard> HrExpenseSplitWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrExpenseSplit> HrExpenseSplitWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrExpense> HrExpenseWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeaveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrHolidaysCancelLeave> HrHolidaysCancelLeaveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrHolidaysSummaryEmployee> HrHolidaysSummaryEmployeeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrHolidaysSummaryEmployee> HrHolidaysSummaryEmployeeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrJob> HrJobCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrJobPlatform> HrJobPlatformCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrJobPlatform> HrJobPlatformWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("HrResponsibleId")]
    // [InverseProperty("HrResponsible")]
    // public virtual ICollection<HrJob> HrJobHrResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<HrJob> HrJobUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrJob> HrJobWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeaveAccrualLevel> HrLeaveAccrualLevelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeaveAccrualLevel> HrLeaveAccrualLevelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlanCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeaveAccrualPlan> HrLeaveAccrualPlanWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeave> HrLeaveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDayCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeaveMandatoryDay> HrLeaveMandatoryDayWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeaveStressDay> HrLeaveStressDayCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeaveStressDay> HrLeaveStressDayWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrLeaveType> HrLeaveTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ResponsibleId")]
    // [InverseProperty("Responsible")]
    // public virtual ICollection<HrLeaveType> HrLeaveTypeResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeaveType> HrLeaveTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<HrLeave> HrLeaveUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrLeave> HrLeaveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPayrollStructure> HrPayrollStructureCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPayrollStructureType> HrPayrollStructureTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPayrollStructure> HrPayrollStructureWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPayslip> HrPayslipCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPayslipEmployees> HrPayslipEmployeesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPayslipEmployees> HrPayslipEmployeesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPayslipInput> HrPayslipInputCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPayslipInput> HrPayslipInputWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPayslipLine> HrPayslipLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPayslipLine> HrPayslipLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPayslipRun> HrPayslipRunCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPayslipRun> HrPayslipRunWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPayslipWorkedDays> HrPayslipWorkedDaysCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPayslipWorkedDays> HrPayslipWorkedDaysWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPayslip> HrPayslipWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ResponsibleId")]
    // [InverseProperty("ResponsibleNavigation")]
    // public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeResponsibleNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPlan> HrPlanCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrPlanWizard> HrPlanWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPlanWizard> HrPlanWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrPlan> HrPlanWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrRecruitmentDegree> HrRecruitmentDegreeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrRecruitmentDegree> HrRecruitmentDegreeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrRecruitmentSource> HrRecruitmentSourceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrRecruitmentSource> HrRecruitmentSourceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrRecruitmentStage> HrRecruitmentStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrRecruitmentStage> HrRecruitmentStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrResumeLine> HrResumeLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrResumeLineType> HrResumeLineTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrResumeLineType> HrResumeLineTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrResumeLine> HrResumeLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrRuleInput> HrRuleInputCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrRuleInput> HrRuleInputWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrSalaryRuleCategory> HrSalaryRuleCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrSalaryRuleCategory> HrSalaryRuleCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrSalaryRule> HrSalaryRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrSalaryRule> HrSalaryRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrSkill> HrSkillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrSkillLevel> HrSkillLevelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrSkillLevel> HrSkillLevelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrSkillType> HrSkillTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrSkillType> HrSkillTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrSkill> HrSkillWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrUserWorkEntryEmployee> HrUserWorkEntryEmployeeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<HrUserWorkEntryEmployee> HrUserWorkEntryEmployeeUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrUserWorkEntryEmployee> HrUserWorkEntryEmployeeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrWorkEntry> HrWorkEntryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrWorkEntryRegenerationWizard> HrWorkEntryRegenerationWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrWorkEntryRegenerationWizard> HrWorkEntryRegenerationWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrWorkEntryType> HrWorkEntryTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrWorkEntryType> HrWorkEntryTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrWorkEntry> HrWorkEntryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<HrWorkLocation> HrWorkLocationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<HrWorkLocation> HrWorkLocationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IapAccount> IapAccountCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IapAccount> IapAccountWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IapService> IapServiceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IapService> IapServiceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ImLivechatChannel> ImLivechatChannelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ImLivechatChannelRule> ImLivechatChannelRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ImLivechatChannelRule> ImLivechatChannelRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ImLivechatChannel> ImLivechatChannelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResUsers> InverseCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResUsers> InverseWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrActClient> IrActClientCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrActClient> IrActClientWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrActReportXml> IrActReportXmlCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrActReportXml> IrActReportXmlWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ActivityUserId")]
    // [InverseProperty("ActivityUser")]
    // public virtual ICollection<IrActServer> IrActServerActivityUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrActServer> IrActServerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrActServer> IrActServerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrActionsActUrl> IrActUrlCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrActionsActUrl> IrActUrlWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrActWindow> IrActWindowCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrActWindowView> IrActWindowViewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrActWindowView> IrActWindowViewWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrActWindow> IrActWindowWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrActions> IrActionsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrActionsTodo> IrActionsTodoCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrActionsTodo> IrActionsTodoWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrActions> IrActionsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrAsset> IrAssetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrAsset> IrAssetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrAttachment> IrAttachmentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrAttachment> IrAttachmentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrConfigParameter> IrConfigParameterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrConfigParameter> IrConfigParameterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrCron> IrCronCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrCronProgress> IrCronProgressCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrCronProgress> IrCronProgressWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrCronTrigger> IrCronTriggerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrCronTrigger> IrCronTriggerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<IrCron> IrCronUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrCron> IrCronWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrDefault> IrDefaultCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<IrDefault> IrDefaultUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrDefault> IrDefaultWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrDemo> IrDemoCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrDemoFailure> IrDemoFailureCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrDemoFailureWizard> IrDemoFailureWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrDemoFailureWizard> IrDemoFailureWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrDemoFailure> IrDemoFailureWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrDemo> IrDemoWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrEmbeddedActions> IrEmbeddedActionsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<IrEmbeddedActions> IrEmbeddedActionsUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrEmbeddedActions> IrEmbeddedActionsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrExports> IrExportsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrExportsLine> IrExportsLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrExportsLine> IrExportsLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrExports> IrExportsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrFilters> IrFiltersCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<IrFilters> IrFiltersUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrFilters> IrFiltersWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrMailServer> IrMailServerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrMailServer> IrMailServerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModelAccess> IrModelAccessCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModelAccess> IrModelAccessWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModelConstraint> IrModelConstraintCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModelConstraint> IrModelConstraintWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModel> IrModelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModelData> IrModelDataCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModelData> IrModelDataWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModelFields> IrModelFieldsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModelFieldsSelection> IrModelFieldsSelectionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModelFieldsSelection> IrModelFieldsSelectionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModelFields> IrModelFieldsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModelRelation> IrModelRelationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModelRelation> IrModelRelationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModel> IrModelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModuleCategory> IrModuleCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModuleCategory> IrModuleCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModuleModule> IrModuleModuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrModuleModuleExclusion> IrModuleModuleExclusionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModuleModuleExclusion> IrModuleModuleExclusionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrModuleModule> IrModuleModuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrProperty> IrPropertyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrProperty> IrPropertyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrRule> IrRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrRule> IrRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrSequence> IrSequenceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrSequenceDateRange> IrSequenceDateRangeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrSequenceDateRange> IrSequenceDateRangeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrSequence> IrSequenceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrServerObjectLines> IrServerObjectLinesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrServerObjectLines> IrServerObjectLinesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrUiMenu> IrUiMenuCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrUiMenu> IrUiMenuWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrUiView> IrUiViewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<IrUiViewCustom> IrUiViewCustomCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<IrUiViewCustom> IrUiViewCustomUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrUiViewCustom> IrUiViewCustomWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<IrUiView> IrUiViewWriteU { get; set; }

    // [Many2one]
    [ForeignKey("LastLunchLocationId")]
    // [InverseProperty("ResUsers")] //Many2one
    public virtual LunchLocation? LastLunchLocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LinkTrackerClick> LinkTrackerClickCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LinkTrackerClick> LinkTrackerClickWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LinkTrackerCode> LinkTrackerCodeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LinkTrackerCode> LinkTrackerCodeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LinkTracker> LinkTrackerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LinkTracker> LinkTrackerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LotLabelLayout> LotLabelLayoutCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LotLabelLayout> LotLabelLayoutWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LoyaltyCard> LoyaltyCardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LoyaltyCardUpdateBalance> LoyaltyCardUpdateBalanceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LoyaltyCardUpdateBalance> LoyaltyCardUpdateBalanceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LoyaltyCard> LoyaltyCardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LoyaltyGenerateWizard> LoyaltyGenerateWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LoyaltyGenerateWizard> LoyaltyGenerateWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LoyaltyHistory> LoyaltyHistoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LoyaltyHistory> LoyaltyHistoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LoyaltyMail> LoyaltyMailCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LoyaltyMail> LoyaltyMailWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LoyaltyProgram> LoyaltyProgramCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LoyaltyProgram> LoyaltyProgramWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LoyaltyReward> LoyaltyRewardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LoyaltyReward> LoyaltyRewardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LoyaltyRule> LoyaltyRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LoyaltyRule> LoyaltyRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LunchAlert> LunchAlertCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LunchAlert> LunchAlertWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LunchCashmove> LunchCashmoveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<LunchCashmove> LunchCashmoveUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LunchCashmove> LunchCashmoveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LunchLocation> LunchLocationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LunchLocation> LunchLocationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LunchOrder> LunchOrderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<LunchOrder> LunchOrderUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LunchOrder> LunchOrderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LunchProductCategory> LunchProductCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LunchProductCategory> LunchProductCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LunchProduct> LunchProductCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LunchProduct> LunchProductWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LunchSupplier> LunchSupplierCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ResponsibleId")]
    // [InverseProperty("Responsible")]
    // public virtual ICollection<LunchSupplier> LunchSupplierResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LunchSupplier> LunchSupplierWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<LunchTopping> LunchToppingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<LunchTopping> LunchToppingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailActivity> MailActivityCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailActivityPlan> MailActivityPlanCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailActivityPlanTemplate> MailActivityPlanTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ResponsibleId")]
    // [InverseProperty("Responsible")]
    // public virtual ICollection<MailActivityPlanTemplate> MailActivityPlanTemplateResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailActivityPlanTemplate> MailActivityPlanTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailActivityPlan> MailActivityPlanWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ActivityUserId")]
    // [InverseProperty("ActivityUser")]
    // public virtual ICollection<MailActivitySchedule> MailActivityScheduleActivityUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailActivitySchedule> MailActivityScheduleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("PlanOnDemandUserId")]
    // [InverseProperty("PlanOnDemandUser")]
    // public virtual ICollection<MailActivitySchedule> MailActivitySchedulePlanOnDemandUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailActivitySchedule> MailActivityScheduleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailActivityTodoCreate> MailActivityTodoCreateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MailActivityTodoCreate> MailActivityTodoCreateUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailActivityTodoCreate> MailActivityTodoCreateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailActivityType> MailActivityTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("DefaultUserId")]
    // [InverseProperty("DefaultUser")]
    // public virtual ICollection<MailActivityType> MailActivityTypeDefaultUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailActivityType> MailActivityTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MailActivity> MailActivityUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailActivity> MailActivityWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("AliasUserId")]
    // [InverseProperty("AliasUser")]
    // public virtual ICollection<MailAlias> MailAliasAliasUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailAlias> MailAliasCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailAliasDomain> MailAliasDomainCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailAliasDomain> MailAliasDomainWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailAlias> MailAliasWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailBlacklist> MailBlacklistCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailBlacklistRemove> MailBlacklistRemoveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailBlacklistRemove> MailBlacklistRemoveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailBlacklist> MailBlacklistWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailCannedResponse> MailCannedResponseCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailCannedResponse> MailCannedResponseWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailChannel> MailChannelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailChannelMember> MailChannelMemberCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailChannelMember> MailChannelMemberWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailChannel> MailChannelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailComposeMessage> MailComposeMessageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ResDomainUserId")]
    // [InverseProperty("ResDomainUser")]
    // public virtual ICollection<MailComposeMessage> MailComposeMessageResDomainUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailComposeMessage> MailComposeMessageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailGatewayAllowed> MailGatewayAllowedCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailGatewayAllowed> MailGatewayAllowedWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailGroup> MailGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailGroupMember> MailGroupMemberCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailGroupMember> MailGroupMemberWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailGroupMessage> MailGroupMessageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("ModeratorId")]
    // [InverseProperty("Moderator")]
    // public virtual ICollection<MailGroupMessage> MailGroupMessageModerator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailGroupMessageReject> MailGroupMessageRejectCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailGroupMessageReject> MailGroupMessageRejectWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailGroupMessage> MailGroupMessageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailGroupModeration> MailGroupModerationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailGroupModeration> MailGroupModerationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailGroup> MailGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailGuest> MailGuestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailGuest> MailGuestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailIceServer> MailIceServerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailIceServer> MailIceServerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailLinkPreview> MailLinkPreviewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailLinkPreview> MailLinkPreviewWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailMail> MailMailCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailMail> MailMailWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailMessage> MailMessageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailMessageSchedule> MailMessageScheduleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailMessageSchedule> MailMessageScheduleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailMessageSubtype> MailMessageSubtypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailMessageSubtype> MailMessageSubtypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailMessageTranslation> MailMessageTranslationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailMessageTranslation> MailMessageTranslationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailMessage> MailMessageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailPush> MailPushCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailPushDevice> MailPushDeviceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailPushDevice> MailPushDeviceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailPush> MailPushWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailResendMessage> MailResendMessageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailResendMessage> MailResendMessageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailResendPartner> MailResendPartnerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailResendPartner> MailResendPartnerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailScheduledMessage> MailScheduledMessageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailScheduledMessage> MailScheduledMessageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailShortcode> MailShortcodeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailShortcode> MailShortcodeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailTemplate> MailTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailTemplatePreview> MailTemplatePreviewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailTemplatePreview> MailTemplatePreviewWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailTemplateReset> MailTemplateResetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailTemplateReset> MailTemplateResetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MailTemplate> MailTemplateUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailTemplate> MailTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailTrackingValue> MailTrackingValueCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailTrackingValue> MailTrackingValueWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailWizardInvite> MailWizardInviteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailWizardInvite> MailWizardInviteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingContact> MailingContactCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingContactImport> MailingContactImportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingContactImport> MailingContactImportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingContactListRel> MailingContactListRelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingContactListRel> MailingContactListRelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingContactToList> MailingContactToListCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingContactToList> MailingContactToListWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingContact> MailingContactWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingFilter> MailingFilterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingFilter> MailingFilterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingList> MailingListCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingListMerge> MailingListMergeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingListMerge> MailingListMergeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingList> MailingListWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingMailing> MailingMailingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingMailingScheduleDate> MailingMailingScheduleDateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingMailingScheduleDate> MailingMailingScheduleDateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingMailingTest> MailingMailingTestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingMailingTest> MailingMailingTestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MailingMailing> MailingMailingUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingMailing> MailingMailingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingSmsTest> MailingSmsTestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingSmsTest> MailingSmsTestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingSubscription> MailingSubscriptionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingSubscriptionOptout> MailingSubscriptionOptoutCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingSubscriptionOptout> MailingSubscriptionOptoutWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingSubscription> MailingSubscriptionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MailingTrace> MailingTraceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MailingTrace> MailingTraceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("TechnicianUserId")]
    // [InverseProperty("TechnicianUser")]
    // public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryTechnicianUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("OwnerUserId")]
    // [InverseProperty("OwnerUser")]
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentOwnerUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("TechnicianUserId")]
    // [InverseProperty("TechnicianUser")]
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentTechnicianUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipmentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MaintenanceRequest> MaintenanceRequestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("OwnerUserId")]
    // [InverseProperty("OwnerUser")]
    // public virtual ICollection<MaintenanceRequest> MaintenanceRequestOwnerUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MaintenanceRequest> MaintenanceRequestUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MaintenanceRequest> MaintenanceRequestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MaintenanceStage> MaintenanceStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MaintenanceStage> MaintenanceStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MaintenanceTeam> MaintenanceTeamCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MaintenanceTeam> MaintenanceTeamWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MembershipInvoice> MembershipInvoiceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MembershipInvoice> MembershipInvoiceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MembershipMembershipLine> MembershipMembershipLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MembershipMembershipLine> MembershipMembershipLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MicrosoftCalendarAccountReset> MicrosoftCalendarAccountResetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MicrosoftCalendarAccountReset> MicrosoftCalendarAccountResetUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MicrosoftCalendarAccountReset> MicrosoftCalendarAccountResetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpAccountWipAccounting> MrpAccountWipAccountingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpAccountWipAccountingLine> MrpAccountWipAccountingLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpAccountWipAccounting> MrpAccountWipAccountingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpBatchProduce> MrpBatchProduceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpBatchProduce> MrpBatchProduceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpBomByproduct> MrpBomByproductCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpBomByproduct> MrpBomByproductWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpBom> MrpBomCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpBomLine> MrpBomLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpBomLine> MrpBomLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpBom> MrpBomWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarningCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpConsumptionWarningLine> MrpConsumptionWarningLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpConsumptionWarning> MrpConsumptionWarningWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpDocument> MrpDocumentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpDocument> MrpDocumentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpImmediateProduction> MrpImmediateProductionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpImmediateProduction> MrpImmediateProductionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpProductionBackorder> MrpProductionBackorderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpProductionBackorderLine> MrpProductionBackorderLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpProductionBackorder> MrpProductionBackorderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpProduction> MrpProductionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpProductionSplit> MrpProductionSplitCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpProductionSplitLine> MrpProductionSplitLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpProductionSplitMulti> MrpProductionSplitMultiCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpProductionSplitMulti> MrpProductionSplitMultiWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpProductionSplit> MrpProductionSplitWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MrpProduction> MrpProductionUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpProduction> MrpProductionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpUnbuild> MrpUnbuildCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpUnbuild> MrpUnbuildWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacityCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacityWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpWorkcenter> MrpWorkcenterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpWorkcenterProductivityLoss> MrpWorkcenterProductivityLossCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpWorkcenterProductivityLossType> MrpWorkcenterProductivityLossTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpWorkcenterProductivityLossType> MrpWorkcenterProductivityLossTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpWorkcenterProductivityLoss> MrpWorkcenterProductivityLossWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivityWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpWorkcenterTag> MrpWorkcenterTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpWorkcenterTag> MrpWorkcenterTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpWorkcenter> MrpWorkcenterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<MrpWorkorder> MrpWorkorderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<MrpWorkorder> MrpWorkorderWriteU { get; set; }

    // [Many2one]
    [ForeignKey("NextRankId")]
    // [InverseProperty("ResUsersNextRank")] //Many2one
    public virtual GamificationKarmaRank? NextRank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<NoteNote> NoteNoteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<NoteNote> NoteNoteUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<NoteNote> NoteNoteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<NoteStage> NoteStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<NoteStage> NoteStageUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<NoteStage> NoteStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<NoteTag> NoteTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<NoteTag> NoteTagWriteU { get; set; }

    // [Many2one]
    [ForeignKey("OauthProviderId")]
    // [InverseProperty("ResUsers")] //Many2one
    public virtual AuthOauthProvider? OauthProvider { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<OnboardingOnboarding> OnboardingOnboardingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<OnboardingOnboardingStep> OnboardingOnboardingStepCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<OnboardingOnboardingStep> OnboardingOnboardingStepWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<OnboardingOnboarding> OnboardingOnboardingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<OnboardingProgress> OnboardingProgressCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<OnboardingProgressStep> OnboardingProgressStepCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<OnboardingProgressStep> OnboardingProgressStepWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<OnboardingProgress> OnboardingProgressWriteU { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("ResUsers")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentCaptureWizard> PaymentCaptureWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentCaptureWizard> PaymentCaptureWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentIcon> PaymentIconCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentIcon> PaymentIconWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentLinkWizard> PaymentLinkWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentLinkWizard> PaymentLinkWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentMethod> PaymentMethodCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentMethod> PaymentMethodWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentProvider> PaymentProviderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentProviderOnboardingWizard> PaymentProviderOnboardingWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentProviderOnboardingWizard> PaymentProviderOnboardingWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentProvider> PaymentProviderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentRefundWizard> PaymentRefundWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentRefundWizard> PaymentRefundWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentToken> PaymentTokenCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentToken> PaymentTokenWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PaymentTransaction> PaymentTransactionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PaymentTransaction> PaymentTransactionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PayslipLinesContributionRegister> PayslipLinesContributionRegisterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PayslipLinesContributionRegister> PayslipLinesContributionRegisterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PeppolRegistration> PeppolRegistrationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PeppolRegistration> PeppolRegistrationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PhoneBlacklist> PhoneBlacklistCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PhoneBlacklistRemove> PhoneBlacklistRemoveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PhoneBlacklistRemove> PhoneBlacklistRemoveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PhoneBlacklist> PhoneBlacklistWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PickingLabelType> PickingLabelTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PickingLabelType> PickingLabelTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PortalShare> PortalShareCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PortalShare> PortalShareWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PortalWizard> PortalWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PortalWizardUser> PortalWizardUserCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PortalWizardUser> PortalWizardUserWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PortalWizard> PortalWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosBill> PosBillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosBill> PosBillWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosCategory> PosCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosCategory> PosCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosCloseSessionWizard> PosCloseSessionWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosConfig> PosConfigCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("SelfOrderingDefaultUserId")]
    // [InverseProperty("SelfOrderingDefaultUser")]
    // public virtual ICollection<PosConfig> PosConfigSelfOrderingDefaultUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosConfig> PosConfigWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosDailySalesReportsWizard> PosDailySalesReportsWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosDailySalesReportsWizard> PosDailySalesReportsWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosDetailsWizard> PosDetailsWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosDetailsWizard> PosDetailsWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosMakePayment> PosMakePaymentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosMakePayment> PosMakePaymentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosNote> PosNoteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosNote> PosNoteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosOrder> PosOrderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosOrderLine> PosOrderLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosOrderLine> PosOrderLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<PosOrder> PosOrderUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosOrder> PosOrderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosPackOperationLot> PosPackOperationLotCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosPackOperationLot> PosPackOperationLotWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosPayment> PosPaymentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosPaymentMethod> PosPaymentMethodCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosPaymentMethod> PosPaymentMethodWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosPayment> PosPaymentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosPrinter> PosPrinterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosPrinter> PosPrinterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosSelfOrderCustomLink> PosSelfOrderCustomLinkCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosSelfOrderCustomLink> PosSelfOrderCustomLinkWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosSessionCheckProductWizard> PosSessionCheckProductWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosSessionCheckProductWizard> PosSessionCheckProductWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PosSession> PosSessionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<PosSession> PosSessionUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PosSession> PosSessionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PrivacyLog> PrivacyLogCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<PrivacyLog> PrivacyLogUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PrivacyLog> PrivacyLogWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PrivacyLookupWizard> PrivacyLookupWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PrivacyLookupWizardLine> PrivacyLookupWizardLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PrivacyLookupWizard> PrivacyLookupWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProcurementGroup> ProcurementGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProcurementGroup> ProcurementGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductAttributeCategory> ProductAttributeCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductAttributeCategory> ProductAttributeCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductAttribute> ProductAttributeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValueCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductAttributeCustomValue> ProductAttributeCustomValueWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductAttributeValue> ProductAttributeValueCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductAttributeValue> ProductAttributeValueWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductAttribute> ProductAttributeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductCategory> ProductCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductCategory> ProductCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductCombo> ProductComboCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductComboItem> ProductComboItemCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductComboItem> ProductComboItemWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductCombo> ProductComboWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductDocument> ProductDocumentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductDocument> ProductDocumentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductFetchImageWizard> ProductFetchImageWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductFetchImageWizard> ProductFetchImageWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductImage> ProductImageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductImage> ProductImageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductLabelLayout> ProductLabelLayoutCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductLabelLayout> ProductLabelLayoutWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductMargin> ProductMarginCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductMargin> ProductMarginWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductPackaging> ProductPackagingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductPackaging> ProductPackagingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductPricelist> ProductPricelistCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductPricelistItem> ProductPricelistItemCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductPricelistItem> ProductPricelistItemWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductPricelist> ProductPricelistWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductProduct> ProductProductCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductProduct> ProductProductWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductPublicCategory> ProductPublicCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductPublicCategory> ProductPublicCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductRemoval> ProductRemovalCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductRemoval> ProductRemovalWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductReplenish> ProductReplenishCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductReplenish> ProductReplenishWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductRibbon> ProductRibbonCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductRibbon> ProductRibbonWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfoCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfoWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductTag> ProductTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductTag> ProductTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductTemplateAttributeLine> ProductTemplateAttributeLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValueCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductTemplateAttributeValue> ProductTemplateAttributeValueWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductTemplate> ProductTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductTemplate> ProductTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProductWishlist> ProductWishlistCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProductWishlist> ProductWishlistWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectCollaborator> ProjectCollaboratorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectCollaborator> ProjectCollaboratorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectCreateInvoice> ProjectCreateInvoiceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectCreateInvoice> ProjectCreateInvoiceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectMilestone> ProjectMilestoneCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectMilestone> ProjectMilestoneWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectProject> ProjectProjectCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectProjectStage> ProjectProjectStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectProjectStageDeleteWizard> ProjectProjectStageDeleteWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectProjectStageDeleteWizard> ProjectProjectStageDeleteWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectProjectStage> ProjectProjectStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("UserNavigation")]
    // public virtual ICollection<ProjectProject> ProjectProjectUserNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectProject> ProjectProjectWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMapCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMapWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectShareCollaboratorWizard> ProjectShareCollaboratorWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectShareCollaboratorWizard> ProjectShareCollaboratorWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectShareWizard> ProjectShareWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectShareWizard> ProjectShareWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectTags> ProjectTagsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectTags> ProjectTagsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectTask> ProjectTaskCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectTaskRecurrence> ProjectTaskRecurrenceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectTaskRecurrence> ProjectTaskRecurrenceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectTaskType> ProjectTaskTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ProjectTaskType> ProjectTaskTypeUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectTaskType> ProjectTaskTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectTaskUserRel> ProjectTaskUserRelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectTask> ProjectTaskWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ProjectUpdate> ProjectUpdateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ProjectUpdate> ProjectUpdateUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ProjectUpdate> ProjectUpdateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PurchaseOrder> PurchaseOrderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PurchaseOrderGroup> PurchaseOrderGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PurchaseOrderGroup> PurchaseOrderGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<PurchaseOrder> PurchaseOrderUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PurchaseOrder> PurchaseOrderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PurchaseRequisitionAlternativeWarning> PurchaseRequisitionAlternativeWarningCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PurchaseRequisitionAlternativeWarning> PurchaseRequisitionAlternativeWarningWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PurchaseRequisitionCreateAlternative> PurchaseRequisitionCreateAlternativeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PurchaseRequisitionCreateAlternative> PurchaseRequisitionCreateAlternativeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisitionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PurchaseRequisitionLine> PurchaseRequisitionLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<PurchaseRequisitionType> PurchaseRequisitionTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PurchaseRequisitionType> PurchaseRequisitionTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisitionUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisitionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<QuotationDocument> QuotationDocumentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<QuotationDocument> QuotationDocumentWriteU { get; set; }

    // [Many2one]
    [ForeignKey("RankId")]
    // [InverseProperty("ResUsersRank")] //Many2one
    public virtual GamificationKarmaRank? Rank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RatingRating> RatingRatingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RatingRating> RatingRatingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RecurringPayment> RecurringPaymentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RecurringPaymentLine> RecurringPaymentLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RecurringPaymentLine> RecurringPaymentLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RecurringPayment> RecurringPaymentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RegistrationEditor> RegistrationEditorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RegistrationEditorLine> RegistrationEditorLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RegistrationEditorLine> RegistrationEditorLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RegistrationEditor> RegistrationEditorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RepairFee> RepairFeeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RepairFee> RepairFeeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RepairLine> RepairLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RepairLine> RepairLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RepairOrder> RepairOrderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RepairOrderMakeInvoice> RepairOrderMakeInvoiceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RepairOrderMakeInvoice> RepairOrderMakeInvoiceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<RepairOrder> RepairOrderUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RepairOrder> RepairOrderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RepairTags> RepairTagsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RepairTags> RepairTagsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ReportLayout> ReportLayoutCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ReportLayout> ReportLayoutWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ReportPaperformat> ReportPaperformatCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ReportPaperformat> ReportPaperformatWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResBank> ResBankCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResBank> ResBankWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResCity> ResCityCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResCity> ResCityWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResCompany> ResCompanyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResCompany> ResCompanyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResConfig> ResConfigCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResConfigInstaller> ResConfigInstallerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResConfigInstaller> ResConfigInstallerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("AuthSignupTemplateUserId")]
    // [InverseProperty("AuthSignupTemplateUser")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsAuthSignupTemplateUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettingsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResConfig> ResConfigWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResCountry> ResCountryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResCountryGroup> ResCountryGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResCountryGroup> ResCountryGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResCountryState> ResCountryStateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResCountryState> ResCountryStateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResCountry> ResCountryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResCurrency> ResCurrencyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResCurrencyRate> ResCurrencyRateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResCurrencyRate> ResCurrencyRateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResCurrency> ResCurrencyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResDeviceLog> ResDeviceLogCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ResDeviceLog> ResDeviceLogUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResDeviceLog> ResDeviceLogWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResGroups> ResGroupsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResGroups> ResGroupsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResLang> ResLangCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResLang> ResLangWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerActivation> ResPartnerActivationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerActivation> ResPartnerActivationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerBank> ResPartnerBankCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerBank> ResPartnerBankWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("BuyerId")]
    // [InverseProperty("Buyer")]
    // public virtual ICollection<ResPartner> ResPartnerBuyer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerCategory> ResPartnerCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerCategory> ResPartnerCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartner> ResPartnerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerGrade> ResPartnerGradeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerGrade> ResPartnerGradeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerIap> ResPartnerIapCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerIap> ResPartnerIapWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerIndustry> ResPartnerIndustryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerIndustry> ResPartnerIndustryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("PaymentResponsibleId")]
    // [InverseProperty("PaymentResponsible")]
    // public virtual ICollection<ResPartner> ResPartnerPaymentResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerTag> ResPartnerTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerTag> ResPartnerTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResPartnerTitle> ResPartnerTitleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartnerTitle> ResPartnerTitleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ResPartner> ResPartnerUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResPartner> ResPartnerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ResUsersApikeys> ResUsersApikeys { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResUsersApikeysDescription> ResUsersApikeysDescriptionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResUsersApikeysDescription> ResUsersApikeysDescriptionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResUsersDeletion> ResUsersDeletionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ResUsersDeletion> ResUsersDeletionUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResUsersDeletion> ResUsersDeletionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResUsersIdentitycheck> ResUsersIdentitycheckCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResUsersIdentitycheck> ResUsersIdentitycheckWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResUsersLog> ResUsersLogCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResUsersLog> ResUsersLogWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResUsersSettings> ResUsersSettingsCreateU { get; set; }

    // [Many2one]
    // [InverseProperty("User")] //Many2one
    public virtual ResUsersSettings? ResUsersSettingsUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResUsersSettings> ResUsersSettingsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendanceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResourceCalendarAttendance> ResourceCalendarAttendanceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResourceCalendar> ResourceCalendarCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeavesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResourceCalendarLeaves> ResourceCalendarLeavesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResourceCalendar> ResourceCalendarWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ResourceResource> ResourceResourceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ResourceResource> ResourceResourceUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ResourceResource> ResourceResourceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RestaurantFloor> RestaurantFloorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RestaurantFloor> RestaurantFloorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RestaurantPrinter> RestaurantPrinterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RestaurantPrinter> RestaurantPrinterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<RestaurantTable> RestaurantTableCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<RestaurantTable> RestaurantTableWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleAdvancePaymentInv> SaleAdvancePaymentInvWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleLoyaltyCouponWizard> SaleLoyaltyCouponWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleLoyaltyCouponWizard> SaleLoyaltyCouponWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleLoyaltyRewardWizard> SaleLoyaltyRewardWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleLoyaltyRewardWizard> SaleLoyaltyRewardWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleMassCancelOrders> SaleMassCancelOrdersCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleMassCancelOrders> SaleMassCancelOrdersWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrderCancel> SaleOrderCancelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrderCancel> SaleOrderCancelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrderCouponPoints> SaleOrderCouponPointsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrderCouponPoints> SaleOrderCouponPointsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrder> SaleOrderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrderDiscount> SaleOrderDiscountCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrderDiscount> SaleOrderDiscountWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("SalesmanId")]
    // [InverseProperty("Salesman")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLineSalesman { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrderOption> SaleOrderOptionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrderOption> SaleOrderOptionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrderTemplate> SaleOrderTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrderTemplateLine> SaleOrderTemplateLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrderTemplateOption> SaleOrderTemplateOptionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrderTemplate> SaleOrderTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<SaleOrder> SaleOrderUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SaleOrder> SaleOrderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SalePaymentProviderOnboardingWizard> SalePaymentProviderOnboardingWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SalePaymentProviderOnboardingWizard> SalePaymentProviderOnboardingWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SalePdfFormField> SalePdfFormFieldCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SalePdfFormField> SalePdfFormFieldWriteU { get; set; }

    // [Many2one]
    [ForeignKey("SaleTeamId")]
    // [InverseProperty("ResUsers")] //Many2one
    public virtual CrmTeam? SaleTeam { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideAnswer> SlideAnswerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideAnswer> SlideAnswerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideChannel> SlideChannelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideChannelInvite> SlideChannelInviteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideChannelInvite> SlideChannelInviteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideChannelPartner> SlideChannelPartnerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideChannelPartner> SlideChannelPartnerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideChannelTag> SlideChannelTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideChannelTagGroup> SlideChannelTagGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideChannelTagGroup> SlideChannelTagGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideChannelTag> SlideChannelTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<SlideChannel> SlideChannelUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideChannel> SlideChannelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideEmbed> SlideEmbedCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideEmbed> SlideEmbedWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideQuestion> SlideQuestionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideQuestion> SlideQuestionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideSlide> SlideSlideCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideSlidePartner> SlideSlidePartnerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideSlidePartner> SlideSlidePartnerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideSlideResource> SlideSlideResourceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideSlideResource> SlideSlideResourceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<SlideSlide> SlideSlideUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideSlide> SlideSlideWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SlideTag> SlideTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SlideTag> SlideTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsAccountCode> SmsAccountCodeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsAccountCode> SmsAccountCodeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsAccountPhone> SmsAccountPhoneCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsAccountPhone> SmsAccountPhoneWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsAccountSender> SmsAccountSenderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsAccountSender> SmsAccountSenderWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsComposer> SmsComposerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsComposer> SmsComposerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsResend> SmsResendCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsResendRecipient> SmsResendRecipientCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsResendRecipient> SmsResendRecipientWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsResend> SmsResendWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsSms> SmsSmsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsSms> SmsSmsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsTemplate> SmsTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsTemplatePreview> SmsTemplatePreviewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsTemplatePreview> SmsTemplatePreviewWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsTemplateReset> SmsTemplateResetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsTemplateReset> SmsTemplateResetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsTemplate> SmsTemplateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SmsTracker> SmsTrackerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SmsTracker> SmsTrackerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoiceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoiceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SnailmailLetter> SnailmailLetterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatErrorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SnailmailLetterFormatError> SnailmailLetterFormatErrorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFieldsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFieldsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<SnailmailLetter> SnailmailLetterUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SnailmailLetter> SnailmailLetterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SparseFieldsTest> SparseFieldsTestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SparseFieldsTest> SparseFieldsTestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SpreadsheetDashboardGroup> SpreadsheetDashboardGroupCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SpreadsheetDashboardGroup> SpreadsheetDashboardGroupWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SpreadsheetDashboardShare> SpreadsheetDashboardShareCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SpreadsheetDashboardShare> SpreadsheetDashboardShareWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockAddToWave> StockAddToWaveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<StockAddToWave> StockAddToWaveUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockAddToWave> StockAddToWaveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockAssignSerial> StockAssignSerialCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockAssignSerial> StockAssignSerialWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockBackorderConfirmationLine> StockBackorderConfirmationLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockBackorderConfirmation> StockBackorderConfirmationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockChangeProductQty> StockChangeProductQtyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockChangeProductQty> StockChangeProductQtyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockImmediateTransfer> StockImmediateTransferCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockImmediateTransfer> StockImmediateTransferWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockInventoryAdjustmentName> StockInventoryAdjustmentNameCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockInventoryAdjustmentName> StockInventoryAdjustmentNameWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockInventoryConflict> StockInventoryConflictCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockInventoryConflict> StockInventoryConflictWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockInventoryWarning> StockInventoryWarningCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockInventoryWarning> StockInventoryWarningWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockLandedCost> StockLandedCostCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockLandedCostLines> StockLandedCostLinesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockLandedCostLines> StockLandedCostLinesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockLandedCost> StockLandedCostWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockLocation> StockLocationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockLocation> StockLocationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockLot> StockLotCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockLot> StockLotWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockMove> StockMoveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockMoveLine> StockMoveLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockMoveLine> StockMoveLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockMove> StockMoveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnoozeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockOrderpointSnooze> StockOrderpointSnoozeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockPackageDestination> StockPackageDestinationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockPackageDestination> StockPackageDestinationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockPackageLevel> StockPackageLevelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockPackageLevel> StockPackageLevelWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockPackageType> StockPackageTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockPackageType> StockPackageTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockPickingBatch> StockPickingBatchCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<StockPickingBatch> StockPickingBatchUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockPickingBatch> StockPickingBatchWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockPicking> StockPickingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockPickingToBatch> StockPickingToBatchCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<StockPickingToBatch> StockPickingToBatchUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockPickingToBatch> StockPickingToBatchWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockPickingType> StockPickingTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockPickingType> StockPickingTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<StockPicking> StockPickingUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockPicking> StockPickingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockPutawayRule> StockPutawayRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockPutawayRule> StockPutawayRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockQuant> StockQuantCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockQuantPackage> StockQuantPackageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockQuantPackage> StockQuantPackageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockQuantRelocate> StockQuantRelocateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockQuantRelocate> StockQuantRelocateWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<StockQuant> StockQuantUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockQuant> StockQuantWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockQuantityHistory> StockQuantityHistoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockQuantityHistory> StockQuantityHistoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfoCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfoWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockReplenishmentOption> StockReplenishmentOptionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockRequestCount> StockRequestCountCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<StockRequestCount> StockRequestCountUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockRequestCount> StockRequestCountWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockReturnPicking> StockReturnPickingCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockReturnPickingLine> StockReturnPickingLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockReturnPickingLine> StockReturnPickingLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockReturnPicking> StockReturnPickingWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockRoute> StockRouteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockRoute> StockRouteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockRule> StockRuleCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockRule> StockRuleWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockRulesReport> StockRulesReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockRulesReport> StockRulesReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockSchedulerCompute> StockSchedulerComputeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockSchedulerCompute> StockSchedulerComputeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockScrap> StockScrapCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockScrapReasonTag> StockScrapReasonTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockScrapReasonTag> StockScrapReasonTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockScrap> StockScrapWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacityCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockStorageCategoryCapacity> StockStorageCategoryCapacityWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockStorageCategory> StockStorageCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockStorageCategory> StockStorageCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockTraceabilityReport> StockTraceabilityReportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockTraceabilityReport> StockTraceabilityReportWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockTrackConfirmation> StockTrackConfirmationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockTrackConfirmation> StockTrackConfirmationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockTrackLine> StockTrackLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockTrackLine> StockTrackLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLinesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockValuationAdjustmentLines> StockValuationAdjustmentLinesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockValuationLayer> StockValuationLayerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockValuationLayerRevaluation> StockValuationLayerRevaluationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockValuationLayer> StockValuationLayerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockWarehouse> StockWarehouseCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockWarehouse> StockWarehouseWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrapCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScrapWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuildCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuildWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SurveyInvite> SurveyInviteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SurveyInvite> SurveyInviteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SurveyQuestionAnswer> SurveyQuestionAnswerWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SurveyQuestion> SurveyQuestionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SurveyQuestion> SurveyQuestionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SurveySurvey> SurveySurveyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<SurveySurvey> SurveySurveyUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SurveySurvey> SurveySurveyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SurveyUserInput> SurveyUserInputCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<SurveyUserInputLine> SurveyUserInputLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SurveyUserInputLine> SurveyUserInputLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<SurveyUserInput> SurveyUserInputWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ThemeIrAsset> ThemeIrAssetCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ThemeIrAsset> ThemeIrAssetWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ThemeIrAttachment> ThemeIrAttachmentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ThemeIrAttachment> ThemeIrAttachmentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ThemeIrUiView> ThemeIrUiViewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ThemeIrUiView> ThemeIrUiViewWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ThemeWebsiteMenu> ThemeWebsiteMenuCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ThemeWebsiteMenu> ThemeWebsiteMenuWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ThemeWebsitePage> ThemeWebsitePageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ThemeWebsitePage> ThemeWebsitePageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<UomCategory> UomCategoryCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<UomCategory> UomCategoryWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<UomUom> UomUomCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<UomUom> UomUomWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<UpdateProductAttributeValue> UpdateProductAttributeValueCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<UpdateProductAttributeValue> UpdateProductAttributeValueWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<UtmCampaign> UtmCampaignCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<UtmCampaign> UtmCampaignUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<UtmCampaign> UtmCampaignWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<UtmMedium> UtmMediumCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<UtmMedium> UtmMediumWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<UtmSource> UtmSourceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<UtmSource> UtmSourceWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<UtmStage> UtmStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<UtmStage> UtmStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<UtmTag> UtmTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<UtmTag> UtmTagWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<ValidateAccountMove> ValidateAccountMoveCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<ValidateAccountMove> ValidateAccountMoveWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebEditorConverterTest> WebEditorConverterTestCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebEditorConverterTestSub> WebEditorConverterTestSubCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebEditorConverterTestSub> WebEditorConverterTestSubWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebEditorConverterTest> WebEditorConverterTestWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<WebTourTour> WebTourTour { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebTourTour> WebTourTourCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebTourTourStep> WebTourTourStepCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebTourTourStep> WebTourTourStepWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebTourTour> WebTourTourWriteU { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("ResUsers")] //Many2one
    public virtual Website? Website { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteBaseUnit> WebsiteBaseUnitCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteBaseUnit> WebsiteBaseUnitWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeatureCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeatureWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteControllerPage> WebsiteControllerPageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteControllerPage> WebsiteControllerPageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<Website> WebsiteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CrmDefaultUserId")]
    // [InverseProperty("CrmDefaultUser")]
    // public virtual ICollection<Website> WebsiteCrmDefaultUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteCustomBlockedThirdPartyDomains> WebsiteCustomBlockedThirdPartyDomainsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteCustomBlockedThirdPartyDomains> WebsiteCustomBlockedThirdPartyDomainsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteEventMenu> WebsiteEventMenuCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteEventMenu> WebsiteEventMenuWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteMenu> WebsiteMenuCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteMenu> WebsiteMenuWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsitePage> WebsitePageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsitePagePropertiesBase> WebsitePagePropertiesBaseCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsitePagePropertiesBase> WebsitePagePropertiesBaseWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsitePageProperties> WebsitePagePropertiesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsitePageProperties> WebsitePagePropertiesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsitePage> WebsitePageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteRewrite> WebsiteRewriteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteRewrite> WebsiteRewriteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteRobots> WebsiteRobotsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteRobots> WebsiteRobotsWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteRoute> WebsiteRouteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteRoute> WebsiteRouteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraFieldCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraFieldWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("SalespersonId")]
    // [InverseProperty("Salesperson")]
    // public virtual ICollection<Website> WebsiteSalesperson { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilterWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<Website> WebsiteUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitorCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitorWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<Website> WebsiteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<WizardIrModelMenuCreate> WizardIrModelMenuCreateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<WizardIrModelMenuCreate> WizardIrModelMenuCreateWriteU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("InverseWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ImLivechatChannel> Channel { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ResCompany> Cid { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMass { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<DataRecycleModel> DataRecycleModel { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<DigestDigest> DigestDigest { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<DigestTip> DigestTip { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<ForumPost> ForumPost { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<GamificationBadge> GamificationBadge { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<GamificationChallenge> GamificationChallenge { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsersNavigation")]
    // public virtual ICollection<GamificationChallenge> GamificationChallengeNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("Uid")]
    // [InverseProperty("UidNavigation")]
    public virtual ICollection<ResGroups> Gids { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsersNavigation")]
    // public virtual ICollection<HrJob> HrJobNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<IapAccount> IapAccount { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("UserId")]
    // [InverseProperty("UserNavigation")]
    // public virtual ICollection<HrJob> Job { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<MailGroup> MailGroup { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<MaintenanceTeam> MaintenanceTeam { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<StockPickingType> PickingType { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<LunchProduct> Product { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("UserId")]
    // [InverseProperty("User")]
    // public virtual ICollection<ProjectProject> Project { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<SurveySurvey> SurveySurvey { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("UserId")]
    // [InverseProperty("UserNavigation")]
    // public virtual ICollection<CrmTeam> Team { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResUsersId")]
    // [InverseProperty("ResUsers")]
    // public virtual ICollection<WebTourTour> WebTourTour { get; set; }

    // v16-Compat
    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsChar> BaseImportTestsModelsCharCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequiredCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequiredWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsCharStates> BaseImportTestsModelsCharStatesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsCharStates> BaseImportTestsModelsCharStatesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsChar> BaseImportTestsModelsCharWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloatCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloatWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2oCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelatedCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelatedWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequiredCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelatedCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelatedWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequiredWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2oWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsO2m> BaseImportTestsModelsO2mCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsO2m> BaseImportTestsModelsO2mWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("CreatorId")]
    // [InverseProperty("CreateU")]
    // public virtual ICollection<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [ForeignKey("LastModifierId")]
    // [InverseProperty("WriteU")]
    // public virtual ICollection<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviewWriteU { get; set; }

}
