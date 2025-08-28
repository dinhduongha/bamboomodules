using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountEdiProxyClientUser(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountEdiProxyClientUser>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_edi_proxy_client_user_pkey");

                        entity.ToTable("account_edi_proxy_client_user");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => new { e.TenantId, e.ProxyType, e.EdiMode }, "account_edi_proxy_client_user_unique_active_company_proxy")
                            .IsUnique()
                            .HasFilter("(active = true)");

                        entity.HasIndex(e => new { e.EdiIdentification, e.ProxyType, e.EdiMode }, "account_edi_proxy_client_user_unique_active_edi_identification")
                            .IsUnique()
                            .HasFilter("(active = true)");

                        entity.HasIndex(e => e.IdClient, "account_edi_proxy_client_user_unique_id_client").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EdiIdentification).HasColumnName("edi_identification");
                        entity.Property(e => e.EdiMode).HasColumnName("edi_mode");
                        entity.Property(e => e.IdClient).HasColumnName("id_client");
                        entity.Property(e => e.PeppolVerificationCode).HasColumnName("peppol_verification_code");
                        entity.Property(e => e.PrivateKeyId).HasColumnName("private_key_id");
                        entity.Property(e => e.ProxyType).HasColumnName("proxy_type");
                        entity.Property(e => e.RefreshToken).HasColumnName("refresh_token");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountEdiProxyClientUser) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_edi_proxy_client_user_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_edi_proxy_client_user_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountEdiProxyClientUserCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_edi_proxy_client_user_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_edi_proxy_client_user_create_uid_fkey");

                        entity.HasOne(d => d.PrivateKey).WithMany(p => p.AccountEdiProxyClientUser)
                            .HasForeignKey(d => d.PrivateKeyId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_edi_proxy_client_user_private_key_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountEdiProxyClientUserWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_edi_proxy_client_user_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_edi_proxy_client_user_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}