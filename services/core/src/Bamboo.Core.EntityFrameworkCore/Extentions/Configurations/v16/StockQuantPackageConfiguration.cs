using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockQuantPackage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockQuantPackage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_quant_package_pkey");

                        entity.ToTable("stock_quant_package");

                        entity.HasIndex(e => e.TenantId, "stock_quant_package__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LocationId, "stock_quant_package__location_id_index");

                        entity.HasIndex(e => e.Name, "stock_quant_package__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.PackageTypeId, "stock_quant_package__package_type_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PackDate).HasColumnName("pack_date");
                        entity.Property(e => e.PackageTypeId).HasColumnName("package_type_id");
                        entity.Property(e => e.PackageUse).HasColumnName("package_use");
                        entity.Property(e => e.ShippingWeight).HasColumnName("shipping_weight");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockQuantPackage) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_quant_package_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_package_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockQuantPackageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_quant_package_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_package_create_uid_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockQuantPackage)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_package_location_id_fkey");

                        entity.HasOne(d => d.PackageType).WithMany(p => p.StockQuantPackage)
                            .HasForeignKey(d => d.PackageTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_package_package_type_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockQuantPackageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_quant_package_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_quant_package_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}