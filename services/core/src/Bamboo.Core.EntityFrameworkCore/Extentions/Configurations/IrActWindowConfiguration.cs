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
        public static void ConfigureIrActWindow(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IrActWindow>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("ir_act_window_pkey");

                entity.ToTable("ir_act_window");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.BindingModelId).HasColumnName("binding_model_id");
                entity.Property(e => e.BindingType).HasColumnName("binding_type");
                entity.Property(e => e.BindingViewTypes).HasColumnName("binding_view_types");
                entity.Property(e => e.Context).HasColumnName("context");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Domain).HasColumnName("domain");
                entity.Property(e => e.Filter).HasColumnName("filter");
                entity.Property(e => e.Help)
                    .HasColumnType("jsonb")
                    .HasColumnName("help");
                entity.Property(e => e.Limit).HasColumnName("limit");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.ResId).HasColumnName("res_id");
                entity.Property(e => e.ResModel).HasColumnName("res_model");
                entity.Property(e => e.SearchViewId).HasColumnName("search_view_id");
                entity.Property(e => e.Target).HasColumnName("target");
                entity.Property(e => e.Type).HasColumnName("type");
                entity.Property(e => e.Usage).HasColumnName("usage");
                entity.Property(e => e.ViewId).HasColumnName("view_id");
                entity.Property(e => e.ViewMode).HasColumnName("view_mode");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.BindingModel).WithMany(p => p.IrActWindows)
                    .HasForeignKey(d => d.BindingModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ir_act_window_binding_model_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_window_create_uid_fkey");

                entity.HasOne(d => d.SearchView).WithMany(p => p.IrActWindowSearchViews)
                    .HasForeignKey(d => d.SearchViewId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_window_search_view_id_fkey");

                entity.HasOne(d => d.View).WithMany(p => p.IrActWindowViews)
                    .HasForeignKey(d => d.ViewId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_window_view_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ir_act_window_write_uid_fkey");

                //entity.HasMany(d => d.Gids).WithMany(p => p.ActsNavigation)
                entity.HasMany<ResGroup>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "IrActWindowGroupRel",
                        r => r.HasOne<ResGroup>().WithMany()
                            .HasForeignKey("Gid")
                            .HasConstraintName("ir_act_window_group_rel_gid_fkey"),
                        l => l.HasOne<IrActWindow>().WithMany()
                            .HasForeignKey("ActId")
                            .HasConstraintName("ir_act_window_group_rel_act_id_fkey"),
                        j =>
                        {
                            j.HasKey("ActId", "Gid").HasName("ir_act_window_group_rel_pkey");
                            j.ToTable("ir_act_window_group_rel");
                            j.HasIndex(new[] { "Gid", "ActId" }, "ir_act_window_group_rel_gid_act_id_idx");
                        });
            });
        }
    }
}