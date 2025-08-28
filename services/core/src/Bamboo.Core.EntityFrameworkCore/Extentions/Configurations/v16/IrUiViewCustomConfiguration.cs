using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrUiViewCustom(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrUiViewCustom>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_ui_view_custom_pkey");

                        entity.ToTable("ir_ui_view_custom");

                        entity.HasIndex(e => e.RefId, "ir_ui_view_custom__ref_id_index");

                        entity.HasIndex(e => e.UserId, "ir_ui_view_custom__user_id_index");

                        entity.HasIndex(e => new { e.UserId, e.RefId }, "ir_ui_view_custom_user_id_ref_id");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");
                        entity.Property(e => e.Arch).HasColumnName("arch");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.RefId).HasColumnName("ref_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrUiViewCustomCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_ui_view_custom_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_ui_view_custom_create_uid_fkey");

                        entity.HasOne(d => d.Ref).WithMany(p => p.IrUiViewCustom)
                            .HasForeignKey(d => d.RefId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_ui_view_custom_ref_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.IrUiViewCustomUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("ir_ui_view_custom_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_ui_view_custom_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrUiViewCustomWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_ui_view_custom_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_ui_view_custom_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}