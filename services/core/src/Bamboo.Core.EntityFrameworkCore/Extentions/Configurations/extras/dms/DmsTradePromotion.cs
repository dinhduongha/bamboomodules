using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsTradePromotion(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsTradePromotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_trade_promotion_pkey");

            entity.ToTable("dms_trade_promotion");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.PromotionCode).HasColumnName("promotion_code");
            entity.Property(e => e.BudgetAmount).HasColumnName("budget_amount");
            entity.Property(e => e.ActualSpend).HasColumnName("actual_spend");
            entity.Property(e => e.ROI).HasColumnName("roi");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.POSMRequired).HasColumnName("posm_required");

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