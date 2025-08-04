using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResCompany(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResCompany>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("res_company_pkey");

                entity.ToTable("res_company");

                entity.HasIndex(e => e.Name, "res_company_name_uniq").IsUnique();

                entity.HasIndex(e => e.ParentId, "res_company_parent_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccountCashBasisBaseAccountId).HasColumnName("account_cash_basis_base_account_id");
                entity.Property(e => e.AccountDashboardOnboardingState).HasColumnName("account_dashboard_onboarding_state");
                entity.Property(e => e.AccountDefaultPosReceivableAccountId).HasColumnName("account_default_pos_receivable_account_id");
                entity.Property(e => e.AccountFiscalCountryId).HasColumnName("account_fiscal_country_id");
                entity.Property(e => e.AccountInvoiceOnboardingState).HasColumnName("account_invoice_onboarding_state");
                entity.Property(e => e.AccountJournalEarlyPayDiscountGainAccountId).HasColumnName("account_journal_early_pay_discount_gain_account_id");
                entity.Property(e => e.AccountJournalEarlyPayDiscountLossAccountId).HasColumnName("account_journal_early_pay_discount_loss_account_id");
                entity.Property(e => e.AccountJournalPaymentCreditAccountId).HasColumnName("account_journal_payment_credit_account_id");
                entity.Property(e => e.AccountJournalPaymentDebitAccountId).HasColumnName("account_journal_payment_debit_account_id");
                entity.Property(e => e.AccountJournalSuspenseAccountId).HasColumnName("account_journal_suspense_account_id");
                entity.Property(e => e.AccountOnboardingCreateInvoiceStateFlag).HasColumnName("account_onboarding_create_invoice_state_flag");
                entity.Property(e => e.AccountOnboardingInvoiceLayoutState).HasColumnName("account_onboarding_invoice_layout_state");
                entity.Property(e => e.AccountOnboardingSaleTaxState).HasColumnName("account_onboarding_sale_tax_state");
                entity.Property(e => e.AccountOpeningDate).HasColumnName("account_opening_date");
                entity.Property(e => e.AccountOpeningMoveId).HasColumnName("account_opening_move_id");
                entity.Property(e => e.AccountPurchaseTaxId).HasColumnName("account_purchase_tax_id");
                entity.Property(e => e.AccountSaleTaxId).HasColumnName("account_sale_tax_id");
                entity.Property(e => e.AccountSetupBankDataState).HasColumnName("account_setup_bank_data_state");
                entity.Property(e => e.AccountSetupBillState).HasColumnName("account_setup_bill_state");
                entity.Property(e => e.AccountSetupCoaState).HasColumnName("account_setup_coa_state");
                entity.Property(e => e.AccountSetupFyDataState).HasColumnName("account_setup_fy_data_state");
                entity.Property(e => e.AccountSetupTaxesState).HasColumnName("account_setup_taxes_state");
                entity.Property(e => e.AccountStorno).HasColumnName("account_storno");
                entity.Property(e => e.AccountUseCreditLimit).HasColumnName("account_use_credit_limit");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AngloSaxonAccounting).HasColumnName("anglo_saxon_accounting");
                entity.Property(e => e.AnnualInventoryDay).HasColumnName("annual_inventory_day");
                entity.Property(e => e.AnnualInventoryMonth).HasColumnName("annual_inventory_month");
                entity.Property(e => e.AttendanceBarcodeSource).HasColumnName("attendance_barcode_source");
                entity.Property(e => e.AttendanceKioskDelay).HasColumnName("attendance_kiosk_delay");
                entity.Property(e => e.AttendanceKioskMode).HasColumnName("attendance_kiosk_mode");
                entity.Property(e => e.AutomaticEntryDefaultJournalId).HasColumnName("automatic_entry_default_journal_id");
                entity.Property(e => e.BankAccountCodePrefix).HasColumnName("bank_account_code_prefix");
                entity.Property(e => e.BaseOnboardingCompanyState).HasColumnName("base_onboarding_company_state");
                entity.Property(e => e.CashAccountCodePrefix).HasColumnName("cash_account_code_prefix");
                entity.Property(e => e.ChartTemplateId).HasColumnName("chart_template_id");
                entity.Property(e => e.CompanyDetails).HasColumnName("company_details");
                entity.Property(e => e.CompanyExpenseJournalId).HasColumnName("company_expense_journal_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyExchangeJournalId).HasColumnName("currency_exchange_journal_id");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.DaysToPurchase).HasColumnName("days_to_purchase");
                entity.Property(e => e.DefaultCashDifferenceExpenseAccountId).HasColumnName("default_cash_difference_expense_account_id");
                entity.Property(e => e.DefaultCashDifferenceIncomeAccountId).HasColumnName("default_cash_difference_income_account_id");
                entity.Property(e => e.EarlyPayDiscountComputation).HasColumnName("early_pay_discount_computation");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.ExpectsChartOfAccounts).HasColumnName("expects_chart_of_accounts");
                entity.Property(e => e.ExpenseAccrualAccountId).HasColumnName("expense_accrual_account_id");
                entity.Property(e => e.ExpenseCurrencyExchangeAccountId).HasColumnName("expense_currency_exchange_account_id");
                entity.Property(e => e.ExpenseJournalId).HasColumnName("expense_journal_id");
                entity.Property(e => e.ExternalReportLayoutId).HasColumnName("external_report_layout_id");
                entity.Property(e => e.FiscalyearLastDay).HasColumnName("fiscalyear_last_day");
                entity.Property(e => e.FiscalyearLastMonth).HasColumnName("fiscalyear_last_month");
                entity.Property(e => e.FiscalyearLockDate).HasColumnName("fiscalyear_lock_date");
                entity.Property(e => e.Font).HasColumnName("font");
                entity.Property(e => e.HasReceivedWarningStockSms).HasColumnName("has_received_warning_stock_sms");
                entity.Property(e => e.HrAttendanceOvertime).HasColumnName("hr_attendance_overtime");
                entity.Property(e => e.HrPresenceControlEmailAmount).HasColumnName("hr_presence_control_email_amount");
                entity.Property(e => e.HrPresenceControlIpList).HasColumnName("hr_presence_control_ip_list");
                entity.Property(e => e.IapEnrichAutoDone).HasColumnName("iap_enrich_auto_done");
                entity.Property(e => e.IncomeCurrencyExchangeAccountId).HasColumnName("income_currency_exchange_account_id");
                entity.Property(e => e.IncotermId).HasColumnName("incoterm_id");
                entity.Property(e => e.InternalTransitLocationId).HasColumnName("internal_transit_location_id");
                entity.Property(e => e.InvoiceIsEmail).HasColumnName("invoice_is_email");
                entity.Property(e => e.InvoiceIsPrint).HasColumnName("invoice_is_print");
                entity.Property(e => e.InvoiceIsSnailmail).HasColumnName("invoice_is_snailmail");
                entity.Property(e => e.InvoiceTerms)
                    .HasColumnType("jsonb")
                    .HasColumnName("invoice_terms");
                entity.Property(e => e.InvoiceTermsHtml)
                    .HasColumnType("jsonb")
                    .HasColumnName("invoice_terms_html");
                entity.Property(e => e.LayoutBackground).HasColumnName("layout_background");
                entity.Property(e => e.LogoWeb).HasColumnName("logo_web");
                entity.Property(e => e.LunchMinimumThreshold).HasColumnName("lunch_minimum_threshold");
                entity.Property(e => e.LunchNotifyMessage)
                    .HasColumnType("jsonb")
                    .HasColumnName("lunch_notify_message");
                entity.Property(e => e.ManufacturingLead).HasColumnName("manufacturing_lead");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Mobile).HasColumnName("mobile");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.NomenclatureId).HasColumnName("nomenclature_id");
                entity.Property(e => e.OvertimeCompanyThreshold).HasColumnName("overtime_company_threshold");
                entity.Property(e => e.OvertimeEmployeeThreshold).HasColumnName("overtime_employee_threshold");
                entity.Property(e => e.OvertimeStartDate).HasColumnName("overtime_start_date");
                entity.Property(e => e.PaperformatId).HasColumnName("paperformat_id");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.PartnerGid).HasColumnName("partner_gid");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PaymentOnboardingPaymentMethod).HasColumnName("payment_onboarding_payment_method");
                entity.Property(e => e.PaymentProviderOnboardingState).HasColumnName("payment_provider_onboarding_state");
                entity.Property(e => e.PeriodLockDate).HasColumnName("period_lock_date");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.PoDoubleValidation).HasColumnName("po_double_validation");
                entity.Property(e => e.PoDoubleValidationAmount).HasColumnName("po_double_validation_amount");
                entity.Property(e => e.PoLead).HasColumnName("po_lead");
                entity.Property(e => e.PoLock).HasColumnName("po_lock");
                entity.Property(e => e.PointOfSaleUpdateStockQuantities).HasColumnName("point_of_sale_update_stock_quantities");
                entity.Property(e => e.PointOfSaleUseTicketQrCode).HasColumnName("point_of_sale_use_ticket_qr_code");
                entity.Property(e => e.PortalConfirmationPay).HasColumnName("portal_confirmation_pay");
                entity.Property(e => e.PortalConfirmationSign).HasColumnName("portal_confirmation_sign");
                entity.Property(e => e.PrimaryColor).HasColumnName("primary_color");
                entity.Property(e => e.PropertyStockAccountInputCategId).HasColumnName("property_stock_account_input_categ_id");
                entity.Property(e => e.PropertyStockAccountOutputCategId).HasColumnName("property_stock_account_output_categ_id");
                entity.Property(e => e.PropertyStockValuationAccountId).HasColumnName("property_stock_valuation_account_id");
                entity.Property(e => e.QrCode).HasColumnName("qr_code");
                entity.Property(e => e.QuickEditMode).HasColumnName("quick_edit_mode");
                entity.Property(e => e.QuotationValidityDays).HasColumnName("quotation_validity_days");
                entity.Property(e => e.ReportFooter)
                    .HasColumnType("jsonb")
                    .HasColumnName("report_footer");
                entity.Property(e => e.ReportHeader).HasColumnName("report_header");
                entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                entity.Property(e => e.RevenueAccrualAccountId).HasColumnName("revenue_accrual_account_id");
                entity.Property(e => e.SaleOnboardingOrderConfirmationState).HasColumnName("sale_onboarding_order_confirmation_state");
                entity.Property(e => e.SaleOnboardingPaymentMethod).HasColumnName("sale_onboarding_payment_method");
                entity.Property(e => e.SaleOnboardingSampleQuotationState).HasColumnName("sale_onboarding_sample_quotation_state");
                entity.Property(e => e.SaleOrderTemplateId).HasColumnName("sale_order_template_id");
                entity.Property(e => e.SaleQuotationOnboardingState).HasColumnName("sale_quotation_onboarding_state");
                entity.Property(e => e.SecondaryColor).HasColumnName("secondary_color");
                entity.Property(e => e.SecurityLead).HasColumnName("security_lead");
                entity.Property(e => e.Sequence).HasColumnName("sequence");
                entity.Property(e => e.SnailmailColor).HasColumnName("snailmail_color");
                entity.Property(e => e.SnailmailCover).HasColumnName("snailmail_cover");
                entity.Property(e => e.SnailmailDuplex).HasColumnName("snailmail_duplex");
                entity.Property(e => e.SocialFacebook).HasColumnName("social_facebook");
                entity.Property(e => e.SocialGithub).HasColumnName("social_github");
                entity.Property(e => e.SocialInstagram).HasColumnName("social_instagram");
                entity.Property(e => e.SocialLinkedin).HasColumnName("social_linkedin");
                entity.Property(e => e.SocialTwitter).HasColumnName("social_twitter");
                entity.Property(e => e.SocialYoutube).HasColumnName("social_youtube");
                entity.Property(e => e.StockMailConfirmationTemplateId).HasColumnName("stock_mail_confirmation_template_id");
                entity.Property(e => e.StockMoveEmailValidation).HasColumnName("stock_move_email_validation");
                entity.Property(e => e.StockMoveSmsValidation).HasColumnName("stock_move_sms_validation");
                entity.Property(e => e.StockSmsConfirmationTemplateId).HasColumnName("stock_sms_confirmation_template_id");
                entity.Property(e => e.TaxCalculationRoundingMethod).HasColumnName("tax_calculation_rounding_method");
                entity.Property(e => e.TaxCashBasisJournalId).HasColumnName("tax_cash_basis_journal_id");
                entity.Property(e => e.TaxExigibility).HasColumnName("tax_exigibility");
                entity.Property(e => e.TaxLockDate).HasColumnName("tax_lock_date");
                entity.Property(e => e.TermsType).HasColumnName("terms_type");
                entity.Property(e => e.TransferAccountCodePrefix).HasColumnName("transfer_account_code_prefix");
                entity.Property(e => e.TransferAccountId).HasColumnName("transfer_account_id");
                entity.Property(e => e.VatCheckVies).HasColumnName("vat_check_vies");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.WebsiteSaleOnboardingPaymentProviderState).HasColumnName("website_sale_onboarding_payment_provider_state");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountCashBasisBaseAccount).WithMany(p => p.ResCompanyAccountCashBasisBaseAccounts)
                    .HasForeignKey(d => d.AccountCashBasisBaseAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_cash_basis_base_account_id_fkey");

                entity.HasOne(d => d.AccountDefaultPosReceivableAccount).WithMany(p => p.ResCompanyAccountDefaultPosReceivableAccounts)
                    .HasForeignKey(d => d.AccountDefaultPosReceivableAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_default_pos_receivable_account_id_fkey");

                entity.HasOne(d => d.AccountFiscalCountry).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.AccountFiscalCountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_fiscal_country_id_fkey");

                entity.HasOne(d => d.AccountJournalEarlyPayDiscountGainAccount).WithMany(p => p.ResCompanyAccountJournalEarlyPayDiscountGainAccounts)
                    .HasForeignKey(d => d.AccountJournalEarlyPayDiscountGainAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_journal_early_pay_discount_gain_accoun_fkey");

                entity.HasOne(d => d.AccountJournalEarlyPayDiscountLossAccount).WithMany(p => p.ResCompanyAccountJournalEarlyPayDiscountLossAccounts)
                    .HasForeignKey(d => d.AccountJournalEarlyPayDiscountLossAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_journal_early_pay_discount_loss_accoun_fkey");

                entity.HasOne(d => d.AccountJournalPaymentCreditAccount).WithMany(p => p.ResCompanyAccountJournalPaymentCreditAccounts)
                    .HasForeignKey(d => d.AccountJournalPaymentCreditAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_journal_payment_credit_account_id_fkey");

                entity.HasOne(d => d.AccountJournalPaymentDebitAccount).WithMany(p => p.ResCompanyAccountJournalPaymentDebitAccounts)
                    .HasForeignKey(d => d.AccountJournalPaymentDebitAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_journal_payment_debit_account_id_fkey");

                entity.HasOne(d => d.AccountJournalSuspenseAccount).WithMany(p => p.ResCompanyAccountJournalSuspenseAccounts)
                    .HasForeignKey(d => d.AccountJournalSuspenseAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_journal_suspense_account_id_fkey");

                entity.HasOne(d => d.AccountOpeningMove).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.AccountOpeningMoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_opening_move_id_fkey");

                entity.HasOne(d => d.AccountPurchaseTax).WithMany(p => p.ResCompanyAccountPurchaseTaxes)
                    .HasForeignKey(d => d.AccountPurchaseTaxId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_purchase_tax_id_fkey");

                entity.HasOne(d => d.AccountSaleTax).WithMany(p => p.ResCompanyAccountSaleTaxes)
                    .HasForeignKey(d => d.AccountSaleTaxId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_account_sale_tax_id_fkey");

                entity.HasOne(d => d.AutomaticEntryDefaultJournal).WithMany(p => p.ResCompanyAutomaticEntryDefaultJournals)
                    .HasForeignKey(d => d.AutomaticEntryDefaultJournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_automatic_entry_default_journal_id_fkey");

                // v16-Compat
                // entity.HasOne(d => d.ChartTemplate).WithMany(p => p.ResCompanies)
                //     .HasForeignKey(d => d.ChartTemplateId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("res_company_chart_template_id_fkey");

                entity.HasOne(d => d.CompanyExpenseJournal).WithMany(p => p.ResCompanyCompanyExpenseJournals)
                    .HasForeignKey(d => d.CompanyExpenseJournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_company_expense_journal_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_create_uid_fkey");

                entity.HasOne(d => d.CurrencyExchangeJournal).WithMany(p => p.ResCompanyCurrencyExchangeJournals)
                    .HasForeignKey(d => d.CurrencyExchangeJournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_currency_exchange_journal_id_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_company_currency_id_fkey");

                entity.HasOne(d => d.DefaultCashDifferenceExpenseAccount).WithMany(p => p.ResCompanyDefaultCashDifferenceExpenseAccounts)
                    .HasForeignKey(d => d.DefaultCashDifferenceExpenseAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_default_cash_difference_expense_account_id_fkey");

                entity.HasOne(d => d.DefaultCashDifferenceIncomeAccount).WithMany(p => p.ResCompanyDefaultCashDifferenceIncomeAccounts)
                    .HasForeignKey(d => d.DefaultCashDifferenceIncomeAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_default_cash_difference_income_account_id_fkey");

                entity.HasOne(d => d.ExpenseAccrualAccount).WithMany(p => p.ResCompanyExpenseAccrualAccounts)
                    .HasForeignKey(d => d.ExpenseAccrualAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_expense_accrual_account_id_fkey");

                entity.HasOne(d => d.ExpenseCurrencyExchangeAccount).WithMany(p => p.ResCompanyExpenseCurrencyExchangeAccounts)
                    .HasForeignKey(d => d.ExpenseCurrencyExchangeAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_expense_currency_exchange_account_id_fkey");

                entity.HasOne(d => d.ExpenseJournal).WithMany(p => p.ResCompanyExpenseJournals)
                    .HasForeignKey(d => d.ExpenseJournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_expense_journal_id_fkey");

                entity.HasOne(d => d.ExternalReportLayout).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.ExternalReportLayoutId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_external_report_layout_id_fkey");

                entity.HasOne(d => d.IncomeCurrencyExchangeAccount).WithMany(p => p.ResCompanyIncomeCurrencyExchangeAccounts)
                    .HasForeignKey(d => d.IncomeCurrencyExchangeAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_income_currency_exchange_account_id_fkey");

                entity.HasOne(d => d.Incoterm).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.IncotermId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_incoterm_id_fkey");

                entity.HasOne(d => d.InternalTransitLocation).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.InternalTransitLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_company_internal_transit_location_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Nomenclature).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.NomenclatureId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_nomenclature_id_fkey");

                entity.HasOne(d => d.Paperformat).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.PaperformatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_paperformat_id_fkey");

                entity.HasOne(d => d.Parent).WithMany()
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_parent_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_company_partner_id_fkey");

                entity.HasOne(d => d.PropertyStockAccountInputCateg).WithMany(p => p.ResCompanyPropertyStockAccountInputCategs)
                    .HasForeignKey(d => d.PropertyStockAccountInputCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_property_stock_account_input_categ_id_fkey");

                entity.HasOne(d => d.PropertyStockAccountOutputCateg).WithMany(p => p.ResCompanyPropertyStockAccountOutputCategs)
                    .HasForeignKey(d => d.PropertyStockAccountOutputCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_property_stock_account_output_categ_id_fkey");

                entity.HasOne(d => d.PropertyStockValuationAccount).WithMany(p => p.ResCompanyPropertyStockValuationAccounts)
                    .HasForeignKey(d => d.PropertyStockValuationAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_property_stock_valuation_account_id_fkey");

                entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.ResourceCalendarId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("res_company_resource_calendar_id_fkey");

                entity.HasOne(d => d.RevenueAccrualAccount).WithMany(p => p.ResCompanyRevenueAccrualAccounts)
                    .HasForeignKey(d => d.RevenueAccrualAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_revenue_accrual_account_id_fkey");

                entity.HasOne(d => d.SaleOrderTemplate).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.SaleOrderTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_sale_order_template_id_fkey");

                entity.HasOne(d => d.StockMailConfirmationTemplate).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.StockMailConfirmationTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_stock_mail_confirmation_template_id_fkey");

                entity.HasOne(d => d.StockSmsConfirmationTemplate).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.StockSmsConfirmationTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_stock_sms_confirmation_template_id_fkey");

                entity.HasOne(d => d.TaxCashBasisJournal).WithMany(p => p.ResCompanyTaxCashBasisJournals)
                    .HasForeignKey(d => d.TaxCashBasisJournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_tax_cash_basis_journal_id_fkey");

                entity.HasOne(d => d.TransferAccount).WithMany(p => p.ResCompanyTransferAccounts)
                    .HasForeignKey(d => d.TransferAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_transfer_account_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.ResCompanies)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_write_uid_fkey");

                entity.HasMany(d => d.AccountPaymentMethodLines).WithMany(p => p.ResCompanies)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountPaymentMethodLineResCompanyRel",
                        r => r.HasOne<AccountPaymentMethodLine>().WithMany()
                            .HasForeignKey("AccountPaymentMethodLineId")
                            .HasConstraintName("account_payment_method_line_r_account_payment_method_line__fkey"),
                        l => l.HasOne<ResCompany>().WithMany()
                            .HasForeignKey("TenantId")
                            .HasConstraintName("account_payment_method_line_res_company_rel_res_company_id_fkey"),
                        j =>
                        {
                            j.HasKey("TenantId", "AccountPaymentMethodLineId").HasName("account_payment_method_line_res_company_rel_pkey");
                            j.ToTable("account_payment_method_line_res_company_rel");
                            j.HasIndex(new[] { "AccountPaymentMethodLineId", "TenantId" }, "account_payment_method_line_r_account_payment_method_line_i_idx");
                            j.IndexerProperty<Guid>("TenantId").HasColumnName("res_company_id");
                            j.IndexerProperty<Guid>("AccountPaymentMethodLineId").HasColumnName("account_payment_method_line_id");
                        });

                /// TODO: SharedTypeEntity    
                //entity.HasMany(d => d.Users).WithMany(p => p.Cids)
                entity.HasMany<ResUser>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ResCompanyUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("res_company_users_rel_user_id_fkey"),
                        l => l.HasOne<ResCompany>().WithMany()
                            .HasForeignKey("Cid")
                            .HasConstraintName("res_company_users_rel_cid_fkey"),
                        j =>
                        {
                            j.HasKey("Cid", "UserId").HasName("res_company_users_rel_pkey");
                            j.ToTable("res_company_users_rel");
                            j.HasIndex(new[] { "UserId", "Cid" }, "res_company_users_rel_user_id_cid_idx");
                        });
            });
        }
    }
}