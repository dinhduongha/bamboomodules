using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResPartnerIap(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResPartnerIap>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_partner_iap_pkey");

                        entity.ToTable("res_partner_iap");

                        entity.HasIndex(e => e.PartnerId, "res_partner_iap_unique_partner_id").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IapEnrichInfo).HasColumnName("iap_enrich_info");
                        entity.Property(e => e.IapSearchDomain).HasColumnName("iap_search_domain");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResPartnerIapCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_iap_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_iap_create_uid_fkey");

                        // entity.HasOne(d => d.Partner).WithOne(p => p.ResPartnerIap) .HasForeignKey<ResPartnerIap>(d => d.PartnerId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("res_partner_iap_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithOne(p => p.ResPartnerIap)
                            .HasForeignKey<ResPartnerIap>(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("res_partner_iap_partner_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResPartnerIapWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_iap_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_iap_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}