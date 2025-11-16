using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("gamification_challenge_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ChallengeId, "gamification_challenge_line__challenge_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ChallengeId).HasColumnName("challenge_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefinitionId).HasColumnName("definition_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TargetGoal).HasColumnName("target_goal");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Challenge).WithMany(p => p.GamificationChallengeLine)
                            .HasForeignKey(d => d.ChallengeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("gamification_challenge_line_challenge_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.GamificationChallengeLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_challenge_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_line_create_uid_fkey");

                        entity.HasOne(d => d.Definition).WithMany(p => p.GamificationChallengeLine)
                            .HasForeignKey(d => d.DefinitionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("gamification_challenge_line_definition_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.GamificationChallengeLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_challenge_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_challenge_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}