using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsPlanogram(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsPlanogram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_planogram_pkey");

            entity.ToTable("dms_planogram");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.ResPartnerType).HasColumnName("res_partner_type");
            entity.Property(e => e.PlanogramImageUrl).HasColumnName("planogram_image_url");
            entity.Property(e => e.Version).HasColumnName("version");
            entity.Property(e => e.ComplianceScore).HasColumnName("compliance_score");
            entity.Property(e => e.LastCheckedDate).HasColumnName("last_checked_date");

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