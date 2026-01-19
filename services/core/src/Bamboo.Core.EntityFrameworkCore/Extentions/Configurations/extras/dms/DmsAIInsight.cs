using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsAIInsight(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsAIInsight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_ai_insight_pkey");

            entity.ToTable("dms_ai_insight");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.OutletVisitId).HasColumnName("outlet_visit_id");
            entity.Property(e => e.AchievementLogId).HasColumnName("achievement_log_id");
            entity.Property(e => e.DemandForecastId).HasColumnName("demand_forecast_id");
            entity.Property(e => e.InsightType).HasColumnName("insight_type");
            entity.Property(e => e.InsightText).HasColumnName("insight_text");
            entity.Property(e => e.ConfidenceScore).HasColumnName("confidence_score");
            entity.Property(e => e.GeneratedAt).HasColumnName("generated_at");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}