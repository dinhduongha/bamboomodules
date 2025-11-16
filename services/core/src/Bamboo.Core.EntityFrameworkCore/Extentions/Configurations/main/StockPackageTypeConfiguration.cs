using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId, "stock_package_type__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Barcode, "stock_package_type_barcode_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Barcode).HasColumnName("barcode");
                        entity.Property(e => e.BaseWeight).HasColumnName("base_weight");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Height).HasColumnName("height");
                        entity.Property(e => e.MaxWeight).HasColumnName("max_weight");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PackageCarrierType).HasColumnName("package_carrier_type");
                        entity.Property(e => e.PackageUse).HasColumnName("package_use");
                        entity.Property(e => e.PackagingLength).HasColumnName("packaging_length");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.SequenceId).HasColumnName("sequence_id");
                        entity.Property(e => e.ShipperPackageCode).HasColumnName("shipper_package_code");
                        entity.Property(e => e.Width).HasColumnName("width");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockPackageType) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_type_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_type_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPackageTypeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_type_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_type_create_uid_fkey");

                        entity.HasOne(d => d.SequenceNavigation).WithMany(p => p.StockPackageType)
                            .HasForeignKey(d => d.SequenceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_type_sequence_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPackageTypeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_type_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_type_write_uid_fkey");

                        // entity.HasMany(d => d.StockRoute).WithMany(p => p.StockPackageType)
                        entity.HasMany(d => d.StockRoute).WithMany(p => p.StockPackageType)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockPackageTypeStockRouteRel",
                                r => r.HasOne<StockRoute>().WithMany()
                                    .HasForeignKey("StockRouteId")
                                    .HasConstraintName("stock_package_type_stock_route_rel_stock_route_id_fkey"),
                                l => l.HasOne<StockPackageType>().WithMany()
                                    .HasForeignKey("StockPackageTypeId")
                                    .HasConstraintName("stock_package_type_stock_route_rel_stock_package_type_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockPackageTypeId", "StockRouteId").HasName("stock_package_type_stock_route_rel_pkey");
                                    j.ToTable("stock_package_type_stock_route_rel");
                                    j.HasIndex(new[] { "StockRouteId", "StockPackageTypeId" }, "stock_package_type_stock_rout_stock_route_id_stock_package__idx");
                                    j.IndexerProperty<Guid>("StockPackageTypeId").HasColumnName("stock_package_type_id");
                                    j.IndexerProperty<Guid>("StockRouteId").HasColumnName("stock_route_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}