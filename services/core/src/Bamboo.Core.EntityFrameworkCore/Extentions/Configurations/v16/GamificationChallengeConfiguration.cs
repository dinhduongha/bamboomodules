using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("gamification_challenge");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ChallengeCategory).HasColumnName("challenge_category");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.EndDate).HasColumnName("end_date");
                        entity.Property(e => e.LastReportDate).HasColumnName("last_report_date");
                        entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.NextReportDate).HasColumnName("next_report_date");
                        entity.Property(e => e.Period).HasColumnName("period");
                        entity.Property(e => e.RemindUpdateDelay).HasColumnName("remind_update_delay");
                        entity.Property(e => e.ReportMessageFrequency).HasColumnName("report_message_frequency");
                        entity.Property(e => e.ReportMessageGroupId).HasColumnName("report_message_group_id");
                        entity.Property(e => e.ReportTemplateId).HasColumnName("report_template_id");
                        entity.Property(e => e.RewardFailure).HasColumnName("reward_failure");
                        entity.Property(e => e.RewardFirstId).HasColumnName("reward_first_id");
                        entity.Property(e => e.RewardId).HasColumnName("reward_id");
                        entity.Property(e => e.RewardRealtime).HasColumnName("reward_realtime");
                        entity.Property(e => e.RewardSecondId).HasColumnName("reward_second_id");
                        entity.Property(e => e.RewardThirdId).HasColumnName("reward_third_id");
                        entity.Property(e => e.StartDate).HasColumnName("start_date");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.UserDomain).HasColumnName("user_domain");
                        entity.Property(e => e.VisibilityMode).HasColumnName("visibility_mode");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.GamificationChallengeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_challenge_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_create_uid_fkey");

                        // entity.HasOne(d => d.Manager).WithMany(p => p.GamificationChallengeManager) .HasForeignKey(d => d.ManagerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_challenge_manager_id_fkey");
                        entity.HasOne(d => d.Manager).WithMany()
                            .HasForeignKey(d => d.ManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_manager_id_fkey");

                        entity.HasOne(d => d.ReportMessageGroup).WithMany(p => p.GamificationChallenge)
                            .HasForeignKey(d => d.ReportMessageGroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_report_message_group_id_fkey");

                        entity.HasOne(d => d.ReportTemplate).WithMany(p => p.GamificationChallenge)
                            .HasForeignKey(d => d.ReportTemplateId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("gamification_challenge_report_template_id_fkey");

                        entity.HasOne(d => d.RewardFirst).WithMany(p => p.GamificationChallengeRewardFirst)
                            .HasForeignKey(d => d.RewardFirstId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_reward_first_id_fkey");

                        entity.HasOne(d => d.Reward).WithMany(p => p.GamificationChallengeReward)
                            .HasForeignKey(d => d.RewardId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_reward_id_fkey");

                        entity.HasOne(d => d.RewardSecond).WithMany(p => p.GamificationChallengeRewardSecond)
                            .HasForeignKey(d => d.RewardSecondId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_reward_second_id_fkey");

                        entity.HasOne(d => d.RewardThird).WithMany(p => p.GamificationChallengeRewardThird)
                            .HasForeignKey(d => d.RewardThirdId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_reward_third_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.GamificationChallengeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_challenge_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.GamificationChallenge)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "GamificationChallengeUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("gamification_challenge_users_rel_res_users_id_fkey"),
                                l => l.HasOne<GamificationChallenge>().WithMany()
                                    .HasForeignKey("GamificationChallengeId")
                                    .HasConstraintName("gamification_challenge_users_rel_gamification_challenge_id_fkey"),
                                j =>
                                {
                                    j.HasKey("GamificationChallengeId", "ResUsersId").HasName("gamification_challenge_users_rel_pkey");
                                    j.ToTable("gamification_challenge_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "GamificationChallengeId" }, "gamification_challenge_users__res_users_id_gamification_cha_idx");
                                    j.IndexerProperty<Guid>("GamificationChallengeId").HasColumnName("gamification_challenge_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                        // entity.HasMany(d => d.ResUsersNavigation).WithMany(p => p.GamificationChallengeNavigation)
                        entity.HasMany(d => d.ResUsersNavigation).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "GamificationInvitedUserIdsRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("gamification_invited_user_ids_rel_res_users_id_fkey"),
                                l => l.HasOne<GamificationChallenge>().WithMany()
                                    .HasForeignKey("GamificationChallengeId")
                                    .HasConstraintName("gamification_invited_user_ids_re_gamification_challenge_id_fkey"),
                                j =>
                                {
                                    j.HasKey("GamificationChallengeId", "ResUsersId").HasName("gamification_invited_user_ids_rel_pkey");
                                    j.ToTable("gamification_invited_user_ids_rel");
                                    j.HasIndex(new[] { "ResUsersId", "GamificationChallengeId" }, "gamification_invited_user_ids_res_users_id_gamification_cha_idx");
                                    j.IndexerProperty<Guid>("GamificationChallengeId").HasColumnName("gamification_challenge_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}