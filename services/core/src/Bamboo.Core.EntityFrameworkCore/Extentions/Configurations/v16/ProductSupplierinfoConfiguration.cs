using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductSupplierinfo(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductSupplierinfo>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_supplierinfo_pkey");

                        entity.ToTable("product_supplierinfo");

                        entity.HasIndex(e => e.TenantId, "product_supplierinfo__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ProductTmplId, "product_supplierinfo__product_tmpl_id_index");

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
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.DateEnd).HasColumnName("date_end");
                        entity.Property(e => e.DateStart).HasColumnName("date_start");
                        entity.Property(e => e.Delay).HasColumnName("delay");
                        entity.Property(e => e.Discount).HasColumnName("discount");
                        entity.Property(e => e.MinQty).HasColumnName("min_qty");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.Price).HasColumnName("price");
                        entity.Property(e => e.ProductCode).HasColumnName("product_code");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductName).HasColumnName("product_name");
                        entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                        entity.Property(e => e.PurchaseRequisitionLineId).HasColumnName("purchase_requisition_line_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.ProductSupplierinfo) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_supplierinfo_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_supplierinfo_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductSupplierinfoCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_supplierinfo_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_supplierinfo_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.ProductSupplierinfo) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_supplierinfo_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_supplierinfo_currency_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.ProductSupplierinfo) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("product_supplierinfo_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_supplierinfo_partner_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.ProductSupplierinfo) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_supplierinfo_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_supplierinfo_product_id_fkey");

                        entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductSupplierinfo)
                            .HasForeignKey(d => d.ProductTmplId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_supplierinfo_product_tmpl_id_fkey");

                        entity.HasOne(d => d.PurchaseRequisitionLine).WithMany(p => p.ProductSupplierinfo)
                            .HasForeignKey(d => d.PurchaseRequisitionLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_supplierinfo_purchase_requisition_line_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductSupplierinfoWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_supplierinfo_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_supplierinfo_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}