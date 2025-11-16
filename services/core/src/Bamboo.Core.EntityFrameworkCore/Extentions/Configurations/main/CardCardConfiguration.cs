using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCardCard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CardCard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("card_card_pkey");

                        entity.ToTable("card_card");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CampaignId, "card_card__campaign_id_index");

                        entity.HasIndex(e => new { e.CampaignId, e.ResId }, "card_card_campaign_record_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.RequiresSync).HasColumnName("requires_sync");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.ShareStatus).HasColumnName("share_status");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Campaign).WithMany(p => p.CardCard)
                            .HasForeignKey(d => d.CampaignId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("card_card_campaign_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CardCardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("card_card_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("card_card_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CardCardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("card_card_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("card_card_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}