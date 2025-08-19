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
        public static void ConfigureHrPayslipRun(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrPayslipRun>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_payslip_run_pkey");

            entity.ToTable("hr_payslip_run");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.State, "hr_payslip_run__state_index");

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
            entity.Property(e => e.CreditNote).HasColumnName("credit_note");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.JournalId).HasColumnName("journal_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrPayslipRunCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_payslip_run_create_uid_fkey");

            // entity.HasOne(d => d.Journal).WithMany(p => p.HrPayslipRun)
            entity.HasOne(d => d.Journal).WithMany()
                .HasForeignKey(d => d.JournalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("hr_payslip_run_journal_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrPayslipRunWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_payslip_run_write_uid_fkey");
            });
        }
    }
}