using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResPartnerAutocompleteSync(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResPartnerAutocompleteSync>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_partner_autocomplete_sync_pkey");

                        entity.ToTable("res_partner_autocomplete_sync");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.Synched).HasColumnName("synched");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResPartnerAutocompleteSyncCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_autocomplete_sync_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_autocomplete_sync_create_uid_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.ResPartnerAutocompleteSync) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("res_partner_autocomplete_sync_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("res_partner_autocomplete_sync_partner_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResPartnerAutocompleteSyncWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_autocomplete_sync_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_partner_autocomplete_sync_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}