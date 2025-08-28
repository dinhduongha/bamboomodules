using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountReportColumn(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountReportColumn>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_report_column_pkey");

                        entity.ToTable("account_report_column");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BlankIfZero).HasColumnName("blank_if_zero");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CustomAuditActionId).HasColumnName("custom_audit_action_id");
                        entity.Property(e => e.ExpressionLabel).HasColumnName("expression_label");
                        entity.Property(e => e.FigureType).HasColumnName("figure_type");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.ReportId).HasColumnName("report_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Sortable).HasColumnName("sortable");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountReportColumnCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_report_column_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_report_column_create_uid_fkey");

                        entity.HasOne(d => d.CustomAuditAction).WithMany(p => p.AccountReportColumn)
                            .HasForeignKey(d => d.CustomAuditActionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_report_column_custom_audit_action_id_fkey");

                        entity.HasOne(d => d.Report).WithMany(p => p.AccountReportColumn)
                            .HasForeignKey(d => d.ReportId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_report_column_report_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountReportColumnWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_report_column_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_report_column_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}