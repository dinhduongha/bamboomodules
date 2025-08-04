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
        public static void ConfigureProductImage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_image_pkey");

                entity.ToTable("product_image");

                entity.HasIndex(e => e.TenantId, "product_image_company_id_index");

                entity.HasIndex(e => e.ProductTmplId, "product_image_product_tmpl_id_index");

                entity.HasIndex(e => e.ProductVariantId, "product_image_product_variant_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CanImage1024BeZoomed).HasColumnName("can_image_1024_be_zoomed");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                entity.Property(e => e.ProductVariantId).HasColumnName("product_variant_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.VideoUrl).HasColumnName("video_url");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_image_create_uid_fkey");

                entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductTmplId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_image_product_tmpl_id_fkey");

                entity.HasOne(d => d.ProductVariant).WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductVariantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_image_product_variant_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_image_write_uid_fkey");
            });
        }
    }
}