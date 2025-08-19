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
        public static void ConfigureWebsiteRewrite(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsiteRewrite>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_rewrite_pkey");

            entity.ToTable("website_rewrite");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.UrlFrom, "website_rewrite__url_from_index");

            entity.HasIndex(e => e.WebsiteId, "website_rewrite__website_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.RedirectType).HasColumnName("redirect_type");
            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.UrlFrom).HasColumnName("url_from");
            entity.Property(e => e.UrlTo).HasColumnName("url_to");
            entity.Property(e => e.WebsiteId).HasColumnName("website_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteRewriteCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("website_rewrite_create_uid_fkey");

            entity.HasOne(d => d.Route).WithMany(p => p.WebsiteRewrite)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("website_rewrite_route_id_fkey");

            // entity.HasOne(d => d.Website).WithMany(p => p.WebsiteRewrite)
            entity.HasOne(d => d.Website).WithMany()
                .HasForeignKey(d => d.WebsiteId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("website_rewrite_website_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteRewriteWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("website_rewrite_write_uid_fkey");
            });
        }
    }
}
