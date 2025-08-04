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
        public static void ConfigureCrossoveredBudgetLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrossoveredBudgetLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("crossovered_budget_lines_pkey");

                entity.ToTable("crossovered_budget_lines");

                entity.HasIndex(e => e.CrossoveredBudgetId, "crossovered_budget_lines_crossovered_budget_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AnalyticAccountId).HasColumnName("analytic_account_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CrossoveredBudgetId).HasColumnName("crossovered_budget_id");
                entity.Property(e => e.CrossoveredBudgetState).HasColumnName("crossovered_budget_state");
                entity.Property(e => e.DateFrom).HasColumnName("date_from");
                entity.Property(e => e.DateTo).HasColumnName("date_to");
                entity.Property(e => e.GeneralBudgetId).HasColumnName("general_budget_id");
                entity.Property(e => e.PaidDate).HasColumnName("paid_date");
                entity.Property(e => e.PlannedAmount).HasColumnName("planned_amount");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AnalyticAccount).WithMany(p => p.CrossoveredBudgetLines)
                    .HasForeignKey(d => d.AnalyticAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crossovered_budget_lines_analytic_account_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crossovered_budget_lines_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crossovered_budget_lines_create_uid_fkey");

                entity.HasOne(d => d.CrossoveredBudget).WithMany(p => p.CrossoveredBudgetLines)
                    .HasForeignKey(d => d.CrossoveredBudgetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("crossovered_budget_lines_crossovered_budget_id_fkey");

                entity.HasOne(d => d.GeneralBudget).WithMany(p => p.CrossoveredBudgetLines)
                    .HasForeignKey(d => d.GeneralBudgetId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crossovered_budget_lines_general_budget_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crossovered_budget_lines_write_uid_fkey");
            });
        }
    }
}