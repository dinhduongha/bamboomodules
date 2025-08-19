using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureGamificationBadge(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<GamificationBadge>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("gamification_badge_pkey");

            entity.ToTable("gamification_badge");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.IsPublished, "gamification_badge_is_published_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Description)
                .HasColumnType("jsonb")
                .HasColumnName("description");
            entity.Property(e => e.IsPublished).HasColumnName("is_published");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.RuleAuth).HasColumnName("rule_auth");
            entity.Property(e => e.RuleMax).HasColumnName("rule_max");
            entity.Property(e => e.RuleMaxNumber).HasColumnName("rule_max_number");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.GamificationBadgeCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gamification_badge_create_uid_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.GamificationBadge)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gamification_badge_message_main_attachment_id_fkey");

            entity.HasOne(d => d.Survey).WithMany(p => p.GamificationBadge)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gamification_badge_survey_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.GamificationBadgeWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gamification_badge_write_uid_fkey");

            // entity.HasMany(d => d.Badge1).WithMany(p => p.Badge2)
            entity.HasMany(d => d.Badge1).WithMany(p => p.Badge2)
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
                        j.ToTable("gamification_badge_rule_badge_rel");
                        j.HasIndex(new[] { "Badge2Id", "Badge1Id" }, "gamification_badge_rule_badge_rel_badge2_id_badge1_id_idx");
                        j.IndexerProperty<Guid>("Badge1Id").HasColumnName("badge1_id");
                        j.IndexerProperty<Guid>("Badge2Id").HasColumnName("badge2_id");
                    });

            // entity.HasMany(d => d.Badge2).WithMany(p => p.Badge1)
            entity.HasMany(d => d.Badge2).WithMany(p => p.Badge1)
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
                        j.ToTable("gamification_badge_rule_badge_rel");
                        j.HasIndex(new[] { "Badge2Id", "Badge1Id" }, "gamification_badge_rule_badge_rel_badge2_id_badge1_id_idx");
                        j.IndexerProperty<Guid>("Badge1Id").HasColumnName("badge1_id");
                        j.IndexerProperty<Guid>("Badge2Id").HasColumnName("badge2_id");
                    });

            // entity.HasMany(d => d.GamificationGoalDefinition).WithMany(p => p.GamificationBadge)
            entity.HasMany(d => d.GamificationGoalDefinition).WithMany(p => p.GamificationBadge)
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
                        j.ToTable("badge_unlocked_definition_rel");
                        j.HasIndex(new[] { "GamificationGoalDefinitionId", "GamificationBadgeId" }, "badge_unlocked_definition_rel_gamification_goal_definition__idx");
                        j.IndexerProperty<Guid>("GamificationBadgeId").HasColumnName("gamification_badge_id");
                        j.IndexerProperty<Guid>("GamificationGoalDefinitionId").HasColumnName("gamification_goal_definition_id");
                    });

            // entity.HasMany(d => d.ResUsers).WithMany(p => p.GamificationBadge)
            entity.HasMany(d => d.ResUsers).WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "RelBadgeAuthUsers",
                    r => r.HasOne<ResUsers>().WithMany()
                        .HasForeignKey("ResUsersId")
                        .HasConstraintName("rel_badge_auth_users_res_users_id_fkey"),
                    l => l.HasOne<GamificationBadge>().WithMany()
                        .HasForeignKey("GamificationBadgeId")
                        .HasConstraintName("rel_badge_auth_users_gamification_badge_id_fkey"),
                    j =>
                    {
                        j.HasKey("GamificationBadgeId", "ResUsersId").HasName("rel_badge_auth_users_pkey");
                        j.ToTable("rel_badge_auth_users");
                        j.HasIndex(new[] { "ResUsersId", "GamificationBadgeId" }, "rel_badge_auth_users_res_users_id_gamification_badge_id_idx");
                        j.IndexerProperty<Guid>("GamificationBadgeId").HasColumnName("gamification_badge_id");
                        j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                    });
            });
        }
    }
}