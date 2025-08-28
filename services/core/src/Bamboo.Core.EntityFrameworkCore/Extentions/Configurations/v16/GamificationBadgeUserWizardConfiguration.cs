using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("gamification_badge_user_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BadgeId).HasColumnName("badge_id");
                        entity.Property(e => e.Comment).HasColumnName("comment");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Badge).WithMany(p => p.GamificationBadgeUserWizard)
                            .HasForeignKey(d => d.BadgeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("gamification_badge_user_wizard_badge_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.GamificationBadgeUserWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_badge_user_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_badge_user_wizard_create_uid_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.GamificationBadgeUserWizard)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_badge_user_wizard_employee_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.GamificationBadgeUserWizardUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("gamification_badge_user_wizard_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("gamification_badge_user_wizard_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.GamificationBadgeUserWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_badge_user_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_badge_user_wizard_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}