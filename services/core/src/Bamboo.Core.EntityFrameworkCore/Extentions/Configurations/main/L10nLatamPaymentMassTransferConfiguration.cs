using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureL10nLatamPaymentMassTransfer(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<L10nLatamPaymentMassTransfer>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("l10n_latam_payment_mass_transfer_pkey");

                        entity.ToTable("l10n_latam_payment_mass_transfer");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Communication).HasColumnName("communication");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DestinationJournalId).HasColumnName("destination_journal_id");
                        entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.L10nLatamPaymentMassTransferCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_payment_mass_transfer_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_payment_mass_transfer_create_uid_fkey");

                        entity.HasOne(d => d.DestinationJournal).WithMany(p => p.L10nLatamPaymentMassTransfer)
                            .HasForeignKey(d => d.DestinationJournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_payment_mass_transfer_destination_journal_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.L10nLatamPaymentMassTransferWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_payment_mass_transfer_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_payment_mass_transfer_write_uid_fkey");

                        // entity.HasMany(d => d.L10nLatamCheck).WithMany(p => p.Check)
                        entity.HasMany(d => d.L10nLatamCheck).WithMany(p => p.Check)
                            .UsingEntity<Dictionary<string, object>>(
                                "LatamTranferCheckReltransferId",
                                r => r.HasOne<L10nLatamCheck>().WithMany()
                                    .HasForeignKey("L10nLatamCheckId")
                                    .HasConstraintName("latam_tranfer_check_reltransfer_id_l10n_latam_check_id_fkey"),
                                l => l.HasOne<L10nLatamPaymentMassTransfer>().WithMany()
                                    .HasForeignKey("CheckId")
                                    .HasConstraintName("latam_tranfer_check_reltransfer_id_check_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CheckId", "L10nLatamCheckId").HasName("latam_tranfer_check_reltransfer_id_pkey");
                                    j.ToTable("latam_tranfer_check_reltransfer_id");
                                    j.HasIndex(new[] { "L10nLatamCheckId", "CheckId" }, "latam_tranfer_check_reltransfe_l10n_latam_check_id_check_id_idx");
                                    j.IndexerProperty<Guid>("CheckId").HasColumnName("check_id");
                                    j.IndexerProperty<Guid>("L10nLatamCheckId").HasColumnName("l10n_latam_check_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}