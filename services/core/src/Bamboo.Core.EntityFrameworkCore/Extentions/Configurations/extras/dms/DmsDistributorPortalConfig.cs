using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsDistributorPortalConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsDistributorPortalConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_distributor_portal_config_pkey");

            entity.ToTable("dms_distributor_portal_config");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PortalAccessLevel).HasColumnName("portal_access_level");
            entity.Property(e => e.DashboardWidgets);
            entity.Property(e => e.AllowedFeatures);
            entity.Property(e => e.LastLoginDate).HasColumnName("last_login_date");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.ResPartner)
                .WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_distributor_portal_config_res_partner_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}