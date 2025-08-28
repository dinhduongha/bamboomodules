using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrEmbeddedActions(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrEmbeddedActions>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_embedded_actions_pkey");

                        entity.ToTable("ir_embedded_actions");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");
                        entity.Property(e => e.ActionId).HasColumnName("action_id");
                        entity.Property(e => e.Context).HasColumnName("context");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DefaultViewMode).HasColumnName("default_view_mode");
                        entity.Property(e => e.Domain).HasColumnName("domain");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.ParentActionId).HasColumnName("parent_action_id");
                        entity.Property(e => e.ParentResId).HasColumnName("parent_res_id");
                        entity.Property(e => e.ParentResModel).HasColumnName("parent_res_model");
                        entity.Property(e => e.PythonMethod).HasColumnName("python_method");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrEmbeddedActionsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_embedded_actions_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_embedded_actions_create_uid_fkey");

                        entity.HasOne(d => d.ParentAction).WithMany(p => p.IrEmbeddedActions)
                            .HasForeignKey(d => d.ParentActionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_embedded_actions_parent_action_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.IrEmbeddedActionsUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("ir_embedded_actions_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_embedded_actions_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrEmbeddedActionsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_embedded_actions_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_embedded_actions_write_uid_fkey");

                        // entity.HasMany(d => d.ResGroups).WithMany(p => p.IrEmbeddedActions)
                        entity.HasMany(d => d.ResGroups).WithMany(p => p.IrEmbeddedActions)
                            .UsingEntity<Dictionary<string, object>>(
                                "IrEmbeddedActionsResGroupsRel",
                                r => r.HasOne<ResGroups>().WithMany()
                                    .HasForeignKey("ResGroupsId")
                                    .HasConstraintName("ir_embedded_actions_res_groups_rel_res_groups_id_fkey"),
                                l => l.HasOne<IrEmbeddedActions>().WithMany()
                                    .HasForeignKey("IrEmbeddedActionsId")
                                    .HasConstraintName("ir_embedded_actions_res_groups_rel_ir_embedded_actions_id_fkey"),
                                j =>
                                {
                                    j.HasKey("IrEmbeddedActionsId", "ResGroupsId").HasName("ir_embedded_actions_res_groups_rel_pkey");
                                    j.ToTable("ir_embedded_actions_res_groups_rel");
                                    j.HasIndex(new[] { "ResGroupsId", "IrEmbeddedActionsId" }, "ir_embedded_actions_res_group_res_groups_id_ir_embedded_act_idx");
                                    j.IndexerProperty<Guid>("IrEmbeddedActionsId").HasColumnName("ir_embedded_actions_id");
                                    j.IndexerProperty<Guid>("ResGroupsId").HasColumnName("res_groups_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}