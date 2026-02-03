using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsOutletInventoryCheck(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsOutletInventoryCheck>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_outlet_inventory_check_pkey");

            entity.ToTable("dms_outlet_inventory_check");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.OutletVisitId).HasColumnName("outlet_visit_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CheckedQty).HasColumnName("checked_qty");
            entity.Property(e => e.SystemQty).HasColumnName("system_qty");
            entity.Property(e => e.VarianceQty).HasColumnName("variance_qty");
            entity.Property(e => e.Photos);

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
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_outlet_inventory_check_outlet_visit_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}