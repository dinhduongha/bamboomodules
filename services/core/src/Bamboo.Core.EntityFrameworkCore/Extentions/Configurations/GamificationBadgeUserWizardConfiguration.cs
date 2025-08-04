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
        public static void ConfigureGamificationBadgeUserWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationBadgeUserWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_badge_user_wizard_pkey");

                entity.ToTable("gamification_badge_user_wizard", tb => tb.HasComment("Gamification User Badge Wizard"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.BadgeId)
                    .HasComment("Badge")
                    .HasColumnName("badge_id");
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

                entity.HasOne(d => d.Badge).WithMany(p => p.GamificationBadgeUserWizards)
                    .HasForeignKey(d => d.BadgeId)
                    .HasConstraintName("gamification_badge_user_wizard_badge_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_user_wizard_create_uid_fkey");

                entity.HasOne(d => d.Employee).WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("gamification_badge_user_wizard_employee_id_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("gamification_badge_user_wizard_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_badge_user_wizard_write_uid_fkey");
            });
        }
    }
}