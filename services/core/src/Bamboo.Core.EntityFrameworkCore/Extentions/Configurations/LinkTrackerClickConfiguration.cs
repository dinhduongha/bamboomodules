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
        public static void ConfigureLinkTrackerClick(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkTrackerClick>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("link_tracker_click_pkey");

                entity.ToTable("link_tracker_click", tb => tb.HasComment("Link Tracker Click"));

                entity.HasIndex(e => e.LinkId, "link_tracker_click_link_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CampaignId)
                    .HasComment("UTM Campaign")
                    .HasColumnName("campaign_id");
                entity.Property(e => e.CountryId)
                    .HasComment("Country")
                    .HasColumnName("country_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Ip)
                    .HasComment("Internet Protocol")
                    .HasColumnType("character varying")
                    .HasColumnName("ip");
                entity.Property(e => e.LinkId)
                    .HasComment("Link")
                    .HasColumnName("link_id");
                entity.Property(e => e.MailingTraceId)
                    .HasComment("Mail Statistics")
                    .HasColumnName("mailing_trace_id");
                entity.Property(e => e.MassMailingId)
                    .HasComment("Mass Mailing")
                    .HasColumnName("mass_mailing_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Campaign).WithMany(p => p.LinkTrackerClicks)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_click_campaign_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_click_country_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_click_create_uid_fkey");

                entity.HasOne(d => d.Link).WithMany(p => p.LinkTrackerClicks)
                    .HasForeignKey(d => d.LinkId)
                    .HasConstraintName("link_tracker_click_link_id_fkey");

                entity.HasOne(d => d.MailingTrace).WithMany(p => p.LinkTrackerClicks)
                    .HasForeignKey(d => d.MailingTraceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_click_mailing_trace_id_fkey");

                entity.HasOne(d => d.MassMailing).WithMany(p => p.LinkTrackerClicks)
                    .HasForeignKey(d => d.MassMailingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_click_mass_mailing_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("link_tracker_click_write_uid_fkey");
            });
        }
    }
}