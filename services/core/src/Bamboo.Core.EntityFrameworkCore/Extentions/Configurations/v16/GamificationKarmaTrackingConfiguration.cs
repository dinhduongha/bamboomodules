using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("gamification_karma_tracking");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.TrackingDate, "gamification_karma_tracking__tracking_date_index");

                        entity.HasIndex(e => e.UserId, "gamification_karma_tracking__user_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Consolidated).HasColumnName("consolidated");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.NewValue).HasColumnName("new_value");
                        entity.Property(e => e.OldValue).HasColumnName("old_value");
                        entity.Property(e => e.OriginRef).HasColumnName("origin_ref");
                        entity.Property(e => e.OriginRefModelName).HasColumnName("origin_ref_model_name");
                        entity.Property(e => e.Reason).HasColumnName("reason");
                        entity.Property(e => e.TrackingDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("tracking_date");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.GamificationKarmaTrackingCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_karma_tracking_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_karma_tracking_create_uid_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.GamificationKarmaTrackingUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("gamification_karma_tracking_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("gamification_karma_tracking_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.GamificationKarmaTrackingWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_karma_tracking_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_karma_tracking_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}