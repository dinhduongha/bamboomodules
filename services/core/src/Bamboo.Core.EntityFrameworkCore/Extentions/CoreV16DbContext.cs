#define ODOO16_ENABLE

using System;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public partial class CoreDbContext
{
#if ODOO16_ENABLE
    public virtual DbSet<AccountAccountTemplate> AccountAccountTemplates { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountBankStatementImport> AccountBankStatementImports { get; set; }

    public virtual DbSet<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreations { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountChartTemplate> AccountChartTemplates { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplates { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplates { get; set; }

    public virtual DbSet<AccountFiscalPositionTemplate> AccountFiscalPositionTemplates { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountGroupTemplate> AccountGroupTemplates { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountInvoiceSend> AccountInvoiceSends { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplates { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountReconcileModelTemplate> AccountReconcileModelTemplates { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplates { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<AccountTaxTemplate> AccountTaxTemplates { get; set; }

    public virtual DbSet<AccountTourUploadBill> AccountTourUploadBills { get; set; }

    public virtual DbSet<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirms { get; set; }

    public virtual DbSet<AccountUnreconcile> AccountUnreconciles { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<BaseImportTestsModelsChar> BaseImportTestsModelsChars { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlies { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlies { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequireds { get; set; }

    public virtual DbSet<BaseImportTestsModelsCharStates> BaseImportTestsModelsCharStates { get; set; }

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
#endif

#if ODOO16_ENABLE
    public virtual DbSet<GoogleCalendarCredentials> GoogleCalendarCredentials { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<HrApplicantSkill> HrApplicantSkills { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<HrLeaveStressDay> HrLeaveStressDays { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<HrPlan> HrPlans { get; set; }

    public virtual DbSet<HrPlanActivityType> HrPlanActivityTypes { get; set; }

    public virtual DbSet<HrPlanWizard> HrPlanWizards { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<IrProperty> IrProperties { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<IrServerObjectLines> IrServerObjectLines { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<MailChannel> MailChannels { get; set; }

    public virtual DbSet<MailChannelMember> MailChannelMembers { get; set; }

    public virtual DbSet<MailChannelRtcSession> MailChannelRtcSessions { get; set; }
#endif    

#if ODOO16_ENABLE
    public virtual DbSet<MailShortcode> MailShortcodes { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<MailingContactListRel> MailingContactListRels { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<MrpDocument> MrpDocuments { get; set; }

    public virtual DbSet<MrpImmediateProduction> MrpImmediateProductions { get; set; }

    public virtual DbSet<MrpImmediateProductionLine> MrpImmediateProductionLines { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<NoteNote> NoteNotes { get; set; }

    public virtual DbSet<NoteStage> NoteStages { get; set; }

    public virtual DbSet<NoteTag> NoteTags { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<PaymentIcon> PaymentIcons { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<PosSessionCheckProductWizard> PosSessionCheckProductWizards { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<ProjectCreateSaleOrder> ProjectCreateSaleOrders { get; set; }

    public virtual DbSet<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLines { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<PurchaseRequisitionType> PurchaseRequisitionTypes { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<RepairFee> RepairFees { get; set; }

    public virtual DbSet<RepairLine> RepairLines { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<RepairOrderMakeInvoice> RepairOrderMakeInvoices { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<ResConfigInstaller> ResConfigInstallers { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<RestaurantPrinter> RestaurantPrinters { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<SnailmailConfirmInvoice> SnailmailConfirmInvoices { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<StockAssignSerial> StockAssignSerials { get; set; }
#endif

#if ODOO16_ENABLE
    public virtual DbSet<StockImmediateTransfer> StockImmediateTransfers { get; set; }

    public virtual DbSet<StockImmediateTransferLine> StockImmediateTransferLines { get; set; }
#endif    

#if ODOO16_ENABLE
    public virtual DbSet<StockSchedulerCompute> StockSchedulerComputes { get; set; }
#endif

}