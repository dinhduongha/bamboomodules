using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountResequenceWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_resequence_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_resequence_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountResequenceWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_resequence_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_resequence_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.AccountMove).WithMany(p => p.AccountResequenceWizard)
                        entity.HasMany(d => d.AccountMove).WithMany(p => p.AccountResequenceWizard)
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

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}