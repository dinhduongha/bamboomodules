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
        public static void ConfigureHrExpenseApproveDuplicate(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrExpenseApproveDuplicate>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_expense_approve_duplicate_pkey");

            entity.ToTable("hr_expense_approve_duplicate");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrExpenseApproveDuplicateCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_approve_duplicate_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrExpenseApproveDuplicateWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_approve_duplicate_write_uid_fkey");

            // entity.HasMany(d => d.HrExpense).WithMany(p => p.HrExpenseApproveDuplicate)
            entity.HasMany(d => d.HrExpense).WithMany(p => p.HrExpenseApproveDuplicate)
                .UsingEntity<Dictionary<string, object>>(
                    "HrExpenseHrExpenseApproveDuplicateRel",
                    r => r.HasOne<HrExpense>().WithMany()
                        .HasForeignKey("HrExpenseId")
                        .HasConstraintName("hr_expense_hr_expense_approve_duplicate_rel_hr_expense_id_fkey"),
                    l => l.HasOne<HrExpenseApproveDuplicate>().WithMany()
                        .HasForeignKey("HrExpenseApproveDuplicateId")
                        .HasConstraintName("hr_expense_hr_expense_approve_hr_expense_approve_duplicate_fkey"),
                    j =>
                    {
                        j.HasKey("HrExpenseApproveDuplicateId", "HrExpenseId").HasName("hr_expense_hr_expense_approve_duplicate_rel_pkey");
                        j.ToTable("hr_expense_hr_expense_approve_duplicate_rel");
                        j.HasIndex(new[] { "HrExpenseId", "HrExpenseApproveDuplicateId" }, "hr_expense_hr_expense_approve_hr_expense_id_hr_expense_appr_idx");
                        j.IndexerProperty<Guid>("HrExpenseApproveDuplicateId").HasColumnName("hr_expense_approve_duplicate_id");
                        j.IndexerProperty<Guid>("HrExpenseId").HasColumnName("hr_expense_id");
                    });

            // entity.HasMany(d => d.HrExpenseSheet).WithMany(p => p.HrExpenseApproveDuplicate)
            entity.HasMany(d => d.HrExpenseSheet).WithMany(p => p.HrExpenseApproveDuplicate)
                .UsingEntity<Dictionary<string, object>>(
                    "HrExpenseApproveDuplicateHrExpenseSheetRel",
                    r => r.HasOne<HrExpenseSheet>().WithMany()
                        .HasForeignKey("HrExpenseSheetId")
                        .HasConstraintName("hr_expense_approve_duplicate_hr_expens_hr_expense_sheet_id_fkey"),
                    l => l.HasOne<HrExpenseApproveDuplicate>().WithMany()
                        .HasForeignKey("HrExpenseApproveDuplicateId")
                        .HasConstraintName("hr_expense_approve_duplicate__hr_expense_approve_duplicate_fkey"),
                    j =>
                    {
                        j.HasKey("HrExpenseApproveDuplicateId", "HrExpenseSheetId").HasName("hr_expense_approve_duplicate_hr_expense_sheet_rel_pkey");
                        j.ToTable("hr_expense_approve_duplicate_hr_expense_sheet_rel");
                        j.HasIndex(new[] { "HrExpenseSheetId", "HrExpenseApproveDuplicateId" }, "hr_expense_approve_duplicate__hr_expense_sheet_id_hr_expens_idx");
                        j.IndexerProperty<Guid>("HrExpenseApproveDuplicateId").HasColumnName("hr_expense_approve_duplicate_id");
                        j.IndexerProperty<Guid>("HrExpenseSheetId").HasColumnName("hr_expense_sheet_id");
                    });
            });
        }
    }
}