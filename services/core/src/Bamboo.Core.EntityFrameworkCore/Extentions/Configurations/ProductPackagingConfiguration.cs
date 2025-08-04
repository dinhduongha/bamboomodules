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
        public static void ConfigureProductPackaging(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPackaging>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_packaging_pkey");

                entity.ToTable("product_packaging");

                entity.HasIndex(e => new { e.TenantId, e.Barcode }, "product_packaging_barcode_uniq").IsUnique();

                entity.HasIndex(e => e.TenantId, "product_packaging_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Barcode).HasColumnName("barcode");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PackageTypeId).HasColumnName("package_type_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Purchase).HasColumnName("purchase");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.Sales).HasColumnName("sales");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_packaging_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_packaging_create_uid_fkey");

                entity.HasOne(d => d.PackageType).WithMany(p => p.ProductPackagings)
                    .HasForeignKey(d => d.PackageTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_packaging_package_type_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductPackagings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_packaging_product_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_packaging_write_uid_fkey");
            });
        }
    }
}