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
        public static void ConfigureHrExpenseRefuseWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrExpenseRefuseWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_expense_refuse_wizard_pkey");

            entity.ToTable("hr_expense_refuse_wizard");

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
            entity.Property(e => e.HrExpenseSheetId).HasColumnName("hr_expense_sheet_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrExpenseRefuseWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_refuse_wizard_create_uid_fkey");

            //entity.HasOne(d => d.HrExpenseSheet).WithMany(p => p.HrExpenseRefuseWizard)
            entity.HasOne(d => d.HrExpenseSheet).WithMany()
                .HasForeignKey(d => d.HrExpenseSheetId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_refuse_wizard_hr_expense_sheet_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrExpenseRefuseWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_expense_refuse_wizard_write_uid_fkey");

            // entity.HasMany(d => d.HrExpenseSheet).WithMany(p => p.HrExpenseRefuseWizard)
            entity.HasMany(d => d.HrExpenseSheets).WithMany(p => p.HrExpenseRefuseWizards)
                .UsingEntity<Dictionary<string, object>>(
                    "HrExpenseRefuseWizardHrExpenseSheetRel",
                    r => r.HasOne<HrExpenseSheet>().WithMany()
                        .HasForeignKey("HrExpenseSheetId")
                        .HasConstraintName("hr_expense_refuse_wizard_hr_expense_sh_hr_expense_sheet_id_fkey"),
                    l => l.HasOne<HrExpenseRefuseWizard>().WithMany()
                        .HasForeignKey("HrExpenseRefuseWizardId")
                        .HasConstraintName("hr_expense_refuse_wizard_hr_ex_hr_expense_refuse_wizard_id_fkey"),
                    j =>
                    {
                        j.HasKey("HrExpenseRefuseWizardId", "HrExpenseSheetId").HasName("hr_expense_refuse_wizard_hr_expense_sheet_rel_pkey");
                        j.ToTable("hr_expense_refuse_wizard_hr_expense_sheet_rel");
                        j.HasIndex(new[] { "HrExpenseSheetId", "HrExpenseRefuseWizardId" }, "hr_expense_refuse_wizard_hr_e_hr_expense_sheet_id_hr_expens_idx");
                        j.IndexerProperty<Guid>("HrExpenseRefuseWizardId").HasColumnName("hr_expense_refuse_wizard_id");
                        j.IndexerProperty<Guid>("HrExpenseSheetId").HasColumnName("hr_expense_sheet_id");
                    });
            
            // v16-Compat
            // entity.HasMany(d => d.HrExpense).WithMany(p => p.HrExpenseRefuseWizard)
            entity.HasMany(d => d.HrExpense).WithMany(p => p.HrExpenseRefuseWizard)
                .UsingEntity<Dictionary<string, object>>(
                    "HrExpenseHrExpenseRefuseWizardRel",
                    r => r.HasOne<HrExpense>().WithMany()
                        .HasForeignKey("HrExpenseId")
                        .HasConstraintName("hr_expense_hr_expense_refuse_wizard_rel_hr_expense_id_fkey"),
                    l => l.HasOne<HrExpenseRefuseWizard>().WithMany()
                        .HasForeignKey("HrExpenseRefuseWizardId")
                        .HasConstraintName("hr_expense_hr_expense_refuse_w_hr_expense_refuse_wizard_id_fkey"),
                    j =>
                    {
                        j.HasKey("HrExpenseRefuseWizardId", "HrExpenseId").HasName("hr_expense_hr_expense_refuse_wizard_rel_pkey");
                        j.ToTable("hr_expense_hr_expense_refuse_wizard_rel");
                        j.HasIndex(new[] { "HrExpenseId", "HrExpenseRefuseWizardId" }, "hr_expense_hr_expense_refuse__hr_expense_id_hr_expense_refu_idx");
                        j.IndexerProperty<Guid>("HrExpenseRefuseWizardId").HasColumnName("hr_expense_refuse_wizard_id");
                        j.IndexerProperty<Guid>("HrExpenseId").HasColumnName("hr_expense_id");
                    });
            });
        }
    }
}
