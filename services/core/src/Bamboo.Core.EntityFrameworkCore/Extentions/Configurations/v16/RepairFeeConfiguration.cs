using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureRepairFee(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RepairFee>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("repair_fee_pkey");

            entity.ToTable("repair_fee");

            entity.HasIndex(e => e.TenantId, "repair_fee_company_id_index");

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Name, "repair_fee_name_index");

            entity.HasIndex(e => e.RepairId, "repair_fee_repair_id_index");

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
            entity.Property(e => e.InvoiceLineId).HasColumnName("invoice_line_id");
            entity.Property(e => e.Invoiced).HasColumnName("invoiced");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PriceSubtotal).HasColumnName("price_subtotal");
            entity.Property(e => e.PriceTotal).HasColumnName("price_total");
            entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductUom).HasColumnName("product_uom");
            entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
            entity.Property(e => e.RepairId).HasColumnName("repair_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.RepairFee)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_fee_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.RepairFeeCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_fee_create_uid_fkey");

            entity.HasOne(d => d.InvoiceLine).WithMany(p => p.RepairFee)
                .HasForeignKey(d => d.InvoiceLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_fee_invoice_line_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.RepairFee)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_fee_product_id_fkey");

            entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.RepairFee)
                .HasForeignKey(d => d.ProductUom)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_fee_product_uom_fkey");

            entity.HasOne(d => d.Repair).WithMany(p => p.RepairFee)
                .HasForeignKey(d => d.RepairId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("repair_fee_repair_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.RepairFeeWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_fee_write_uid_fkey");

            // entity.HasMany(d => d.Tax).WithMany(p => p.RepairFeeLine)
            entity.HasMany(d => d.Tax).WithMany(p => p.RepairFeeLine)
                .UsingEntity<Dictionary<string, object>>(
                    "RepairFeeLineTax",
                    r => r.HasOne<AccountTax>().WithMany()
                        .HasForeignKey("TaxId")
                        .HasConstraintName("repair_fee_line_tax_tax_id_fkey"),
                    l => l.HasOne<RepairFee>().WithMany()
                        .HasForeignKey("RepairFeeLineId")
                        .HasConstraintName("repair_fee_line_tax_repair_fee_line_id_fkey"),
                    j =>
                    {
                        j.HasKey("RepairFeeLineId", "TaxId").HasName("repair_fee_line_tax_pkey");
                        j.ToTable("repair_fee_line_tax");
                        j.HasIndex(new[] { "TaxId", "RepairFeeLineId" }, "repair_fee_line_tax_tax_id_repair_fee_line_id_idx");
                        j.IndexerProperty<Guid>("RepairFeeLineId").HasColumnName("repair_fee_line_id");
                        j.IndexerProperty<Guid>("TaxId").HasColumnName("tax_id");
                    });
            });
        }
    }
}