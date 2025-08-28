using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureUtmCampaign(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<UtmCampaign>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("utm_campaign_pkey");

                        entity.ToTable("utm_campaign");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Name, "utm_campaign_unique_name").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AbTestingCompleted).HasColumnName("ab_testing_completed");
                        entity.Property(e => e.AbTestingScheduleDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("ab_testing_schedule_datetime");
                        entity.Property(e => e.AbTestingSmsWinnerSelection).HasColumnName("ab_testing_sms_winner_selection");
                        entity.Property(e => e.AbTestingWinnerMailingId).HasColumnName("ab_testing_winner_mailing_id");
                        entity.Property(e => e.AbTestingWinnerSelection).HasColumnName("ab_testing_winner_selection");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsAutoCampaign).HasColumnName("is_auto_campaign");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.StageId).HasColumnName("stage_id");
                        entity.Property(e => e.Title)
                            .HasColumnType("jsonb")
                            .HasColumnName("title");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AbTestingWinnerMailing).WithMany(p => p.UtmCampaign)
                            .HasForeignKey(d => d.AbTestingWinnerMailingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("utm_campaign_ab_testing_winner_mailing_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.UtmCampaign) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("utm_campaign_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("utm_campaign_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.UtmCampaignCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("utm_campaign_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("utm_campaign_create_uid_fkey");

                        entity.HasOne(d => d.Stage).WithMany(p => p.UtmCampaign)
                            .HasForeignKey(d => d.StageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("utm_campaign_stage_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.UtmCampaignUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("utm_campaign_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("utm_campaign_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.UtmCampaignWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("utm_campaign_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("utm_campaign_write_uid_fkey");

                        // entity.HasMany(d => d.Campaign).WithMany(p => p.Tag)
                        entity.HasMany(d => d.Campaign).WithMany(p => p.Tag)
                            .UsingEntity<Dictionary<string, object>>(
                                "UtmTagRel",
                                r => r.HasOne<UtmTag>().WithMany()
                                    .HasForeignKey("CampaignId")
                                    .HasConstraintName("utm_tag_rel_campaign_id_fkey"),
                                l => l.HasOne<UtmCampaign>().WithMany()
                                    .HasForeignKey("TagId")
                                    .HasConstraintName("utm_tag_rel_tag_id_fkey"),
                                j =>
                                {
                                    j.HasKey("TagId", "CampaignId").HasName("utm_tag_rel_pkey");
                                    j.ToTable("utm_tag_rel");
                                    j.HasIndex(new[] { "CampaignId", "TagId" }, "utm_tag_rel_campaign_id_tag_id_idx");
                                    j.IndexerProperty<Guid>("TagId").HasColumnName("tag_id");
                                    j.IndexerProperty<Guid>("CampaignId").HasColumnName("campaign_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}