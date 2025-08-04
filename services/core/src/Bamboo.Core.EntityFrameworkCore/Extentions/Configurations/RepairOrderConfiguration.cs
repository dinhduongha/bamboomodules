using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
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

                entity.HasIndex(e => e.TenantId, "repair_order_company_id_index");

                entity.HasIndex(e => e.InvoiceMethod, "repair_order_invoice_method_index");

                entity.HasIndex(e => e.LocationId, "repair_order_location_id_index");

                entity.HasIndex(e => new { e.TenantId, e.Name }, "repair_order_name").IsUnique();

                entity.HasIndex(e => e.Name, "repair_order_name_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.PartnerId, "repair_order_partner_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
                entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
                entity.Property(e => e.AmountUntaxed).HasColumnName("amount_untaxed");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.GuaranteeLimit).HasColumnName("guarantee_limit");
                entity.Property(e => e.InternalNotes).HasColumnName("internal_notes");
                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
                entity.Property(e => e.InvoiceMethod).HasColumnName("invoice_method");
                entity.Property(e => e.Invoiced).HasColumnName("invoiced");
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.LotId).HasColumnName("lot_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.MoveId).HasColumnName("move_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PartnerInvoiceId).HasColumnName("partner_invoice_id");
                entity.Property(e => e.PickingId).HasColumnName("picking_id");
                entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                entity.Property(e => e.Priority).HasColumnName("priority");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductQty).HasColumnName("product_qty");
                entity.Property(e => e.ProductUom).HasColumnName("product_uom");
                entity.Property(e => e.QuotationNotes).HasColumnName("quotation_notes");
                entity.Property(e => e.Repaired).HasColumnName("repaired");
                entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                entity.Property(e => e.ScheduleDate).HasColumnName("schedule_date");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Address).WithMany(p => p.RepairOrderAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_address_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("repair_order_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_create_uid_fkey");

                entity.HasOne(d => d.Invoice).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_invoice_id_fkey");

                entity.HasOne(d => d.Location).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("repair_order_location_id_fkey");

                entity.HasOne(d => d.Lot).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_lot_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Move).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_move_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_partner_id_fkey");

                entity.HasOne(d => d.PartnerInvoice).WithMany(p => p.RepairOrderPartnerInvoices)
                    .HasForeignKey(d => d.PartnerInvoiceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_partner_invoice_id_fkey");

                entity.HasOne(d => d.Picking).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.PickingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_picking_id_fkey");

                entity.HasOne(d => d.Pricelist).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.PricelistId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_pricelist_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("repair_order_product_id_fkey");

                entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.ProductUom)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("repair_order_product_uom_fkey");

                entity.HasOne(d => d.SaleOrder).WithMany(p => p.RepairOrders)
                    .HasForeignKey(d => d.SaleOrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_sale_order_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("repair_order_write_uid_fkey");

                //entity.HasMany(d => d.RepairTags).WithMany(p => p.RepairOrders)
                entity.HasMany<RepairTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "RepairOrderRepairTagsRel",
                        r => r.HasOne<RepairTag>().WithMany()
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
                        });
            });
        }
    }
}