using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePosOrderLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosOrderLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_order_line_pkey");

                        entity.ToTable("pos_order_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.OrderId, "pos_order_line__order_id_index");

                        entity.HasIndex(e => e.RewardId, "pos_order_line__reward_id_index").HasFilter("(reward_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ComboId).HasColumnName("combo_id");
                        entity.Property(e => e.ComboItemId).HasColumnName("combo_item_id");
                        entity.Property(e => e.ComboParentId).HasColumnName("combo_parent_id");

                        entity.Property(e => e.CouponId).HasColumnName("coupon_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CustomerNote).HasColumnName("customer_note");
                        entity.Property(e => e.Discount).HasColumnName("discount");
                        entity.Property(e => e.DownPaymentDetails).HasColumnName("down_payment_details");
                        entity.Property(e => e.EventTicketId).HasColumnName("event_ticket_id");
                        entity.Property(e => e.FullProductName).HasColumnName("full_product_name");
                        entity.Property(e => e.IsEdited).HasColumnName("is_edited");
                        entity.Property(e => e.IsRewardLine).HasColumnName("is_reward_line");
                        entity.Property(e => e.IsTotalCostComputed).HasColumnName("is_total_cost_computed");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Note).HasColumnName("note");
                        entity.Property(e => e.Notice).HasColumnName("notice");
                        entity.Property(e => e.OrderId).HasColumnName("order_id");
                        entity.Property(e => e.PointsCost).HasColumnName("points_cost");
                        entity.Property(e => e.PriceExtra).HasColumnName("price_extra");
                        entity.Property(e => e.PriceSubtotal).HasColumnName("price_subtotal");
                        entity.Property(e => e.PriceSubtotalIncl).HasColumnName("price_subtotal_incl");
                        entity.Property(e => e.PriceType).HasColumnName("price_type");
                        entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.Qty).HasColumnName("qty");
                        entity.Property(e => e.QtyDelivered).HasColumnName("qty_delivered");
                        entity.Property(e => e.RefundedOrderlineId).HasColumnName("refunded_orderline_id");
                        entity.Property(e => e.RewardId).HasColumnName("reward_id");
                        entity.Property(e => e.RewardIdentifierCode).HasColumnName("reward_identifier_code");
                        entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
                        entity.Property(e => e.SaleOrderOriginId).HasColumnName("sale_order_origin_id");
                        entity.Property(e => e.SkipChange).HasColumnName("skip_change");
                        entity.Property(e => e.TotalCost).HasColumnName("total_cost");
                        entity.Property(e => e.Uuid).HasColumnName("uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Combo).WithMany(p => p.PosOrderLine)
                            .HasForeignKey(d => d.ComboId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_combo_id_fkey");

                        entity.HasOne(d => d.ComboItem).WithMany(p => p.PosOrderLine)
                            .HasForeignKey(d => d.ComboItemId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_combo_item_id_fkey");

                        entity.HasOne(d => d.ComboParent).WithMany(p => p.InverseComboParent)
                            .HasForeignKey(d => d.ComboParentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_combo_parent_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PosOrderLine) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_order_line_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_company_id_fkey");

                        entity.HasOne(d => d.Coupon).WithMany(p => p.PosOrderLine)
                            .HasForeignKey(d => d.CouponId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_order_line_coupon_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PosOrderLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_order_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_create_uid_fkey");

                        entity.HasOne(d => d.EventTicket).WithMany(p => p.PosOrderLine)
                            .HasForeignKey(d => d.EventTicketId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_event_ticket_id_fkey");

                        entity.HasOne(d => d.Order).WithMany(p => p.PosOrderLine)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("pos_order_line_order_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.PosOrderLine) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("pos_order_line_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_order_line_product_id_fkey");

                        entity.HasOne(d => d.RefundedOrderline).WithMany(p => p.InverseRefundedOrderline)
                            .HasForeignKey(d => d.RefundedOrderlineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_refunded_orderline_id_fkey");

                        entity.HasOne(d => d.Reward).WithMany(p => p.PosOrderLine)
                            .HasForeignKey(d => d.RewardId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_order_line_reward_id_fkey");

                        entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.PosOrderLine)
                            .HasForeignKey(d => d.SaleOrderLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_sale_order_line_id_fkey");

                        entity.HasOne(d => d.SaleOrderOrigin).WithMany(p => p.PosOrderLine)
                            .HasForeignKey(d => d.SaleOrderOriginId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_sale_order_origin_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PosOrderLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_order_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_line_write_uid_fkey");

                        // entity.HasMany(d => d.AccountTax).WithMany(p => p.PosOrderLine)
                        entity.HasMany(d => d.AccountTax).WithMany(p => p.PosOrderLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountTaxPosOrderLineRel",
                                r => r.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("AccountTaxId")
                                    .HasConstraintName("account_tax_pos_order_line_rel_account_tax_id_fkey"),
                                l => l.HasOne<PosOrderLine>().WithMany()
                                    .HasForeignKey("PosOrderLineId")
                                    .HasConstraintName("account_tax_pos_order_line_rel_pos_order_line_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PosOrderLineId", "AccountTaxId").HasName("account_tax_pos_order_line_rel_pkey");
                                    j.ToTable("account_tax_pos_order_line_rel");
                                    j.HasIndex(new[] { "AccountTaxId", "PosOrderLineId" }, "account_tax_pos_order_line_re_account_tax_id_pos_order_line_idx");
                                    j.IndexerProperty<Guid>("PosOrderLineId").HasColumnName("pos_order_line_id");
                                    j.IndexerProperty<Guid>("AccountTaxId").HasColumnName("account_tax_id");
                                });

                        // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.PosOrderLine)
                        entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.PosOrderLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "PosOrderLineProductTemplateAttributeValueRel",
                                r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                                    .HasForeignKey("ProductTemplateAttributeValueId")
                                    .HasConstraintName("pos_order_line_product_templa_product_template_attribute_v_fkey"),
                                l => l.HasOne<PosOrderLine>().WithMany()
                                    .HasForeignKey("PosOrderLineId")
                                    .HasConstraintName("pos_order_line_product_template_attribut_pos_order_line_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PosOrderLineId", "ProductTemplateAttributeValueId").HasName("pos_order_line_product_template_attribute_value_rel_pkey");
                                    j.ToTable("pos_order_line_product_template_attribute_value_rel");
                                    j.HasIndex(new[] { "ProductTemplateAttributeValueId", "PosOrderLineId" }, "pos_order_line_product_templa_product_template_attribute_va_idx");
                                    j.IndexerProperty<Guid>("PosOrderLineId").HasColumnName("pos_order_line_id");
                                    j.IndexerProperty<Guid>("ProductTemplateAttributeValueId").HasColumnName("product_template_attribute_value_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}