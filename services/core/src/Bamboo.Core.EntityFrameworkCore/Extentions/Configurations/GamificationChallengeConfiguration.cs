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
        public static void ConfigureGamificationChallenge(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationChallenge>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_challenge_pkey");

                entity.ToTable("gamification_challenge", tb => tb.HasComment("Gamification Challenge"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ChallengeCategory)
                    .HasComment("Appears in")
                    .HasColumnType("character varying")
                    .HasColumnName("challenge_category");
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
                entity.Property(e => e.EndDate)
                    .HasComment("End Date")
                    .HasColumnName("end_date");
                entity.Property(e => e.LastReportDate)
                    .HasComment("Last Report Date")
                    .HasColumnName("last_report_date");
                entity.Property(e => e.ManagerId)
                    .HasComment("Responsible")
                    .HasColumnName("manager_id");
                entity.Property(e => e.MessageMainAttachmentId)
                    .HasComment("Main Attachment")
                    .HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Name)
                    .HasComment("Challenge Name")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.NextReportDate)
                    .HasComment("Next Report Date")
                    .HasColumnName("next_report_date");
                entity.Property(e => e.Period)
                    .HasComment("Periodicity")
                    .HasColumnType("character varying")
                    .HasColumnName("period");
                entity.Property(e => e.RemindUpdateDelay)
                    .HasComment("Non-updated manual goals will be reminded after")
                    .HasColumnName("remind_update_delay");
                entity.Property(e => e.ReportMessageFrequency)
                    .HasComment("Report Frequency")
                    .HasColumnType("character varying")
                    .HasColumnName("report_message_frequency");
                entity.Property(e => e.ReportMessageGroupId)
                    .HasComment("Send a copy to")
                    .HasColumnName("report_message_group_id");
                entity.Property(e => e.ReportTemplateId)
                    .HasComment("Report Template")
                    .HasColumnName("report_template_id");
                entity.Property(e => e.RewardFailure)
                    .HasComment("Reward Bests if not Succeeded?")
                    .HasColumnName("reward_failure");
                entity.Property(e => e.RewardFirstId)
                    .HasComment("For 1st user")
                    .HasColumnName("reward_first_id");
                entity.Property(e => e.RewardId)
                    .HasComment("For Every Succeeding User")
                    .HasColumnName("reward_id");
                entity.Property(e => e.RewardRealtime)
                    .HasComment("Reward as soon as every goal is reached")
                    .HasColumnName("reward_realtime");
                entity.Property(e => e.RewardSecondId)
                    .HasComment("For 2nd user")
                    .HasColumnName("reward_second_id");
                entity.Property(e => e.RewardThirdId)
                    .HasComment("For 3rd user")
                    .HasColumnName("reward_third_id");
                entity.Property(e => e.StartDate)
                    .HasComment("Start Date")
                    .HasColumnName("start_date");
                entity.Property(e => e.State)
                    .HasComment("State")
                    .HasColumnType("character varying")
                    .HasColumnName("state");
                entity.Property(e => e.UserDomain)
                    .HasComment("User domain")
                    .HasColumnType("character varying")
                    .HasColumnName("user_domain");
                entity.Property(e => e.VisibilityMode)
                    .HasComment("Display Mode")
                    .HasColumnType("character varying")
                    .HasColumnName("visibility_mode");
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
                    .HasConstraintName("gamification_challenge_create_uid_fkey");

                entity.HasOne(d => d.Manager).WithMany()
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_manager_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany()
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_message_main_attachment_id_fkey");

                entity.HasOne(d => d.ReportMessageGroup).WithMany(p => p.GamificationChallenges)
                    .HasForeignKey(d => d.ReportMessageGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_report_message_group_id_fkey");

                entity.HasOne(d => d.ReportTemplate).WithMany()
                    .HasForeignKey(d => d.ReportTemplateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gamification_challenge_report_template_id_fkey");

                entity.HasOne(d => d.RewardFirst).WithMany(p => p.GamificationChallengeRewardFirsts)
                    .HasForeignKey(d => d.RewardFirstId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_reward_first_id_fkey");

                entity.HasOne(d => d.Reward).WithMany(p => p.GamificationChallengeRewards)
                    .HasForeignKey(d => d.RewardId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_reward_id_fkey");

                entity.HasOne(d => d.RewardSecond).WithMany(p => p.GamificationChallengeRewardSeconds)
                    .HasForeignKey(d => d.RewardSecondId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_reward_second_id_fkey");

                entity.HasOne(d => d.RewardThird).WithMany(p => p.GamificationChallengeRewardThirds)
                    .HasForeignKey(d => d.RewardThirdId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_reward_third_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_write_uid_fkey");

                // TODO: multiple navigations
                entity.HasMany(d => d.ResUsers).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "GamificationChallengeUsersRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("ResUsersId")
                            .HasConstraintName("gamification_challenge_users_rel_res_users_id_fkey"),
                        l => l.HasOne<GamificationChallenge>().WithMany()
                            .HasForeignKey("GamificationChallengeId")
                            .HasConstraintName("gamification_challenge_users_rel_gamification_challenge_id_fkey"),
                        j =>
                        {
                            j.HasKey("GamificationChallengeId", "ResUsersId").HasName("gamification_challenge_users_rel_pkey");
                            j.ToTable("gamification_challenge_users_rel", tb => tb.HasComment("RELATION BETWEEN gamification_challenge AND res_users"));
                            j.HasIndex(new[] { "ResUsersId", "GamificationChallengeId" }, "gamification_challenge_users__res_users_id_gamification_cha_idx");
                            j.IndexerProperty<Guid>("GamificationChallengeId").HasColumnName("gamification_challenge_id");
                            j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                        });

                // TODO: multiple navigations
                entity.HasMany(d => d.ResUsersNavigation).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "GamificationInvitedUserIdsRel",
                        r => r.HasOne<ResUser>().WithMany()
                            .HasForeignKey("ResUsersId")
                            .HasConstraintName("gamification_invited_user_ids_rel_res_users_id_fkey"),
                        l => l.HasOne<GamificationChallenge>().WithMany()
                            .HasForeignKey("GamificationChallengeId")
                            .HasConstraintName("gamification_invited_user_ids_re_gamification_challenge_id_fkey"),
                        j =>
                        {
                            j.HasKey("GamificationChallengeId", "ResUsersId").HasName("gamification_invited_user_ids_rel_pkey");
                            j.ToTable("gamification_invited_user_ids_rel", tb => tb.HasComment("RELATION BETWEEN gamification_challenge AND res_users"));
                            j.HasIndex(new[] { "ResUsersId", "GamificationChallengeId" }, "gamification_invited_user_ids_res_users_id_gamification_cha_idx");
                            j.IndexerProperty<Guid>("GamificationChallengeId").HasColumnName("gamification_challenge_id");
                            j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                        });
            });
        }
    }
}