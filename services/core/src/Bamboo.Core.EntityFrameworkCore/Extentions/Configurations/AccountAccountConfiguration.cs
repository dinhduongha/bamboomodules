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
        public static void ConfigureAccountAccount(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAccount>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_account_pkey");

                entity.ToTable("account_account");
                entity.HasIndex(e => e.AccountType, "account_account__account_type_index");
                entity.HasIndex(e => e.TenantId, "account_account_company_id_index");
                entity.HasIndex(e => new { e.TenantId, e.Code }, "account_account_code_company_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.AccountType).HasColumnName("account_type");
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.CodeStore)
                    .HasColumnType("jsonb")
                    .HasColumnName("code_store");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.Deprecated).HasColumnName("deprecated");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.IncludeInitialBalance).HasColumnName("include_initial_balance");
                entity.Property(e => e.InternalGroup).HasColumnName("internal_group");
                entity.Property(e => e.IsOffBalance).HasColumnName("is_off_balance");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.NonTrade).HasColumnName("non_trade");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.Reconcile).HasColumnName("reconcile");
                entity.Property(e => e.RootId).HasColumnName("root_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_account_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_account_create_uid_fkey");

                entity.HasOne<ResCurrency>().WithMany()
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_account_currency_id_fkey");

                entity.HasOne(d => d.Group).WithMany(p => p.AccountAccounts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_account_group_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.AccountAccounts)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_account_message_main_attachment_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_account_write_uid_fkey");

                // modelBuilder.SharedTypeEntity<Dictionary<string, object>>("AccountAccountAccountTag", builder =>
                // {
                //     builder.Property<Guid>("AccountAccountId");
                //     builder.Property<long>("AccountAccountTagId");
                // });

                // No new tables
                //entity.HasMany(d => d.AccountAccountTags).WithMany(p => p.AccountAccounts)
                entity.HasMany<AccountAccountTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountAccountTag",
                        r => r.HasOne<AccountAccountTag>().WithMany()
                            .HasForeignKey("AccountAccountTagId")
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_account_account_tag_account_account_tag_id_fkey"),
                        l => l.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountAccountId")
                            .HasConstraintName("account_account_account_tag_account_account_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountAccountId", "AccountAccountTagId").HasName("account_account_account_tag_pkey");
                            j.ToTable("account_account_account_tag");
                            j.HasIndex(new[] { "AccountAccountTagId", "AccountAccountId" }, "account_account_account_tag_account_account_tag_id_account__idx");
                            j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                            j.IndexerProperty<Guid>("AccountAccountTagId").HasColumnName("account_account_tag_id");
                        });

                //entity.HasMany(d => d.AccountJournals).WithMany(p => p.AccountAccounts)
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountAccountJournalRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_account_account_journal_rel_account_journal_id_fkey"),
                        l => l.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountAccountId")
                            .HasConstraintName("account_account_account_journal_rel_account_account_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountAccountId", "AccountJournalId").HasName("account_account_account_journal_rel_pkey");
                            j.ToTable("account_account_account_journal_rel");
                            j.HasIndex(new[] { "AccountJournalId", "AccountAccountId" }, "account_account_account_journ_account_journal_id_account_ac_idx");
                            j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                            j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                        });

                //entity.HasMany(d => d.ResCompanies).WithMany(p => p.AccountAccounts)
                entity.HasMany(d => d.ResCompanies).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountResCompanyRel",
                        r => r.HasOne<ResCompany>().WithMany()
                            .HasForeignKey("TenantId")
                            .HasConstraintName("account_account_res_company_rel_res_company_id_fkey"),
                        l => l.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountAccountId")
                            .HasConstraintName("account_account_res_company_rel_account_account_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountAccountId", "TenantId").HasName("account_account_res_company_rel_pkey");
                            j.ToTable("account_account_res_company_rel");
                            j.HasIndex(new[] { "TenantId", "AccountAccountId" }, "account_account_res_company_r_res_company_id_account_accoun_idx");
                            j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                            j.IndexerProperty<Guid>("TenantId").HasColumnName("res_company_id");
                        });

                //entity.HasMany(d => d.Taxes).WithMany(p => p.Accounts)
                entity.HasMany<AccountTax>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountTaxDefaultRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("TaxId")
                            .HasConstraintName("account_account_tax_default_rel_tax_id_fkey"),
                        l => l.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountId")
                            .HasConstraintName("account_account_tax_default_rel_account_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountId", "TaxId").HasName("account_account_tax_default_rel_pkey");
                            j.ToTable("account_account_tax_default_rel");
                            j.HasIndex(new[] { "TaxId", "AccountId" }, "account_account_tax_default_rel_tax_id_account_id_idx");
                        });

                //TODO: RELATION CHECK
                //entity.HasMany(d => d.Taxes).WithMany(p => p.Accounts)
                entity.HasMany(d => d.Taxes).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountTaxDefaultRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("TaxId")
                            .HasConstraintName("account_account_tax_default_rel_tax_id_fkey"),
                        l => l.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountId")
                            .HasConstraintName("account_account_tax_default_rel_account_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountId", "TaxId").HasName("account_account_tax_default_rel_pkey");
                            j.ToTable("account_account_tax_default_rel");
                            j.HasIndex(new[] { "TaxId", "AccountId" }, "account_account_tax_default_rel_tax_id_account_id_idx");
                            j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                            j.IndexerProperty<Guid>("TaxId").HasColumnName("tax_id");
                        });
            });
        }
    }
}