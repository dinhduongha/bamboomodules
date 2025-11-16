using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockPackageHistory(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockPackageHistory>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_package_history_pkey");

                        entity.ToTable("stock_package_history");

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
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.OutermostDestId).HasColumnName("outermost_dest_id");
                        entity.Property(e => e.PackageId).HasColumnName("package_id");
                        entity.Property(e => e.PackageName).HasColumnName("package_name");
                        entity.Property(e => e.ParentDestId).HasColumnName("parent_dest_id");
                        entity.Property(e => e.ParentDestName).HasColumnName("parent_dest_name");
                        entity.Property(e => e.ParentOrigId).HasColumnName("parent_orig_id");
                        entity.Property(e => e.ParentOrigName).HasColumnName("parent_orig_name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockPackageHistory) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_package_history_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_package_history_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockPackageHistoryCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_history_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_history_create_uid_fkey");

                        entity.HasOne(d => d.LocationDest).WithMany(p => p.StockPackageHistoryLocationDest)
                            .HasForeignKey(d => d.LocationDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_history_location_dest_id_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockPackageHistoryLocation)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_history_location_id_fkey");

                        entity.HasOne(d => d.OutermostDest).WithMany(p => p.StockPackageHistoryOutermostDest)
                            .HasForeignKey(d => d.OutermostDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_history_outermost_dest_id_fkey");

                        entity.HasOne(d => d.Package).WithMany(p => p.StockPackageHistoryPackage)
                            .HasForeignKey(d => d.PackageId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_package_history_package_id_fkey");

                        entity.HasOne(d => d.ParentDest).WithMany(p => p.StockPackageHistoryParentDest)
                            .HasForeignKey(d => d.ParentDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_history_parent_dest_id_fkey");

                        entity.HasOne(d => d.ParentOrig).WithMany(p => p.StockPackageHistoryParentOrig)
                            .HasForeignKey(d => d.ParentOrigId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_history_parent_orig_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockPackageHistoryWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_package_history_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_package_history_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}