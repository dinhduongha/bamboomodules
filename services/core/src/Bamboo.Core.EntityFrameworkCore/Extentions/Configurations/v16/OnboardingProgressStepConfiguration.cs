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
        public static void ConfigureOnboardingProgressStep(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<OnboardingProgressStep>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("onboarding_progress_step_pkey");

            entity.ToTable("onboarding_progress_step");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.ProgressId, e.StepId }, "onboarding_progress_step_progress_step_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.ProgressId).HasColumnName("progress_id");
            entity.Property(e => e.StepId).HasColumnName("step_id");
            entity.Property(e => e.StepState).HasColumnName("step_state");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.OnboardingProgressStep)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("onboarding_progress_step_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.OnboardingProgressStepCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("onboarding_progress_step_create_uid_fkey");

            entity.HasOne(d => d.Progress).WithMany(p => p.OnboardingProgressStep)
                .HasForeignKey(d => d.ProgressId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("onboarding_progress_step_progress_id_fkey");

            entity.HasOne(d => d.Step).WithMany(p => p.OnboardingProgressStep)
                .HasForeignKey(d => d.StepId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("onboarding_progress_step_step_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.OnboardingProgressStepWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("onboarding_progress_step_write_uid_fkey");
            });
        }
    }
}
