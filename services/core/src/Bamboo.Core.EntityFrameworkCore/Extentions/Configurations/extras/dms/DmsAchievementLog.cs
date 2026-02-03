using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsAchievementLog(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsAchievementLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_achievement_log_pkey");

            entity.ToTable("dms_achievement_log");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);
            entity.HasIndex(e => e.TeamId);

            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.SalesToday).HasColumnName("sales_today");
            entity.Property(e => e.VisitsToday).HasColumnName("visits_today");
            entity.Property(e => e.CoveragePercentToday).HasColumnName("coverage_percent_today");
            entity.Property(e => e.OrdersCount).HasColumnName("orders_count");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Team).WithMany().HasForeignKey(d => d.TeamId).OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_achievement_log_user_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}