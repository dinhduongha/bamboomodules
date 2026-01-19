using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsRouteTemplate(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsRouteTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_route_template_pkey");

            entity.ToTable("dms_route_template");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);
            entity.HasIndex(e => e.TemplateCode).IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.TemplateCode).HasColumnName("template_code");
            entity.Property(e => e.TemplateName).HasColumnName("template_name");
            entity.Property(e => e.Frequency).HasColumnName("frequency");
            entity.Property(e => e.DayOfWeek).HasColumnName("day_of_week");
            entity.Property(e => e.WeekOfMonth).HasColumnName("week_of_month");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Description).HasColumnName("description");

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