using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsPromotionApplication(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsPromotionApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_promotion_application_pkey");

            entity.ToTable("dms_promotion_application");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
            entity.Property(e => e.ProvisionOrderId).HasColumnName("provision_order_id");
            entity.Property(e => e.PromotionSchemeId).HasColumnName("promotion_scheme_id");
            entity.Property(e => e.AppliedDiscountAmount).HasColumnName("applied_discount_amount");
            entity.Property(e => e.FreeItemsJson).HasColumnName("free_items_json");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.PromotionScheme)
                .WithMany()
                .HasForeignKey(d => d.PromotionSchemeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_promotion_application_promotion_scheme_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}