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
        public static void ConfigureGamificationBadgeUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationBadgeUser>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_badge_user_pkey");

                entity.ToTable("gamification_badge_user", tb => tb.HasComment("Gamification User Badge"));

                entity.HasIndex(e => e.BadgeId, "gamification_badge_user_badge_id_index");

                entity.HasIndex(e => e.EmployeeId, "gamification_badge_user_employee_id_index");

                entity.HasIndex(e => e.UserId, "gamification_badge_user_user_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.BadgeId)
                    .HasComment("Badge")
                    .HasColumnName("badge_id");
                entity.Property(e => e.ChallengeId)
                    .HasComment("Challenge")
                    .HasColumnName("challenge_id");
                entity.Property(e => e.Comment)
                    .HasComment("Comment")
                    .HasColumnName("comment");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.EmployeeId)
                    .HasComment("Employee")
                    .HasColumnName("employee_id");
                entity.Property(e => e.Level)
                    .HasComment("Badge Level")
                    .HasColumnType("character varying")
                    .HasColumnName("level");
                entity.Property(e => e.SenderId)
                    .HasComment("Sender")
                    .HasColumnName("sender_id");
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

                entity.HasOne(d => d.Badge).WithMany(p => p.GamificationBadgeUsers)
                    .HasForeignKey(d => d.BadgeId)
                    .HasConstraintName("gamification_badge_user_badge_id_fkey");

                entity.HasOne(d => d.Challenge).WithMany(p => p.GamificationBadgeUsers)
                    .HasForeignKey(d => d.ChallengeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_user_challenge_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_user_create_uid_fkey");

                entity.HasOne(d => d.Employee).WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_user_employee_id_fkey");

                entity.HasOne(d => d.Sender).WithMany()
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_user_sender_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("gamification_badge_user_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_user_write_uid_fkey");
            });
        }
    }
}