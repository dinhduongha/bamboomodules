using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockPackageDestination(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockPackageDestination>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_package_destination_pkey");

                        entity.ToTable("stock_package_destination");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                        entity.Property(e => e.PickingId).HasColumnName("picking_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPackageDestinationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_destination_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_destination_create_uid_fkey");

                        entity.HasOne(d => d.LocationDest).WithMany(p => p.StockPackageDestination)
                            .HasForeignKey(d => d.LocationDestId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_package_destination_location_dest_id_fkey");

                        entity.HasOne(d => d.Picking).WithMany(p => p.StockPackageDestination)
                            .HasForeignKey(d => d.PickingId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_package_destination_picking_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPackageDestinationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_destination_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_destination_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}