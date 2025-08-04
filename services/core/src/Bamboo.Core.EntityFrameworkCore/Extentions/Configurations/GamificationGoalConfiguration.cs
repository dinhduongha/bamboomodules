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
        public static void ConfigureGamificationGoal(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationGoal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_goal_pkey");

                entity.ToTable("gamification_goal", tb => tb.HasComment("Gamification Goal"));

                entity.HasIndex(e => e.ChallengeId, "gamification_goal_challenge_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ChallengeId)
                    .HasComment("Challenge")
                    .HasColumnName("challenge_id");
                entity.Property(e => e.Closed)
                    .HasComment("Closed goal")
                    .HasColumnName("closed");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Current)
                    .HasComment("Current Value")
                    .HasColumnName("current");
                entity.Property(e => e.DefinitionId)
                    .HasComment("Goal Definition")
                    .HasColumnName("definition_id");
                entity.Property(e => e.EndDate)
                    .HasComment("End Date")
                    .HasColumnName("end_date");
                entity.Property(e => e.LastUpdate)
                    .HasComment("Last Update")
                    .HasColumnName("last_update");
                entity.Property(e => e.LineId)
                    .HasComment("Challenge Line")
                    .HasColumnName("line_id");
                entity.Property(e => e.RemindUpdateDelay)
                    .HasComment("Remind delay")
                    .HasColumnName("remind_update_delay");
                entity.Property(e => e.StartDate)
                    .HasComment("Start Date")
                    .HasColumnName("start_date");
                entity.Property(e => e.State)
                    .HasComment("State")
                    .HasColumnType("character varying")
                    .HasColumnName("state");
                entity.Property(e => e.TargetGoal)
                    .HasComment("To Reach")
                    .HasColumnName("target_goal");
                entity.Property(e => e.ToUpdate)
                    .HasComment("To update")
                    .HasColumnName("to_update");
                entity.Property(e => e.UserId)
                    .HasComment("User")
                    .HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Challenge).WithMany(p => p.GamificationGoals)
                    .HasForeignKey(d => d.ChallengeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_challenge_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_create_uid_fkey");

                entity.HasOne(d => d.Definition).WithMany(p => p.GamificationGoals)
                    .HasForeignKey(d => d.DefinitionId)
                    .HasConstraintName("gamification_goal_definition_id_fkey");

                entity.HasOne(d => d.Line).WithMany(p => p.GamificationGoals)
                    .HasForeignKey(d => d.LineId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("gamification_goal_line_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("gamification_goal_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_write_uid_fkey");
            });
        }
    }
}