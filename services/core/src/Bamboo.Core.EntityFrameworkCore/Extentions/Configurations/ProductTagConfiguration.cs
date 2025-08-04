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
        public static void ConfigureProductTag(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_tag_pkey");

                entity.ToTable("product_tag");

                entity.HasIndex(e => e.TenantId, "product_tag_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.Name }, "product_tag_name_uniq").IsUnique();

                entity.HasIndex(e => e.WebsiteId, "product_tag_website_id_index");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.RibbonId).HasColumnName("ribbon_id");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_tag_create_uid_fkey");

                entity.HasOne(d => d.Ribbon).WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.RibbonId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_tag_ribbon_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("product_tag_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_tag_write_uid_fkey");
            });
        }
    }
}