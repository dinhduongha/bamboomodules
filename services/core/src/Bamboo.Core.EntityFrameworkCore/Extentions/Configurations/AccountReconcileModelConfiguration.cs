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
        public static void ConfigureAccountReconcileModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountReconcileModel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_reconcile_model_pkey");

                entity.ToTable("account_reconcile_model");

                entity.HasIndex(e => e.TenantId, "account_reconcile_model_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.Name }, "account_reconcile_model_name_unique").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AllowPaymentTolerance).HasColumnName("allow_payment_tolerance");
                entity.Property(e => e.AutoReconcile).HasColumnName("auto_reconcile");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DecimalSeparator).HasColumnName("decimal_separator");
                entity.Property(e => e.MatchAmount).HasColumnName("match_amount");
                entity.Property(e => e.MatchAmountMax).HasColumnName("match_amount_max");
                entity.Property(e => e.MatchAmountMin).HasColumnName("match_amount_min");
                entity.Property(e => e.MatchLabel).HasColumnName("match_label");
                entity.Property(e => e.MatchLabelParam).HasColumnName("match_label_param");
                entity.Property(e => e.MatchNature).HasColumnName("match_nature");
                entity.Property(e => e.MatchNote).HasColumnName("match_note");
                entity.Property(e => e.MatchNoteParam).HasColumnName("match_note_param");
                entity.Property(e => e.MatchPartner).HasColumnName("match_partner");
                entity.Property(e => e.MatchSameCurrency).HasColumnName("match_same_currency");
                entity.Property(e => e.MatchTextLocationLabel).HasColumnName("match_text_location_label");
                entity.Property(e => e.MatchTextLocationNote).HasColumnName("match_text_location_note");
                entity.Property(e => e.MatchTextLocationReference).HasColumnName("match_text_location_reference");
                entity.Property(e => e.MatchTransactionType).HasColumnName("match_transaction_type");
                entity.Property(e => e.MatchTransactionTypeParam).HasColumnName("match_transaction_type_param");
                entity.Property(e => e.MatchingOrder).HasColumnName("matching_order");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PastMonthsLimit).HasColumnName("past_months_limit");
                entity.Property(e => e.PaymentToleranceParam).HasColumnName("payment_tolerance_param");
                entity.Property(e => e.PaymentToleranceType).HasColumnName("payment_tolerance_type");
                entity.Property(e => e.RuleType).HasColumnName("rule_type");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.ToCheck).HasColumnName("to_check");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_reconcile_model_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_reconcile_model_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountReconcileModels)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_reconcile_model_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_reconcile_model_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountJournals).WithMany(p => p.AccountReconcileModels)
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountJournalAccountReconcileModelRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_journal_account_reconcile_model_account_journal_id_fkey"),
                        l => l.HasOne<AccountReconcileModel>().WithMany()
                            .HasForeignKey("AccountReconcileModelId")
                            .HasConstraintName("account_journal_account_reconci_account_reconcile_model_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountReconcileModelId", "AccountJournalId").HasName("account_journal_account_reconcile_model_rel_pkey");
                            j.ToTable("account_journal_account_reconcile_model_rel");
                            j.HasIndex(new[] { "AccountJournalId", "AccountReconcileModelId" }, "account_journal_account_recon_account_journal_id_account_re_idx");
                            j.IndexerProperty<Guid>("AccountReconcileModelId").HasColumnName("account_reconcile_model_id");
                            j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                        });

                //entity.HasMany(d => d.ResPartnerCategories).WithMany(p => p.AccountReconcileModels)
                entity.HasMany<ResPartnerCategory>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReconcileModelResPartnerCategoryRel",
                        r => r.HasOne<ResPartnerCategory>().WithMany()
                            .HasForeignKey("ResPartnerCategoryId")
                            .HasConstraintName("account_reconcile_model_res_partne_res_partner_category_id_fkey"),
                        l => l.HasOne<AccountReconcileModel>().WithMany()
                            .HasForeignKey("AccountReconcileModelId")
                            .HasConstraintName("account_reconcile_model_res_pa_account_reconcile_model_id_fkey1"),
                        j =>
                        {
                            j.HasKey("AccountReconcileModelId", "ResPartnerCategoryId").HasName("account_reconcile_model_res_partner_category_rel_pkey");
                            j.ToTable("account_reconcile_model_res_partner_category_rel");
                            j.HasIndex(new[] { "ResPartnerCategoryId", "AccountReconcileModelId" }, "account_reconcile_model_res_p_res_partner_category_id_accou_idx");
                            j.IndexerProperty<Guid>("AccountReconcileModelId").HasColumnName("account_reconcile_model_id");
                            j.IndexerProperty<Guid>("ResPartnerCategoryId").HasColumnName("res_partner_category_id");
                        });

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.ResPartners).WithMany(p => p.AccountReconcileModels)
                entity.HasMany<ResPartner>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReconcileModelResPartnerRel",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("ResPartnerId")
                            .HasConstraintName("account_reconcile_model_res_partner_rel_res_partner_id_fkey"),
                        l => l.HasOne<AccountReconcileModel>().WithMany()
                            .HasForeignKey("AccountReconcileModelId")
                            .HasConstraintName("account_reconcile_model_res_par_account_reconcile_model_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountReconcileModelId", "ResPartnerId").HasName("account_reconcile_model_res_partner_rel_pkey");
                            j.ToTable("account_reconcile_model_res_partner_rel");
                            j.HasIndex(new[] { "ResPartnerId", "AccountReconcileModelId" }, "account_reconcile_model_res_p_res_partner_id_account_reconc_idx");
                            j.IndexerProperty<Guid>("AccountReconcileModelId").HasColumnName("account_reconcile_model_id");
                            j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                        });
            });
        }
    }
}