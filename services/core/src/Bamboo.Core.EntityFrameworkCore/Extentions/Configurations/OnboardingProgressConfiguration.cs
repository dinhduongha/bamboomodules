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
        public static void ConfigureOnboardingProgress(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OnboardingProgress>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("onboarding_progress_pkey");

                entity.ToTable("onboarding_progress");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.IsOnboardingClosed).HasColumnName("is_onboarding_closed");
                entity.Property(e => e.OnboardingId).HasColumnName("onboarding_id");
                entity.Property(e => e.OnboardingState).HasColumnName("onboarding_state");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("onboarding_progress_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("onboarding_progress_create_uid_fkey");

                entity.HasOne(d => d.Onboarding).WithMany(p => p.OnboardingProgresses)
                    .HasForeignKey(d => d.OnboardingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("onboarding_progress_onboarding_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("onboarding_progress_write_uid_fkey");

                entity.HasMany(d => d.OnboardingProgressSteps).WithMany(p => p.OnboardingProgresses)
                    .UsingEntity<Dictionary<string, object>>(
                        "OnboardingProgressOnboardingProgressStepRel",
                        r => r.HasOne<OnboardingProgressStep>().WithMany()
                            .HasForeignKey("OnboardingProgressStepId")
                            .HasConstraintName("onboarding_progress_onboarding_onboarding_progress_step_id_fkey"),
                        l => l.HasOne<OnboardingProgress>().WithMany()
                            .HasForeignKey("OnboardingProgressId")
                            .HasConstraintName("onboarding_progress_onboarding_prog_onboarding_progress_id_fkey"),
                        j =>
                        {
                            j.HasKey("OnboardingProgressId", "OnboardingProgressStepId").HasName("onboarding_progress_onboarding_progress_step_rel_pkey");
                            j.ToTable("onboarding_progress_onboarding_progress_step_rel");
                            j.HasIndex(new[] { "OnboardingProgressStepId", "OnboardingProgressId" }, "onboarding_progress_onboardin_onboarding_progress_step_id_o_idx");
                            j.IndexerProperty<Guid>("OnboardingProgressId").HasColumnName("onboarding_progress_id");
                            j.IndexerProperty<Guid>("OnboardingProgressStepId").HasColumnName("onboarding_progress_step_id");
                        });
            });
        }
    }
}