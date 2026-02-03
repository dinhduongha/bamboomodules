using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsShopDisplayAudit(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsShopDisplayAudit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_shop_display_audit_pkey");

            entity.ToTable("dms_shop_display_audit");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.OutletVisitId).HasColumnName("outlet_visit_id");
            entity.Property(e => e.DisplayScore).HasColumnName("display_score");
            entity.Property(e => e.PhotosBefore);
            entity.Property(e => e.PhotosAfter);
            entity.Property(e => e.CompetitorNotes).HasColumnName("competitor_notes");

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
                .HasConstraintName("dms_shop_display_audit_outlet_visit_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}
