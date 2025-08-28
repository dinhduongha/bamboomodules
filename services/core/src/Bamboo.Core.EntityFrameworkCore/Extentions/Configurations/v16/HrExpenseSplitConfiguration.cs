using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrExpenseSplit(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrExpenseSplit>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_expense_split_pkey");

                        entity.ToTable("hr_expense_split");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AnalyticDistribution)
                            .HasColumnType("jsonb")
                            .HasColumnName("analytic_distribution");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ProductHasCost).HasColumnName("product_has_cost");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                        entity.Property(e => e.TotalAmountCurrency).HasColumnName("total_amount_currency");
                        entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrExpenseSplit) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_expense_split_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_expense_split_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrExpenseSplitCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_expense_split_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_expense_split_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.HrExpenseSplit) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_expense_split_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_expense_split_currency_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrExpenseSplit)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_expense_split_employee_id_fkey");

                        entity.HasOne(d => d.Expense).WithMany(p => p.HrExpenseSplit)
                            .HasForeignKey(d => d.ExpenseId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_expense_split_expense_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.HrExpenseSplit) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("hr_expense_split_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_expense_split_product_id_fkey");

                        entity.HasOne(d => d.SaleOrder).WithMany(p => p.HrExpenseSplit)
                            .HasForeignKey(d => d.SaleOrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_expense_split_sale_order_id_fkey");

                        entity.HasOne(d => d.Wizard).WithMany(p => p.HrExpenseSplit)
                            .HasForeignKey(d => d.WizardId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_expense_split_wizard_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrExpenseSplitWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_expense_split_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_expense_split_write_uid_fkey");

                        // entity.HasMany(d => d.AccountTax).WithMany(p => p.HrExpenseSplit)
                        entity.HasMany(d => d.AccountTax).WithMany(p => p.HrExpenseSplit)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountTaxHrExpenseSplitRel",
                                r => r.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("AccountTaxId")
                                    .HasConstraintName("account_tax_hr_expense_split_rel_account_tax_id_fkey"),
                                l => l.HasOne<HrExpenseSplit>().WithMany()
                                    .HasForeignKey("HrExpenseSplitId")
                                    .HasConstraintName("account_tax_hr_expense_split_rel_hr_expense_split_id_fkey"),
                                j =>
                                {
                                    j.HasKey("HrExpenseSplitId", "AccountTaxId").HasName("account_tax_hr_expense_split_rel_pkey");
                                    j.ToTable("account_tax_hr_expense_split_rel");
                                    j.HasIndex(new[] { "AccountTaxId", "HrExpenseSplitId" }, "account_tax_hr_expense_split__account_tax_id_hr_expense_spl_idx");
                                    j.IndexerProperty<Guid>("HrExpenseSplitId").HasColumnName("hr_expense_split_id");
                                    j.IndexerProperty<Guid>("AccountTaxId").HasColumnName("account_tax_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}