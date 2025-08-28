using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpUnbuild(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpUnbuild>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_unbuild_pkey");

                        entity.ToTable("mrp_unbuild");

                        entity.HasIndex(e => e.TenantId, "mrp_unbuild__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BomId).HasColumnName("bom_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.LotId).HasColumnName("lot_id");
                        entity.Property(e => e.MoId).HasColumnName("mo_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductQty).HasColumnName("product_qty");
                        entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Bom).WithMany(p => p.MrpUnbuild)
                            .HasForeignKey(d => d.BomId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_unbuild_bom_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.MrpUnbuild) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_unbuild_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_unbuild_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpUnbuildCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_unbuild_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_unbuild_create_uid_fkey");

                        entity.HasOne(d => d.LocationDest).WithMany(p => p.MrpUnbuildLocationDest)
                            .HasForeignKey(d => d.LocationDestId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_unbuild_location_dest_id_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.MrpUnbuildLocation)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_unbuild_location_id_fkey");

                        entity.HasOne(d => d.Lot).WithMany(p => p.MrpUnbuild)
                            .HasForeignKey(d => d.LotId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_unbuild_lot_id_fkey");

                        entity.HasOne(d => d.Mo).WithMany(p => p.MrpUnbuild)
                            .HasForeignKey(d => d.MoId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_unbuild_mo_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.MrpUnbuild) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_unbuild_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_unbuild_product_id_fkey");

                        // entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpUnbuild) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_unbuild_product_uom_id_fkey");
                        entity.HasOne(d => d.ProductUom).WithMany()
                            .HasForeignKey(d => d.ProductUomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_unbuild_product_uom_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpUnbuildWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_unbuild_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_unbuild_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}