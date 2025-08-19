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
        public static void ConfigureRepairOrder(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RepairOrder>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("repair_order_pkey");

            entity.ToTable("repair_order");

            entity.HasIndex(e => e.TenantId, "repair_order__company_id_index");

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.LocationDestId, "repair_order__location_dest_id_index");

            entity.HasIndex(e => e.InvoiceMethod, "repair_order_invoice_method_index");

            entity.HasIndex(e => e.LocationId, "repair_order__location_id_index");

            entity.HasIndex(e => e.Name, "repair_order_name").IsUnique();

            entity.HasIndex(e => e.Name, "repair_order__name_index")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => e.PartnerId, "repair_order__partner_id_index");

            entity.HasIndex(e => e.PartsLocationId, "repair_order__parts_location_id_index");

            entity.HasIndex(e => e.PickingTypeId, "repair_order__picking_type_id_index");

            entity.HasIndex(e => e.ProductLocationDestId, "repair_order__product_location_dest_id_index");

            entity.HasIndex(e => e.ProductLocationSrcId, "repair_order__product_location_src_id_index");

            entity.HasIndex(e => e.RecycleLocationId, "repair_order__recycle_location_id_index");

            entity.HasIndex(e => e.ScheduleDate, "repair_order__schedule_date_index");

            entity.HasIndex(e => e.State, "repair_order__state_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
            entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
            entity.Property(e => e.AmountUntaxed).HasColumnName("amount_untaxed");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.GuaranteeLimit).HasColumnName("guarantee_limit");
            entity.Property(e => e.InternalNotes).HasColumnName("internal_notes");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.InvoiceMethod).HasColumnName("invoice_method");
            entity.Property(e => e.Invoiced).HasColumnName("invoiced");
            entity.Property(e => e.IsPartsAvailable).HasColumnName("is_parts_available");
            entity.Property(e => e.IsPartsLate).HasColumnName("is_parts_late");
            entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.LotId).HasColumnName("lot_id");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.MoveId).HasColumnName("move_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PartnerInvoiceId).HasColumnName("partner_invoice_id");
            entity.Property(e => e.PartsLocationId).HasColumnName("parts_location_id");
            entity.Property(e => e.PickingId).HasColumnName("picking_id");
            entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
            entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductLocationDestId).HasColumnName("product_location_dest_id");
            entity.Property(e => e.ProductLocationSrcId).HasColumnName("product_location_src_id");
            entity.Property(e => e.ProductQty).HasColumnName("product_qty");
            entity.Property(e => e.ProductUom).HasColumnName("product_uom");
            entity.Property(e => e.QuotationNotes).HasColumnName("quotation_notes");
            entity.Property(e => e.RecycleLocationId).HasColumnName("recycle_location_id");
            entity.Property(e => e.Repaired).HasColumnName("repaired");
            entity.Property(e => e.RepairProperties)
                .HasColumnType("jsonb")
                .HasColumnName("repair_properties");
            entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
            entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
            entity.Property(e => e.ScheduleDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("schedule_date");
            //entity.Property(e => e.ScheduleDate).HasColumnName("schedule_date");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UnderWarranty).HasColumnName("under_warranty");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Address).WithMany()
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_address_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.RepairOrder)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_order_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.RepairOrderCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_create_uid_fkey");

            entity.HasOne(d => d.Invoice).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_invoice_id_fkey");

            entity.HasOne(d => d.LocationDest).WithMany(p => p.RepairOrderLocationDest)
                .HasForeignKey(d => d.LocationDestId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_location_dest_id_fkey");

            entity.HasOne(d => d.Location).WithMany(p => p.RepairOrderLocation)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_order_location_id_fkey");

            // v16-Compat
            //entity.HasOne(d => d.Location).WithMany(p => p.RepairOrder)
            //    .HasForeignKey(d => d.LocationId)
            //    .OnDelete(DeleteBehavior.Restrict)
            //    .HasConstraintName("repair_order_location_id_fkey");

            entity.HasOne(d => d.Lot).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.LotId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_lot_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.RepairOrder)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_message_main_attachment_id_fkey");

            entity.HasOne(d => d.Move).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.MoveId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_move_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.RepairOrderPartner)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_partner_id_fkey");

            entity.HasOne(d => d.PartnerInvoice).WithMany()
                .HasForeignKey(d => d.PartnerInvoiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_partner_invoice_id_fkey");

            entity.HasOne(d => d.PartsLocation).WithMany(p => p.RepairOrderPartsLocation)
                .HasForeignKey(d => d.PartsLocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_parts_location_id_fkey");

            entity.HasOne(d => d.Picking).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.PickingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_picking_id_fkey");

            entity.HasOne(d => d.PickingType).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.PickingTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_order_picking_type_id_fkey");

            entity.HasOne(d => d.Pricelist).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.PricelistId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_pricelist_id_fkey");

            entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.ProcurementGroupId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_procurement_group_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.RepairOrder)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_product_id_fkey");

            entity.HasOne(d => d.ProductLocationDest).WithMany(p => p.RepairOrderProductLocationDest)
                .HasForeignKey(d => d.ProductLocationDestId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_order_product_location_dest_id_fkey");

            entity.HasOne(d => d.ProductLocationSrc).WithMany(p => p.RepairOrderProductLocationSrc)
                .HasForeignKey(d => d.ProductLocationSrcId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_order_product_location_src_id_fkey");

            entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.ProductUom)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_product_uom_fkey");

            entity.HasOne(d => d.RecycleLocation).WithMany(p => p.RepairOrderRecycleLocation)
                .HasForeignKey(d => d.RecycleLocationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("repair_order_recycle_location_id_fkey");

            entity.HasOne(d => d.SaleOrder).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.SaleOrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_sale_order_id_fkey");

            entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.RepairOrder)
                .HasForeignKey(d => d.SaleOrderLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_sale_order_line_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.RepairOrderUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.RepairOrderWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("repair_order_write_uid_fkey");

            // entity.HasMany(d => d.RepairTags).WithMany(p => p.RepairOrder)
            entity.HasMany(d => d.RepairTags).WithMany(p => p.RepairOrder)
                .UsingEntity<Dictionary<string, object>>(
                    "RepairOrderRepairTagsRel",
                    r => r.HasOne<RepairTags>().WithMany()
                        .HasForeignKey("RepairTagsId")
                        .HasConstraintName("repair_order_repair_tags_rel_repair_tags_id_fkey"),
                    l => l.HasOne<RepairOrder>().WithMany()
                        .HasForeignKey("RepairOrderId")
                        .HasConstraintName("repair_order_repair_tags_rel_repair_order_id_fkey"),
                    j =>
                    {
                        j.HasKey("RepairOrderId", "RepairTagsId").HasName("repair_order_repair_tags_rel_pkey");
                        j.ToTable("repair_order_repair_tags_rel");
                        j.HasIndex(new[] { "RepairTagsId", "RepairOrderId" }, "repair_order_repair_tags_rel_repair_tags_id_repair_order_id_idx");
                        j.IndexerProperty<Guid>("RepairOrderId").HasColumnName("repair_order_id");
                        j.IndexerProperty<Guid>("RepairTagsId").HasColumnName("repair_tags_id");
                    });
            });
        }
    }
}
