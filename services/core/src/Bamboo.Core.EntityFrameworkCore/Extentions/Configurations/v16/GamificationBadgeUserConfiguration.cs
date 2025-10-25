using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureGamificationBadgeUser(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<GamificationBadgeUser>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("gamification_badge_user_pkey");

                        entity.ToTable("gamification_badge_user");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.BadgeId, "gamification_badge_user__badge_id_index");

                        entity.HasIndex(e => e.EmployeeId, "gamification_badge_user__employee_id_index");

                        entity.HasIndex(e => e.UserId, "gamification_badge_user__user_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BadgeId).HasColumnName("badge_id");
                        entity.Property(e => e.ChallengeId).HasColumnName("challenge_id");
                        entity.Property(e => e.Comment).HasColumnName("comment");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.Level).HasColumnName("level");
                        entity.Property(e => e.SenderId).HasColumnName("sender_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Badge).WithMany(p => p.GamificationBadgeUser)
                            .HasForeignKey(d => d.BadgeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("gamification_badge_user_badge_id_fkey");

                        entity.HasOne(d => d.Challenge).WithMany(p => p.GamificationBadgeUser)
                            .HasForeignKey(d => d.ChallengeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_badge_user_challenge_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.GamificationBadgeUserCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_badge_user_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_badge_user_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.GamificationBadgeUser)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_badge_user_employee_id_fkey");

                        // entity.HasOne(d => d.Sender).WithMany(p => p.GamificationBadgeUserSender) .HasForeignKey(d => d.SenderId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_badge_user_sender_id_fkey");
                        entity.HasOne(d => d.Sender).WithMany()
                            .HasForeignKey(d => d.SenderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_badge_user_sender_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.GamificationBadgeUserUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("gamification_badge_user_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("gamification_badge_user_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.GamificationBadgeUserWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_badge_user_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_badge_user_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}