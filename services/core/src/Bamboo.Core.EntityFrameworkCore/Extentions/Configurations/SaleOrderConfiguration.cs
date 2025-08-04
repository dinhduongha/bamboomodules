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
        public static void ConfigureSaleOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("sale_order_pkey");

                entity.ToTable("sale_order");

                entity.HasIndex(e => e.TenantId, "sale_order_company_id_index");

                entity.HasIndex(e => e.CreationTime, "sale_order_create_date_index");

                entity.HasIndex(e => new { e.DateOrder, e.Id }, "sale_order_date_order_id_idx").IsDescending();

                entity.HasIndex(e => e.Name, "sale_order_name_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.PartnerId, "sale_order_partner_id_index");

                entity.HasIndex(e => e.State, "sale_order_state_index");

                entity.HasIndex(e => e.UserId, "sale_order_user_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccessToken).HasColumnName("access_token");
                entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
                entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
                entity.Property(e => e.AmountUnpaid).HasColumnName("amount_unpaid");
                entity.Property(e => e.AmountUntaxed).HasColumnName("amount_untaxed");
                entity.Property(e => e.AnalyticAccountId).HasColumnName("analytic_account_id");
                entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                entity.Property(e => e.CartRecoveryEmailSent).HasColumnName("cart_recovery_email_sent");
                entity.Property(e => e.ClientOrderRef).HasColumnName("client_order_ref");
                entity.Property(e => e.CommitmentDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("commitment_date");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.CurrencyRate).HasColumnName("currency_rate");
                entity.Property(e => e.DateOrder)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_order");
                entity.Property(e => e.DeliveryStatus).HasColumnName("delivery_status");
                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("effective_date");
                entity.Property(e => e.FiscalPositionId).HasColumnName("fiscal_position_id");
                entity.Property(e => e.Incoterm).HasColumnName("incoterm");
                entity.Property(e => e.IncotermLocation).HasColumnName("incoterm_location");
                entity.Property(e => e.InvoiceStatus).HasColumnName("invoice_status");
                entity.Property(e => e.MediumId).HasColumnName("medium_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.OpportunityId).HasColumnName("opportunity_id");
                entity.Property(e => e.Origin).HasColumnName("origin");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PartnerInvoiceId).HasColumnName("partner_invoice_id");
                entity.Property(e => e.PartnerShippingId).HasColumnName("partner_shipping_id");
                entity.Property(e => e.PaymentTermId).HasColumnName("payment_term_id");
                entity.Property(e => e.PickingPolicy).HasColumnName("picking_policy");
                entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");
                entity.Property(e => e.ProjectId).HasColumnName("project_id");
                entity.Property(e => e.Reference).HasColumnName("reference");
                entity.Property(e => e.RequirePayment).HasColumnName("require_payment");
                entity.Property(e => e.RequireSignature).HasColumnName("require_signature");
                entity.Property(e => e.SaleOrderTemplateId).HasColumnName("sale_order_template_id");
                entity.Property(e => e.ShopWarning).HasColumnName("shop_warning");
                entity.Property(e => e.SignedBy).HasColumnName("signed_by");
                entity.Property(e => e.SignedOn)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("signed_on");
                entity.Property(e => e.SourceId).HasColumnName("source_id");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.TeamId).HasColumnName("team_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.ValidityDate).HasColumnName("validity_date");
                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AnalyticAccount).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.AnalyticAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_analytic_account_id_fkey");

                entity.HasOne(d => d.Campaign).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_campaign_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_currency_id_fkey");

                entity.HasOne(d => d.FiscalPosition).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.FiscalPositionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_fiscal_position_id_fkey");

                entity.HasOne(d => d.IncotermNavigation).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.Incoterm)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_incoterm_fkey");

                entity.HasOne(d => d.Medium).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.MediumId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_medium_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Opportunity).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.OpportunityId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_opportunity_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_partner_id_fkey");

                entity.HasOne(d => d.PartnerInvoice).WithMany(p => p.SaleOrderPartnerInvoices)
                    .HasForeignKey(d => d.PartnerInvoiceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_partner_invoice_id_fkey");

                entity.HasOne(d => d.PartnerShipping).WithMany(p => p.SaleOrderPartnerShippings)
                    .HasForeignKey(d => d.PartnerShippingId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_partner_shipping_id_fkey");

                entity.HasOne(d => d.PaymentTerm).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.PaymentTermId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_payment_term_id_fkey");

                entity.HasOne(d => d.Pricelist).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.PricelistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_pricelist_id_fkey");

                entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.ProcurementGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_procurement_group_id_fkey");

                entity.HasOne(d => d.Project).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_project_id_fkey");

                entity.HasOne(d => d.SaleOrderTemplate).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.SaleOrderTemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_sale_order_template_id_fkey");

                entity.HasOne(d => d.Source).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_source_id_fkey");

                entity.HasOne(d => d.Team).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_team_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_user_id_fkey");

                entity.HasOne(d => d.Warehouse).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_warehouse_id_fkey");

                entity.HasOne(d => d.Website).WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.WebsiteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_website_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("sale_order_write_uid_fkey");

                //entity.HasMany(d => d.QuotationDocuments).WithMany(p => p.SaleOrders)
                entity.HasMany<QuotationDocument>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "QuotationDocumentSaleOrderRel",
                        r => r.HasOne<QuotationDocument>().WithMany()
                            .HasForeignKey("QuotationDocumentId")
                            .HasConstraintName("quotation_document_sale_order_rel_quotation_document_id_fkey"),
                        l => l.HasOne<SaleOrder>().WithMany()
                            .HasForeignKey("SaleOrderId")
                            .HasConstraintName("quotation_document_sale_order_rel_sale_order_id_fkey"),
                        j =>
                        {
                            j.HasKey("SaleOrderId", "QuotationDocumentId").HasName("quotation_document_sale_order_rel_pkey");
                            j.ToTable("quotation_document_sale_order_rel");
                            j.HasIndex(new[] { "QuotationDocumentId", "SaleOrderId" }, "quotation_document_sale_order_quotation_document_id_sale_or_idx");
                            j.IndexerProperty<Guid>("SaleOrderId").HasColumnName("sale_order_id");
                            j.IndexerProperty<Guid>("QuotationDocumentId").HasColumnName("quotation_document_id");
                        });

                //entity.HasMany(d => d.Tags).WithMany(p => p.Orders)
                entity.HasMany<CrmTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "SaleOrderTagRel",
                        r => r.HasOne<CrmTag>().WithMany()
                            .HasForeignKey("TagId")
                            .HasConstraintName("sale_order_tag_rel_tag_id_fkey"),
                        l => l.HasOne<SaleOrder>().WithMany()
                            .HasForeignKey("OrderId")
                            .HasConstraintName("sale_order_tag_rel_order_id_fkey"),
                        j =>
                        {
                            j.HasKey("OrderId", "TagId").HasName("sale_order_tag_rel_pkey");
                            j.ToTable("sale_order_tag_rel");
                            j.HasIndex(new[] { "TagId", "OrderId" }, "sale_order_tag_rel_tag_id_order_id_idx");
                        });
            });
        }
    }
}