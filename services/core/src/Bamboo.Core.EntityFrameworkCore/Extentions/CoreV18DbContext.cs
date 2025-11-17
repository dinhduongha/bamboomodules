using System;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public partial class CoreDbContext
{
    public virtual DbSet<AccountFiscalPositionTax> AccountFiscalPositionTaxes { get; set; }
    public virtual DbSet<AccountPeppolServiceWizard> AccountPeppolServiceWizards { get; set; }
    public virtual DbSet<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappings { get; set; }
    public virtual DbSet<CandidateSendMail> CandidateSendMails { get; set; }
    public virtual DbSet<ChatRoom> ChatRooms { get; set; }
    public virtual DbSet<ChooseDeliveryPackage> ChooseDeliveryPackages { get; set; }
    public virtual DbSet<EventMeetingRoom> EventMeetingRooms { get; set; }
    public virtual DbSet<HrAttendanceOvertime> HrAttendanceOvertimes { get; set; }
    public virtual DbSet<HrCandidate> HrCandidates { get; set; }

    public virtual DbSet<HrCandidateSkill> HrCandidateSkills { get; set; }

    public virtual DbSet<HrContract> HrContracts { get; set; }

    public virtual DbSet<HrContractAdvantageTemplate> HrContractAdvantageTemplates { get; set; }
    public virtual DbSet<HrContributionRegister> HrContributionRegisters { get; set; }
    public virtual DbSet<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; set; }
    public virtual DbSet<HrExpenseSheet> HrExpenseSheets { get; set; }
    public virtual DbSet<HrPayrollStructure> HrPayrollStructures { get; set; }
    public virtual DbSet<HrPayslip> HrPayslips { get; set; }

    public virtual DbSet<HrPayslipEmployees> HrPayslipEmployees { get; set; }

    public virtual DbSet<HrPayslipInput> HrPayslipInputs { get; set; }

    public virtual DbSet<HrPayslipLine> HrPayslipLines { get; set; }

    public virtual DbSet<HrPayslipRun> HrPayslipRuns { get; set; }

    public virtual DbSet<HrPayslipWorkedDays> HrPayslipWorkedDays { get; set; }
    public virtual DbSet<HrRuleInput> HrRuleInputs { get; set; }

    public virtual DbSet<HrSalaryRule> HrSalaryRules { get; set; }
    public virtual DbSet<HrSalaryRuleCategory> HrSalaryRuleCategories { get; set; }
    public virtual DbSet<MailGroup> MailGroups { get; set; }

    public virtual DbSet<MailGroupMember> MailGroupMembers { get; set; }

    public virtual DbSet<MailGroupMessage> MailGroupMessages { get; set; }

    public virtual DbSet<MailGroupMessageReject> MailGroupMessageRejects { get; set; }

    public virtual DbSet<MailGroupModeration> MailGroupModerations { get; set; }

    public virtual DbSet<MailResendMessage> MailResendMessages { get; set; }

    public virtual DbSet<MailResendPartner> MailResendPartners { get; set; }
    public virtual DbSet<MailWizardInvite> MailWizardInvites { get; set; }
    public virtual DbSet<MembershipInvoice> MembershipInvoices { get; set; }

    public virtual DbSet<MembershipMembershipLine> MembershipMembershipLines { get; set; }
    public virtual DbSet<MrpBatchProduce> MrpBatchProduces { get; set; }
    public virtual DbSet<PaymentProviderOnboardingWizard> PaymentProviderOnboardingWizards { get; set; }
    public virtual DbSet<PayslipLinesContributionRegister> PayslipLinesContributionRegisters { get; set; }
    public virtual DbSet<ProcurementGroup> ProcurementGroups { get; set; }
    public virtual DbSet<ProductFetchImageWizard> ProductFetchImageWizards { get; set; }
    public virtual DbSet<ProductPackaging> ProductPackagings { get; set; }
    public virtual DbSet<ProjectCreateInvoice> ProjectCreateInvoices { get; set; }
    public virtual DbSet<SaleOrderCancel> SaleOrderCancels { get; set; }
    public virtual DbSet<SaleOrderOption> SaleOrderOptions { get; set; }
    public virtual DbSet<SaleOrderTemplateOption> SaleOrderTemplateOptions { get; set; }
    public virtual DbSet<SalePaymentProviderOnboardingWizard> SalePaymentProviderOnboardingWizards { get; set; }
    public virtual DbSet<SmsResend> SmsResends { get; set; }

    public virtual DbSet<SmsResendRecipient> SmsResendRecipients { get; set; }

    public virtual DbSet<SnailmailLetterFormatError> SnailmailLetterFormatErrors { get; set; }

    public virtual DbSet<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFields { get; set; }

    public virtual DbSet<StockChangeProductQty> StockChangeProductQties { get; set; }
    public virtual DbSet<StockPackageLevel> StockPackageLevels { get; set; }
    public virtual DbSet<StockQuantPackage> StockQuantPackages { get; set; }
    public virtual DbSet<StockTrackConfirmation> StockTrackConfirmations { get; set; }

    public virtual DbSet<StockTrackLine> StockTrackLines { get; set; }
    public virtual DbSet<StockValuationLayer> StockValuationLayers { get; set; }

    public virtual DbSet<StockValuationLayerRevaluation> StockValuationLayerRevaluations { get; set; }
    public virtual DbSet<UomCategory> UomCategories { get; set; }

}