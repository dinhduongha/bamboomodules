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
        public static void ConfigureAccountMove(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountMove>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_move_pkey");

            entity.ToTable("account_move");

            entity.HasIndex(e => e.AutoPostOriginId, "account_move_auto_post_origin_id_index").HasFilter("(auto_post_origin_id IS NOT NULL)");

            entity.HasIndex(e => e.CampaignId, "account_move_campaign_id_index").HasFilter("(campaign_id IS NOT NULL)");

            entity.HasIndex(e => e.TenantId, "account_move_company_id_index");

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Date, "account_move_date_index");

            entity.HasIndex(e => e.DebitOriginId, "account_move_debit_origin_id_index").HasFilter("(debit_origin_id IS NOT NULL)");

            entity.HasIndex(e => e.ExpenseSheetId, "account_move_expense_sheet_id_index").HasFilter("(expense_sheet_id IS NOT NULL)");

            entity.HasIndex(e => e.InalterableHash, "account_move_inalterable_hash_index").HasFilter("(inalterable_hash IS NOT NULL)");

            entity.HasIndex(e => e.InvoiceDateDue, "account_move_invoice_date_due_index");

            entity.HasIndex(e => e.InvoiceDate, "account_move_invoice_date_index");

            entity.HasIndex(e => e.MediumId, "account_move_medium_id_index").HasFilter("(medium_id IS NOT NULL)");

            entity.HasIndex(e => e.MessageMainAttachmentId, "account_move_message_main_attachment_id_index").HasFilter("(message_main_attachment_id IS NOT NULL)");

            entity.HasIndex(e => e.MoveType, "account_move_move_type_index");

            entity.HasIndex(e => e.Name, "account_move_name_index")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => e.OriginPaymentId, "account_move_origin_payment_id_index").HasFilter("(origin_payment_id IS NOT NULL)");

            entity.HasIndex(e => e.PartnerId, "account_move_partner_id_index");

            entity.HasIndex(e => e.PaymentId, "account_move_payment_id_index").HasFilter("(payment_id IS NOT NULL)");

            entity.HasIndex(e => e.PaymentReference, "account_move_payment_reference_index")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => e.Ref, "account_move_ref_index")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => e.ReversedEntryId, "account_move_reversed_entry_id_index").HasFilter("(reversed_entry_id IS NOT NULL)");

            entity.HasIndex(e => e.SecureSequenceNumber, "account_move_secure_sequence_number_index");

            entity.HasIndex(e => e.SourceId, "account_move_source_id_index").HasFilter("(source_id IS NOT NULL)");

            entity.HasIndex(e => e.StatementLineId, "account_move_statement_line_id_index").HasFilter("(statement_line_id IS NOT NULL)");

            entity.HasIndex(e => e.StockMoveId, "account_move_stock_move_id_index").HasFilter("(stock_move_id IS NOT NULL)");

            entity.HasIndex(e => e.TaxCashBasisOriginMoveId, "account_move_tax_cash_basis_origin_move_id_index").HasFilter("(tax_cash_basis_origin_move_id IS NOT NULL)");

            entity.HasIndex(e => e.TaxCashBasisRecId, "account_move_tax_cash_basis_rec_id_index").HasFilter("(tax_cash_basis_rec_id IS NOT NULL)");

            entity.HasIndex(e => e.JournalId, "account_move_checked_idx").HasFilter("(checked = false)");

            entity.HasIndex(e => e.JournalId, "account_move_to_check_idx").HasFilter("(to_check = true)");

            entity.HasIndex(e => new { e.JournalId, e.TenantId, e.Date }, "account_move_journal_id_company_id_idx");

            entity.HasIndex(e => new { e.JournalId, e.TenantId, e.Date }, "account_move_made_gaps").HasFilter("(made_sequence_gap = true)");

            entity.HasIndex(e => new { e.JournalId, e.State, e.PaymentState, e.MoveType, e.Date }, "account_move_payment_idx");

            entity.HasIndex(e => new { e.JournalId, e.SequencePrefix, e.SequenceNumber, e.Name }, "account_move_sequence_index").IsDescending(false, true, true, false);

            entity.HasIndex(e => new { e.JournalId, e.Id, e.SequencePrefix }, "account_move_sequence_index2").IsDescending(false, true, false);

            entity.HasIndex(e => new { e.Name, e.JournalId }, "account_move_unique_name")
                .IsUnique()
                .HasFilter("((state = 'posted'::text) AND (name <> '/'::text))");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccessToken).HasColumnName("access_token");
            entity.Property(e => e.AlwaysTaxExigible).HasColumnName("always_tax_exigible");
            entity.Property(e => e.AmountResidual).HasColumnName("amount_residual");
            entity.Property(e => e.AmountResidualSigned).HasColumnName("amount_residual_signed");
            entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
            entity.Property(e => e.AmountTaxSigned).HasColumnName("amount_tax_signed");
            entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
            entity.Property(e => e.AmountTotalInCurrencySigned).HasColumnName("amount_total_in_currency_signed");
            entity.Property(e => e.AmountTotalSigned).HasColumnName("amount_total_signed");
            entity.Property(e => e.AmountUntaxed).HasColumnName("amount_untaxed");
            entity.Property(e => e.AmountUntaxedInCurrencySigned).HasColumnName("amount_untaxed_in_currency_signed");
            entity.Property(e => e.AmountUntaxedSigned).HasColumnName("amount_untaxed_signed");
            entity.Property(e => e.AutoPost).HasColumnName("auto_post");
            entity.Property(e => e.AutoPostOriginId).HasColumnName("auto_post_origin_id");
            entity.Property(e => e.AutoPostUntil).HasColumnName("auto_post_until");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.Checked).HasColumnName("checked");
            entity.Property(e => e.CommercialPartnerId).HasColumnName("commercial_partner_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DebitOriginId).HasColumnName("debit_origin_id");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.EdiState).HasColumnName("edi_state");
            entity.Property(e => e.ExpenseSheetId).HasColumnName("expense_sheet_id");
            entity.Property(e => e.FiscalPositionId).HasColumnName("fiscal_position_id");
            entity.Property(e => e.InalterableHash).HasColumnName("inalterable_hash");
            entity.Property(e => e.IncotermLocation).HasColumnName("incoterm_location");
            entity.Property(e => e.InvoiceCashRoundingId).HasColumnName("invoice_cash_rounding_id");
            entity.Property(e => e.InvoiceCurrencyRate).HasColumnName("invoice_currency_rate");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");
            entity.Property(e => e.InvoiceDateDue).HasColumnName("invoice_date_due");
            entity.Property(e => e.InvoiceIncotermId).HasColumnName("invoice_incoterm_id");
            entity.Property(e => e.InvoiceOrigin).HasColumnName("invoice_origin");
            entity.Property(e => e.InvoicePartnerDisplayName).HasColumnName("invoice_partner_display_name");
            entity.Property(e => e.InvoicePaymentTermId).HasColumnName("invoice_payment_term_id");
            entity.Property(e => e.InvoiceSourceEmail).HasColumnName("invoice_source_email");
            entity.Property(e => e.InvoiceUserId).HasColumnName("invoice_user_id");
            entity.Property(e => e.IsManuallyModified).HasColumnName("is_manually_modified");
            entity.Property(e => e.IsMoveSent).HasColumnName("is_move_sent");
            entity.Property(e => e.IsStorno).HasColumnName("is_storno");
            entity.Property(e => e.JournalId).HasColumnName("journal_id");
            entity.Property(e => e.L10nVnEInvoiceNumber).HasColumnName("l10n_vn_e_invoice_number");
            entity.Property(e => e.MadeSequenceGap).HasColumnName("made_sequence_gap");
            entity.Property(e => e.MediumId).HasColumnName("medium_id");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.MoveType).HasColumnName("move_type");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Narration).HasColumnName("narration");
            entity.Property(e => e.OriginPaymentId).HasColumnName("origin_payment_id");
            entity.Property(e => e.PartnerBankId).HasColumnName("partner_bank_id");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PartnerShippingId).HasColumnName("partner_shipping_id");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.PaymentReference).HasColumnName("payment_reference");
            entity.Property(e => e.PaymentState).HasColumnName("payment_state");
            entity.Property(e => e.PeppolMessageUuid).HasColumnName("peppol_message_uuid");
            entity.Property(e => e.PeppolMoveState).HasColumnName("peppol_move_state");
            entity.Property(e => e.PostedBefore).HasColumnName("posted_before");
            entity.Property(e => e.PreferredPaymentMethodLineId).HasColumnName("preferred_payment_method_line_id");
            entity.Property(e => e.QrCodeMethod).HasColumnName("qr_code_method");
            entity.Property(e => e.QuickEditTotalAmount).HasColumnName("quick_edit_total_amount");
            entity.Property(e => e.Ref).HasColumnName("ref");
            entity.Property(e => e.ReversedEntryId).HasColumnName("reversed_entry_id");
            entity.Property(e => e.ReversedPosOrderId).HasColumnName("reversed_pos_order_id");
            entity.Property(e => e.SecureSequenceNumber).HasColumnName("secure_sequence_number");
            entity.Property(e => e.SendingData)
                .HasColumnType("jsonb")
                .HasColumnName("sending_data");
            entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");
            entity.Property(e => e.SequencePrefix).HasColumnName("sequence_prefix");
            entity.Property(e => e.SourceId).HasColumnName("source_id");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.StatementLineId).HasColumnName("statement_line_id");
            entity.Property(e => e.StockMoveId).HasColumnName("stock_move_id");
            entity.Property(e => e.TaxCashBasisOriginMoveId).HasColumnName("tax_cash_basis_origin_move_id");
            entity.Property(e => e.TaxCashBasisRecId).HasColumnName("tax_cash_basis_rec_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.ToCheck).HasColumnName("to_check");
            entity.Property(e => e.WebsiteId).HasColumnName("website_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.AutoPostOrigin).WithMany(p => p.InverseAutoPostOrigin)
                .HasForeignKey(d => d.AutoPostOriginId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_auto_post_origin_id_fkey");

            entity.HasOne(d => d.Campaign).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.CampaignId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_campaign_id_fkey");

            entity.HasOne(d => d.CommercialPartner).WithMany()
                .HasForeignKey(d => d.CommercialPartnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_move_commercial_partner_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.AccountMove)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountMoveCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.AccountMove)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_move_currency_id_fkey");

            entity.HasOne(d => d.DebitOrigin).WithMany(p => p.InverseDebitOrigin)
                .HasForeignKey(d => d.DebitOriginId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_debit_origin_id_fkey");

            //entity.HasOne(d => d.ExpenseSheet).WithMany(p => p.AccountMove)
            entity.HasOne(d => d.ExpenseSheet).WithMany()
                .HasForeignKey(d => d.ExpenseSheetId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_expense_sheet_id_fkey");

            entity.HasOne(d => d.FiscalPosition).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.FiscalPositionId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_move_fiscal_position_id_fkey");

            entity.HasOne(d => d.InvoiceCashRounding).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.InvoiceCashRoundingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_invoice_cash_rounding_id_fkey");

            entity.HasOne(d => d.InvoiceIncoterm).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.InvoiceIncotermId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_invoice_incoterm_id_fkey");

            entity.HasOne(d => d.InvoicePaymentTerm).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.InvoicePaymentTermId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_invoice_payment_term_id_fkey");

            entity.HasOne(d => d.InvoiceUser).WithMany()
                .HasForeignKey(d => d.InvoiceUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_invoice_user_id_fkey");

            // entity.HasOne(d => d.Journal).WithMany(p => p.AccountMove)
            entity.HasOne(d => d.Journal).WithMany()
                .HasForeignKey(d => d.JournalId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_move_journal_id_fkey");

            entity.HasOne(d => d.Medium).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.MediumId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_medium_id_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountMove)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_message_main_attachment_id_fkey");

            entity.HasOne(d => d.OriginPayment).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.OriginPaymentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_origin_payment_id_fkey");

            entity.HasOne(d => d.PartnerBank).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.PartnerBankId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_move_partner_bank_id_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.AccountMovePartner)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("account_move_partner_id_fkey");

            entity.HasOne(d => d.PartnerShipping).WithMany()
                .HasForeignKey(d => d.PartnerShippingId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_partner_shipping_id_fkey");

            entity.HasOne(d => d.PreferredPaymentMethodLine).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.PreferredPaymentMethodLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_preferred_payment_method_line_id_fkey");

            // v16-Compat
            // entity.HasOne(d => d.Payment).WithMany(p => p.AccountMovePayment)
            //     .HasForeignKey(d => d.PaymentId)
            //     .OnDelete(DeleteBehavior.SetNull)
            //     .HasConstraintName("account_move_payment_id_fkey");

            entity.HasOne(d => d.ReversedEntry).WithMany(p => p.InverseReversedEntry)
                .HasForeignKey(d => d.ReversedEntryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_reversed_entry_id_fkey");

            entity.HasOne(d => d.ReversedPosOrder).WithMany(p => p.AccountMoveNavigation)
                .HasForeignKey(d => d.ReversedPosOrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_reversed_pos_order_id_fkey");

            entity.HasOne(d => d.Source).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_source_id_fkey");

            entity.HasOne(d => d.StatementLine).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.StatementLineId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_statement_line_id_fkey");

            entity.HasOne(d => d.StockMove).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.StockMoveId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_stock_move_id_fkey");

            entity.HasOne(d => d.TaxCashBasisOriginMove).WithMany(p => p.InverseTaxCashBasisOriginMove)
                .HasForeignKey(d => d.TaxCashBasisOriginMoveId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_tax_cash_basis_origin_move_id_fkey");

            entity.HasOne(d => d.TaxCashBasisRec).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.TaxCashBasisRecId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_tax_cash_basis_rec_id_fkey");

            entity.HasOne(d => d.Team).WithMany(p => p.AccountMove)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_team_id_fkey");

            // entity.HasOne(d => d.Website).WithMany(p => p.AccountMove)
            entity.HasOne(d => d.Website).WithMany()
                .HasForeignKey(d => d.WebsiteId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_website_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountMoveWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("account_move_write_uid_fkey");

            // entity.HasMany(d => d.MrpProduction).WithMany(p => p.AccountMove)
            entity.HasMany(d => d.MrpProduction).WithMany(p => p.AccountMove)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountMoveMrpProductionRel",
                    r => r.HasOne<MrpProduction>().WithMany()
                        .HasForeignKey("MrpProductionId")
                        .HasConstraintName("account_move_mrp_production_rel_mrp_production_id_fkey"),
                    l => l.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("AccountMoveId")
                        .HasConstraintName("account_move_mrp_production_rel_account_move_id_fkey"),
                    j =>
                    {
                        j.HasKey("AccountMoveId", "MrpProductionId").HasName("account_move_mrp_production_rel_pkey");
                        j.ToTable("account_move_mrp_production_rel");
                        j.HasIndex(new[] { "MrpProductionId", "AccountMoveId" }, "account_move_mrp_production_r_mrp_production_id_account_mov_idx");
                        j.IndexerProperty<Guid>("AccountMoveId").HasColumnName("account_move_id");
                        j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                    });

            // entity.HasMany(d => d.OriginalAccountMove).WithMany(p => p.RefundAccountMove)
            entity.HasMany(d => d.OriginalAccountMove).WithMany(p => p.RefundAccountMove)
                .UsingEntity<Dictionary<string, object>>(
                    "RefundedInvoices",
                    r => r.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("OriginalAccountMove")
                        .HasConstraintName("refunded_invoices_original_account_move_fkey"),
                    l => l.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("RefundAccountMove")
                        .HasConstraintName("refunded_invoices_refund_account_move_fkey"),
                    j =>
                    {
                        j.HasKey("RefundAccountMove", "OriginalAccountMove").HasName("refunded_invoices_pkey");
                        j.ToTable("refunded_invoices");
                        j.HasIndex(new[] { "OriginalAccountMove", "RefundAccountMove" }, "refunded_invoices_original_account_move_refund_account_move_idx");
                        j.IndexerProperty<Guid>("RefundAccountMove").HasColumnName("refund_account_move");
                        j.IndexerProperty<Guid>("OriginalAccountMove").HasColumnName("original_account_move");
                    });

            // entity.HasMany(d => d.Payment).WithMany(p => p.Invoice)
            entity.HasMany(d => d.Payments).WithMany(p => p.Invoice)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountMoveAccountPayment",
                    r => r.HasOne<AccountPayment>().WithMany()
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("account_move__account_payment_payment_id_fkey"),
                    l => l.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("account_move__account_payment_invoice_id_fkey"),
                    j =>
                    {
                        j.HasKey("InvoiceId", "PaymentId").HasName("account_move__account_payment_pkey");
                        j.ToTable("account_move__account_payment");
                        j.HasIndex(new[] { "PaymentId", "InvoiceId" }, "account_move__account_payment_payment_id_invoice_id_idx");
                        j.IndexerProperty<Guid>("InvoiceId").HasColumnName("invoice_id");
                        j.IndexerProperty<Guid>("PaymentId").HasColumnName("payment_id");
                    });

            // entity.HasMany(d => d.RefundAccountMove).WithMany(p => p.OriginalAccountMove)
            entity.HasMany(d => d.RefundAccountMove).WithMany(p => p.OriginalAccountMove)
                .UsingEntity<Dictionary<string, object>>(
                    "RefundedInvoices",
                    r => r.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("RefundAccountMove")
                        .HasConstraintName("refunded_invoices_refund_account_move_fkey"),
                    l => l.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("OriginalAccountMove")
                        .HasConstraintName("refunded_invoices_original_account_move_fkey"),
                    j =>
                    {
                        j.HasKey("RefundAccountMove", "OriginalAccountMove").HasName("refunded_invoices_pkey");
                        j.ToTable("refunded_invoices");
                        j.HasIndex(new[] { "OriginalAccountMove", "RefundAccountMove" }, "refunded_invoices_original_account_move_refund_account_move_idx");
                        j.IndexerProperty<Guid>("RefundAccountMove").HasColumnName("refund_account_move");
                        j.IndexerProperty<Guid>("OriginalAccountMove").HasColumnName("original_account_move");
                    });

            // entity.HasMany(d => d.Transaction).WithMany(p => p.Invoice)
            entity.HasMany(d => d.Transaction).WithMany(p => p.Invoice)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountInvoiceTransactionRel",
                    r => r.HasOne<PaymentTransaction>().WithMany()
                        .HasForeignKey("TransactionId")
                        .HasConstraintName("account_invoice_transaction_rel_transaction_id_fkey"),
                    l => l.HasOne<AccountMove>().WithMany()
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("account_invoice_transaction_rel_invoice_id_fkey"),
                    j =>
                    {
                        j.HasKey("InvoiceId", "TransactionId").HasName("account_invoice_transaction_rel_pkey");
                        j.ToTable("account_invoice_transaction_rel");
                        j.HasIndex(new[] { "TransactionId", "InvoiceId" }, "account_invoice_transaction_rel_transaction_id_invoice_id_idx");
                        j.IndexerProperty<Guid>("InvoiceId").HasColumnName("invoice_id");
                        j.IndexerProperty<Guid>("TransactionId").HasColumnName("transaction_id");
                    });
            });
        }
    }
}
