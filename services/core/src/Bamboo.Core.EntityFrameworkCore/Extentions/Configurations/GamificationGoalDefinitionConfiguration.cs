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
        public static void ConfigureGamificationGoalDefinition(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamificationGoalDefinition>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("gamification_goal_definition_pkey");

                entity.ToTable("gamification_goal_definition", tb => tb.HasComment("Gamification Goal Definition"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ActionId)
                    .HasComment("Action")
                    .HasColumnName("action_id");
                entity.Property(e => e.BatchDistinctiveField)
                    .HasComment("Distinctive field for batch user")
                    .HasColumnName("batch_distinctive_field");
                entity.Property(e => e.BatchMode)
                    .HasComment("Batch Mode")
                    .HasColumnName("batch_mode");
                entity.Property(e => e.BatchUserExpression)
                    .HasComment("Evaluated expression for batch mode")
                    .HasColumnType("character varying")
                    .HasColumnName("batch_user_expression");
                entity.Property(e => e.ComputationMode)
                    .HasComment("Computation Mode")
                    .HasColumnType("character varying")
                    .HasColumnName("computation_mode");
                entity.Property(e => e.ComputeCode)
                    .HasComment("Python Code")
                    .HasColumnName("compute_code");
                entity.Property(e => e.Condition)
                    .HasComment("Goal Performance")
                    .HasColumnType("character varying")
                    .HasColumnName("condition");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.Description)
                    .HasComment("Goal Description")
                    .HasColumnName("description");
                entity.Property(e => e.DisplayMode)
                    .HasComment("Displayed as")
                    .HasColumnType("character varying")
                    .HasColumnName("display_mode");
                entity.Property(e => e.Domain)
                    .HasComment("Filter Domain")
                    .HasColumnType("character varying")
                    .HasColumnName("domain");
                entity.Property(e => e.FieldDateId)
                    .HasComment("Date Field")
                    .HasColumnName("field_date_id");
                entity.Property(e => e.FieldId)
                    .HasComment("Field to Sum")
                    .HasColumnName("field_id");
                entity.Property(e => e.ModelId)
                    .HasComment("Model")
                    .HasColumnName("model_id");
                entity.Property(e => e.Monetary)
                    .HasComment("Monetary Value")
                    .HasColumnName("monetary");
                entity.Property(e => e.Name)
                    .HasComment("Goal Definition")
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ResIdField)
                    .HasComment("ID Field of user")
                    .HasColumnType("character varying")
                    .HasColumnName("res_id_field");
                entity.Property(e => e.Suffix)
                    .HasComment("Suffix")
                    .HasColumnType("jsonb")
                    .HasColumnName("suffix");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne(d => d.Action).WithMany(p => p.GamificationGoalDefinitions)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_definition_action_id_fkey");

                entity.HasOne(d => d.BatchDistinctiveFieldNavigation).WithMany(p => p.GamificationGoalDefinitionBatchDistinctiveFieldNavigations)
                    .HasForeignKey(d => d.BatchDistinctiveField)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_definition_batch_distinctive_field_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_definition_create_uid_fkey");

                entity.HasOne(d => d.FieldDate).WithMany(p => p.GamificationGoalDefinitionFieldDates)
                    .HasForeignKey(d => d.FieldDateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_definition_field_date_id_fkey");

                entity.HasOne(d => d.Field).WithMany(p => p.GamificationGoalDefinitionFields)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_definition_field_id_fkey");

                entity.HasOne(d => d.Model).WithMany(p => p.GamificationGoalDefinitions)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_definition_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("gamification_goal_definition_write_uid_fkey");
            });
        }
    }
}