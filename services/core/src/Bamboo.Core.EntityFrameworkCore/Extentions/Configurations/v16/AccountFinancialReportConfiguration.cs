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
        public static void ConfigureAccountFinancialReport(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountFinancialReport>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_financial_report_pkey");

            entity.ToTable("account_financial_report");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountReportId).HasColumnName("account_report_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DisplayDetail).HasColumnName("display_detail");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.ReportDomain).HasColumnName("report_domain");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.Sign).HasColumnName("sign");
            entity.Property(e => e.StyleOverwrite).HasColumnName("style_overwrite");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.AccountReport).WithMany(p => p.InverseAccountReport)
                .HasForeignKey(d => d.AccountReportId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_financial_report_account_report_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountFinancialReportCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_financial_report_create_uid_fkey");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_financial_report_parent_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountFinancialReportWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_financial_report_write_uid_fkey");

            // entity.HasMany(d => d.Account).WithMany(p => p.ReportLine2)
            entity.HasMany(d => d.Account).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAccountFinancialReport",
                    r => r.HasOne<AccountAccount>().WithMany()
                        .HasForeignKey("AccountId")
                        .HasConstraintName("account_account_financial_report_account_id_fkey"),
                    l => l.HasOne<AccountFinancialReport>().WithMany()
                        .HasForeignKey("ReportLineId")
                        .HasConstraintName("account_account_financial_report_report_line_id_fkey"),
                    j =>
                    {
                        j.HasKey("ReportLineId", "AccountId").HasName("account_account_financial_report_pkey");
                        j.ToTable("account_account_financial_report");
                        j.HasIndex(new[] { "AccountId", "ReportLineId" }, "account_account_financial_report_account_id_report_line_id_idx");
                        j.IndexerProperty<Guid>("ReportLineId").HasColumnName("report_line_id");
                        j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                    });

            // entity.HasMany(d => d.AccountType).WithMany(p => p.Report)
            entity.HasMany(d => d.AccountType).WithMany(p => p.Report)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountAccountFinancialReportType",
                    r => r.HasOne<AccountAccountType>().WithMany()
                        .HasForeignKey("AccountTypeId")
                        .HasConstraintName("account_account_financial_report_type_account_type_id_fkey"),
                    l => l.HasOne<AccountFinancialReport>().WithMany()
                        .HasForeignKey("ReportId")
                        .HasConstraintName("account_account_financial_report_type_report_id_fkey"),
                    j =>
                    {
                        j.HasKey("ReportId", "AccountTypeId").HasName("account_account_financial_report_type_pkey");
                        j.ToTable("account_account_financial_report_type");
                        j.HasIndex(new[] { "AccountTypeId", "ReportId" }, "account_account_financial_report__account_type_id_report_id_idx");
                        j.IndexerProperty<Guid>("ReportId").HasColumnName("report_id");
                        j.IndexerProperty<Guid>("AccountTypeId").HasColumnName("account_type_id");
                    });
            });
        }
    }
}