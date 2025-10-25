using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureGamificationGoalDefinition(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<GamificationGoalDefinition>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("gamification_goal_definition_pkey");

                        entity.ToTable("gamification_goal_definition");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ActionId).HasColumnName("action_id");
                        entity.Property(e => e.BatchDistinctiveField).HasColumnName("batch_distinctive_field");
                        entity.Property(e => e.BatchMode).HasColumnName("batch_mode");
                        entity.Property(e => e.BatchUserExpression).HasColumnName("batch_user_expression");
                        entity.Property(e => e.ComputationMode).HasColumnName("computation_mode");
                        entity.Property(e => e.ComputeCode).HasColumnName("compute_code");
                        entity.Property(e => e.Condition).HasColumnName("condition");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.DisplayMode).HasColumnName("display_mode");
                        entity.Property(e => e.Domain).HasColumnName("domain");
                        entity.Property(e => e.FieldDateId).HasColumnName("field_date_id");
                        entity.Property(e => e.FieldId).HasColumnName("field_id");
                        entity.Property(e => e.ModelId).HasColumnName("model_id");
                        entity.Property(e => e.Monetary).HasColumnName("monetary");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.ResIdField).HasColumnName("res_id_field");
                        entity.Property(e => e.Suffix)
                            .HasColumnType("jsonb")
                            .HasColumnName("suffix");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Action).WithMany(p => p.GamificationGoalDefinition)
                            .HasForeignKey(d => d.ActionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_goal_definition_action_id_fkey");

                        entity.HasOne(d => d.BatchDistinctiveFieldNavigation).WithMany(p => p.GamificationGoalDefinitionBatchDistinctiveFieldNavigation)
                            .HasForeignKey(d => d.BatchDistinctiveField)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_goal_definition_batch_distinctive_field_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.GamificationGoalDefinitionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_goal_definition_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_goal_definition_create_uid_fkey");

                        entity.HasOne(d => d.FieldDate).WithMany(p => p.GamificationGoalDefinitionFieldDate)
                            .HasForeignKey(d => d.FieldDateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_goal_definition_field_date_id_fkey");

                        entity.HasOne(d => d.Field).WithMany(p => p.GamificationGoalDefinitionField)
                            .HasForeignKey(d => d.FieldId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_goal_definition_field_id_fkey");

                        entity.HasOne(d => d.Model).WithMany(p => p.GamificationGoalDefinition)
                            .HasForeignKey(d => d.ModelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("gamification_goal_definition_model_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.GamificationGoalDefinitionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("gamification_goal_definition_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("gamification_goal_definition_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}