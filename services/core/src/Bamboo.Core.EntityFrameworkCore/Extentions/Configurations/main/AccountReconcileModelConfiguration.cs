using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CanBeProposed).HasColumnName("can_be_proposed");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.MappedPartnerId).HasColumnName("mapped_partner_id");
                        entity.Property(e => e.MatchAmount).HasColumnName("match_amount");
                        entity.Property(e => e.MatchAmountMax).HasColumnName("match_amount_max");
                        entity.Property(e => e.MatchAmountMin).HasColumnName("match_amount_min");
                        entity.Property(e => e.MatchLabel).HasColumnName("match_label");
                        entity.Property(e => e.MatchLabelParam).HasColumnName("match_label_param");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.NextActivityTypeId).HasColumnName("next_activity_type_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Trigger).HasColumnName("trigger");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountReconcileModel) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_reconcile_model_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_reconcile_model_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountReconcileModelCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_reconcile_model_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_reconcile_model_create_uid_fkey");

                        // entity.HasOne(d => d.MappedPartner).WithMany(p => p.AccountReconcileModel) .HasForeignKey(d => d.MappedPartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_reconcile_model_mapped_partner_id_fkey");
                        entity.HasOne(d => d.MappedPartner).WithMany()
                            .HasForeignKey(d => d.MappedPartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_reconcile_model_mapped_partner_id_fkey");

                        entity.HasOne(d => d.NextActivityType).WithMany(p => p.AccountReconcileModel)
                            .HasForeignKey(d => d.NextActivityTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_reconcile_model_next_activity_type_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountReconcileModelWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_reconcile_model_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_reconcile_model_write_uid_fkey");

                        // entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountReconcileModel)
                        entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountReconcileModel)
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

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.AccountReconcileModelNavigation)
                        entity.HasMany(d => d.ResPartner).WithMany()
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

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}