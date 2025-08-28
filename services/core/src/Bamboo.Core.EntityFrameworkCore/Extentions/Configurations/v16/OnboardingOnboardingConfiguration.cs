using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureOnboardingOnboarding(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<OnboardingOnboarding>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("onboarding_onboarding_pkey");

                        entity.ToTable("onboarding_onboarding");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.RouteName, "onboarding_onboarding_route_name_uniq").IsUnique();

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
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PanelCloseActionName).HasColumnName("panel_close_action_name");
                        entity.Property(e => e.RouteName).HasColumnName("route_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.TextCompleted).HasColumnName("text_completed");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.OnboardingOnboardingCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("onboarding_onboarding_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("onboarding_onboarding_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.OnboardingOnboardingWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("onboarding_onboarding_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("onboarding_onboarding_write_uid_fkey");

                        // entity.HasMany(d => d.OnboardingOnboardingStep).WithMany(p => p.OnboardingOnboarding)
                        entity.HasMany(d => d.OnboardingOnboardingStep).WithMany(p => p.OnboardingOnboarding)
                            .UsingEntity<Dictionary<string, object>>(
                                "OnboardingOnboardingOnboardingOnboardingStepRel",
                                r => r.HasOne<OnboardingOnboardingStep>().WithMany()
                                    .HasForeignKey("OnboardingOnboardingStepId")
                                    .HasConstraintName("onboarding_onboarding_onboard_onboarding_onboarding_step_i_fkey"),
                                l => l.HasOne<OnboardingOnboarding>().WithMany()
                                    .HasForeignKey("OnboardingOnboardingId")
                                    .HasConstraintName("onboarding_onboarding_onboarding__onboarding_onboarding_id_fkey"),
                                j =>
                                {
                                    j.HasKey("OnboardingOnboardingId", "OnboardingOnboardingStepId").HasName("onboarding_onboarding_onboarding_onboarding_step_rel_pkey");
                                    j.ToTable("onboarding_onboarding_onboarding_onboarding_step_rel");
                                    j.HasIndex(new[] { "OnboardingOnboardingStepId", "OnboardingOnboardingId" }, "onboarding_onboarding_onboard_onboarding_onboarding_step_id_idx");
                                    j.IndexerProperty<Guid>("OnboardingOnboardingId").HasColumnName("onboarding_onboarding_id");
                                    j.IndexerProperty<Guid>("OnboardingOnboardingStepId").HasColumnName("onboarding_onboarding_step_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}