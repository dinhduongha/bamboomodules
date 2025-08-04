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
        public static void ConfigureWebsiteSnippetFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebsiteSnippetFilter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("website_snippet_filter_pkey");

                entity.ToTable("website_snippet_filter");

                entity.HasIndex(e => e.IsPublished, "website_snippet_filter_is_published_index");

                entity.HasIndex(e => e.WebsiteId, "website_snippet_filter_website_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ActionServerId).HasColumnName("action_server_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.FieldNames).HasColumnName("field_names");
                entity.Property(e => e.FilterId).HasColumnName("filter_id");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.Limit).HasColumnName("limit");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ProductCrossSelling).HasColumnName("product_cross_selling");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.ActionServer).WithMany(p => p.WebsiteSnippetFilters)
                    .HasForeignKey(d => d.ActionServerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_snippet_filter_action_server_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_snippet_filter_create_uid_fkey");

                entity.HasOne(d => d.Filter).WithMany(p => p.WebsiteSnippetFilters)
                    .HasForeignKey(d => d.FilterId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_snippet_filter_filter_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.WebsiteSnippetFilters)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_snippet_filter_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_snippet_filter_write_uid_fkey");
            });
        }
    }
}