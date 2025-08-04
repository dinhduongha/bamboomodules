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
        public static void ConfigureStockPackageLevel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockPackageLevel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_package_level_pkey");

                entity.ToTable("stock_package_level");

                entity.HasIndex(e => e.TenantId, "stock_package_level_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                entity.Property(e => e.PackageId).HasColumnName("package_id");
                entity.Property(e => e.PickingId).HasColumnName("picking_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_package_level_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_package_level_create_uid_fkey");

                entity.HasOne(d => d.LocationDest).WithMany(p => p.StockPackageLevels)
                    .HasForeignKey(d => d.LocationDestId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_package_level_location_dest_id_fkey");

                entity.HasOne(d => d.Package).WithMany(p => p.StockPackageLevels)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_package_level_package_id_fkey");

                entity.HasOne(d => d.Picking).WithMany(p => p.StockPackageLevels)
                    .HasForeignKey(d => d.PickingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_package_level_picking_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_package_level_write_uid_fkey");
            });
        }
    }
}