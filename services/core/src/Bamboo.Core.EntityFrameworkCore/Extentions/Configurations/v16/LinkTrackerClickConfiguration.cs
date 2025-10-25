using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("link_tracker_click");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CampaignId, "link_tracker_click__campaign_id_index").HasFilter("(campaign_id IS NOT NULL)");

                        entity.HasIndex(e => e.LinkId, "link_tracker_click__link_id_index");

                        entity.HasIndex(e => e.MailingTraceId, "link_tracker_click__mailing_trace_id_index").HasFilter("(mailing_trace_id IS NOT NULL)");

                        entity.HasIndex(e => e.MassMailingId, "link_tracker_click__mass_mailing_id_index").HasFilter("(mass_mailing_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Ip).HasColumnName("ip");
                        entity.Property(e => e.LinkId).HasColumnName("link_id");
                        entity.Property(e => e.MailingTraceId).HasColumnName("mailing_trace_id");
                        entity.Property(e => e.MassMailingId).HasColumnName("mass_mailing_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Campaign).WithMany(p => p.LinkTrackerClick)
                            .HasForeignKey(d => d.CampaignId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_click_campaign_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.LinkTrackerClick) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("link_tracker_click_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_click_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LinkTrackerClickCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("link_tracker_click_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_click_create_uid_fkey");

                        entity.HasOne(d => d.Link).WithMany(p => p.LinkTrackerClick)
                            .HasForeignKey(d => d.LinkId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("link_tracker_click_link_id_fkey");

                        entity.HasOne(d => d.MailingTrace).WithMany(p => p.LinkTrackerClick)
                            .HasForeignKey(d => d.MailingTraceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_click_mailing_trace_id_fkey");

                        entity.HasOne(d => d.MassMailing).WithMany(p => p.LinkTrackerClick)
                            .HasForeignKey(d => d.MassMailingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_click_mass_mailing_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LinkTrackerClickWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("link_tracker_click_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("link_tracker_click_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}