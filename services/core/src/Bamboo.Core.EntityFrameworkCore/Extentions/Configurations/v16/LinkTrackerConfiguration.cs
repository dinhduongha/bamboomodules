using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureLinkTracker(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LinkTracker>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("link_tracker_pkey");

                        entity.ToTable("link_tracker");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CampaignId, "link_tracker__campaign_id_index").HasFilter("(campaign_id IS NOT NULL)");

                        entity.HasIndex(e => e.MediumId, "link_tracker__medium_id_index").HasFilter("(medium_id IS NOT NULL)");

                        entity.HasIndex(e => e.SourceId, "link_tracker__source_id_index").HasFilter("(source_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                        entity.Property(e => e.Count).HasColumnName("count");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Label).HasColumnName("label");
                        entity.Property(e => e.MassMailingId).HasColumnName("mass_mailing_id");
                        entity.Property(e => e.MediumId).HasColumnName("medium_id");
                        entity.Property(e => e.SourceId).HasColumnName("source_id");
                        entity.Property(e => e.Title).HasColumnName("title");
                        entity.Property(e => e.Url).HasColumnName("url");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Campaign).WithMany(p => p.LinkTracker)
                            .HasForeignKey(d => d.CampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_campaign_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LinkTrackerCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("link_tracker_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_create_uid_fkey");

                        entity.HasOne(d => d.MassMailing).WithMany(p => p.LinkTracker)
                            .HasForeignKey(d => d.MassMailingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_mass_mailing_id_fkey");

                        entity.HasOne(d => d.Medium).WithMany(p => p.LinkTracker)
                            .HasForeignKey(d => d.MediumId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_medium_id_fkey");

                        entity.HasOne(d => d.Source).WithMany(p => p.LinkTracker)
                            .HasForeignKey(d => d.SourceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_source_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LinkTrackerWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("link_tracker_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}