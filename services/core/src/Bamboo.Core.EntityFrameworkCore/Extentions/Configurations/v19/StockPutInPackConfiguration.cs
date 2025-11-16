using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockPutInPack(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockPutInPack>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_put_in_pack_pkey");

                        entity.ToTable("stock_put_in_pack");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                        entity.Property(e => e.PackageCarrierType).HasColumnName("package_carrier_type");
                        entity.Property(e => e.PackageTypeId).HasColumnName("package_type_id");
                        entity.Property(e => e.ResultPackageId).HasColumnName("result_package_id");
                        entity.Property(e => e.ShippingWeight).HasColumnName("shipping_weight");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPutInPackCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_put_in_pack_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_put_in_pack_create_uid_fkey");

                        entity.HasOne(d => d.LocationDest).WithMany(p => p.StockPutInPack)
                            .HasForeignKey(d => d.LocationDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_put_in_pack_location_dest_id_fkey");

                        entity.HasOne(d => d.PackageType).WithMany(p => p.StockPutInPack)
                            .HasForeignKey(d => d.PackageTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_put_in_pack_package_type_id_fkey");

                        entity.HasOne(d => d.ResultPackage).WithMany(p => p.StockPutInPackNavigation)
                            .HasForeignKey(d => d.ResultPackageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_put_in_pack_result_package_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPutInPackWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_put_in_pack_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_put_in_pack_write_uid_fkey");

                        // entity.HasMany(d => d.StockMoveLine).WithMany(p => p.StockPutInPack)
                        entity.HasMany(d => d.StockMoveLine).WithMany(p => p.StockPutInPack)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockMoveLineStockPutInPackRel",
                                r => r.HasOne<StockMoveLine>().WithMany()
                                    .HasForeignKey("StockMoveLineId")
                                    .HasConstraintName("stock_move_line_stock_put_in_pack_rel_stock_move_line_id_fkey"),
                                l => l.HasOne<StockPutInPack>().WithMany()
                                    .HasForeignKey("StockPutInPackId")
                                    .HasConstraintName("stock_move_line_stock_put_in_pack_rel_stock_put_in_pack_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockPutInPackId", "StockMoveLineId").HasName("stock_move_line_stock_put_in_pack_rel_pkey");
                                    j.ToTable("stock_move_line_stock_put_in_pack_rel");
                                    j.HasIndex(new[] { "StockMoveLineId", "StockPutInPackId" }, "stock_move_line_stock_put_in__stock_move_line_id_stock_put__idx");
                                    j.IndexerProperty<Guid>("StockPutInPackId").HasColumnName("stock_put_in_pack_id");
                                    j.IndexerProperty<Guid>("StockMoveLineId").HasColumnName("stock_move_line_id");
                                });

                        // entity.HasMany(d => d.StockPackage).WithMany(p => p.StockPutInPack)
                        entity.HasMany(d => d.StockPackage).WithMany(p => p.StockPutInPack)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockPackageStockPutInPackRel",
                                r => r.HasOne<StockPackage>().WithMany()
                                    .HasForeignKey("StockPackageId")
                                    .HasConstraintName("stock_package_stock_put_in_pack_rel_stock_package_id_fkey"),
                                l => l.HasOne<StockPutInPack>().WithMany()
                                    .HasForeignKey("StockPutInPackId")
                                    .HasConstraintName("stock_package_stock_put_in_pack_rel_stock_put_in_pack_id_fkey"),
                                j =>
                                {
                                    j.HasKey("StockPutInPackId", "StockPackageId").HasName("stock_package_stock_put_in_pack_rel_pkey");
                                    j.ToTable("stock_package_stock_put_in_pack_rel");
                                    j.HasIndex(new[] { "StockPackageId", "StockPutInPackId" }, "stock_package_stock_put_in_pa_stock_package_id_stock_put_in_idx");
                                    j.IndexerProperty<Guid>("StockPutInPackId").HasColumnName("stock_put_in_pack_id");
                                    j.IndexerProperty<Guid>("StockPackageId").HasColumnName("stock_package_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}