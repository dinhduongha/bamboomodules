using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountMoveLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountMoveLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_move_line_pkey");

                        entity.ToTable("account_move_line");

                        entity.HasIndex(e => e.CogsOriginId, "account_move_line__cogs_origin_id_index").HasFilter("(cogs_origin_id IS NOT NULL)");

                        entity.HasIndex(e => e.TenantId, "account_move_line__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.DateMaturity, "account_move_line__date_maturity_index");

                        entity.HasIndex(e => e.ExpenseId, "account_move_line__expense_id_index").HasFilter("(expense_id IS NOT NULL)");

                        entity.HasIndex(e => e.FullReconcileId, "account_move_line__full_reconcile_id_index").HasFilter("(full_reconcile_id IS NOT NULL)");

                        entity.HasIndex(e => e.GroupTaxId, "account_move_line__group_tax_id_index").HasFilter("(group_tax_id IS NOT NULL)");

                        entity.HasIndex(e => e.JournalId, "account_move_line__journal_id_index");

                        entity.HasIndex(e => e.L10nLatamDocumentTypeId, "account_move_line__l10n_latam_document_type_id_index").HasFilter("(l10n_latam_document_type_id IS NOT NULL)");

                        entity.HasIndex(e => e.MatchingNumber, "account_move_line__matching_number_index");

                        entity.HasIndex(e => e.MoveId, "account_move_line__move_id_index");

                        entity.HasIndex(e => e.MoveName, "account_move_line__move_name_index");

                        entity.HasIndex(e => e.PaymentId, "account_move_line__payment_id_index").HasFilter("(payment_id IS NOT NULL)");

                        entity.HasIndex(e => e.ProductId, "account_move_line__product_id_index");

                        entity.HasIndex(e => e.PurchaseLineId, "account_move_line__purchase_line_id_index").HasFilter("(purchase_line_id IS NOT NULL)");

                        entity.HasIndex(e => e.Ref, "account_move_line__ref_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.StatementId, "account_move_line__statement_id_index").HasFilter("(statement_id IS NOT NULL)");

                        entity.HasIndex(e => e.StatementLineId, "account_move_line__statement_line_id_index").HasFilter("(statement_line_id IS NOT NULL)");

                        entity.HasIndex(e => e.VehicleId, "account_move_line__vehicle_id_index").HasFilter("(vehicle_id IS NOT NULL)");

                        entity.HasIndex(e => new { e.AccountId, e.Date }, "account_move_line_account_id_date_idx");

                        entity.HasIndex(e => new { e.Date, e.MoveName, e.Id }, "account_move_line_date_name_id_idx").IsDescending(true, true, false);

                        entity.HasIndex(e => e.JournalId, "account_move_line_journal_id_neg_amnt_residual_idx").HasFilter("(amount_residual < (0)::numeric)");

                        entity.HasIndex(e => new { e.PartnerId, e.Ref }, "account_move_line_partner_id_ref_idx");

                        entity.HasIndex(e => new { e.AccountId, e.PartnerId }, "account_move_line_unreconciled_index").HasFilter("(reconciled IS NOT TRUE)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountId).HasColumnName("account_id");
                        entity.Property(e => e.AmountCurrency).HasColumnName("amount_currency");
                        entity.Property(e => e.AmountResidual).HasColumnName("amount_residual");
                        entity.Property(e => e.AmountResidualCurrency).HasColumnName("amount_residual_currency");
                        entity.Property(e => e.AnalyticDistribution)
                            .HasColumnType("jsonb")
                            .HasColumnName("analytic_distribution");
                        entity.Property(e => e.AssetCategoryId).HasColumnName("asset_category_id");
                        entity.Property(e => e.AssetEndDate).HasColumnName("asset_end_date");
                        entity.Property(e => e.AssetMrr).HasColumnName("asset_mrr");
                        entity.Property(e => e.AssetStartDate).HasColumnName("asset_start_date");
                        entity.Property(e => e.Balance).HasColumnName("balance");
                        entity.Property(e => e.CogsOriginId).HasColumnName("cogs_origin_id");
                        entity.Property(e => e.CollapseComposition).HasColumnName("collapse_composition");
                        entity.Property(e => e.CollapsePrices).HasColumnName("collapse_prices");
                        entity.Property(e => e.CompanyCurrencyId).HasColumnName("company_currency_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Credit).HasColumnName("credit");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.DateMaturity).HasColumnName("date_maturity");
                        entity.Property(e => e.Debit).HasColumnName("debit");
                        entity.Property(e => e.DeductibleAmount).HasColumnName("deductible_amount");
                        entity.Property(e => e.Discount).HasColumnName("discount");
                        entity.Property(e => e.DiscountAmountCurrency).HasColumnName("discount_amount_currency");
                        entity.Property(e => e.DiscountBalance).HasColumnName("discount_balance");
                        entity.Property(e => e.DiscountDate).HasColumnName("discount_date");
                        entity.Property(e => e.DisplayType).HasColumnName("display_type");
                        entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
                        entity.Property(e => e.ExtraTaxData)
                            .HasColumnType("jsonb")
                            .HasColumnName("extra_tax_data");
                        entity.Property(e => e.FollowupDate).HasColumnName("followup_date");
                        entity.Property(e => e.FollowupLineId).HasColumnName("followup_line_id");
                        entity.Property(e => e.FullReconcileId).HasColumnName("full_reconcile_id");
                        entity.Property(e => e.GroupTaxId).HasColumnName("group_tax_id");
                        entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
                        entity.Property(e => e.IsDownpayment).HasColumnName("is_downpayment");
                        entity.Property(e => e.IsImported).HasColumnName("is_imported");
                        entity.Property(e => e.IsLandedCostsLine).HasColumnName("is_landed_costs_line");
                        entity.Property(e => e.IsStorno).HasColumnName("is_storno");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.L10nLatamDocumentTypeId).HasColumnName("l10n_latam_document_type_id");
                        entity.Property(e => e.MatchingNumber).HasColumnName("matching_number");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.MoveName).HasColumnName("move_name");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.NoFollowup).HasColumnName("no_followup");
                        entity.Property(e => e.ParentState).HasColumnName("parent_state");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PaymentId).HasColumnName("payment_id");
                        entity.Property(e => e.PriceSubtotal).HasColumnName("price_subtotal");
                        entity.Property(e => e.PriceTotal).HasColumnName("price_total");
                        entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                        entity.Property(e => e.PurchaseLineId).HasColumnName("purchase_line_id");
                        entity.Property(e => e.Quantity).HasColumnName("quantity");
                        entity.Property(e => e.ReconcileModelId).HasColumnName("reconcile_model_id");
                        entity.Property(e => e.Reconciled).HasColumnName("reconciled");
                        entity.Property(e => e.Ref).HasColumnName("ref");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.StatementId).HasColumnName("statement_id");
                        entity.Property(e => e.StatementLineId).HasColumnName("statement_line_id");
                        entity.Property(e => e.TaxBaseAmount).HasColumnName("tax_base_amount");
                        entity.Property(e => e.TaxGroupId).HasColumnName("tax_group_id");
                        entity.Property(e => e.TaxLineId).HasColumnName("tax_line_id");
                        entity.Property(e => e.TaxRepartitionLineId).HasColumnName("tax_repartition_line_id");
                        entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Account).WithMany(p => p.AccountMoveLine) .HasForeignKey(d => d.AccountId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("account_move_line_account_id_fkey");
                        entity.HasOne(d => d.Account).WithMany()
                            .HasForeignKey(d => d.AccountId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_move_line_account_id_fkey");

                        entity.HasOne(d => d.AssetCategory).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.AssetCategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_asset_category_id_fkey");

                        entity.HasOne(d => d.CogsOrigin).WithMany(p => p.InverseCogsOrigin)
                            .HasForeignKey(d => d.CogsOriginId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_cogs_origin_id_fkey");

                        // entity.HasOne(d => d.CompanyCurrency).WithMany(p => p.AccountMoveLineCompanyCurrency) .HasForeignKey(d => d.CompanyCurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_move_line_company_currency_id_fkey");
                        entity.HasOne(d => d.CompanyCurrency).WithMany()
                            .HasForeignKey(d => d.CompanyCurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_company_currency_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountMoveLine) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_move_line_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountMoveLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_move_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.AccountMoveLineCurrency) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_move_line_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_move_line_currency_id_fkey");

                        entity.HasOne(d => d.Expense).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.ExpenseId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_expense_id_fkey");

                        entity.HasOne(d => d.FollowupLine).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.FollowupLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_followup_line_id_fkey");

                        entity.HasOne(d => d.FullReconcile).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.FullReconcileId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_full_reconcile_id_fkey");

                        entity.HasOne(d => d.GroupTax).WithMany(p => p.AccountMoveLineGroupTax)
                            .HasForeignKey(d => d.GroupTaxId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_group_tax_id_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.AccountMoveLine) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_move_line_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_journal_id_fkey");

                        entity.HasOne(d => d.L10nLatamDocumentType).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.L10nLatamDocumentTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_l10n_latam_document_type_id_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_move_line_move_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.AccountMoveLine) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_move_line_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_move_line_partner_id_fkey");

                        entity.HasOne(d => d.Payment).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.PaymentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_payment_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.AccountMoveLine) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_move_line_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_move_line_product_id_fkey");

                        // entity.HasOne(d => d.ProductUom).WithMany(p => p.AccountMoveLine) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_move_line_product_uom_id_fkey");
                        entity.HasOne(d => d.ProductUom).WithMany()
                            .HasForeignKey(d => d.ProductUomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_move_line_product_uom_id_fkey");

                        entity.HasOne(d => d.PurchaseLine).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.PurchaseLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_purchase_line_id_fkey");

                        entity.HasOne(d => d.ReconcileModel).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.ReconcileModelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_reconcile_model_id_fkey");

                        entity.HasOne(d => d.Statement).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.StatementId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_statement_id_fkey");

                        entity.HasOne(d => d.StatementLine).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.StatementLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_statement_line_id_fkey");

                        entity.HasOne(d => d.TaxGroup).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.TaxGroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_tax_group_id_fkey");

                        entity.HasOne(d => d.TaxLine).WithMany(p => p.AccountMoveLineTaxLine)
                            .HasForeignKey(d => d.TaxLineId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_move_line_tax_line_id_fkey");

                        entity.HasOne(d => d.TaxRepartitionLine).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.TaxRepartitionLineId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_move_line_tax_repartition_line_id_fkey");

                        entity.HasOne(d => d.Vehicle).WithMany(p => p.AccountMoveLine)
                            .HasForeignKey(d => d.VehicleId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_vehicle_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountMoveLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_move_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_move_line_write_uid_fkey");

                        // entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.AccountMoveLine)
                        entity.HasMany(d => d.AccountAccountTag).WithMany(p => p.AccountMoveLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountAccountTagAccountMoveLineRel",
                                r => r.HasOne<AccountAccountTag>().WithMany()
                                    .HasForeignKey("AccountAccountTagId")
                                    .OnDelete(DeleteBehavior.Restrict)
                                    .HasConstraintName("account_account_tag_account_move_li_account_account_tag_id_fkey"),
                                l => l.HasOne<AccountMoveLine>().WithMany()
                                    .HasForeignKey("AccountMoveLineId")
                                    .HasConstraintName("account_account_tag_account_move_line_account_move_line_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountMoveLineId", "AccountAccountTagId").HasName("account_account_tag_account_move_line_rel_pkey");
                                    j.ToTable("account_account_tag_account_move_line_rel");
                                    j.HasIndex(new[] { "AccountAccountTagId", "AccountMoveLineId" }, "account_account_tag_account_m_account_account_tag_id_accoun_idx");
                                    j.IndexerProperty<Guid>("AccountMoveLineId").HasColumnName("account_move_line_id");
                                    j.IndexerProperty<Guid>("AccountAccountTagId").HasColumnName("account_account_tag_id");
                                });

                        // entity.HasMany(d => d.AccountTax).WithMany(p => p.AccountMoveLine)
                        entity.HasMany(d => d.AccountTax).WithMany(p => p.AccountMoveLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountMoveLineAccountTaxRel",
                                r => r.HasOne<AccountTax>().WithMany()
                                    .HasForeignKey("AccountTaxId")
                                    .HasConstraintName("account_move_line_account_tax_rel_account_tax_id_fkey"),
                                l => l.HasOne<AccountMoveLine>().WithMany()
                                    .HasForeignKey("AccountMoveLineId")
                                    .HasConstraintName("account_move_line_account_tax_rel_account_move_line_id_fkey"),
                                j =>
                                {
                                    j.HasKey("AccountMoveLineId", "AccountTaxId").HasName("account_move_line_account_tax_rel_pkey");
                                    j.ToTable("account_move_line_account_tax_rel");
                                    j.HasIndex(new[] { "AccountTaxId", "AccountMoveLineId" }, "account_move_line_account_tax_account_tax_id_account_move_l_idx");
                                    j.IndexerProperty<Guid>("AccountMoveLineId").HasColumnName("account_move_line_id");
                                    j.IndexerProperty<Guid>("AccountTaxId").HasColumnName("account_tax_id");
                                });

                        // entity.HasMany(d => d.OrderLine).WithMany(p => p.InvoiceLine)
                        entity.HasMany(d => d.OrderLine).WithMany(p => p.InvoiceLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "SaleOrderLineInvoiceRel",
                                r => r.HasOne<SaleOrderLine>().WithMany()
                                    .HasForeignKey("OrderLineId")
                                    .HasConstraintName("sale_order_line_invoice_rel_order_line_id_fkey"),
                                l => l.HasOne<AccountMoveLine>().WithMany()
                                    .HasForeignKey("InvoiceLineId")
                                    .HasConstraintName("sale_order_line_invoice_rel_invoice_line_id_fkey"),
                                j =>
                                {
                                    j.HasKey("InvoiceLineId", "OrderLineId").HasName("sale_order_line_invoice_rel_pkey");
                                    j.ToTable("sale_order_line_invoice_rel");
                                    j.HasIndex(new[] { "OrderLineId", "InvoiceLineId" }, "sale_order_line_invoice_rel_order_line_id_invoice_line_id_idx");
                                    j.IndexerProperty<Guid>("InvoiceLineId").HasColumnName("invoice_line_id");
                                    j.IndexerProperty<Guid>("OrderLineId").HasColumnName("order_line_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}