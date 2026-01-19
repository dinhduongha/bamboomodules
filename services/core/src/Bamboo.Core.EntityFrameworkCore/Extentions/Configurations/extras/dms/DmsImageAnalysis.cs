using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsImageAnalysis(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsImageAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_image_analysis_pkey");

            entity.ToTable("dms_image_analysis");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.OutletVisitId).HasColumnName("outlet_visit_id");
            entity.Property(e => e.PlanogramCheckId).HasColumnName("planogram_check_id");
            entity.Property(e => e.AnalyzedImageUrl).HasColumnName("analyzed_image_url");
            entity.Property(e => e.DetectedProductsJson).HasColumnName("detected_products_json");
            entity.Property(e => e.ComplianceScore).HasColumnName("compliance_score");
            entity.Property(e => e.IssuesJson).HasColumnName("issues_json");
            entity.Property(e => e.AIProvider).HasColumnName("ai_provider");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.OutletVisit)
                .WithMany()
                .HasForeignKey(d => d.OutletVisitId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("dms_image_analysis_outlet_visit_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}