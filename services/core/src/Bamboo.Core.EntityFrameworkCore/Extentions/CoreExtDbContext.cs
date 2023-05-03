using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Bamboo.Core.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bamboo.Core.EntityFrameworkCore;

// <summary>
/// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
/// </summary>
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    /// <summary>
    /// Creates a new instance of this converter.
    /// </summary>
    public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
    { }
}
public partial class CoreDbContext
{
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder
    //        .UseNpgsql()
    //        .UseSnakeCaseNamingConvention();
    //}
    public virtual DbSet<AccountAccount> AccountAccounts { get; set; }

    public virtual DbSet<AccountAccountTag> AccountAccountTags { get; set; }

    public virtual DbSet<AccountAccountTemplate> AccountAccountTemplates { get; set; }

    public virtual DbSet<AccountAccountType> AccountAccountTypes { get; set; }

    public virtual DbSet<AccountAccruedOrdersWizard> AccountAccruedOrdersWizards { get; set; }

    public virtual DbSet<AccountAgedTrialBalance> AccountAgedTrialBalances { get; set; }

    public virtual DbSet<AccountAnalyticAccount> AccountAnalyticAccounts { get; set; }

    public virtual DbSet<AccountAnalyticApplicability> AccountAnalyticApplicabilities { get; set; }

    public virtual DbSet<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; set; }

    public virtual DbSet<AccountAnalyticLine> AccountAnalyticLines { get; set; }

    public virtual DbSet<AccountAnalyticPlan> AccountAnalyticPlans { get; set; }

    public virtual DbSet<AccountAssetAsset> AccountAssetAssets { get; set; }

    public virtual DbSet<AccountAssetCategory> AccountAssetCategories { get; set; }

    public virtual DbSet<AccountAssetDepreciationLine> AccountAssetDepreciationLines { get; set; }

    public virtual DbSet<AccountAutomaticEntryWizard> AccountAutomaticEntryWizards { get; set; }

    public virtual DbSet<AccountBalanceReport> AccountBalanceReports { get; set; }

    public virtual DbSet<AccountBankStatement> AccountBankStatements { get; set; }

    public virtual DbSet<AccountBankStatementImport> AccountBankStatementImports { get; set; }

    public virtual DbSet<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreations { get; set; }

    public virtual DbSet<AccountBankStatementLine> AccountBankStatementLines { get; set; }

    public virtual DbSet<AccountBankbookReport> AccountBankbookReports { get; set; }

    public virtual DbSet<AccountBudgetPost> AccountBudgetPosts { get; set; }

    public virtual DbSet<AccountCashRounding> AccountCashRoundings { get; set; }

    public virtual DbSet<AccountCashbookReport> AccountCashbookReports { get; set; }

    public virtual DbSet<AccountChartTemplate> AccountChartTemplates { get; set; }

    public virtual DbSet<AccountCommonAccountReport> AccountCommonAccountReports { get; set; }

    public virtual DbSet<AccountCommonJournalReport> AccountCommonJournalReports { get; set; }

    public virtual DbSet<AccountCommonPartnerReport> AccountCommonPartnerReports { get; set; }

    public virtual DbSet<AccountCommonReport> AccountCommonReports { get; set; }

    public virtual DbSet<AccountDaybookReport> AccountDaybookReports { get; set; }

    public virtual DbSet<AccountEdiDocument> AccountEdiDocuments { get; set; }

    public virtual DbSet<AccountEdiFormat> AccountEdiFormats { get; set; }

    public virtual DbSet<AccountFinancialReport> AccountFinancialReports { get; set; }

    public virtual DbSet<AccountFinancialYearOp> AccountFinancialYearOps { get; set; }

    public virtual DbSet<AccountFiscalPosition> AccountFiscalPositions { get; set; }

    public virtual DbSet<AccountFiscalPositionAccount> AccountFiscalPositionAccounts { get; set; }

    public virtual DbSet<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplates { get; set; }

    public virtual DbSet<AccountFiscalPositionTax> AccountFiscalPositionTaxes { get; set; }

    public virtual DbSet<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplates { get; set; }

    public virtual DbSet<AccountFiscalPositionTemplate> AccountFiscalPositionTemplates { get; set; }

    public virtual DbSet<AccountFiscalYear> AccountFiscalYears { get; set; }

    public virtual DbSet<AccountFullReconcile> AccountFullReconciles { get; set; }

    public virtual DbSet<AccountGroup> AccountGroups { get; set; }

    public virtual DbSet<AccountGroupTemplate> AccountGroupTemplates { get; set; }

    public virtual DbSet<AccountIncoterm> AccountIncoterms { get; set; }

    public virtual DbSet<AccountInvoiceSend> AccountInvoiceSends { get; set; }

    public virtual DbSet<AccountJournal> AccountJournals { get; set; }

    public virtual DbSet<AccountJournalGroup> AccountJournalGroups { get; set; }

    public virtual DbSet<AccountMove> AccountMoves { get; set; }

    public virtual DbSet<AccountMoveLine> AccountMoveLines { get; set; }

    public virtual DbSet<AccountMoveReversal> AccountMoveReversals { get; set; }

    public virtual DbSet<AccountPartialReconcile> AccountPartialReconciles { get; set; }

    public virtual DbSet<AccountPayment> AccountPayments { get; set; }

    public virtual DbSet<AccountPaymentMethod> AccountPaymentMethods { get; set; }

    public virtual DbSet<AccountPaymentMethodLine> AccountPaymentMethodLines { get; set; }

    public virtual DbSet<AccountPaymentRegister> AccountPaymentRegisters { get; set; }

    public virtual DbSet<AccountPaymentTerm> AccountPaymentTerms { get; set; }

    public virtual DbSet<AccountPaymentTermLine> AccountPaymentTermLines { get; set; }

    public virtual DbSet<AccountPrintJournal> AccountPrintJournals { get; set; }

    public virtual DbSet<AccountReconcileModel> AccountReconcileModels { get; set; }

    public virtual DbSet<AccountReconcileModelLine> AccountReconcileModelLines { get; set; }

    public virtual DbSet<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplates { get; set; }

    public virtual DbSet<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappings { get; set; }

    public virtual DbSet<AccountReconcileModelTemplate> AccountReconcileModelTemplates { get; set; }

    public virtual DbSet<AccountRecurringTemplate> AccountRecurringTemplates { get; set; }

    public virtual DbSet<AccountReport> AccountReports { get; set; }

    public virtual DbSet<AccountReportColumn> AccountReportColumns { get; set; }

    public virtual DbSet<AccountReportExpression> AccountReportExpressions { get; set; }

    public virtual DbSet<AccountReportExternalValue> AccountReportExternalValues { get; set; }

    public virtual DbSet<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; set; }

    public virtual DbSet<AccountReportLine> AccountReportLines { get; set; }

    public virtual DbSet<AccountReportPartnerLedger> AccountReportPartnerLedgers { get; set; }

    public virtual DbSet<AccountResequenceWizard> AccountResequenceWizards { get; set; }

    public virtual DbSet<AccountSetupBankManualConfig> AccountSetupBankManualConfigs { get; set; }

    public virtual DbSet<AccountTax> AccountTaxes { get; set; }

    public virtual DbSet<AccountTaxGroup> AccountTaxGroups { get; set; }

    public virtual DbSet<AccountTaxRepartitionLine> AccountTaxRepartitionLines { get; set; }

    public virtual DbSet<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplates { get; set; }

    public virtual DbSet<AccountTaxReportWizard> AccountTaxReportWizards { get; set; }

    public virtual DbSet<AccountTaxTemplate> AccountTaxTemplates { get; set; }

    public virtual DbSet<AccountTourUploadBill> AccountTourUploadBills { get; set; }

    public virtual DbSet<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirms { get; set; }

    public virtual DbSet<AccountUnreconcile> AccountUnreconciles { get; set; }

    public virtual DbSet<AccountingReport> AccountingReports { get; set; }

    public virtual DbSet<ApplicantGetRefuseReason> ApplicantGetRefuseReasons { get; set; }

    public virtual DbSet<ApplicantSendMail> ApplicantSendMails { get; set; }

    public virtual DbSet<AssetDepreciationConfirmationWizard> AssetDepreciationConfirmationWizards { get; set; }

    public virtual DbSet<AssetModify> AssetModifies { get; set; }

    public virtual DbSet<AuthTotpDevice> AuthTotpDevices { get; set; }

    public virtual DbSet<AuthTotpWizard> AuthTotpWizards { get; set; }

    public virtual DbSet<BarcodeNomenclature> BarcodeNomenclatures { get; set; }

    public virtual DbSet<BarcodeRule> BarcodeRules { get; set; }

    public virtual DbSet<BaseDocumentLayout> BaseDocumentLayouts { get; set; }

    public virtual DbSet<BaseEnableProfilingWizard> BaseEnableProfilingWizards { get; set; }

    public virtual DbSet<BaseImportImport> BaseImportImports { get; set; }

    public virtual DbSet<BaseImportMapping> BaseImportMappings { get; set; }

    public virtual DbSet<BaseImportTestsModelsChar> BaseImportTestsModelsChars { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlies { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlies { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequireds { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharState> BaseImportTestsModelsCharStates { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlies { get; set; }

    public virtual DbSet<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexes { get; set; }

    public virtual DbSet<BaseImportTestsModelsFloat> BaseImportTestsModelsFloats { get; set; }

    public virtual DbSet<BaseImportTestsModelsM2o> BaseImportTestsModelsM2os { get; set; }

    public virtual DbSet<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelateds { get; set; }

    public virtual DbSet<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequireds { get; set; }

    public virtual DbSet<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelateds { get; set; }

    public virtual DbSet<BaseImportTestsModelsO2m> BaseImportTestsModelsO2ms { get; set; }

    public virtual DbSet<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildren { get; set; }

    public virtual DbSet<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviews { get; set; }

    public virtual DbSet<BaseLanguageExport> BaseLanguageExports { get; set; }

    public virtual DbSet<BaseLanguageImport> BaseLanguageImports { get; set; }

    public virtual DbSet<BaseLanguageInstall> BaseLanguageInstalls { get; set; }

    public virtual DbSet<BaseModuleInstallRequest> BaseModuleInstallRequests { get; set; }

    public virtual DbSet<BaseModuleInstallReview> BaseModuleInstallReviews { get; set; }

    public virtual DbSet<BaseModuleUninstall> BaseModuleUninstalls { get; set; }

    public virtual DbSet<BaseModuleUpdate> BaseModuleUpdates { get; set; }

    public virtual DbSet<BaseModuleUpgrade> BaseModuleUpgrades { get; set; }

    public virtual DbSet<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizards { get; set; }

    public virtual DbSet<BasePartnerMergeLine> BasePartnerMergeLines { get; set; }

    public virtual DbSet<BusBu> BusBus { get; set; }

    public virtual DbSet<BusPresence> BusPresences { get; set; }

    public virtual DbSet<CalendarAlarm> CalendarAlarms { get; set; }

    public virtual DbSet<CalendarAttendee> CalendarAttendees { get; set; }

    public virtual DbSet<CalendarEvent> CalendarEvents { get; set; }

    public virtual DbSet<CalendarEventType> CalendarEventTypes { get; set; }

    public virtual DbSet<CalendarFilter> CalendarFilters { get; set; }

    public virtual DbSet<CalendarProviderConfig> CalendarProviderConfigs { get; set; }

    public virtual DbSet<CalendarRecurrence> CalendarRecurrences { get; set; }

    public virtual DbSet<ChangeLockDate> ChangeLockDates { get; set; }

    public virtual DbSet<ChangePasswordOwn> ChangePasswordOwns { get; set; }

    public virtual DbSet<ChangePasswordUser> ChangePasswordUsers { get; set; }

    public virtual DbSet<ChangePasswordWizard> ChangePasswordWizards { get; set; }

    public virtual DbSet<ChangeProductionQty> ChangeProductionQties { get; set; }

    public virtual DbSet<ConfirmStockSm> ConfirmStockSms { get; set; }

    public virtual DbSet<CrmIapLeadHelper> CrmIapLeadHelpers { get; set; }

    public virtual DbSet<CrmIapLeadIndustry> CrmIapLeadIndustries { get; set; }

    public virtual DbSet<CrmIapLeadMiningRequest> CrmIapLeadMiningRequests { get; set; }

    public virtual DbSet<CrmIapLeadRole> CrmIapLeadRoles { get; set; }

    public virtual DbSet<CrmIapLeadSeniority> CrmIapLeadSeniorities { get; set; }

    public virtual DbSet<CrmLead> CrmLeads { get; set; }

    public virtual DbSet<CrmLead2opportunityPartner> CrmLead2opportunityPartners { get; set; }

    public virtual DbSet<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMasses { get; set; }

    public virtual DbSet<CrmLeadLost> CrmLeadLosts { get; set; }

    public virtual DbSet<CrmLeadPlsUpdate> CrmLeadPlsUpdates { get; set; }

    public virtual DbSet<CrmLeadScoringFrequency> CrmLeadScoringFrequencies { get; set; }

    public virtual DbSet<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyFields { get; set; }

    public virtual DbSet<CrmLostReason> CrmLostReasons { get; set; }

    public virtual DbSet<CrmMergeOpportunity> CrmMergeOpportunities { get; set; }

    public virtual DbSet<CrmQuotationPartner> CrmQuotationPartners { get; set; }

    public virtual DbSet<CrmRecurringPlan> CrmRecurringPlans { get; set; }

    public virtual DbSet<CrmStage> CrmStages { get; set; }

    public virtual DbSet<CrmTag> CrmTags { get; set; }

    public virtual DbSet<CrmTeam> CrmTeams { get; set; }

    public virtual DbSet<CrmTeamMember> CrmTeamMembers { get; set; }

    public virtual DbSet<CrossoveredBudget> CrossoveredBudgets { get; set; }

    public virtual DbSet<CrossoveredBudgetLine> CrossoveredBudgetLines { get; set; }

    public virtual DbSet<DecimalPrecision> DecimalPrecisions { get; set; }

    public virtual DbSet<DigestDigest> DigestDigests { get; set; }

    public virtual DbSet<DigestTip> DigestTips { get; set; }

    public virtual DbSet<FetchmailServer> FetchmailServers { get; set; }

    public virtual DbSet<FleetServiceType> FleetServiceTypes { get; set; }

    public virtual DbSet<FleetVehicle> FleetVehicles { get; set; }

    public virtual DbSet<FleetVehicleAssignationLog> FleetVehicleAssignationLogs { get; set; }

    public virtual DbSet<FleetVehicleLogContract> FleetVehicleLogContracts { get; set; }

    public virtual DbSet<FleetVehicleLogService> FleetVehicleLogServices { get; set; }

    public virtual DbSet<FleetVehicleModel> FleetVehicleModels { get; set; }

    public virtual DbSet<FleetVehicleModelBrand> FleetVehicleModelBrands { get; set; }

    public virtual DbSet<FleetVehicleModelCategory> FleetVehicleModelCategories { get; set; }

    public virtual DbSet<FleetVehicleOdometer> FleetVehicleOdometers { get; set; }

    public virtual DbSet<FleetVehicleState> FleetVehicleStates { get; set; }

    public virtual DbSet<FleetVehicleTag> FleetVehicleTags { get; set; }

    public virtual DbSet<FollowupFollowup> FollowupFollowups { get; set; }

    public virtual DbSet<FollowupLine> FollowupLines { get; set; }

    public virtual DbSet<FollowupPrint> FollowupPrints { get; set; }

    public virtual DbSet<FollowupSendingResult> FollowupSendingResults { get; set; }

    public virtual DbSet<HrApplicant> HrApplicants { get; set; }

    public virtual DbSet<HrApplicantCategory> HrApplicantCategories { get; set; }

    public virtual DbSet<HrApplicantRefuseReason> HrApplicantRefuseReasons { get; set; }

    public virtual DbSet<HrApplicantSkill> HrApplicantSkills { get; set; }

    public virtual DbSet<HrAttendance> HrAttendances { get; set; }

    public virtual DbSet<HrAttendanceOvertime> HrAttendanceOvertimes { get; set; }

    public virtual DbSet<HrContract> HrContracts { get; set; }

    public virtual DbSet<HrContractType> HrContractTypes { get; set; }

    public virtual DbSet<HrDepartment> HrDepartments { get; set; }

    public virtual DbSet<HrDepartureReason> HrDepartureReasons { get; set; }

    public virtual DbSet<HrDepartureWizard> HrDepartureWizards { get; set; }

    public virtual DbSet<HrEmployee> HrEmployees { get; set; }

    public virtual DbSet<HrEmployeeCategory> HrEmployeeCategories { get; set; }

    public virtual DbSet<HrEmployeeSkill> HrEmployeeSkills { get; set; }

    public virtual DbSet<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; set; }

    public virtual DbSet<HrExpense> HrExpenses { get; set; }

    public virtual DbSet<HrExpenseApproveDuplicate> HrExpenseApproveDuplicates { get; set; }

    public virtual DbSet<HrExpenseRefuseWizard> HrExpenseRefuseWizards { get; set; }

    public virtual DbSet<HrExpenseSheet> HrExpenseSheets { get; set; }

    public virtual DbSet<HrExpenseSplit> HrExpenseSplits { get; set; }

    public virtual DbSet<HrExpenseSplitWizard> HrExpenseSplitWizards { get; set; }

    public virtual DbSet<HrHolidaysCancelLeave> HrHolidaysCancelLeaves { get; set; }

    public virtual DbSet<HrHolidaysSummaryEmployee> HrHolidaysSummaryEmployees { get; set; }

    public virtual DbSet<HrJob> HrJobs { get; set; }

    public virtual DbSet<HrLeave> HrLeaves { get; set; }

    public virtual DbSet<HrLeaveAccrualLevel> HrLeaveAccrualLevels { get; set; }

    public virtual DbSet<HrLeaveAccrualPlan> HrLeaveAccrualPlans { get; set; }

    public virtual DbSet<HrLeaveAllocation> HrLeaveAllocations { get; set; }

    public virtual DbSet<HrLeaveStressDay> HrLeaveStressDays { get; set; }

    public virtual DbSet<HrLeaveType> HrLeaveTypes { get; set; }

    public virtual DbSet<HrPayrollStructureType> HrPayrollStructureTypes { get; set; }

    public virtual DbSet<HrPlan> HrPlans { get; set; }

    public virtual DbSet<HrPlanActivityType> HrPlanActivityTypes { get; set; }

    public virtual DbSet<HrPlanWizard> HrPlanWizards { get; set; }

    public virtual DbSet<HrRecruitmentDegree> HrRecruitmentDegrees { get; set; }

    public virtual DbSet<HrRecruitmentSource> HrRecruitmentSources { get; set; }

    public virtual DbSet<HrRecruitmentStage> HrRecruitmentStages { get; set; }

    public virtual DbSet<HrResumeLine> HrResumeLines { get; set; }

    public virtual DbSet<HrResumeLineType> HrResumeLineTypes { get; set; }

    public virtual DbSet<HrSkill> HrSkills { get; set; }

    public virtual DbSet<HrSkillLevel> HrSkillLevels { get; set; }

    public virtual DbSet<HrSkillType> HrSkillTypes { get; set; }

    public virtual DbSet<HrWorkLocation> HrWorkLocations { get; set; }

    public virtual DbSet<IapAccount> IapAccounts { get; set; }

    public virtual DbSet<IrActClient> IrActClients { get; set; }

    public virtual DbSet<IrActReportXml> IrActReportXmls { get; set; }

    public virtual DbSet<IrActServer> IrActServers { get; set; }

    public virtual DbSet<IrActUrl> IrActUrls { get; set; }

    public virtual DbSet<IrActWindow> IrActWindows { get; set; }

    public virtual DbSet<IrActWindowView> IrActWindowViews { get; set; }

    public virtual DbSet<IrAction> IrActions { get; set; }

    public virtual DbSet<IrActionsTodo> IrActionsTodos { get; set; }

    public virtual DbSet<IrAsset> IrAssets { get; set; }

    public virtual DbSet<IrAttachment> IrAttachments { get; set; }

    public virtual DbSet<IrConfigParameter> IrConfigParameters { get; set; }

    public virtual DbSet<IrCron> IrCrons { get; set; }

    public virtual DbSet<IrCronTrigger> IrCronTriggers { get; set; }

    public virtual DbSet<IrDefault> IrDefaults { get; set; }

    public virtual DbSet<IrDemo> IrDemos { get; set; }

    public virtual DbSet<IrDemoFailure> IrDemoFailures { get; set; }

    public virtual DbSet<IrDemoFailureWizard> IrDemoFailureWizards { get; set; }

    public virtual DbSet<IrExport> IrExports { get; set; }

    public virtual DbSet<IrExportsLine> IrExportsLines { get; set; }

    public virtual DbSet<IrFilter> IrFilters { get; set; }

    public virtual DbSet<IrLogging> IrLoggings { get; set; }

    public virtual DbSet<IrMailServer> IrMailServers { get; set; }

    public virtual DbSet<IrModel> IrModels { get; set; }

    public virtual DbSet<IrModelAccess> IrModelAccesses { get; set; }

    public virtual DbSet<IrModelConstraint> IrModelConstraints { get; set; }

    public virtual DbSet<IrModelDatum> IrModelData { get; set; }

    public virtual DbSet<IrModelField> IrModelFields { get; set; }

    public virtual DbSet<IrModelFieldsSelection> IrModelFieldsSelections { get; set; }

    public virtual DbSet<IrModelRelation> IrModelRelations { get; set; }

    public virtual DbSet<IrModuleCategory> IrModuleCategories { get; set; }

    public virtual DbSet<IrModuleModule> IrModuleModules { get; set; }

    public virtual DbSet<IrModuleModuleDependency> IrModuleModuleDependencies { get; set; }

    public virtual DbSet<IrModuleModuleExclusion> IrModuleModuleExclusions { get; set; }

    public virtual DbSet<IrProfile> IrProfiles { get; set; }

    public virtual DbSet<IrProperty> IrProperties { get; set; }

    public virtual DbSet<IrRule> IrRules { get; set; }

    public virtual DbSet<IrSequence> IrSequences { get; set; }

    public virtual DbSet<IrSequenceDateRange> IrSequenceDateRanges { get; set; }

    public virtual DbSet<IrServerObjectLine> IrServerObjectLines { get; set; }

    public virtual DbSet<IrUiMenu> IrUiMenus { get; set; }

    public virtual DbSet<IrUiView> IrUiViews { get; set; }

    public virtual DbSet<IrUiViewCustom> IrUiViewCustoms { get; set; }

    public virtual DbSet<LotLabelLayout> LotLabelLayouts { get; set; }

    public virtual DbSet<LunchAlert> LunchAlerts { get; set; }

    public virtual DbSet<LunchCashmove> LunchCashmoves { get; set; }

    public virtual DbSet<LunchLocation> LunchLocations { get; set; }

    public virtual DbSet<LunchOrder> LunchOrders { get; set; }

    public virtual DbSet<LunchProduct> LunchProducts { get; set; }

    public virtual DbSet<LunchProductCategory> LunchProductCategories { get; set; }

    public virtual DbSet<LunchSupplier> LunchSuppliers { get; set; }

    public virtual DbSet<LunchTopping> LunchToppings { get; set; }

    public virtual DbSet<MailActivity> MailActivities { get; set; }

    public virtual DbSet<MailActivityType> MailActivityTypes { get; set; }

    public virtual DbSet<MailAlias> MailAliases { get; set; }

    public virtual DbSet<MailBlacklist> MailBlacklists { get; set; }

    public virtual DbSet<MailBlacklistRemove> MailBlacklistRemoves { get; set; }

    public virtual DbSet<MailChannel> MailChannels { get; set; }

    public virtual DbSet<MailChannelMember> MailChannelMembers { get; set; }

    public virtual DbSet<MailChannelRtcSession> MailChannelRtcSessions { get; set; }

    public virtual DbSet<MailComposeMessage> MailComposeMessages { get; set; }

    public virtual DbSet<MailFollower> MailFollowers { get; set; }

    public virtual DbSet<MailGatewayAllowed> MailGatewayAlloweds { get; set; }

    public virtual DbSet<MailGuest> MailGuests { get; set; }

    public virtual DbSet<MailIceServer> MailIceServers { get; set; }

    public virtual DbSet<MailLinkPreview> MailLinkPreviews { get; set; }

    public virtual DbSet<MailMail> MailMails { get; set; }

    public virtual DbSet<MailMessage> MailMessages { get; set; }

    public virtual DbSet<MailMessageReaction> MailMessageReactions { get; set; }

    public virtual DbSet<MailMessageSchedule> MailMessageSchedules { get; set; }

    public virtual DbSet<MailMessageSubtype> MailMessageSubtypes { get; set; }

    public virtual DbSet<MailNotification> MailNotifications { get; set; }

    public virtual DbSet<MailResendMessage> MailResendMessages { get; set; }

    public virtual DbSet<MailResendPartner> MailResendPartners { get; set; }

    public virtual DbSet<MailShortcode> MailShortcodes { get; set; }

    public virtual DbSet<MailTemplate> MailTemplates { get; set; }

    public virtual DbSet<MailTemplatePreview> MailTemplatePreviews { get; set; }

    public virtual DbSet<MailTemplateReset> MailTemplateResets { get; set; }

    public virtual DbSet<MailTrackingValue> MailTrackingValues { get; set; }

    public virtual DbSet<MailWizardInvite> MailWizardInvites { get; set; }

    public virtual DbSet<MaintenanceEquipment> MaintenanceEquipments { get; set; }

    public virtual DbSet<MaintenanceEquipmentCategory> MaintenanceEquipmentCategories { get; set; }

    public virtual DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

    public virtual DbSet<MaintenanceStage> MaintenanceStages { get; set; }

    public virtual DbSet<MaintenanceTeam> MaintenanceTeams { get; set; }

    public virtual DbSet<MrpBom> MrpBoms { get; set; }

    public virtual DbSet<MrpBomByproduct> MrpBomByproducts { get; set; }

    public virtual DbSet<MrpBomLine> MrpBomLines { get; set; }

    public virtual DbSet<MrpConsumptionWarning> MrpConsumptionWarnings { get; set; }

    public virtual DbSet<MrpConsumptionWarningLine> MrpConsumptionWarningLines { get; set; }

    public virtual DbSet<MrpDocument> MrpDocuments { get; set; }

    public virtual DbSet<MrpImmediateProduction> MrpImmediateProductions { get; set; }

    public virtual DbSet<MrpImmediateProductionLine> MrpImmediateProductionLines { get; set; }

    public virtual DbSet<MrpProduction> MrpProductions { get; set; }

    public virtual DbSet<MrpProductionBackorder> MrpProductionBackorders { get; set; }

    public virtual DbSet<MrpProductionBackorderLine> MrpProductionBackorderLines { get; set; }

    public virtual DbSet<MrpProductionSplit> MrpProductionSplits { get; set; }

    public virtual DbSet<MrpProductionSplitLine> MrpProductionSplitLines { get; set; }

    public virtual DbSet<MrpProductionSplitMulti> MrpProductionSplitMultis { get; set; }

    public virtual DbSet<MrpRoutingWorkcenter> MrpRoutingWorkcenters { get; set; }

    public virtual DbSet<MrpUnbuild> MrpUnbuilds { get; set; }

    public virtual DbSet<MrpWorkcenter> MrpWorkcenters { get; set; }

    public virtual DbSet<MrpWorkcenterCapacity> MrpWorkcenterCapacities { get; set; }

    public virtual DbSet<MrpWorkcenterProductivity> MrpWorkcenterProductivities { get; set; }

    public virtual DbSet<MrpWorkcenterProductivityLoss> MrpWorkcenterProductivityLosses { get; set; }

    public virtual DbSet<MrpWorkcenterProductivityLossType> MrpWorkcenterProductivityLossTypes { get; set; }

    public virtual DbSet<MrpWorkcenterTag> MrpWorkcenterTags { get; set; }

    public virtual DbSet<MrpWorkorder> MrpWorkorders { get; set; }

    public virtual DbSet<NoteNote> NoteNotes { get; set; }

    public virtual DbSet<NoteStage> NoteStages { get; set; }

    public virtual DbSet<NoteTag> NoteTags { get; set; }

    public virtual DbSet<PartnerStatRel> PartnerStatRels { get; set; }

    public virtual DbSet<PaymentIcon> PaymentIcons { get; set; }

    public virtual DbSet<PaymentLinkWizard> PaymentLinkWizards { get; set; }

    public virtual DbSet<PaymentProvider> PaymentProviders { get; set; }

    public virtual DbSet<PaymentProviderOnboardingWizard> PaymentProviderOnboardingWizards { get; set; }

    public virtual DbSet<PaymentRefundWizard> PaymentRefundWizards { get; set; }

    public virtual DbSet<PaymentToken> PaymentTokens { get; set; }

    public virtual DbSet<PaymentTransaction> PaymentTransactions { get; set; }

    public virtual DbSet<PhoneBlacklist> PhoneBlacklists { get; set; }

    public virtual DbSet<PhoneBlacklistRemove> PhoneBlacklistRemoves { get; set; }

    public virtual DbSet<PickingLabelType> PickingLabelTypes { get; set; }

    public virtual DbSet<PortalShare> PortalShares { get; set; }

    public virtual DbSet<PortalWizard> PortalWizards { get; set; }

    public virtual DbSet<PortalWizardUser> PortalWizardUsers { get; set; }

    public virtual DbSet<PosBill> PosBills { get; set; }

    public virtual DbSet<PosCategory> PosCategories { get; set; }

    public virtual DbSet<PosCloseSessionWizard> PosCloseSessionWizards { get; set; }

    public virtual DbSet<PosConfig> PosConfigs { get; set; }

    public virtual DbSet<PosDetailsWizard> PosDetailsWizards { get; set; }

    public virtual DbSet<PosMakePayment> PosMakePayments { get; set; }

    public virtual DbSet<PosOrder> PosOrders { get; set; }

    public virtual DbSet<PosOrderLine> PosOrderLines { get; set; }

    public virtual DbSet<PosPackOperationLot> PosPackOperationLots { get; set; }

    public virtual DbSet<PosPayment> PosPayments { get; set; }

    public virtual DbSet<PosPaymentMethod> PosPaymentMethods { get; set; }

    public virtual DbSet<PosSession> PosSessions { get; set; }

    public virtual DbSet<PosSessionCheckProductWizard> PosSessionCheckProductWizards { get; set; }

    public virtual DbSet<PrivacyLog> PrivacyLogs { get; set; }

    public virtual DbSet<PrivacyLookupWizard> PrivacyLookupWizards { get; set; }

    public virtual DbSet<PrivacyLookupWizardLine> PrivacyLookupWizardLines { get; set; }

    public virtual DbSet<ProcurementGroup> ProcurementGroups { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductAttributeCustomValue> ProductAttributeCustomValues { get; set; }

    public virtual DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductLabelLayout> ProductLabelLayouts { get; set; }

    public virtual DbSet<ProductPackaging> ProductPackagings { get; set; }

    public virtual DbSet<ProductPricelist> ProductPricelists { get; set; }

    public virtual DbSet<ProductPricelistItem> ProductPricelistItems { get; set; }

    public virtual DbSet<ProductProduct> ProductProducts { get; set; }

    public virtual DbSet<ProductPublicCategory> ProductPublicCategories { get; set; }

    public virtual DbSet<ProductRemoval> ProductRemovals { get; set; }

    public virtual DbSet<ProductReplenish> ProductReplenishes { get; set; }

    public virtual DbSet<ProductRibbon> ProductRibbons { get; set; }

    public virtual DbSet<ProductSupplierinfo> ProductSupplierinfos { get; set; }

    public virtual DbSet<ProductTag> ProductTags { get; set; }

    public virtual DbSet<ProductTemplate> ProductTemplates { get; set; }

    public virtual DbSet<ProductTemplateAttributeExclusion> ProductTemplateAttributeExclusions { get; set; }

    public virtual DbSet<ProductTemplateAttributeLine> ProductTemplateAttributeLines { get; set; }

    public virtual DbSet<ProductTemplateAttributeValue> ProductTemplateAttributeValues { get; set; }

    public virtual DbSet<ProjectCollaborator> ProjectCollaborators { get; set; }

    public virtual DbSet<ProjectMilestone> ProjectMilestones { get; set; }

    public virtual DbSet<ProjectProject> ProjectProjects { get; set; }

    public virtual DbSet<ProjectProjectStage> ProjectProjectStages { get; set; }

    public virtual DbSet<ProjectShareWizard> ProjectShareWizards { get; set; }

    public virtual DbSet<ProjectTag> ProjectTags { get; set; }

    public virtual DbSet<ProjectTask> ProjectTasks { get; set; }

    public virtual DbSet<ProjectTaskRecurrence> ProjectTaskRecurrences { get; set; }

    public virtual DbSet<ProjectTaskType> ProjectTaskTypes { get; set; }

    public virtual DbSet<ProjectTaskTypeDeleteWizard> ProjectTaskTypeDeleteWizards { get; set; }

    public virtual DbSet<ProjectTaskUserRel> ProjectTaskUserRels { get; set; }

    public virtual DbSet<ProjectUpdate> ProjectUpdates { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

    public virtual DbSet<RatingRating> RatingRatings { get; set; }

    public virtual DbSet<RecurringPayment> RecurringPayments { get; set; }

    public virtual DbSet<RecurringPaymentLine> RecurringPaymentLines { get; set; }

    public virtual DbSet<RepairFee> RepairFees { get; set; }

    public virtual DbSet<RepairLine> RepairLines { get; set; }

    public virtual DbSet<RepairOrder> RepairOrders { get; set; }

    public virtual DbSet<RepairOrderMakeInvoice> RepairOrderMakeInvoices { get; set; }

    public virtual DbSet<RepairTag> RepairTags { get; set; }

    public virtual DbSet<ReportLayout> ReportLayouts { get; set; }

    public virtual DbSet<ReportPaperformat> ReportPaperformats { get; set; }

    public virtual DbSet<ResBank> ResBanks { get; set; }

    public virtual DbSet<ResCompany> ResCompanies { get; set; }

    public virtual DbSet<ResConfig> ResConfigs { get; set; }

    public virtual DbSet<ResConfigInstaller> ResConfigInstallers { get; set; }

    public virtual DbSet<ResConfigSetting> ResConfigSettings { get; set; }

    public virtual DbSet<ResCountry> ResCountries { get; set; }

    public virtual DbSet<ResCountryGroup> ResCountryGroups { get; set; }

    public virtual DbSet<ResCountryState> ResCountryStates { get; set; }

    public virtual DbSet<ResCurrency> ResCurrencies { get; set; }

    public virtual DbSet<ResCurrencyRate> ResCurrencyRates { get; set; }

    public virtual DbSet<ResGroup> ResGroups { get; set; }

    public virtual DbSet<ResLang> ResLangs { get; set; }

    public virtual DbSet<ResPartner> ResPartners { get; set; }

    public virtual DbSet<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncs { get; set; }

    public virtual DbSet<ResPartnerBank> ResPartnerBanks { get; set; }

    public virtual DbSet<ResPartnerCategory> ResPartnerCategories { get; set; }

    public virtual DbSet<ResPartnerIndustry> ResPartnerIndustries { get; set; }

    public virtual DbSet<ResPartnerTitle> ResPartnerTitles { get; set; }

    public virtual DbSet<ResUser> ResUsers { get; set; }

    public virtual DbSet<ResUsersApikey> ResUsersApikeys { get; set; }

    public virtual DbSet<ResUsersApikeysDescription> ResUsersApikeysDescriptions { get; set; }

    public virtual DbSet<ResUsersDeletion> ResUsersDeletions { get; set; }

    public virtual DbSet<ResUsersIdentitycheck> ResUsersIdentitychecks { get; set; }

    public virtual DbSet<ResUsersLog> ResUsersLogs { get; set; }

    public virtual DbSet<ResUsersSetting> ResUsersSettings { get; set; }

    public virtual DbSet<ResUsersSettingsVolume> ResUsersSettingsVolumes { get; set; }

    public virtual DbSet<ResetViewArchWizard> ResetViewArchWizards { get; set; }

    public virtual DbSet<ResourceCalendar> ResourceCalendars { get; set; }

    public virtual DbSet<ResourceCalendarAttendance> ResourceCalendarAttendances { get; set; }

    public virtual DbSet<ResourceCalendarLeaf> ResourceCalendarLeaves { get; set; }

    public virtual DbSet<ResourceResource> ResourceResources { get; set; }

    public virtual DbSet<SaleAdvancePaymentInv> SaleAdvancePaymentInvs { get; set; }

    public virtual DbSet<SaleOrder> SaleOrders { get; set; }

    public virtual DbSet<SaleOrderCancel> SaleOrderCancels { get; set; }

    public virtual DbSet<SaleOrderLine> SaleOrderLines { get; set; }

    public virtual DbSet<SaleOrderOption> SaleOrderOptions { get; set; }

    public virtual DbSet<SaleOrderTemplate> SaleOrderTemplates { get; set; }

    public virtual DbSet<SaleOrderTemplateLine> SaleOrderTemplateLines { get; set; }

    public virtual DbSet<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; set; }

    public virtual DbSet<SalePaymentProviderOnboardingWizard> SalePaymentProviderOnboardingWizards { get; set; }

    public virtual DbSet<SmsComposer> SmsComposers { get; set; }

    public virtual DbSet<SmsResend> SmsResends { get; set; }

    public virtual DbSet<SmsResendRecipient> SmsResendRecipients { get; set; }

    public virtual DbSet<SmsSm> SmsSms { get; set; }

    public virtual DbSet<SmsTemplate> SmsTemplates { get; set; }

    public virtual DbSet<SmsTemplatePreview> SmsTemplatePreviews { get; set; }

    public virtual DbSet<SmsTemplateReset> SmsTemplateResets { get; set; }

    public virtual DbSet<SnailmailConfirmInvoice> SnailmailConfirmInvoices { get; set; }

    public virtual DbSet<SnailmailLetter> SnailmailLetters { get; set; }

    public virtual DbSet<SnailmailLetterFormatError> SnailmailLetterFormatErrors { get; set; }

    public virtual DbSet<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFields { get; set; }

    public virtual DbSet<SpreadsheetDashboard> SpreadsheetDashboards { get; set; }

    public virtual DbSet<SpreadsheetDashboardGroup> SpreadsheetDashboardGroups { get; set; }

    public virtual DbSet<StockAssignSerial> StockAssignSerials { get; set; }

    public virtual DbSet<StockBackorderConfirmation> StockBackorderConfirmations { get; set; }

    public virtual DbSet<StockBackorderConfirmationLine> StockBackorderConfirmationLines { get; set; }

    public virtual DbSet<StockChangeProductQty> StockChangeProductQties { get; set; }

    public virtual DbSet<StockImmediateTransfer> StockImmediateTransfers { get; set; }

    public virtual DbSet<StockImmediateTransferLine> StockImmediateTransferLines { get; set; }

    public virtual DbSet<StockInventoryAdjustmentName> StockInventoryAdjustmentNames { get; set; }

    public virtual DbSet<StockInventoryConflict> StockInventoryConflicts { get; set; }

    public virtual DbSet<StockInventoryWarning> StockInventoryWarnings { get; set; }

    public virtual DbSet<StockLocation> StockLocations { get; set; }

    public virtual DbSet<StockLot> StockLots { get; set; }

    public virtual DbSet<StockMove> StockMoves { get; set; }

    public virtual DbSet<StockMoveLine> StockMoveLines { get; set; }

    public virtual DbSet<StockOrderpointSnooze> StockOrderpointSnoozes { get; set; }

    public virtual DbSet<StockPackageDestination> StockPackageDestinations { get; set; }

    public virtual DbSet<StockPackageLevel> StockPackageLevels { get; set; }

    public virtual DbSet<StockPackageType> StockPackageTypes { get; set; }

    public virtual DbSet<StockPicking> StockPickings { get; set; }

    public virtual DbSet<StockPickingType> StockPickingTypes { get; set; }

    public virtual DbSet<StockPutawayRule> StockPutawayRules { get; set; }

    public virtual DbSet<StockQuant> StockQuants { get; set; }

    public virtual DbSet<StockQuantPackage> StockQuantPackages { get; set; }

    public virtual DbSet<StockQuantityHistory> StockQuantityHistories { get; set; }

    public virtual DbSet<StockReplenishmentInfo> StockReplenishmentInfos { get; set; }

    public virtual DbSet<StockReplenishmentOption> StockReplenishmentOptions { get; set; }

    public virtual DbSet<StockRequestCount> StockRequestCounts { get; set; }

    public virtual DbSet<StockReturnPicking> StockReturnPickings { get; set; }

    public virtual DbSet<StockReturnPickingLine> StockReturnPickingLines { get; set; }

    public virtual DbSet<StockRoute> StockRoutes { get; set; }

    public virtual DbSet<StockRule> StockRules { get; set; }

    public virtual DbSet<StockRulesReport> StockRulesReports { get; set; }

    public virtual DbSet<StockSchedulerCompute> StockSchedulerComputes { get; set; }

    public virtual DbSet<StockScrap> StockScraps { get; set; }

    public virtual DbSet<StockStorageCategory> StockStorageCategories { get; set; }

    public virtual DbSet<StockStorageCategoryCapacity> StockStorageCategoryCapacities { get; set; }

    public virtual DbSet<StockTraceabilityReport> StockTraceabilityReports { get; set; }

    public virtual DbSet<StockTrackConfirmation> StockTrackConfirmations { get; set; }

    public virtual DbSet<StockTrackLine> StockTrackLines { get; set; }

    public virtual DbSet<StockValuationLayer> StockValuationLayers { get; set; }

    public virtual DbSet<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; set; }

    public virtual DbSet<StockWarehouse> StockWarehouses { get; set; }

    public virtual DbSet<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; set; }

    public virtual DbSet<StockWarnInsufficientQtyRepair> StockWarnInsufficientQtyRepairs { get; set; }

    public virtual DbSet<StockWarnInsufficientQtyScrap> StockWarnInsufficientQtyScraps { get; set; }

    public virtual DbSet<StockWarnInsufficientQtyUnbuild> StockWarnInsufficientQtyUnbuilds { get; set; }

    public virtual DbSet<ThemeIrAsset> ThemeIrAssets { get; set; }

    public virtual DbSet<ThemeIrAttachment> ThemeIrAttachments { get; set; }

    public virtual DbSet<ThemeIrUiView> ThemeIrUiViews { get; set; }

    public virtual DbSet<ThemeWebsiteMenu> ThemeWebsiteMenus { get; set; }

    public virtual DbSet<ThemeWebsitePage> ThemeWebsitePages { get; set; }

    public virtual DbSet<UomCategory> UomCategories { get; set; }

    public virtual DbSet<UomUom> UomUoms { get; set; }

    public virtual DbSet<UtmCampaign> UtmCampaigns { get; set; }

    public virtual DbSet<UtmMedium> UtmMedia { get; set; }

    public virtual DbSet<UtmSource> UtmSources { get; set; }

    public virtual DbSet<UtmStage> UtmStages { get; set; }

    public virtual DbSet<UtmTag> UtmTags { get; set; }

    public virtual DbSet<ValidateAccountMove> ValidateAccountMoves { get; set; }

    public virtual DbSet<WebEditorConverterTest> WebEditorConverterTests { get; set; }

    public virtual DbSet<WebEditorConverterTestSub> WebEditorConverterTestSubs { get; set; }

    public virtual DbSet<WebTourTour> WebTourTours { get; set; }

    public virtual DbSet<Website> Websites { get; set; }

    public virtual DbSet<WebsiteBaseUnit> WebsiteBaseUnits { get; set; }

    public virtual DbSet<WebsiteConfiguratorFeature> WebsiteConfiguratorFeatures { get; set; }

    public virtual DbSet<WebsiteMenu> WebsiteMenus { get; set; }

    public virtual DbSet<WebsitePage> WebsitePages { get; set; }

    public virtual DbSet<WebsiteRewrite> WebsiteRewrites { get; set; }

    public virtual DbSet<WebsiteRobot> WebsiteRobots { get; set; }

    public virtual DbSet<WebsiteRoute> WebsiteRoutes { get; set; }

    public virtual DbSet<WebsiteSaleExtraField> WebsiteSaleExtraFields { get; set; }

    public virtual DbSet<WebsiteSnippetFilter> WebsiteSnippetFilters { get; set; }

    public virtual DbSet<WebsiteTrack> WebsiteTracks { get; set; }

    public virtual DbSet<WebsiteVisitor> WebsiteVisitors { get; set; }

    public virtual DbSet<WizardIrModelMenuCreate> WizardIrModelMenuCreates { get; set; }
    

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
