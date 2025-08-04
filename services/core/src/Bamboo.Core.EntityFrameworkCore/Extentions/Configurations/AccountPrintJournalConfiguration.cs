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
        public static void ConfigureAccountPrintJournal(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountPrintJournal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_print_journal_pkey");

                entity.ToTable("account_print_journal");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AmountCurrency).HasColumnName("amount_currency");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateFrom).HasColumnName("date_from");
                entity.Property(e => e.DateTo).HasColumnName("date_to");
                entity.Property(e => e.SortSelection).HasColumnName("sort_selection");
                entity.Property(e => e.TargetMove).HasColumnName("target_move");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_print_journal_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_print_journal_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_print_journal_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountJournals).WithMany(p => p.AccountPrintJournals)
                //entity.HasMany(d => d.AccountJournals).WithMany()
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountJournalAccountPrintJournalRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_journal_account_print_journal_r_account_journal_id_fkey"),
                        l => l.HasOne<AccountPrintJournal>().WithMany()
                            .HasForeignKey("AccountPrintJournalId")
                            .HasConstraintName("account_journal_account_print_jou_account_print_journal_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountPrintJournalId", "AccountJournalId").HasName("account_journal_account_print_journal_rel_pkey");
                            j.ToTable("account_journal_account_print_journal_rel");
                            j.HasIndex(new[] { "AccountJournalId", "AccountPrintJournalId" }, "account_journal_account_print_account_journal_id_account_pr_idx");
                            j.IndexerProperty<Guid>("AccountPrintJournalId").HasColumnName("account_print_journal_id");
                            j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                        });
            });
        }
    }
}