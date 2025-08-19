using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrExpense(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrExpense>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_expense_pkey");

            entity.ToTable("hr_expense");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.MessageMainAttachmentId, "hr_expense__message_main_attachment_id_index").HasFilter("(message_main_attachment_id IS NOT NULL)");

            entity.HasIndex(e => e.SaleOrderId, "hr_expense__sale_order_id_index").HasFilter("(sale_order_id IS NOT NULL)");

            entity.HasIndex(e => e.SheetId, "hr_expense__sheet_id_index");

            entity.HasIndex(e => e.AnalyticDistribution, "hr_expense_analytic_distribution_gin_index").HasMethod("gin");

            entity.HasIndex(e => e.State, "hr_expense__state_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AccountingDate).HasColumnName("accounting_date");
            entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
            entity.Property(e => e.AmountTaxCompany).HasColumnName("amount_tax_company");
            entity.Property(e => e.AnalyticDistribution)
                .HasColumnType("jsonb")
                .HasColumnName("analytic_distribution");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.IsRefused).HasColumnName("is_refused");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PaymentMode).HasColumnName("payment_mode");
            entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Reference).HasColumnName("reference");
            entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
            entity.Property(e => e.Sample).HasColumnName("sample");
            entity.Property(e => e.SheetId).HasColumnName("sheet_id");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.TaxAmount).HasColumnName("tax_amount");
            entity.Property(e => e.TaxAmountCurrency).HasColumnName("tax_amount_currency");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.TotalAmountCurrency).HasColumnName("total_amount_currency");
            entity.Property(e => e.UntaxedAmountCurrency).HasColumnName("untaxed_amount_currency");
            entity.Property(e => e.VendorId).HasColumnName("vendor_id");
            entity.Property(e => e.TotalAmountCompany).HasColumnName("total_amount_company");
            entity.Property(e => e.UnitAmount).HasColumnName("unit_amount");
            entity.Property(e => e.UntaxedAmount).HasColumnName("untaxed_amount");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Account).WithMany(p => p.HrExpense)
            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_account_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.HrExpense)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_expense_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrExpenseCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.HrExpense)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_expense_currency_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.HrExpense)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_expense_employee_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrExpense)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_message_main_attachment_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.HrExpense)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_expense_product_id_fkey");

            // entity.HasOne(d => d.ProductUom).WithMany(p => p.HrExpense)
            entity.HasOne(d => d.ProductUom).WithMany()
                .HasForeignKey(d => d.ProductUomId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_product_uom_id_fkey");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.HrExpense)
                .HasForeignKey(d => d.SaleOrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sale_order_id_fkey");

            entity.HasOne(d => d.Sheet).WithMany(p => p.HrExpense)
                .HasForeignKey(d => d.SheetId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_sheet_id_fkey");

            entity.HasOne(d => d.Vendor).WithMany()
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_vendor_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrExpenseWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_write_uid_fkey");

            // entity.HasMany(d => d.Tax).WithMany(p => p.Expense)
            entity.HasMany(d => d.Tax).WithMany(p => p.Expense)
                .UsingEntity<Dictionary<string, object>>(
                    "ExpenseTax",
                    r => r.HasOne<AccountTax>().WithMany()
                        .HasForeignKey("TaxId")
                        .HasConstraintName("expense_tax_tax_id_fkey"),
                    l => l.HasOne<HrExpense>().WithMany()
                        .HasForeignKey("ExpenseId")
                        .HasConstraintName("expense_tax_expense_id_fkey"),
                    j =>
                    {
                        j.HasKey("ExpenseId", "TaxId").HasName("expense_tax_pkey");
                        j.ToTable("expense_tax");
                        j.HasIndex(new[] { "TaxId", "ExpenseId" }, "expense_tax_tax_id_expense_id_idx");
                        j.IndexerProperty<Guid>("ExpenseId").HasColumnName("expense_id");
                        j.IndexerProperty<Guid>("TaxId").HasColumnName("tax_id");
                    });
            });
        }
    }
}
