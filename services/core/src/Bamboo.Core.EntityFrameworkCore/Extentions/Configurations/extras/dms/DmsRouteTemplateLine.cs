using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsRouteTemplateLine(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsRouteTemplateLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_route_template_line_pkey");

            entity.ToTable("dms_route_template_line");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);
            entity.HasIndex(e => e.TemplateId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.ResPartnerId).HasColumnName("res_partner_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.EstimatedTimeMinutes).HasColumnName("estimated_time_minutes");
            entity.Property(e => e.EstimatedDistanceKm).HasColumnName("estimated_distance_km");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Template)
                .WithMany(t => t.TemplateLines)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_route_template_line_template_id_fkey");

            entity.HasOne(d => d.ResPartner)
                .WithMany()
                .HasForeignKey(d => d.ResPartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_route_template_line_res_partner_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}