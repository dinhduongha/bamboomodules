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
        public static void ConfigureIrActions(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrActions>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_actions_pkey");

            entity.ToTable("ir_actions");

            entity.HasIndex(e => e.Path, "ir_actions_path_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.BindingModelId).HasColumnName("binding_model_id");
            entity.Property(e => e.BindingType).HasColumnName("binding_type");
            entity.Property(e => e.BindingViewTypes).HasColumnName("binding_view_types");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Help)
                .HasColumnType("jsonb")
                .HasColumnName("help");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Path).HasColumnName("path");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.BindingModel).WithMany(p => p.IrActions)
                .HasForeignKey(d => d.BindingModelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_actions_binding_model_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrActionsCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_actions_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrActionsWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_actions_write_uid_fkey");
            });
        }
    }
}
