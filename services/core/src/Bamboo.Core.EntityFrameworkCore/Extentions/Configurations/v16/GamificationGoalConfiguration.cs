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
        public static void ConfigureGamificationGoal(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<GamificationGoal>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("gamification_goal_pkey");

            entity.ToTable("gamification_goal");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.ChallengeId, "gamification_goal_challenge_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.ChallengeId).HasColumnName("challenge_id");
            entity.Property(e => e.Closed).HasColumnName("closed");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Current).HasColumnName("current");
            entity.Property(e => e.DefinitionId).HasColumnName("definition_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.LastUpdate).HasColumnName("last_update");
            entity.Property(e => e.LineId).HasColumnName("line_id");
            entity.Property(e => e.RemindUpdateDelay).HasColumnName("remind_update_delay");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.TargetGoal).HasColumnName("target_goal");
            entity.Property(e => e.ToUpdate).HasColumnName("to_update");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Challenge).WithMany(p => p.GamificationGoal)
                .HasForeignKey(d => d.ChallengeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gamification_goal_challenge_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.GamificationGoalCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gamification_goal_create_uid_fkey");

            entity.HasOne(d => d.Definition).WithMany(p => p.GamificationGoal)
                .HasForeignKey(d => d.DefinitionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("gamification_goal_definition_id_fkey");

            entity.HasOne(d => d.Line).WithMany(p => p.GamificationGoal)
                .HasForeignKey(d => d.LineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("gamification_goal_line_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.GamificationGoalUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("gamification_goal_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.GamificationGoalWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("gamification_goal_write_uid_fkey");
            });
        }
    }
}