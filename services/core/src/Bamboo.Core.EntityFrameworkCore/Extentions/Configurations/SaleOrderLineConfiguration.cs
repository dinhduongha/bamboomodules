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
        public static void ConfigureSaleOrderLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrderLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sale_order_line_pkey");

                entity.ToTable("sale_order_line");

                entity.HasIndex(e => e.AnalyticDistribution, "sale_order_line_analytic_distribution_gin_index").HasMethod("gin");

                entity.HasIndex(e => e.TenantId, "sale_order_line_company_id_index");

                entity.HasIndex(e => e.LinkedLineId, "sale_order_line_linked_line_id_index");

                entity.HasIndex(e => e.OrderId, "sale_order_line_order_id_index");

                entity.HasIndex(e => e.OrderPartnerId, "sale_order_line_order_partner_id_index");

                entity.HasIndex(e => e.ProductId, "sale_order_line_product_id_index").HasFilter("(product_id IS NOT NULL)");

                entity.HasIndex(e => e.ProjectId, "sale_order_line_project_id_index");

                entity.HasIndex(e => e.TaskId, "sale_order_line_task_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AnalyticDistribution)
                    .HasColumnType("jsonb")
                    .HasColumnName("analytic_distribution");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.CustomerLead).HasColumnName("customer_lead");
                entity.Property(e => e.Discount).HasColumnName("discount");
                entity.Property(e => e.DisplayType).HasColumnName("display_type");
                entity.Property(e => e.InvoiceStatus).HasColumnName("invoice_status");
                entity.Property(e => e.IsDownpayment).HasColumnName("is_downpayment");
                entity.Property(e => e.IsExpense).HasColumnName("is_expense");
                entity.Property(e => e.IsService).HasColumnName("is_service");
                entity.Property(e => e.LinkedLineId).HasColumnName("linked_line_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OrderId).HasColumnName("order_id");
                entity.Property(e => e.OrderPartnerId).HasColumnName("order_partner_id");
                entity.Property(e => e.PriceReduce).HasColumnName("price_reduce");
                entity.Property(e => e.PriceReduceTaxexcl).HasColumnName("price_reduce_taxexcl");
                entity.Property(e => e.PriceReduceTaxinc).HasColumnName("price_reduce_taxinc");
                entity.Property(e => e.PriceSubtotal).HasColumnName("price_subtotal");
                entity.Property(e => e.PriceTax).HasColumnName("price_tax");
                entity.Property(e => e.PriceTotal).HasColumnName("price_total");
                entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductPackagingId).HasColumnName("product_packaging_id");
                entity.Property(e => e.ProductPackagingQty).HasColumnName("product_packaging_qty");
                entity.Property(e => e.ProductUom).HasColumnName("product_uom");
                entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
                entity.Property(e => e.ProjectId).HasColumnName("project_id");
                entity.Property(e => e.QtyDelivered).HasColumnName("qty_delivered");
                entity.Property(e => e.QtyDeliveredMethod).HasColumnName("qty_delivered_method");
                entity.Property(e => e.QtyInvoiced).HasColumnName("qty_invoiced");
                entity.Property(e => e.QtyToInvoice).HasColumnName("qty_to_invoice");
                entity.Property(e => e.RouteId).HasColumnName("route_id");
                entity.Property(e => e.SalesmanId).HasColumnName("salesman_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.ShopWarning).HasColumnName("shop_warning");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.TaskId).HasColumnName("task_id");
                entity.Property(e => e.UntaxedAmountInvoiced).HasColumnName("untaxed_amount_invoiced");
                entity.Property(e => e.UntaxedAmountToInvoice).HasColumnName("untaxed_amount_to_invoice");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_currency_id_fkey");

                entity.HasOne(d => d.LinkedLine).WithMany(p => p.InverseLinkedLine)
                    .HasForeignKey(d => d.LinkedLineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sale_order_line_linked_line_id_fkey");

                entity.HasOne(d => d.Order).WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sale_order_line_order_id_fkey");

                entity.HasOne(d => d.OrderPartner).WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.OrderPartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_order_partner_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_line_product_id_fkey");

                entity.HasOne(d => d.ProductPackaging).WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.ProductPackagingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_product_packaging_id_fkey");

                entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.ProductUom)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_line_product_uom_fkey");

                entity.HasOne(d => d.Project).WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_project_id_fkey");

                entity.HasOne(d => d.Route).WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_line_route_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.SalesmanId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_salesman_id_fkey");

                entity.HasOne(d => d.Task).WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_task_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_line_write_uid_fkey");

                //entity.HasMany(d => d.AccountTaxes).WithMany(p => p.SaleOrderLines)
                entity.HasMany<AccountTax>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxSaleOrderLineRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("AccountTaxId")
                            .HasConstraintName("account_tax_sale_order_line_rel_account_tax_id_fkey"),
                        l => l.HasOne<SaleOrderLine>().WithMany()
                            .HasForeignKey("SaleOrderLineId")
                            .HasConstraintName("account_tax_sale_order_line_rel_sale_order_line_id_fkey"),
                        j =>
                        {
                            j.HasKey("SaleOrderLineId", "AccountTaxId").HasName("account_tax_sale_order_line_rel_pkey");
                            j.ToTable("account_tax_sale_order_line_rel");
                            j.HasIndex(new[] { "AccountTaxId", "SaleOrderLineId" }, "account_tax_sale_order_line_r_account_tax_id_sale_order_lin_idx");
                        });

                //entity.HasMany(d => d.ProductDocuments).WithMany(p => p.SaleOrderLines)
                entity.HasMany<ProductDocument>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "SaleOrderLineProductDocumentRel",
                        r => r.HasOne<ProductDocument>().WithMany()
                            .HasForeignKey("ProductDocumentId")
                            .HasConstraintName("sale_order_line_product_document_rel_product_document_id_fkey"),
                        l => l.HasOne<SaleOrderLine>().WithMany()
                            .HasForeignKey("SaleOrderLineId")
                            .HasConstraintName("sale_order_line_product_document_rel_sale_order_line_id_fkey"),
                        j =>
                        {
                            j.HasKey("SaleOrderLineId", "ProductDocumentId").HasName("sale_order_line_product_document_rel_pkey");
                            j.ToTable("sale_order_line_product_document_rel");
                            j.HasIndex(new[] { "ProductDocumentId", "SaleOrderLineId" }, "sale_order_line_product_docum_product_document_id_sale_orde_idx");
                            j.IndexerProperty<Guid>("SaleOrderLineId").HasColumnName("sale_order_line_id");
                            j.IndexerProperty<Guid>("ProductDocumentId").HasColumnName("product_document_id");
                        });
                //entity.HasMany(d => d.ProductTemplateAttributeValues).WithMany(p => p.SaleOrderLines)
                entity.HasMany<ProductTemplateAttributeValue>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductTemplateAttributeValueSaleOrderLineRel",
                        r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                            .HasForeignKey("ProductTemplateAttributeValueId")
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_template_attribute_va_product_template_attribute_v_fkey"),
                        l => l.HasOne<SaleOrderLine>().WithMany()
                            .HasForeignKey("SaleOrderLineId")
                            .HasConstraintName("product_template_attribute_value_sale_o_sale_order_line_id_fkey"),
                        j =>
                        {
                            j.HasKey("SaleOrderLineId", "ProductTemplateAttributeValueId").HasName("product_template_attribute_value_sale_order_line_rel_pkey");
                            j.ToTable("product_template_attribute_value_sale_order_line_rel");
                            j.HasIndex(new[] { "ProductTemplateAttributeValueId", "SaleOrderLineId" }, "product_template_attribute_va_product_template_attribute_va_idx");
                        });
            });
        }
    }
}