using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePaymentToken(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PaymentToken>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("payment_token_pkey");

                        entity.ToTable("payment_token");

                        entity.HasIndex(e => e.TenantId, "payment_token__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AuthorizeProfile).HasColumnName("authorize_profile");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PaymentDetails).HasColumnName("payment_details");
                        entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
                        entity.Property(e => e.ProviderId).HasColumnName("provider_id");
                        entity.Property(e => e.ProviderRef).HasColumnName("provider_ref");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PaymentToken) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_token_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_token_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PaymentTokenCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_token_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_token_create_uid_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.PaymentToken) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("payment_token_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_token_partner_id_fkey");

                        entity.HasOne(d => d.PaymentMethod).WithMany(p => p.PaymentToken)
                            .HasForeignKey(d => d.PaymentMethodId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_token_payment_method_id_fkey");

                        entity.HasOne(d => d.Provider).WithMany(p => p.PaymentToken)
                            .HasForeignKey(d => d.ProviderId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("payment_token_provider_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PaymentTokenWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("payment_token_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("payment_token_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}