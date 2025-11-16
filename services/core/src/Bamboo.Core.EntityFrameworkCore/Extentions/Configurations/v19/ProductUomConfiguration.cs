using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductUom(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductUom>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_uom_pkey");

                        entity.ToTable("product_uom");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Barcode, "product_uom__barcode_index").HasFilter("(barcode IS NOT NULL)");

                        entity.HasIndex(e => e.ProductId, "product_uom__product_id_index");

                        entity.HasIndex(e => e.UomId, "product_uom__uom_id_index");

                        entity.HasIndex(e => e.Barcode, "product_uom_barcode_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Barcode).HasColumnName("barcode");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.UomId).HasColumnName("uom_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ProductUom) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_uom_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_uom_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductUomCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_uom_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_uom_create_uid_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.ProductUom) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("product_uom_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_uom_product_id_fkey");

                        // entity.HasOne(d => d.Uom).WithMany(p => p.ProductUom) .HasForeignKey(d => d.UomId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("product_uom_uom_id_fkey");
                        entity.HasOne(d => d.Uom).WithMany()
                            .HasForeignKey(d => d.UomId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_uom_uom_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductUomWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_uom_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_uom_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}