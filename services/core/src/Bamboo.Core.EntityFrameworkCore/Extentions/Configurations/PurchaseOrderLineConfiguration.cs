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
        public static void ConfigurePurchaseOrderLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseOrderLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("purchase_order_line_pkey");

                entity.ToTable("purchase_order_line");

                entity.HasIndex(e => e.AnalyticDistribution, "purchase_order_line_analytic_distribution_gin_index").HasMethod("gin");

                entity.HasIndex(e => e.DatePlanned, "purchase_order_line_date_planned_index");

                entity.HasIndex(e => e.OrderId, "purchase_order_line_order_id_index");

                entity.HasIndex(e => e.OrderpointId, "purchase_order_line_orderpoint_id_index").HasFilter("(orderpoint_id IS NOT NULL)");

                entity.HasIndex(e => e.ProductId, "purchase_order_line_product_id_index").HasFilter("(product_id IS NOT NULL)");

                entity.HasIndex(e => e.SaleLineId, "purchase_order_line_sale_line_id_index").HasFilter("(sale_line_id IS NOT NULL)");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AnalyticDistribution)
                    .HasColumnType("jsonb")
                    .HasColumnName("analytic_distribution");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.DatePlanned)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_planned");
                entity.Property(e => e.DisplayType).HasColumnName("display_type");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.OrderpointId).HasColumnName("orderpoint_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PriceSubtotal).HasColumnName("price_subtotal");
                entity.Property(e => e.PriceTax).HasColumnName("price_tax");
                entity.Property(e => e.PriceTotal).HasColumnName("price_total");
                entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
                entity.Property(e => e.ProductDescriptionVariants).HasColumnName("product_description_variants");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductPackagingId).HasColumnName("product_packaging_id");
                entity.Property(e => e.ProductPackagingQty).HasColumnName("product_packaging_qty");
                entity.Property(e => e.ProductQty).HasColumnName("product_qty");
                entity.Property(e => e.ProductUom).HasColumnName("product_uom");
                entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
                entity.Property(e => e.PropagateCancel).HasColumnName("propagate_cancel");
                entity.Property(e => e.QtyInvoiced).HasColumnName("qty_invoiced");
                entity.Property(e => e.QtyReceived).HasColumnName("qty_received");
                entity.Property(e => e.QtyReceivedManual).HasColumnName("qty_received_manual");
                entity.Property(e => e.QtyReceivedMethod).HasColumnName("qty_received_method");
                entity.Property(e => e.QtyToInvoice).HasColumnName("qty_to_invoice");
                entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_currency_id_fkey");

                entity.HasOne(d => d.Order).WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("purchase_order_line_order_id_fkey");

                entity.HasOne(d => d.Orderpoint).WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.OrderpointId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_orderpoint_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_partner_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_product_id_fkey");

                entity.HasOne(d => d.ProductPackaging).WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.ProductPackagingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_product_packaging_id_fkey");

                entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.ProductUom)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_product_uom_fkey");

                entity.HasOne(d => d.SaleLine).WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.SaleLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_sale_line_id_fkey");

                entity.HasOne(d => d.SaleOrder).WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.SaleOrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_sale_order_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("purchase_order_line_write_uid_fkey");

                //entity.HasMany(d => d.AccountTaxes).WithMany(p => p.PurchaseOrderLines)
                entity.HasMany<AccountTax>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxPurchaseOrderLineRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("AccountTaxId")
                            .HasConstraintName("account_tax_purchase_order_line_rel_account_tax_id_fkey"),
                        l => l.HasOne<PurchaseOrderLine>().WithMany()
                            .HasForeignKey("PurchaseOrderLineId")
                            .HasConstraintName("account_tax_purchase_order_line_rel_purchase_order_line_id_fkey"),
                        j =>
                        {
                            j.HasKey("PurchaseOrderLineId", "AccountTaxId").HasName("account_tax_purchase_order_line_rel_pkey");
                            j.ToTable("account_tax_purchase_order_line_rel");
                            j.HasIndex(new[] { "AccountTaxId", "PurchaseOrderLineId" }, "account_tax_purchase_order_li_account_tax_id_purchase_order_idx");
                        });

                //entity.HasMany(d => d.Moves).WithMany(p => p.CreatedPurchaseLines)
                entity.HasMany<StockMove>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockMoveCreatedPurchaseLineRel",
                        r => r.HasOne<StockMove>().WithMany()
                            .HasForeignKey("MoveId")
                            .HasConstraintName("stock_move_created_purchase_line_rel_move_id_fkey"),
                        l => l.HasOne<PurchaseOrderLine>().WithMany()
                            .HasForeignKey("CreatedPurchaseLineId")
                            .HasConstraintName("stock_move_created_purchase_line__created_purchase_line_id_fkey"),
                        j =>
                        {
                            j.HasKey("CreatedPurchaseLineId", "MoveId").HasName("stock_move_created_purchase_line_rel_pkey");
                            j.ToTable("stock_move_created_purchase_line_rel");
                            j.HasIndex(new[] { "MoveId", "CreatedPurchaseLineId" }, "stock_move_created_purchase_l_move_id_created_purchase_line_idx");
                            j.IndexerProperty<Guid>("CreatedPurchaseLineId").HasColumnName("created_purchase_line_id");
                            j.IndexerProperty<Guid>("MoveId").HasColumnName("move_id");
                        });

                //entity.HasMany(d => d.ProductTemplateAttributeValues).WithMany(p => p.PurchaseOrderLines)
                entity.HasMany<ProductTemplateAttributeValue>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductTemplateAttributeValuePurchaseOrderLineRel",
                        r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                            .HasForeignKey("ProductTemplateAttributeValueId")
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_template_attribute_v_product_template_attribute_v_fkey1"),
                        l => l.HasOne<PurchaseOrderLine>().WithMany()
                            .HasForeignKey("PurchaseOrderLineId")
                            .HasConstraintName("product_template_attribute_value_pu_purchase_order_line_id_fkey"),
                        j =>
                        {
                            j.HasKey("PurchaseOrderLineId", "ProductTemplateAttributeValueId").HasName("product_template_attribute_value_purchase_order_line_rel_pkey");
                            j.ToTable("product_template_attribute_value_purchase_order_line_rel");
                            j.HasIndex(new[] { "ProductTemplateAttributeValueId", "PurchaseOrderLineId" }, "product_template_attribute_va_product_template_attribute_v_idx1");
                            j.IndexerProperty<Guid>("PurchaseOrderLineId").HasColumnName("purchase_order_line_id");
                            j.IndexerProperty<Guid>("ProductTemplateAttributeValueId").HasColumnName("product_template_attribute_value_id");
                        });
            });
        }
    }
}