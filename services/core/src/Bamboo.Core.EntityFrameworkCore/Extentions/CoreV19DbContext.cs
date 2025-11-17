using System;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public partial class CoreDbContext
{
    public virtual DbSet<AccountAnalyticLineCalendarEmployee> AccountAnalyticLineCalendarEmployee { get; set; }
    public virtual DbSet<AccountPaymentRegisterWithholdingLine> AccountPaymentRegisterWithholdingLine { get; set; }
    public virtual DbSet<AccountPaymentWithholdingLine> AccountPaymentWithholdingLine { get; set; }
    public virtual DbSet<DiscussCallHistory> DiscussCallHistory { get; set; }
    public virtual DbSet<EventMailSlot> EventMailSlot { get; set; }
    public virtual DbSet<EventSlot> EventSlot { get; set; }
    public virtual DbSet<HrApplicantSkill> HrApplicantSkill { get; set; }
    public virtual DbSet<HrAttendanceOvertimeLine> HrAttendanceOvertimeLine { get; set; }

    public virtual DbSet<HrAttendanceOvertimeRule> HrAttendanceOvertimeRule { get; set; }

    public virtual DbSet<HrAttendanceOvertimeRuleset> HrAttendanceOvertimeRuleset { get; set; }

    public virtual DbSet<HrBankAccountAllocationWizard> HrBankAccountAllocationWizard { get; set; }
    public virtual DbSet<HrBankAccountAllocationWizardLine> HrBankAccountAllocationWizardLine { get; set; }
    public virtual DbSet<HrExpensePostWizard> HrExpensePostWizard { get; set; }
    public virtual DbSet<HrJobSkill> HrJobSkill { get; set; }
    public virtual DbSet<HrTalentPool> HrTalentPool { get; set; }
    public virtual DbSet<HrVersion> HrVersion { get; set; }
    public virtual DbSet<HrVersionWizard> HrVersionWizard { get; set; }
    public virtual DbSet<HtmlEditorConverterTest> HtmlEditorConverterTest { get; set; }
    public virtual DbSet<HtmlEditorConverterTestSub> HtmlEditorConverterTestSub { get; set; }
    public virtual DbSet<ImLivechatChannelMemberHistory> ImLivechatChannelMemberHistory { get; set; }
    public virtual DbSet<ImLivechatConversationTag> ImLivechatConversationTag { get; set; }
    public virtual DbSet<ImLivechatExpertise> ImLivechatExpertise { get; set; }
    public virtual DbSet<IrActionsServerHistory> IrActionsServerHistory { get; set; }
    public virtual DbSet<JobAddApplicants> JobAddApplicants { get; set; }
    public virtual DbSet<MailActivityScheduleLine> MailActivityScheduleLine { get; set; }
    public virtual DbSet<MailFollowersEdit> MailFollowersEdit { get; set; }
    public virtual DbSet<MailMessageLinkPreview> MailMessageLinkPreview { get; set; }
    public virtual DbSet<MailPresence> MailPresence { get; set; }
    public virtual DbSet<MrpProductionGroup> MrpProductionGroup { get; set; }

    public virtual DbSet<MrpProductionSerials> MrpProductionSerials { get; set; }
    public virtual DbSet<OrmSignalingAssets> OrmSignalingAssets { get; set; }
    public virtual DbSet<OrmSignalingDefault> OrmSignalingDefault { get; set; }

    public virtual DbSet<OrmSignalingGroups> OrmSignalingGroups { get; set; }

    public virtual DbSet<OrmSignalingRegistry> OrmSignalingRegistry { get; set; }

    public virtual DbSet<OrmSignalingRouting> OrmSignalingRouting { get; set; }

    public virtual DbSet<OrmSignalingStable> OrmSignalingStable { get; set; }

    public virtual DbSet<OrmSignalingTemplates> OrmSignalingTemplates { get; set; }

    public virtual DbSet<PeppolConfigWizard> PeppolConfigWizard { get; set; }
    public virtual DbSet<PosConfirmationWizard> PosConfirmationWizard { get; set; }
    public virtual DbSet<PosMakeInvoice> PosMakeInvoice { get; set; }
    public virtual DbSet<PosPreset> PosPreset { get; set; }
    public virtual DbSet<PrintPrenumberedChecks> PrintPrenumberedChecks { get; set; }
    public virtual DbSet<ProductFeed> ProductFeed { get; set; }
    public virtual DbSet<ProductUom> ProductUom { get; set; }
    public virtual DbSet<ProductValue> ProductValue { get; set; }
    public virtual DbSet<ProjectRole> ProjectRole { get; set; }
    public virtual DbSet<ProjectTemplateCreateWizard> ProjectTemplateCreateWizard { get; set; }
    public virtual DbSet<ProjectTemplateRoleToUsersMap> ProjectTemplateRoleToUsersMap { get; set; }
    public virtual DbSet<PropertiesBaseDefinition> PropertiesBaseDefinition { get; set; }
    public virtual DbSet<ResGroupsPrivilege> ResGroupsPrivilege { get; set; }
    public virtual DbSet<ResRole> ResRole { get; set; }
    public virtual DbSet<RestaurantOrderCourse> RestaurantOrderCourse { get; set; }
    public virtual DbSet<ResUsersSettingsEmbeddedAction> ResUsersSettingsEmbeddedAction { get; set; }
    public virtual DbSet<ServerActionHistoryWizard> ServerActionHistoryWizard { get; set; }
    public virtual DbSet<SmsTwilioAccountManage> SmsTwilioAccountManage { get; set; }
    public virtual DbSet<SmsTwilioNumber> SmsTwilioNumber { get; set; }
    public virtual DbSet<StockPackage> StockPackage { get; set; }
    public virtual DbSet<StockPackageHistory> StockPackageHistory { get; set; }
    public virtual DbSet<StockPutInPack> StockPutInPack { get; set; }
    public virtual DbSet<StockReference> StockReference { get; set; }
    public virtual DbSet<TalentPoolAddApplicants> TalentPoolAddApplicants { get; set; }
    public virtual DbSet<TaskShareWizard> TaskShareWizard { get; set; }
    public virtual DbSet<WebsiteCheckoutStep> WebsiteCheckoutStep { get; set; }
}