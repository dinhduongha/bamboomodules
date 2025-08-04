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
        public static void ConfigureAccountJournal(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountJournal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_journal_pkey");

                entity.ToTable("account_journal");

                entity.HasIndex(e => e.TenantId, "account_journal_company_id_index");

                entity.HasIndex(e => new { e.TenantId, e.Code }, "account_journal_code_company_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccessToken).HasColumnName("access_token");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AliasId).HasColumnName("alias_id");
                entity.Property(e => e.AutocheckOnPost).HasColumnName("autocheck_on_post");
                entity.Property(e => e.BankAccountId).HasColumnName("bank_account_id");
                entity.Property(e => e.BankStatementsSource).HasColumnName("bank_statements_source");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.DefaultAccountId).HasColumnName("default_account_id");
                entity.Property(e => e.InvoiceReferenceModel).HasColumnName("invoice_reference_model");
                entity.Property(e => e.InvoiceReferenceType).HasColumnName("invoice_reference_type");
                entity.Property(e => e.LossAccountId).HasColumnName("loss_account_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.PaymentSequence).HasColumnName("payment_sequence");
                entity.Property(e => e.ProfitAccountId).HasColumnName("profit_account_id");
                entity.Property(e => e.RefundSequence).HasColumnName("refund_sequence");
                entity.Property(e => e.RestrictModeHashTable).HasColumnName("restrict_mode_hash_table");
                entity.Property(e => e.SaleActivityNote).HasColumnName("sale_activity_note");
                entity.Property(e => e.SaleActivityTypeId).HasColumnName("sale_activity_type_id");
                entity.Property(e => e.SaleActivityUserId).HasColumnName("sale_activity_user_id");
                entity.Property(e => e.SecureSequenceId).HasColumnName("secure_sequence_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.SequenceOverrideRegex).HasColumnName("sequence_override_regex");
                entity.Property(e => e.ShowOnDashboard).HasColumnName("show_on_dashboard");
                entity.Property(e => e.SuspenseAccountId).HasColumnName("suspense_account_id");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Alias).WithMany(p => p.AccountJournals)
                    .HasForeignKey(d => d.AliasId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_journal_alias_id_fkey");

                entity.HasOne(d => d.BankAccount).WithMany(p => p.AccountJournals)
                    .HasForeignKey(d => d.BankAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_journal_bank_account_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_journal_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_currency_id_fkey");

                entity.HasOne(d => d.DefaultAccount).WithMany(p => p.AccountJournalDefaultAccounts)
                    .HasForeignKey(d => d.DefaultAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_journal_default_account_id_fkey");

                entity.HasOne(d => d.LossAccount).WithMany(p => p.AccountJournalLossAccounts)
                    .HasForeignKey(d => d.LossAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_loss_account_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountJournals)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_message_main_attachment_id_fkey");

                entity.HasOne(d => d.ProfitAccount).WithMany(p => p.AccountJournalProfitAccounts)
                    .HasForeignKey(d => d.ProfitAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_profit_account_id_fkey");

                entity.HasOne(d => d.SaleActivityType).WithMany(p => p.AccountJournals)
                    .HasForeignKey(d => d.SaleActivityTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_sale_activity_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.SaleActivityUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_sale_activity_user_id_fkey");

                entity.HasOne(d => d.SecureSequence).WithMany(p => p.AccountJournals)
                    .HasForeignKey(d => d.SecureSequenceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_secure_sequence_id_fkey");

                entity.HasOne(d => d.SuspenseAccount).WithMany(p => p.AccountJournalSuspenseAccounts)
                    .HasForeignKey(d => d.SuspenseAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_journal_suspense_account_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_journal_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountEdiFormats).WithMany(p => p.AccountJournals)
                entity.HasMany<AccountEdiFormat>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountEdiFormatAccountJournalRel",
                        r => r.HasOne<AccountEdiFormat>().WithMany()
                            .HasForeignKey("AccountEdiFormatId")
                            .HasConstraintName("account_edi_format_account_journal_r_account_edi_format_id_fkey"),
                        l => l.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_edi_format_account_journal_rel_account_journal_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountJournalId", "AccountEdiFormatId").HasName("account_edi_format_account_journal_rel_pkey");
                            j.ToTable("account_edi_format_account_journal_rel");
                            j.HasIndex(new[] { "AccountEdiFormatId", "AccountJournalId" }, "account_edi_format_account_jo_account_edi_format_id_account_idx");
                        });

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.Accounts1).WithMany(p => p.Journals)
                entity.HasMany<AccountAccount>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "JournalAccountControlRel",
                        r => r.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountId")
                            .HasConstraintName("journal_account_control_rel_account_id_fkey"),
                        l => l.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("JournalId")
                            .HasConstraintName("journal_account_control_rel_journal_id_fkey"),
                        j =>
                        {
                            j.HasKey("JournalId", "AccountId").HasName("journal_account_control_rel_pkey");
                            j.ToTable("journal_account_control_rel");
                            j.HasIndex(new[] { "AccountId", "JournalId" }, "journal_account_control_rel_account_id_journal_id_idx");
                            j.IndexerProperty<Guid>("JournalId").HasColumnName("journal_id");
                            j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                        });
            });
        }
    }
}