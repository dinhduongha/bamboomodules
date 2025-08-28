using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureOnboardingOnboardingStep(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<OnboardingOnboardingStep>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("onboarding_onboarding_step_pkey");

                        entity.ToTable("onboarding_onboarding_step");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ButtonText)
                            .HasColumnType("jsonb")
                            .HasColumnName("button_text");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description)
                            .HasColumnType("jsonb")
                            .HasColumnName("description");
                        entity.Property(e => e.DoneIcon).HasColumnName("done_icon");
                        entity.Property(e => e.DoneText)
                            .HasColumnType("jsonb")
                            .HasColumnName("done_text");
                        entity.Property(e => e.IsPerCompany).HasColumnName("is_per_company");
                        entity.Property(e => e.PanelStepOpenActionName).HasColumnName("panel_step_open_action_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.StepImageAlt)
                            .HasColumnType("jsonb")
                            .HasColumnName("step_image_alt");
                        entity.Property(e => e.StepImageFilename).HasColumnName("step_image_filename");
                        entity.Property(e => e.Title)
                            .HasColumnType("jsonb")
                            .HasColumnName("title");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.OnboardingOnboardingStepCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("onboarding_onboarding_step_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("onboarding_onboarding_step_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.OnboardingOnboardingStepWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("onboarding_onboarding_step_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("onboarding_onboarding_step_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}