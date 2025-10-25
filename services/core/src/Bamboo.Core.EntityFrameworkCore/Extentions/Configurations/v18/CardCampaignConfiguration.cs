using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureCardCampaign(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CardCampaign>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("card_campaign_pkey");

                        entity.ToTable("card_campaign");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CardTemplateId).HasColumnName("card_template_id");
                        entity.Property(e => e.ContentButton).HasColumnName("content_button");
                        entity.Property(e => e.ContentHeader).HasColumnName("content_header");
                        entity.Property(e => e.ContentHeaderColor).HasColumnName("content_header_color");
                        entity.Property(e => e.ContentHeaderDyn).HasColumnName("content_header_dyn");
                        entity.Property(e => e.ContentHeaderPath).HasColumnName("content_header_path");
                        entity.Property(e => e.ContentImage1Path).HasColumnName("content_image1_path");
                        entity.Property(e => e.ContentImage2Path).HasColumnName("content_image2_path");
                        entity.Property(e => e.ContentSection).HasColumnName("content_section");
                        entity.Property(e => e.ContentSectionDyn).HasColumnName("content_section_dyn");
                        entity.Property(e => e.ContentSectionPath).HasColumnName("content_section_path");
                        entity.Property(e => e.ContentSubHeader).HasColumnName("content_sub_header");
                        entity.Property(e => e.ContentSubHeaderColor).HasColumnName("content_sub_header_color");
                        entity.Property(e => e.ContentSubHeaderDyn).HasColumnName("content_sub_header_dyn");
                        entity.Property(e => e.ContentSubHeaderPath).HasColumnName("content_sub_header_path");
                        entity.Property(e => e.ContentSubSection1).HasColumnName("content_sub_section1");
                        entity.Property(e => e.ContentSubSection1Dyn).HasColumnName("content_sub_section1_dyn");
                        entity.Property(e => e.ContentSubSection1Path).HasColumnName("content_sub_section1_path");
                        entity.Property(e => e.ContentSubSection2).HasColumnName("content_sub_section2");
                        entity.Property(e => e.ContentSubSection2Dyn).HasColumnName("content_sub_section2_dyn");
                        entity.Property(e => e.ContentSubSection2Path).HasColumnName("content_sub_section2_path");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ImagePreview).HasColumnName("image_preview");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.LinkTrackerId).HasColumnName("link_tracker_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PostSuggestion).HasColumnName("post_suggestion");
                        entity.Property(e => e.PreviewRecordRef).HasColumnName("preview_record_ref");
                        entity.Property(e => e.RequestDescription).HasColumnName("request_description");
                        entity.Property(e => e.RequestTitle).HasColumnName("request_title");
                        entity.Property(e => e.ResModel).HasColumnName("res_model");
                        entity.Property(e => e.RewardMessage).HasColumnName("reward_message");
                        entity.Property(e => e.RewardTargetUrl).HasColumnName("reward_target_url");
                        entity.Property(e => e.TargetUrl).HasColumnName("target_url");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.CardTemplate).WithMany(p => p.CardCampaign)
                            .HasForeignKey(d => d.CardTemplateId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("card_campaign_card_template_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.CardCampaignCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("card_campaign_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("card_campaign_create_uid_fkey");

                        entity.HasOne(d => d.LinkTracker).WithMany(p => p.CardCampaign)
                            .HasForeignKey(d => d.LinkTrackerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("card_campaign_link_tracker_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.CardCampaignUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("card_campaign_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("card_campaign_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.CardCampaignWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("card_campaign_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("card_campaign_write_uid_fkey");

                        // entity.HasMany(d => d.CardCampaignTag).WithMany(p => p.CardCampaign)
                        entity.HasMany(d => d.CardCampaignTag).WithMany(p => p.CardCampaign)
                            .UsingEntity<Dictionary<string, object>>(
                                "CardCampaignCardCampaignTagRel",
                                r => r.HasOne<CardCampaignTag>().WithMany()
                                    .HasForeignKey("CardCampaignTagId")
                                    .HasConstraintName("card_campaign_card_campaign_tag_rel_card_campaign_tag_id_fkey"),
                                l => l.HasOne<CardCampaign>().WithMany()
                                    .HasForeignKey("CardCampaignId")
                                    .HasConstraintName("card_campaign_card_campaign_tag_rel_card_campaign_id_fkey"),
                                j =>
                                {
                                    j.HasKey("CardCampaignId", "CardCampaignTagId").HasName("card_campaign_card_campaign_tag_rel_pkey");
                                    j.ToTable("card_campaign_card_campaign_tag_rel");
                                    j.HasIndex(new[] { "CardCampaignTagId", "CardCampaignId" }, "card_campaign_card_campaign_t_card_campaign_tag_id_card_cam_idx");
                                    j.IndexerProperty<Guid>("CardCampaignId").HasColumnName("card_campaign_id");
                                    j.IndexerProperty<Guid>("CardCampaignTagId").HasColumnName("card_campaign_tag_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}