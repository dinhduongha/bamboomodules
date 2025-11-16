using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureL10nLatamPaymentRegisterCheck(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<L10nLatamPaymentRegisterCheck>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("l10n_latam_payment_register_check_pkey");

                        entity.ToTable("l10n_latam_payment_register_check");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.BankId).HasColumnName("bank_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IssuerVat).HasColumnName("issuer_vat");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
                        entity.Property(e => e.PaymentRegisterId).HasColumnName("payment_register_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Bank).WithMany(p => p.L10nLatamPaymentRegisterCheck)
                            .HasForeignKey(d => d.BankId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_payment_register_check_bank_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.L10nLatamPaymentRegisterCheckCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_payment_register_check_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_payment_register_check_create_uid_fkey");

                        entity.HasOne(d => d.PaymentRegister).WithMany(p => p.L10nLatamPaymentRegisterCheck)
                            .HasForeignKey(d => d.PaymentRegisterId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("l10n_latam_payment_register_check_payment_register_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.L10nLatamPaymentRegisterCheckWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("l10n_latam_payment_register_check_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("l10n_latam_payment_register_check_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}