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
        public static void ConfigureHrExpenseSplitWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrExpenseSplitWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_expense_split_wizard_pkey");

                entity.ToTable("hr_expense_split_wizard");

                entity.HasIndex(e => e.TenantId, "hr_expense_split_wizard_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_split_wizard_create_uid_fkey");

                entity.HasOne(d => d.Expense).WithMany(p => p.HrExpenseSplitWizards)
                    .HasForeignKey(d => d.ExpenseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("hr_expense_split_wizard_expense_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_split_wizard_write_uid_fkey");
            });
        }
    }
}