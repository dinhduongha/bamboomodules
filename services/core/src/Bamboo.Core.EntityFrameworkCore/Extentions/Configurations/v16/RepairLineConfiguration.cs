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
        public static void ConfigureRepairLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RepairLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("repair_line_pkey");

            entity.ToTable("repair_line");

            entity.HasIndex(e => e.TenantId, "repair_line_company_id_index");

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.LocationDestId, "repair_line_location_dest_id_index");

            entity.HasIndex(e => e.LocationId, "repair_line_location_id_index");

            entity.HasIndex(e => e.RepairId, "repair_line_repair_id_index");

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
            entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.LotId).HasColumnName("lot_id");
            entity.Property(e => e.MoveId).HasColumnName("move_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PriceSubtotal).HasColumnName("price_subtotal");
            entity.Property(e => e.PriceTotal).HasColumnName("price_total");
            entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductUom).HasColumnName("product_uom");
            entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
            entity.Property(e => e.RepairId).HasColumnName("repair_id");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.RepairLine)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_line_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.RepairLineCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_line_create_uid_fkey");

            entity.HasOne(d => d.InvoiceLine).WithMany(p => p.RepairLine)
                .HasForeignKey(d => d.InvoiceLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_line_invoice_line_id_fkey");

            entity.HasOne(d => d.LocationDest).WithMany(p => p.RepairLineLocationDest)
                .HasForeignKey(d => d.LocationDestId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_line_location_dest_id_fkey");

            entity.HasOne(d => d.Location).WithMany(p => p.RepairLineLocation)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_line_location_id_fkey");

            entity.HasOne(d => d.Lot).WithMany(p => p.RepairLine)
                .HasForeignKey(d => d.LotId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_line_lot_id_fkey");

            entity.HasOne(d => d.Move).WithMany(p => p.RepairLine)
                .HasForeignKey(d => d.MoveId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_line_move_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.RepairLine)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_line_product_id_fkey");

            entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.RepairLine)
                .HasForeignKey(d => d.ProductUom)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_line_product_uom_fkey");

            entity.HasOne(d => d.Repair).WithMany(p => p.RepairLine)
                .HasForeignKey(d => d.RepairId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("repair_line_repair_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.RepairLineWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_line_write_uid_fkey");

            // entity.HasMany(d => d.Tax).WithMany(p => p.RepairOperationLine)
            entity.HasMany(d => d.Tax).WithMany(p => p.RepairOperationLine)
                .UsingEntity<Dictionary<string, object>>(
                    "RepairOperationLineTax",
                    r => r.HasOne<AccountTax>().WithMany()
                        .HasForeignKey("TaxId")
                        .HasConstraintName("repair_operation_line_tax_tax_id_fkey"),
                    l => l.HasOne<RepairLine>().WithMany()
                        .HasForeignKey("RepairOperationLineId")
                        .HasConstraintName("repair_operation_line_tax_repair_operation_line_id_fkey"),
                    j =>
                    {
                        j.HasKey("RepairOperationLineId", "TaxId").HasName("repair_operation_line_tax_pkey");
                        j.ToTable("repair_operation_line_tax");
                        j.HasIndex(new[] { "TaxId", "RepairOperationLineId" }, "repair_operation_line_tax_tax_id_repair_operation_line_id_idx");
                        j.IndexerProperty<Guid>("RepairOperationLineId").HasColumnName("repair_operation_line_id");
                        j.IndexerProperty<Guid>("TaxId").HasColumnName("tax_id");
                    });
            });
        }
    }
}