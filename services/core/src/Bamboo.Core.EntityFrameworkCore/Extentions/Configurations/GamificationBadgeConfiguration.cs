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
        public static void ConfigureGamificationBadge(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationBadge>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_badge_pkey");

                entity.ToTable("gamification_badge", tb => tb.HasComment("Gamification Badge"));

                entity.HasIndex(e => e.IsPublished, "gamification_badge_is_published_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active)
                    .HasComment("Active")
                    .HasColumnName("active");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasComment("Description")
                    .HasColumnType("jsonb")
                    .HasColumnName("description");
                entity.Property(e => e.IsPublished)
                    .HasComment("Is Published")
                    .HasColumnName("is_published");
                entity.Property(e => e.Level)
                    .HasComment("Forum Badge Level")
                    .HasColumnType("character varying")
                    .HasColumnName("level");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasComment("Badge")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.RuleAuth)
                    .HasComment("Allowance to Grant")
                    .HasColumnType("character varying")
                    .HasColumnName("rule_auth");
                entity.Property(e => e.RuleMax)
                    .HasComment("Monthly Limited Sending")
                    .HasColumnName("rule_max");
                entity.Property(e => e.RuleMaxNumber)
                    .HasComment("Limitation Number")
                    .HasColumnName("rule_max_number");
                entity.Property(e => e.SurveyId)
                    .HasComment("Survey")
                    .HasColumnName("survey_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_create_uid_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Survey).WithMany(p => p.GamificationBadges)
                    .HasForeignKey(d => d.SurveyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_survey_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_write_uid_fkey");

                entity.HasMany(d => d.Badge1s).WithMany(p => p.Badge2s)
                    .UsingEntity<Dictionary<string, object>>(
                        "GamificationBadgeRuleBadgeRel",
                        r => r.HasOne<GamificationBadge>().WithMany()
                            .HasForeignKey("Badge1Id")
                            .HasConstraintName("gamification_badge_rule_badge_rel_badge1_id_fkey"),
                        l => l.HasOne<GamificationBadge>().WithMany()
                            .HasForeignKey("Badge2Id")
                            .HasConstraintName("gamification_badge_rule_badge_rel_badge2_id_fkey"),
                        j =>
                        {
                            j.HasKey("Badge1Id", "Badge2Id").HasName("gamification_badge_rule_badge_rel_pkey");
                            j.ToTable("gamification_badge_rule_badge_rel", tb => tb.HasComment("RELATION BETWEEN gamification_badge AND gamification_badge"));
                            j.HasIndex(new[] { "Badge2Id", "Badge1Id" }, "gamification_badge_rule_badge_rel_badge2_id_badge1_id_idx");
                            j.IndexerProperty<Guid>("Badge1Id").HasColumnName("badge1_id");
                            j.IndexerProperty<Guid>("Badge2Id").HasColumnName("badge2_id");
                        });

                entity.HasMany(d => d.Badge2s).WithMany(p => p.Badge1s)
                    .UsingEntity<Dictionary<string, object>>(
                        "GamificationBadgeRuleBadgeRel",
                        r => r.HasOne<GamificationBadge>().WithMany()
                            .HasForeignKey("Badge2Id")
                            .HasConstraintName("gamification_badge_rule_badge_rel_badge2_id_fkey"),
                        l => l.HasOne<GamificationBadge>().WithMany()
                            .HasForeignKey("Badge1Id")
                            .HasConstraintName("gamification_badge_rule_badge_rel_badge1_id_fkey"),
                        j =>
                        {
                            j.HasKey("Badge1Id", "Badge2Id").HasName("gamification_badge_rule_badge_rel_pkey");
                            j.ToTable("gamification_badge_rule_badge_rel", tb => tb.HasComment("RELATION BETWEEN gamification_badge AND gamification_badge"));
                            j.HasIndex(new[] { "Badge2Id", "Badge1Id" }, "gamification_badge_rule_badge_rel_badge2_id_badge1_id_idx");
                            j.IndexerProperty<Guid>("Badge1Id").HasColumnName("badge1_id");
                            j.IndexerProperty<Guid>("Badge2Id").HasColumnName("badge2_id");
                        });

                entity.HasMany(d => d.GamificationGoalDefinitions).WithMany(p => p.GamificationBadges)
                    .UsingEntity<Dictionary<string, object>>(
                        "BadgeUnlockedDefinitionRel",
                        r => r.HasOne<GamificationGoalDefinition>().WithMany()
                            .HasForeignKey("GamificationGoalDefinitionId")
                            .HasConstraintName("badge_unlocked_definition_rel_gamification_goal_definition_fkey"),
                        l => l.HasOne<GamificationBadge>().WithMany()
                            .HasForeignKey("GamificationBadgeId")
                            .HasConstraintName("badge_unlocked_definition_rel_gamification_badge_id_fkey"),
                        j =>
                        {
                            j.HasKey("GamificationBadgeId", "GamificationGoalDefinitionId").HasName("badge_unlocked_definition_rel_pkey");
                            j.ToTable("badge_unlocked_definition_rel", tb => tb.HasComment("RELATION BETWEEN gamification_badge AND gamification_goal_definition"));
                            j.HasIndex(new[] { "GamificationGoalDefinitionId", "GamificationBadgeId" }, "badge_unlocked_definition_rel_gamification_goal_definition__idx");
                            j.IndexerProperty<Guid>("GamificationBadgeId").HasColumnName("gamification_badge_id");
                            j.IndexerProperty<Guid>("GamificationGoalDefinitionId").HasColumnName("gamification_goal_definition_id");
                        });

                entity.HasMany(d => d.ResUsers).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "RelBadgeAuthUser",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("ResUsersId")
                            .HasConstraintName("rel_badge_auth_users_res_users_id_fkey"),
                        l => l.HasOne<GamificationBadge>().WithMany()
                            .HasForeignKey("GamificationBadgeId")
                            .HasConstraintName("rel_badge_auth_users_gamification_badge_id_fkey"),
                        j =>
                        {
                            j.HasKey("GamificationBadgeId", "ResUsersId").HasName("rel_badge_auth_users_pkey");
                            j.ToTable("rel_badge_auth_users", tb => tb.HasComment("RELATION BETWEEN gamification_badge AND res_users"));
                            j.HasIndex(new[] { "ResUsersId", "GamificationBadgeId" }, "rel_badge_auth_users_res_users_id_gamification_badge_id_idx");
                            j.IndexerProperty<Guid>("GamificationBadgeId").HasColumnName("gamification_badge_id");
                            j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                        });
            });
        }
    }
}