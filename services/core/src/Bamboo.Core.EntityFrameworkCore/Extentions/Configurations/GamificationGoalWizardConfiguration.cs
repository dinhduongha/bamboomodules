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
        public static void ConfigureGamificationGoalWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationGoalWizard>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_goal_wizard_pkey");

                entity.ToTable("gamification_goal_wizard", tb => tb.HasComment("Gamification Goal Wizard"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Current)
                    .HasComment("Current")
                    .HasColumnName("current");
                entity.Property(e => e.GoalId)
                    .HasComment("Goal")
                    .HasColumnName("goal_id");
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
                    .HasConstraintName("gamification_goal_wizard_create_uid_fkey");

                entity.HasOne(d => d.Goal).WithMany(p => p.GamificationGoalWizards)
                    .HasForeignKey(d => d.GoalId)
                    .HasConstraintName("gamification_goal_wizard_goal_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_wizard_write_uid_fkey");
            });
        }
    }
}