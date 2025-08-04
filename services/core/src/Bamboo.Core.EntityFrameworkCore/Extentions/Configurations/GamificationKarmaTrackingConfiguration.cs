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
        public static void ConfigureGamificationKarmaTracking(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationKarmaTracking>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_karma_tracking_pkey");

                entity.ToTable("gamification_karma_tracking", tb => tb.HasComment("Track Karma Changes"));

                entity.HasIndex(e => e.UserId, "gamification_karma_tracking_user_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Consolidated)
                    .HasComment("Consolidated")
                    .HasColumnName("consolidated");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.NewValue)
                    .HasComment("New Karma Value")
                    .HasColumnName("new_value");
                entity.Property(e => e.OldValue)
                    .HasComment("Old Karma Value")
                    .HasColumnName("old_value");
                entity.Property(e => e.TrackingDate)
                    .HasComment("Tracking Date")
                    .HasColumnName("tracking_date");
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_karma_tracking_create_uid_fkey");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("gamification_karma_tracking_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_karma_tracking_write_uid_fkey");
            });
        }
    }
}