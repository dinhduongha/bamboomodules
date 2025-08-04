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
        public static void ConfigurePosOrderLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosOrderLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pos_order_line_pkey");

                entity.ToTable("pos_order_line");

                entity.HasIndex(e => e.OrderId, "pos_order_line_order_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CustomerNote).HasColumnName("customer_note");
                entity.Property(e => e.Discount).HasColumnName("discount");
                entity.Property(e => e.DownPaymentDetails).HasColumnName("down_payment_details");
                entity.Property(e => e.FullProductName).HasColumnName("full_product_name");
                entity.Property(e => e.IsTotalCostComputed).HasColumnName("is_total_cost_computed");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Notice).HasColumnName("notice");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.PriceExtra).HasColumnName("price_extra");
                entity.Property(e => e.PriceSubtotal).HasColumnName("price_subtotal");
                entity.Property(e => e.PriceSubtotalIncl).HasColumnName("price_subtotal_incl");
                entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.RefundedOrderlineId).HasColumnName("refunded_orderline_id");
                entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
                entity.Property(e => e.SaleOrderOriginId).HasColumnName("sale_order_origin_id");
                entity.Property(e => e.TotalCost).HasColumnName("total_cost");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_line_create_uid_fkey");

                entity.HasOne(d => d.Order).WithMany(p => p.PosOrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("pos_order_line_order_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.PosOrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_order_line_product_id_fkey");

                entity.HasOne(d => d.RefundedOrderline).WithMany(p => p.InverseRefundedOrderline)
                    .HasForeignKey(d => d.RefundedOrderlineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_line_refunded_orderline_id_fkey");

                entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.PosOrderLines)
                    .HasForeignKey(d => d.SaleOrderLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_line_sale_order_line_id_fkey");

                entity.HasOne(d => d.SaleOrderOrigin).WithMany(p => p.PosOrderLines)
                    .HasForeignKey(d => d.SaleOrderOriginId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_line_sale_order_origin_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_line_write_uid_fkey");

                //entity.HasMany(d => d.AccountTaxes).WithMany(p => p.PosOrderLines)
                entity.HasMany<AccountTax>().WithMany()
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
                        });

                //entity.HasMany(d => d.ProductTemplateAttributeValues).WithMany(p => p.PosOrderLines)
                entity.HasMany<ProductTemplateAttributeValue>().WithMany()
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
            });
        }
    }
}