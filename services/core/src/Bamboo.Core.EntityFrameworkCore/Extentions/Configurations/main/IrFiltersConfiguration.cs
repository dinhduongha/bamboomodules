using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrFilters(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrFilters>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_filters_pkey");

                        entity.ToTable("ir_filters");

                        entity.HasIndex(e => e.EmbeddedActionId, "ir_filters__embedded_action_id_index").HasFilter("(embedded_action_id IS NOT NULL)");

                        entity.HasIndex(e => new { e.ModelId, e.ActionId, e.EmbeddedActionId, e.EmbeddedParentResId }, "ir_filters_get_filters_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.ActionId).HasColumnName("action_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Context).HasColumnName("context");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Domain).HasColumnName("domain");
                        entity.Property(e => e.EmbeddedActionId).HasColumnName("embedded_action_id");
                        entity.Property(e => e.EmbeddedParentResId).HasColumnName("embedded_parent_res_id");
                        entity.Property(e => e.IsDefault).HasColumnName("is_default");
                        entity.Property(e => e.ModelId).HasColumnName("model_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Sort).HasColumnName("sort");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrFiltersCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_filters_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_filters_create_uid_fkey");

                        entity.HasOne(d => d.EmbeddedAction).WithMany(p => p.IrFilters)
                            .HasForeignKey(d => d.EmbeddedActionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_filters_embedded_action_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrFiltersWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_filters_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_filters_write_uid_fkey");

                        // entity.HasMany(d => d.ResUsers).WithMany(p => p.IrFilters)
                        entity.HasMany(d => d.ResUsers).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "IrFiltersResUsersRel",
                                r => r.HasOne<ResUsers>().WithMany()
                                    .HasForeignKey("ResUsersId")
                                    .HasConstraintName("ir_filters_res_users_rel_res_users_id_fkey"),
                                l => l.HasOne<IrFilters>().WithMany()
                                    .HasForeignKey("IrFiltersId")
                                    .HasConstraintName("ir_filters_res_users_rel_ir_filters_id_fkey"),
                                j =>
                                {
                                    j.HasKey("IrFiltersId", "ResUsersId").HasName("ir_filters_res_users_rel_pkey");
                                    j.ToTable("ir_filters_res_users_rel");
                                    j.HasIndex(new[] { "ResUsersId", "IrFiltersId" }, "ir_filters_res_users_rel_res_users_id_ir_filters_id_idx");
                                    j.IndexerProperty<Guid>("IrFiltersId").HasColumnName("ir_filters_id");
                                    j.IndexerProperty<Guid>("ResUsersId").HasColumnName("res_users_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}