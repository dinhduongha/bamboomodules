using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureSpreadsheetDashboardShare(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SpreadsheetDashboardShare>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("spreadsheet_dashboard_share_pkey");

            entity.ToTable("spreadsheet_dashboard_share");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccessToken).HasColumnName("access_token");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DashboardId).HasColumnName("dashboard_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SpreadsheetDashboardShareCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("spreadsheet_dashboard_share_create_uid_fkey");

            entity.HasOne(d => d.Dashboard).WithMany(p => p.SpreadsheetDashboardShare)
                .HasForeignKey(d => d.DashboardId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("spreadsheet_dashboard_share_dashboard_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SpreadsheetDashboardShareWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("spreadsheet_dashboard_share_write_uid_fkey");
            });
        }
    }
}