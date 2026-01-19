using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsAdvancedAnalytics(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsAdvancedAnalytics>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_advanced_analytics_pkey");

            entity.ToTable("dms_advanced_analytics");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.BIReportConfigId).HasColumnName("bi_report_config_id");
            entity.Property(e => e.SalesKPIId).HasColumnName("sales_kpi_id");
            entity.Property(e => e.MetricType).HasColumnName("metric_type");
            entity.Property(e => e.PredictedValue).HasColumnName("predicted_value");
            entity.Property(e => e.InsightText).HasColumnName("insight_text");
            entity.Property(e => e.ModelVersion).HasColumnName("model_version");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.BIReportConfig)
                .WithMany()
                .HasForeignKey(d => d.BIReportConfigId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("dms_advanced_analytics_bi_report_config_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}