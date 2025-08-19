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
        public static void ConfigureWebsiteTrack(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsiteTrack>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_track_pkey");

            entity.ToTable("website_track");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.PageId, "website_track__page_id_index");

            entity.HasIndex(e => e.ProductId, "website_track__product_id_index").HasFilter("(product_id IS NOT NULL)");

            entity.HasIndex(e => e.Url, "website_track__url_index");

            entity.HasIndex(e => e.VisitorId, "website_track__visitor_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.PageId).HasColumnName("page_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Url).HasColumnName("url");
            entity.Property(e => e.VisitDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("visit_datetime");
            entity.Property(e => e.VisitorId).HasColumnName("visitor_id");

            entity.HasOne(d => d.Page).WithMany(p => p.WebsiteTrack)
                .HasForeignKey(d => d.PageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("website_track_page_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.WebsiteTrack)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("website_track_product_id_fkey");

            entity.HasOne(d => d.Visitor).WithMany(p => p.WebsiteTrack)
                .HasForeignKey(d => d.VisitorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("website_track_visitor_id_fkey");
            });
        }
    }
}
