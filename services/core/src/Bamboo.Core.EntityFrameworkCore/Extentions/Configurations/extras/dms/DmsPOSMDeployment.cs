using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsPOSMDeployment(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsPOSMDeployment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_posm_deployment_pkey");

            entity.ToTable("dms_posm_deployment");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.TradePromotionId).HasColumnName("trade_promotion_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.DeploymentDate).HasColumnName("deployment_date");
            entity.Property(e => e.PhotosBefore);
            entity.Property(e => e.PhotosAfter);
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Cost).HasColumnName("cost");

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
                .HasConstraintName("dms_posm_deployment_res_partner_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}