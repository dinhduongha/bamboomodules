using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
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

                entity.ToTable("link_tracker", tb => tb.HasComment("Link Tracker"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CampaignId)
                    .HasComment("Campaign")
                    .HasColumnName("campaign_id");
                entity.Property(e => e.Count)
                    .HasComment("Number of Clicks")
                    .HasColumnName("count");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Label)
                    .HasComment("Button label")
                    .HasColumnType("character varying")
                    .HasColumnName("label");
                entity.Property(e => e.MassMailingId)
                    .HasComment("Mass Mailing")
                    .HasColumnName("mass_mailing_id");
                entity.Property(e => e.MediumId)
                    .HasComment("Medium")
                    .HasColumnName("medium_id");
                entity.Property(e => e.SourceId)
                    .HasComment("Source")
                    .HasColumnName("source_id");
                entity.Property(e => e.Title)
                    .HasComment("Page Title")
                    .HasColumnType("character varying")
                    .HasColumnName("title");
                entity.Property(e => e.Url)
                    .HasComment("Target URL")
                    .HasColumnType("character varying")
                    .HasColumnName("url");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Campaign).WithMany(p => p.LinkTrackers)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_campaign_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_create_uid_fkey");

                entity.HasOne(d => d.MassMailing).WithMany(p => p.LinkTrackers)
                    .HasForeignKey(d => d.MassMailingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_mass_mailing_id_fkey");

                entity.HasOne(d => d.Medium).WithMany(p => p.LinkTrackers)
                    .HasForeignKey(d => d.MediumId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_medium_id_fkey");

                entity.HasOne(d => d.Source).WithMany()
                    .HasForeignKey(d => d.SourceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_source_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_write_uid_fkey");
            });
        }
    }
}