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
        public static void ConfigureGamificationChallengeLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationChallengeLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_challenge_line_pkey");

                entity.ToTable("gamification_challenge_line", tb => tb.HasComment("Gamification generic goal for challenge"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ChallengeId)
                    .HasComment("Challenge")
                    .HasColumnName("challenge_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.DefinitionId)
                    .HasComment("Goal Definition")
                    .HasColumnName("definition_id");
                entity.Property(e => e.Sequence)
                    .HasComment("Sequence")
                    .HasColumnName("sequence");
                entity.Property(e => e.TargetGoal)
                    .HasComment("Target Value to Reach")
                    .HasColumnName("target_goal");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Challenge).WithMany(p => p.GamificationChallengeLines)
                    .HasForeignKey(d => d.ChallengeId)
                    .HasConstraintName("gamification_challenge_line_challenge_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_line_create_uid_fkey");

                entity.HasOne(d => d.Definition).WithMany(p => p.GamificationChallengeLines)
                    .HasForeignKey(d => d.DefinitionId)
                    .HasConstraintName("gamification_challenge_line_definition_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_challenge_line_write_uid_fkey");
            });
        }
    }
}