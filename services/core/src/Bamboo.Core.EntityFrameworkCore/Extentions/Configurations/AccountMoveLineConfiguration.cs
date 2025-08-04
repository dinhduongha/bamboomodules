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
        public static void ConfigureAccountMoveLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountMoveLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_move_line_pkey");

                entity.ToTable("account_move_line");

                entity.HasIndex(e => e.CogsOriginId, "account_move_line__cogs_origin_id_index").HasFilter("(cogs_origin_id IS NOT NULL)");

                entity.HasIndex(e => e.AccountId, "account_move_line_account_id_index");

                entity.HasIndex(e => e.TenantId, "account_move_line_company_id_index");

                entity.HasIndex(e => e.DateMaturity, "account_move_line_date_maturity_index");

                entity.HasIndex(e => new { e.TenantId, e.Date, e.MoveName, e.Id }, "account_move_line_date_name_id_idx").IsDescending(false, true, true, false);

                entity.HasIndex(e => e.FullReconcileId, "account_move_line_full_reconcile_id_index").HasFilter("(full_reconcile_id IS NOT NULL)");

                entity.HasIndex(e => e.GroupTaxId, "account_move_line_group_tax_id_index").HasFilter("(group_tax_id IS NOT NULL)");

                entity.HasIndex(e => e.JournalId, "account_move_line_journal_id_index");

                entity.HasIndex(e => e.MatchingNumber, "account_move_line__matching_number_index");

                entity.HasIndex(e => e.MoveId, "account_move_line_move_id_index");

                entity.HasIndex(e => e.MoveName, "account_move_line_move_name_index");

                entity.HasIndex(e => new { e.TenantId, e.PartnerId, e.Ref }, "account_move_line_partner_id_ref_idx");

                entity.HasIndex(e => e.PaymentId, "account_move_line_payment_id_index").HasFilter("(payment_id IS NOT NULL)");

                entity.HasIndex(e => e.PurchaseLineId, "account_move_line_purchase_line_id_index").HasFilter("(purchase_line_id IS NOT NULL)");

                entity.HasIndex(e => e.Ref, "account_move_line_ref_index")
                    .HasMethod("gin")
                    .HasOperators(new[] { "gin_trgm_ops" });

                entity.HasIndex(e => e.StatementId, "account_move_line_statement_id_index").HasFilter("(statement_id IS NOT NULL)");

                entity.HasIndex(e => e.StatementLineId, "account_move_line_statement_line_id_index").HasFilter("(statement_line_id IS NOT NULL)");

                entity.HasIndex(e => new { e.AccountId, e.PartnerId }, "account_move_line__unreconciled_index").HasFilter("(((reconciled IS NULL) OR (reconciled = false) OR (reconciled IS NOT TRUE)) AND (parent_state = 'posted'::text))");

                entity.HasIndex(e => e.VehicleId, "account_move_line_vehicle_id_index").HasFilter("(vehicle_id IS NOT NULL)");

                entity.HasIndex(e => new { e.AccountId, e.Date }, "account_move_line_account_id_date_idx");

                //entity.HasIndex(e => new { e.Date, e.MoveName, e.Id }, "account_move_line_date_name_id_idx").IsDescending(true, true, false);

                entity.HasIndex(e => e.JournalId, "account_move_line_journal_id_neg_amnt_residual_idx").HasFilter("((amount_residual < (0)::numeric) AND (parent_state = 'posted'::text))");

                //entity.HasIndex(e => new { e.PartnerId, e.Ref }, "account_move_line_partner_id_ref_idx");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.AccountRootId).HasColumnName("account_root_id");
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
                entity.Property(e => e.Blocked).HasColumnName("blocked");
                entity.Property(e => e.CompanyCurrencyId).HasColumnName("company_currency_id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Credit).HasColumnName("credit");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.DateMaturity).HasColumnName("date_maturity");
                entity.Property(e => e.Debit).HasColumnName("debit");
                entity.Property(e => e.Discount).HasColumnName("discount");
                entity.Property(e => e.DiscountAmountCurrency).HasColumnName("discount_amount_currency");
                entity.Property(e => e.DiscountBalance).HasColumnName("discount_balance");
                entity.Property(e => e.DiscountDate).HasColumnName("discount_date");
                entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
                entity.Property(e => e.DisplayType).HasColumnName("display_type");
                entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
                entity.Property(e => e.FollowupDate).HasColumnName("followup_date");
                entity.Property(e => e.FollowupLineId).HasColumnName("followup_line_id");
                entity.Property(e => e.FullReconcileId).HasColumnName("full_reconcile_id");
                entity.Property(e => e.GroupTaxId).HasColumnName("group_tax_id");
                entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
                entity.Property(e => e.IsDownpayment).HasColumnName("is_downpayment");
                entity.Property(e => e.IsImported).HasColumnName("is_imported");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.MatchingNumber).HasColumnName("matching_number");
                entity.Property(e => e.MoveId).HasColumnName("move_id");
                entity.Property(e => e.MoveName).HasColumnName("move_name");
                entity.Property(e => e.Name).HasColumnName("name");
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
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.StatementId).HasColumnName("statement_id");
                entity.Property(e => e.StatementLineId).HasColumnName("statement_line_id");
                entity.Property(e => e.TaxAudit).HasColumnName("tax_audit");
                entity.Property(e => e.TaxBaseAmount).HasColumnName("tax_base_amount");
                entity.Property(e => e.TaxGroupId).HasColumnName("tax_group_id");
                entity.Property(e => e.TaxLineId).HasColumnName("tax_line_id");
                entity.Property(e => e.TaxRepartitionLineId).HasColumnName("tax_repartition_line_id");
                entity.Property(e => e.TaxTagInvert).HasColumnName("tax_tag_invert");
                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Account).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_move_line_account_id_fkey");

                entity.HasOne(d => d.AssetCategory).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.AssetCategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_asset_category_id_fkey");

                //entity.HasOne(d => d.CogsOrigin).WithMany(p => p.InverseCogsOrigin)
                entity.HasOne(d => d.CogsOrigin).WithMany()
                    .HasForeignKey(d => d.CogsOriginId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_cogs_origin_id_fkey");

                entity.HasOne(d => d.CompanyCurrency).WithMany(p => p.AccountMoveLineCompanyCurrencies)
                    .HasForeignKey(d => d.CompanyCurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_company_currency_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_move_line_currency_id_fkey");

                entity.HasOne(d => d.Expense).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.ExpenseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_expense_id_fkey");

                entity.HasOne(d => d.FollowupLine).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.FollowupLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_followup_line_id_fkey");

                entity.HasOne(d => d.FullReconcile).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.FullReconcileId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_full_reconcile_id_fkey");

                entity.HasOne(d => d.GroupTax).WithMany(p => p.AccountMoveLineGroupTaxes)
                    .HasForeignKey(d => d.GroupTaxId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_group_tax_id_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_journal_id_fkey");

                entity.HasOne(d => d.Move).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_move_line_move_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_move_line_partner_id_fkey");

                entity.HasOne(d => d.Payment).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_payment_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_move_line_product_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_move_line_product_uom_id_fkey");

                entity.HasOne(d => d.PurchaseLine).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.PurchaseLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_purchase_line_id_fkey");

                entity.HasOne(d => d.ReconcileModel).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.ReconcileModelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_reconcile_model_id_fkey");

                entity.HasOne(d => d.Statement).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.StatementId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_statement_id_fkey");

                entity.HasOne(d => d.StatementLine).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.StatementLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_statement_line_id_fkey");

                entity.HasOne(d => d.TaxGroup).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.TaxGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_tax_group_id_fkey");

                entity.HasOne(d => d.TaxLine).WithMany(p => p.AccountMoveLineTaxLines)
                    .HasForeignKey(d => d.TaxLineId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_move_line_tax_line_id_fkey");

                entity.HasOne(d => d.TaxRepartitionLine).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.TaxRepartitionLineId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_move_line_tax_repartition_line_id_fkey");

                entity.HasOne(d => d.Vehicle).WithMany(p => p.AccountMoveLines)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_vehicle_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_move_line_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountAccountTags).WithMany(p => p.AccountMoveLines)
                entity.HasMany<AccountAccountTag>().WithMany()
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

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountTaxes).WithMany(p => p.AccountMoveLines)
                entity.HasMany<AccountTax>().WithMany()
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

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.OrderLines).WithMany(p => p.InvoiceLines)
                //entity.HasMany<SaleOrderLine>().WithMany()
                entity.HasMany(d => d.OrderLines).WithMany()
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
            });
        }
    }
}