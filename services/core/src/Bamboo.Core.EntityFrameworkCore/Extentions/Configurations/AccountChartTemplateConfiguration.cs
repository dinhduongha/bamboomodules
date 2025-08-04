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
        public static void ConfigureAccountChartTemplate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountChartTemplate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_chart_template_pkey");

                entity.ToTable("account_chart_template");

                entity.HasIndex(e => e.TenantId, "account_chart_template_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountJournalEarlyPayDiscountGainAccountId).HasColumnName("account_journal_early_pay_discount_gain_account_id");
                entity.Property(e => e.AccountJournalEarlyPayDiscountLossAccountId).HasColumnName("account_journal_early_pay_discount_loss_account_id");
                entity.Property(e => e.AccountJournalPaymentCreditAccountId).HasColumnName("account_journal_payment_credit_account_id");
                entity.Property(e => e.AccountJournalPaymentDebitAccountId).HasColumnName("account_journal_payment_debit_account_id");
                entity.Property(e => e.AccountJournalSuspenseAccountId).HasColumnName("account_journal_suspense_account_id");
                entity.Property(e => e.BankAccountCodePrefix).HasColumnName("bank_account_code_prefix");
                entity.Property(e => e.CashAccountCodePrefix).HasColumnName("cash_account_code_prefix");
                entity.Property(e => e.CodeDigits).HasColumnName("code_digits");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.DefaultCashDifferenceExpenseAccountId).HasColumnName("default_cash_difference_expense_account_id");
                entity.Property(e => e.DefaultCashDifferenceIncomeAccountId).HasColumnName("default_cash_difference_income_account_id");
                entity.Property(e => e.DefaultPosReceivableAccountId).HasColumnName("default_pos_receivable_account_id");
                entity.Property(e => e.ExpenseCurrencyExchangeAccountId).HasColumnName("expense_currency_exchange_account_id");
                entity.Property(e => e.IncomeCurrencyExchangeAccountId).HasColumnName("income_currency_exchange_account_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.PropertyAccountExpenseCategId).HasColumnName("property_account_expense_categ_id");
                entity.Property(e => e.PropertyAccountExpenseId).HasColumnName("property_account_expense_id");
                entity.Property(e => e.PropertyAccountIncomeCategId).HasColumnName("property_account_income_categ_id");
                entity.Property(e => e.PropertyAccountIncomeId).HasColumnName("property_account_income_id");
                entity.Property(e => e.PropertyAccountPayableId).HasColumnName("property_account_payable_id");
                entity.Property(e => e.PropertyAccountReceivableId).HasColumnName("property_account_receivable_id");
                entity.Property(e => e.PropertyAdvanceTaxPaymentAccountId).HasColumnName("property_advance_tax_payment_account_id");
                entity.Property(e => e.PropertyCashBasisBaseAccountId).HasColumnName("property_cash_basis_base_account_id");
                entity.Property(e => e.PropertyStockAccountInputCategId).HasColumnName("property_stock_account_input_categ_id");
                entity.Property(e => e.PropertyStockAccountOutputCategId).HasColumnName("property_stock_account_output_categ_id");
                entity.Property(e => e.PropertyStockValuationAccountId).HasColumnName("property_stock_valuation_account_id");
                entity.Property(e => e.PropertyTaxPayableAccountId).HasColumnName("property_tax_payable_account_id");
                entity.Property(e => e.PropertyTaxReceivableAccountId).HasColumnName("property_tax_receivable_account_id");
                entity.Property(e => e.SpokenLanguages).HasColumnName("spoken_languages");
                entity.Property(e => e.TransferAccountCodePrefix).HasColumnName("transfer_account_code_prefix");
                entity.Property(e => e.UseAngloSaxon).HasColumnName("use_anglo_saxon");
                entity.Property(e => e.UseStornoAccounting).HasColumnName("use_storno_accounting");
                entity.Property(e => e.Visible).HasColumnName("visible");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountJournalEarlyPayDiscountGainAccount).WithMany(p => p.AccountChartTemplateAccountJournalEarlyPayDiscountGainAccounts)
                    .HasForeignKey(d => d.AccountJournalEarlyPayDiscountGainAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_account_journal_early_pay_discount_fkey1");

                entity.HasOne(d => d.AccountJournalEarlyPayDiscountLossAccount).WithMany(p => p.AccountChartTemplateAccountJournalEarlyPayDiscountLossAccounts)
                    .HasForeignKey(d => d.AccountJournalEarlyPayDiscountLossAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_account_journal_early_pay_discount__fkey");

                entity.HasOne(d => d.AccountJournalPaymentCreditAccount).WithMany(p => p.AccountChartTemplateAccountJournalPaymentCreditAccounts)
                    .HasForeignKey(d => d.AccountJournalPaymentCreditAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_account_journal_payment_credit_acco_fkey");

                entity.HasOne(d => d.AccountJournalPaymentDebitAccount).WithMany(p => p.AccountChartTemplateAccountJournalPaymentDebitAccounts)
                    .HasForeignKey(d => d.AccountJournalPaymentDebitAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_account_journal_payment_debit_accou_fkey");

                entity.HasOne(d => d.AccountJournalSuspenseAccount).WithMany(p => p.AccountChartTemplateAccountJournalSuspenseAccounts)
                    .HasForeignKey(d => d.AccountJournalSuspenseAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_account_journal_suspense_account_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_chart_template_currency_id_fkey");

                entity.HasOne(d => d.DefaultCashDifferenceExpenseAccount).WithMany(p => p.AccountChartTemplateDefaultCashDifferenceExpenseAccounts)
                    .HasForeignKey(d => d.DefaultCashDifferenceExpenseAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_default_cash_difference_expense_acc_fkey");

                entity.HasOne(d => d.DefaultCashDifferenceIncomeAccount).WithMany(p => p.AccountChartTemplateDefaultCashDifferenceIncomeAccounts)
                    .HasForeignKey(d => d.DefaultCashDifferenceIncomeAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_default_cash_difference_income_acco_fkey");

                entity.HasOne(d => d.DefaultPosReceivableAccount).WithMany(p => p.AccountChartTemplateDefaultPosReceivableAccounts)
                    .HasForeignKey(d => d.DefaultPosReceivableAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_default_pos_receivable_account_id_fkey");

                entity.HasOne(d => d.ExpenseCurrencyExchangeAccount).WithMany(p => p.AccountChartTemplateExpenseCurrencyExchangeAccounts)
                    .HasForeignKey(d => d.ExpenseCurrencyExchangeAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_expense_currency_exchange_account_i_fkey");

                entity.HasOne(d => d.IncomeCurrencyExchangeAccount).WithMany(p => p.AccountChartTemplateIncomeCurrencyExchangeAccounts)
                    .HasForeignKey(d => d.IncomeCurrencyExchangeAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_income_currency_exchange_account_id_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_parent_id_fkey");

                entity.HasOne(d => d.PropertyAccountExpenseCateg).WithMany(p => p.AccountChartTemplatePropertyAccountExpenseCategs)
                    .HasForeignKey(d => d.PropertyAccountExpenseCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_account_expense_categ_id_fkey");

                entity.HasOne(d => d.PropertyAccountExpense).WithMany(p => p.AccountChartTemplatePropertyAccountExpenses)
                    .HasForeignKey(d => d.PropertyAccountExpenseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_account_expense_id_fkey");

                entity.HasOne(d => d.PropertyAccountIncomeCateg).WithMany(p => p.AccountChartTemplatePropertyAccountIncomeCategs)
                    .HasForeignKey(d => d.PropertyAccountIncomeCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_account_income_categ_id_fkey");

                entity.HasOne(d => d.PropertyAccountIncome).WithMany(p => p.AccountChartTemplatePropertyAccountIncomes)
                    .HasForeignKey(d => d.PropertyAccountIncomeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_account_income_id_fkey");

                entity.HasOne(d => d.PropertyAccountPayable).WithMany(p => p.AccountChartTemplatePropertyAccountPayables)
                    .HasForeignKey(d => d.PropertyAccountPayableId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_account_payable_id_fkey");

                entity.HasOne(d => d.PropertyAccountReceivable).WithMany(p => p.AccountChartTemplatePropertyAccountReceivables)
                    .HasForeignKey(d => d.PropertyAccountReceivableId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_account_receivable_id_fkey");

                entity.HasOne(d => d.PropertyAdvanceTaxPaymentAccount).WithMany(p => p.AccountChartTemplatePropertyAdvanceTaxPaymentAccounts)
                    .HasForeignKey(d => d.PropertyAdvanceTaxPaymentAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_advance_tax_payment_accoun_fkey");

                entity.HasOne(d => d.PropertyCashBasisBaseAccount).WithMany(p => p.AccountChartTemplatePropertyCashBasisBaseAccounts)
                    .HasForeignKey(d => d.PropertyCashBasisBaseAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_cash_basis_base_account_id_fkey");

                entity.HasOne(d => d.PropertyStockAccountInputCateg).WithMany(p => p.AccountChartTemplatePropertyStockAccountInputCategs)
                    .HasForeignKey(d => d.PropertyStockAccountInputCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_stock_account_input_categ__fkey");

                entity.HasOne(d => d.PropertyStockAccountOutputCateg).WithMany(p => p.AccountChartTemplatePropertyStockAccountOutputCategs)
                    .HasForeignKey(d => d.PropertyStockAccountOutputCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_stock_account_output_categ_fkey");

                entity.HasOne(d => d.PropertyStockValuationAccount).WithMany(p => p.AccountChartTemplatePropertyStockValuationAccounts)
                    .HasForeignKey(d => d.PropertyStockValuationAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_stock_valuation_account_id_fkey");

                entity.HasOne(d => d.PropertyTaxPayableAccount).WithMany(p => p.AccountChartTemplatePropertyTaxPayableAccounts)
                    .HasForeignKey(d => d.PropertyTaxPayableAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_tax_payable_account_id_fkey");

                entity.HasOne(d => d.PropertyTaxReceivableAccount).WithMany(p => p.AccountChartTemplatePropertyTaxReceivableAccounts)
                    .HasForeignKey(d => d.PropertyTaxReceivableAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_property_tax_receivable_account_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_chart_template_write_uid_fkey");
            });
        }
    }
}