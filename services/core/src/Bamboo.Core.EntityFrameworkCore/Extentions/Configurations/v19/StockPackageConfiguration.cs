using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockPackage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockPackage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_package_pkey");

                        entity.ToTable("stock_package");

                        entity.HasIndex(e => e.TenantId, "stock_package__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LocationId, "stock_package__location_id_index");

                        entity.HasIndex(e => e.Name, "stock_package__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.PackageDestId, "stock_package__package_dest_id_index").HasFilter("(package_dest_id IS NOT NULL)");

                        entity.HasIndex(e => e.PackageTypeId, "stock_package__package_type_id_index");

                        entity.HasIndex(e => e.ParentPackageId, "stock_package__parent_package_id_index").HasFilter("(parent_package_id IS NOT NULL)");

                        entity.HasIndex(e => e.ParentPath, "stock_package__parent_path_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                        entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PackDate).HasColumnName("pack_date");
                        entity.Property(e => e.PackageDestId).HasColumnName("package_dest_id");
                        entity.Property(e => e.PackageTypeId).HasColumnName("package_type_id");
                        entity.Property(e => e.ParentPackageId).HasColumnName("parent_package_id");
                        entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                        entity.Property(e => e.ShippingWeight).HasColumnName("shipping_weight");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockPackage) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPackageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_create_uid_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockPackage)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_location_id_fkey");

                        entity.HasOne(d => d.PackageDest).WithMany(p => p.InversePackageDest)
                            .HasForeignKey(d => d.PackageDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_package_dest_id_fkey");

                        entity.HasOne(d => d.PackageType).WithMany(p => p.StockPackage)
                            .HasForeignKey(d => d.PackageTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_package_type_id_fkey");

                        entity.HasOne(d => d.ParentPackage).WithMany(p => p.InverseParentPackage)
                            .HasForeignKey(d => d.ParentPackageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_parent_package_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPackageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}