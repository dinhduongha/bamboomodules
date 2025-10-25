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

                        entity.HasIndex(e => new { e.ModelId, e.UserId, e.ActionId, e.EmbeddedActionId, e.EmbeddedParentResId, e.Name }, "ir_filters_name_model_uid_unique").IsUnique();

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
                        entity.Property(e => e.UserId).HasColumnName("user_id");
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

                        // entity.HasOne(d => d.User).WithMany(p => p.IrFiltersUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("ir_filters_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_filters_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrFiltersWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_filters_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_filters_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}