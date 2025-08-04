using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
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

                entity.HasIndex(e => e.PageId, "website_track_page_id_index");

                entity.HasIndex(e => e.ProductId, "website_track_product_id_index").HasFilter("(product_id IS NOT NULL)");

                entity.HasIndex(e => e.Url, "website_track_url_index");

                entity.HasIndex(e => e.VisitorId, "website_track_visitor_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.PageId).HasColumnName("page_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.VisitDatetime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("visit_datetime");
                entity.Property(e => e.VisitorId).HasColumnName("visitor_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");

                entity.HasOne(d => d.Page).WithMany(p => p.WebsiteTracks)
                    .HasForeignKey(d => d.PageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_track_page_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.WebsiteTracks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_track_product_id_fkey");

                entity.HasOne(d => d.Visitor).WithMany(p => p.WebsiteTracks)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_track_visitor_id_fkey");
            });
        }
    }
}