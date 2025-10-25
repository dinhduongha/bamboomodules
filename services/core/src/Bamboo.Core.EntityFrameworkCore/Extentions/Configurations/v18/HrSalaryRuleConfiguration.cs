using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrSalaryRule(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrSalaryRule>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_salary_rule_pkey");

                        entity.ToTable("hr_salary_rule");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AmountSelect, "hr_salary_rule__amount_select_index");

                        entity.HasIndex(e => e.ParentRuleId, "hr_salary_rule__parent_rule_id_index");

                        entity.HasIndex(e => e.Sequence, "hr_salary_rule__sequence_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountCredit).HasColumnName("account_credit");
                        entity.Property(e => e.AccountDebit).HasColumnName("account_debit");
                        entity.Property(e => e.AccountTaxId).HasColumnName("account_tax_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AmountFix).HasColumnName("amount_fix");
                        entity.Property(e => e.AmountPercentage).HasColumnName("amount_percentage");
                        entity.Property(e => e.AmountPercentageBase).HasColumnName("amount_percentage_base");
                        entity.Property(e => e.AmountPythonCompute).HasColumnName("amount_python_compute");
                        entity.Property(e => e.AmountSelect).HasColumnName("amount_select");
                        entity.Property(e => e.AnalyticAccountId).HasColumnName("analytic_account_id");
                        entity.Property(e => e.AppearsOnPayslip).HasColumnName("appears_on_payslip");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");
                        entity.Property(e => e.Code).HasColumnName("code");

                        entity.Property(e => e.ConditionPython).HasColumnName("condition_python");
                        entity.Property(e => e.ConditionRange).HasColumnName("condition_range");
                        entity.Property(e => e.ConditionRangeMax).HasColumnName("condition_range_max");
                        entity.Property(e => e.ConditionRangeMin).HasColumnName("condition_range_min");
                        entity.Property(e => e.ConditionSelect).HasColumnName("condition_select");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.ParentRuleId).HasColumnName("parent_rule_id");
                        entity.Property(e => e.Quantity).HasColumnName("quantity");
                        entity.Property(e => e.RegisterId).HasColumnName("register_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.AccountCreditNavigation).WithMany(p => p.HrSalaryRuleAccountCreditNavigation) .HasForeignKey(d => d.AccountCredit) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_salary_rule_account_credit_fkey");
                        entity.HasOne(d => d.AccountCreditNavigation).WithMany()
                            .HasForeignKey(d => d.AccountCredit)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_account_credit_fkey");

                        // entity.HasOne(d => d.AccountDebitNavigation).WithMany(p => p.HrSalaryRuleAccountDebitNavigation) .HasForeignKey(d => d.AccountDebit) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_salary_rule_account_debit_fkey");
                        entity.HasOne(d => d.AccountDebitNavigation).WithMany()
                            .HasForeignKey(d => d.AccountDebit)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_account_debit_fkey");

                        entity.HasOne(d => d.AccountTax).WithMany(p => p.HrSalaryRule)
                            .HasForeignKey(d => d.AccountTaxId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_account_tax_id_fkey");

                        entity.HasOne(d => d.AnalyticAccount).WithMany(p => p.HrSalaryRule)
                            .HasForeignKey(d => d.AnalyticAccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_analytic_account_id_fkey");

                        entity.HasOne(d => d.Category).WithMany(p => p.HrSalaryRule)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_salary_rule_category_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrSalaryRule) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_salary_rule_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrSalaryRuleCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_salary_rule_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_create_uid_fkey");

                        entity.HasOne(d => d.ParentRule).WithMany(p => p.InverseParentRule)
                            .HasForeignKey(d => d.ParentRuleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_parent_rule_id_fkey");

                        entity.HasOne(d => d.Register).WithMany(p => p.HrSalaryRule)
                            .HasForeignKey(d => d.RegisterId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_register_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrSalaryRuleWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_salary_rule_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_salary_rule_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}