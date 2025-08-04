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
        public static void ConfigureAccountReconcileModelLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountReconcileModelLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_reconcile_model_line_pkey");

                entity.ToTable("account_reconcile_model_line");

                entity.HasIndex(e => e.AnalyticDistribution, "account_reconcile_model_line_analytic_distribution_gin_index").HasMethod("gin");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.Amount).HasColumnName("amount");
                entity.Property(e => e.AmountString).HasColumnName("amount_string");
                entity.Property(e => e.AmountType).HasColumnName("amount_type");
                entity.Property(e => e.AnalyticDistribution)
                    .HasColumnType("jsonb")
                    .HasColumnName("analytic_distribution");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ForceTaxIncluded).HasColumnName("force_tax_included");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.Label).HasColumnName("label");
                entity.Property(e => e.ModelId).HasColumnName("model_id");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Account).WithMany(p => p.AccountReconcileModelLines)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_reconcile_model_line_account_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_reconcile_model_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_reconcile_model_line_create_uid_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.AccountReconcileModelLines)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_reconcile_model_line_journal_id_fkey");

                entity.HasOne(d => d.Model).WithMany(p => p.AccountReconcileModelLines)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_reconcile_model_line_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_reconcile_model_line_write_uid_fkey");

                // TODO: CHECK RELATION
                //entity.HasMany(d => d.AccountTaxes).WithMany(p => p.AccountReconcileModelLines)
                entity.HasMany<AccountTax>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReconcileModelLineAccountTaxRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("AccountTaxId")
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_reconcile_model_line_account_tax_re_account_tax_id_fkey"),
                        l => l.HasOne<AccountReconcileModelLine>().WithMany()
                            .HasForeignKey("AccountReconcileModelLineId")
                            .HasConstraintName("account_reconcile_model_line__account_reconcile_model_line_fkey"),
                        j =>
                        {
                            j.HasKey("AccountReconcileModelLineId", "AccountTaxId").HasName("account_reconcile_model_line_account_tax_rel_pkey");
                            j.ToTable("account_reconcile_model_line_account_tax_rel");
                            j.HasIndex(new[] { "AccountTaxId", "AccountReconcileModelLineId" }, "account_reconcile_model_line__account_tax_id_account_reconc_idx");
                            j.IndexerProperty<Guid>("AccountReconcileModelLineId").HasColumnName("account_reconcile_model_line_id");
                            j.IndexerProperty<Guid>("AccountTaxId").HasColumnName("account_tax_id");
                        });
            });
        }
    }
}