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
        public static void ConfigureAccountResequenceWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountResequenceWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_resequence_wizard_pkey");

                entity.ToTable("account_resequence_wizard");

                entity.HasIndex(e => e.TenantId, "account_resequence_wizard_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.FirstDate).HasColumnName("first_date");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.Ordering).HasColumnName("ordering");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_resequence_wizard_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_resequence_wizard_write_uid_fkey");

                //entity.HasMany(d => d.AccountMoves).WithMany(p => p.AccountResequenceWizards)
                entity.HasMany<AccountMove>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountMoveAccountResequenceWizardRel",
                        r => r.HasOne<AccountMove>().WithMany()
                            .HasForeignKey("AccountMoveId")
                            .HasConstraintName("account_move_account_resequence_wizard_rel_account_move_id_fkey"),
                        l => l.HasOne<AccountResequenceWizard>().WithMany()
                            .HasForeignKey("AccountResequenceWizardId")
                            .HasConstraintName("account_move_account_resequen_account_resequence_wizard_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountResequenceWizardId", "AccountMoveId").HasName("account_move_account_resequence_wizard_rel_pkey");
                            j.ToTable("account_move_account_resequence_wizard_rel");
                            j.HasIndex(new[] { "AccountMoveId", "AccountResequenceWizardId" }, "account_move_account_resequen_account_move_id_account_reseq_idx");
                            j.IndexerProperty<Guid>("AccountResequenceWizardId").HasColumnName("account_resequence_wizard_id");
                            j.IndexerProperty<Guid>("AccountMoveId").HasColumnName("account_move_id");
                        });
            });
        }
    }
}