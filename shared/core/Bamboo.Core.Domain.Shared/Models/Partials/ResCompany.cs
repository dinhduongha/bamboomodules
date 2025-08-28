using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("res_company")]
//[Index("ParentId", Name = "res_company__parent_id_index")]
//[Index("Name", Name = "res_company_name_uniq", IsUnique = true)]
public partial class ResCompany
{

    [Column("base_onboarding_company_state")]
    public string? BaseOnboardingCompanyState { get; set; }

    // [Column("report_header")]
    // public string? ReportHeader { get; set; }

    // [Column("company_details")]
    // public string? CompanyDetails { get; set; }

    [Column("payment_provider_onboarding_state")]
    public string? PaymentProviderOnboardingState { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("account_journal_payment_debit_account_id")]
    public Guid? AccountJournalPaymentDebitAccountId { get; set; }

    [Column("account_journal_payment_credit_account_id")]
    public Guid? AccountJournalPaymentCreditAccountId { get; set; }

    [Column("property_stock_account_input_categ_id")]
    public Guid? PropertyStockAccountInputCategId { get; set; }

    [Column("property_stock_account_output_categ_id")]
    public Guid? PropertyStockAccountOutputCategId { get; set; }

    [Column("property_stock_valuation_account_id")]
    public Guid? PropertyStockValuationAccountId { get; set; }

    [Column("early_pay_discount_computation")]
    public string? EarlyPayDiscountComputation { get; set; }

    [Column("account_setup_bank_data_state")]
    public string? AccountSetupBankDataState { get; set; }

    [Column("account_setup_fy_data_state")]
    public string? AccountSetupFyDataState { get; set; }

    [Column("account_setup_coa_state")]
    public string? AccountSetupCoaState { get; set; }

    [Column("account_setup_taxes_state")]
    public string? AccountSetupTaxesState { get; set; }

    [Column("account_onboarding_invoice_layout_state")]
    public string? AccountOnboardingInvoiceLayoutState { get; set; }

    [Column("account_onboarding_sale_tax_state")]
    public string? AccountOnboardingSaleTaxState { get; set; }

    [Column("account_invoice_onboarding_state")]
    public string? AccountInvoiceOnboardingState { get; set; }

    [Column("account_dashboard_onboarding_state")]
    public string? AccountDashboardOnboardingState { get; set; }

    [Column("account_setup_bill_state")]
    public string? AccountSetupBillState { get; set; }


    [Column("period_lock_date")]
    public DateTime? PeriodLockDate { get; set; }


    [Column("invoice_is_email")]
    public bool? InvoiceIsEmail { get; set; }

    [Column("invoice_is_print")]
    public bool? InvoiceIsPrint { get; set; }


    [Column("account_onboarding_create_invoice_state_flag")]
    public bool? AccountOnboardingCreateInvoiceStateFlag { get; set; }


    [Column("invoice_is_snailmail")]
    public bool? InvoiceIsSnailmail { get; set; }


    [Column("sale_quotation_onboarding_state")]
    public string? SaleQuotationOnboardingState { get; set; }

    [Column("sale_onboarding_order_confirmation_state")]
    public string? SaleOnboardingOrderConfirmationState { get; set; }

    [Column("sale_onboarding_sample_quotation_state")]
    public string? SaleOnboardingSampleQuotationState { get; set; }


    // [Column("vat_check_vies")]
    // public bool? VatCheckVies { get; set; }

    // [Column("manufacturing_lead")]
    // public double? ManufacturingLead { get; set; }


    [Column("company_expense_journal_id")]
    public Guid? CompanyExpenseJournalId { get; set; }

    [Column("overtime_start_date")]
    public DateTime? OvertimeStartDate { get; set; }

    [Column("hr_attendance_overtime")]
    public bool? HrAttendanceOvertime { get; set; }


    [Column("website_sale_onboarding_payment_provider_state")]
    public string? WebsiteSaleOnboardingPaymentProviderState { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }



    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (AccountAnalyticPlan) is commented out
    // public virtual ICollection<AccountAnalyticPlan> AccountAnalyticPlan { get; set; }


    // [Many2one]
    [ForeignKey("AccountJournalPaymentCreditAccountId")]
    public virtual AccountAccount? AccountJournalPaymentCreditAccount { get; set; }

    // [Many2one]
    [ForeignKey("AccountJournalPaymentDebitAccountId")]
    public virtual AccountAccount? AccountJournalPaymentDebitAccount { get; set; }


    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    public virtual AccountChartTemplate? ChartTemplateObject { get; set; }

    // [Many2one]
    [ForeignKey("CompanyExpenseJournalId")]
    public virtual AccountJournal? CompanyExpenseJournal { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("EmployeeCompanyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("EmployeeCompany")] // One2many // Peer relationship (HrLeaveAllocation) is commented out
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationEmployeeCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("ModeCompanyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ModeCompany")] // One2many // Peer relationship (HrLeaveAllocation) is commented out
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationModeCompany { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("ModeCompanyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ModeCompany")] // One2many // Peer relationship (HrLeave) is commented out
    // public virtual ICollection<HrLeave> HrLeaveModeCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrLeaveStressDay) is commented out
    // public virtual ICollection<HrLeaveStressDay> HrLeaveStressDay { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrPlan) is commented out
    // public virtual ICollection<HrPlan> HrPlan { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (HrPlanActivityType) is commented out
    // public virtual ICollection<HrPlanActivityType> HrPlanActivityType { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (IrProperty) is commented out
    // public virtual ICollection<IrProperty> IrProperty { get; set; }


    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (NoteNote) is commented out
    // public virtual ICollection<NoteNote> NoteNote { get; set; }


    // [Many2one]
    [ForeignKey("PropertyStockAccountInputCategId")]
    public virtual AccountAccount? PropertyStockAccountInputCateg { get; set; }

    // [Many2one]
    [ForeignKey("PropertyStockAccountOutputCategId")]
    public virtual AccountAccount? PropertyStockAccountOutputCateg { get; set; }

    // [Many2one]
    [ForeignKey("PropertyStockValuationAccountId")]
    public virtual AccountAccount? PropertyStockValuationAccount { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (RepairFee) is commented out
    // public virtual ICollection<RepairFee> RepairFee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCompany'
    // [One2many] [ForeignKey("TenantId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Company")] // One2many // Peer relationship (RepairLine) is commented out
    // public virtual ICollection<RepairLine> RepairLine { get; set; }
}
