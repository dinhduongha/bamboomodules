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
        public static void ConfigureStockPackageType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockPackageType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_package_type_pkey");

                entity.ToTable("stock_package_type");

                entity.HasIndex(e => new { e.TenantId, e.Barcode }, "stock_package_type_barcode_uniq").IsUnique();

                entity.HasIndex(e => e.TenantId, "stock_package_type_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Barcode).HasColumnName("barcode");
                entity.Property(e => e.BaseWeight).HasColumnName("base_weight");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Height).HasColumnName("height");
                entity.Property(e => e.MaxWeight).HasColumnName("max_weight");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PackagingLength).HasColumnName("packaging_length");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.Width).HasColumnName("width");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_package_type_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_package_type_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_package_type_write_uid_fkey");
            });
        }
    }
}