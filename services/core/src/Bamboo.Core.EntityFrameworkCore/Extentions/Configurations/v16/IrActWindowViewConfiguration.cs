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
        public static void ConfigureIrActWindowView(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrActWindowView>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_act_window_view_pkey");

            entity.ToTable("ir_act_window_view");

            entity.HasIndex(e => new { e.ActWindowId, e.ViewMode }, "act_window_view_unique_mode_per_action").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ActWindowId).HasColumnName("act_window_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Multi).HasColumnName("multi");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.ViewId).HasColumnName("view_id");
            entity.Property(e => e.ViewMode).HasColumnName("view_mode");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.ActWindow).WithMany(p => p.IrActWindowView)
                .HasForeignKey(d => d.ActWindowId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ir_act_window_view_act_window_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.IrActWindowViewCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_act_window_view_create_uid_fkey");

            entity.HasOne(d => d.View).WithMany(p => p.IrActWindowViewNavigation)
                .HasForeignKey(d => d.ViewId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_act_window_view_view_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.IrActWindowViewWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ir_act_window_view_write_uid_fkey");
            });
        }
    }
}