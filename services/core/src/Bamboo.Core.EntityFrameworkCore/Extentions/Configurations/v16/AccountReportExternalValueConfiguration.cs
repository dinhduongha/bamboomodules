using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountReportExternalValue(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountReportExternalValue>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_report_external_value_pkey");

                        entity.ToTable("account_report_external_value");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CarryoverOriginExpressionLabel).HasColumnName("carryover_origin_expression_label");
                        entity.Property(e => e.CarryoverOriginReportLineId).HasColumnName("carryover_origin_report_line_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.ForeignVatFiscalPositionId).HasColumnName("foreign_vat_fiscal_position_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.TargetReportExpressionId).HasColumnName("target_report_expression_id");
                        entity.Property(e => e.TextValue).HasColumnName("text_value");
                        entity.Property(e => e.Value).HasColumnName("value");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.CarryoverOriginReportLine).WithMany(p => p.AccountReportExternalValue)
                            .HasForeignKey(d => d.CarryoverOriginReportLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_report_external_value_carryover_origin_report_line_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountReportExternalValue) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_report_external_value_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_report_external_value_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountReportExternalValueCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_report_external_value_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_report_external_value_create_uid_fkey");

                        entity.HasOne(d => d.ForeignVatFiscalPosition).WithMany(p => p.AccountReportExternalValue)
                            .HasForeignKey(d => d.ForeignVatFiscalPositionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_report_external_value_foreign_vat_fiscal_position__fkey");

                        entity.HasOne(d => d.TargetReportExpression).WithMany(p => p.AccountReportExternalValue)
                            .HasForeignKey(d => d.TargetReportExpressionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_report_external_value_target_report_expression_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountReportExternalValueWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_report_external_value_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_report_external_value_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}