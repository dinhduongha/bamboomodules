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
        public static void ConfigureBaseModuleUninstall(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseModuleUninstall>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_module_uninstall_pkey");

            entity.ToTable("base_module_uninstall");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.ShowAll).HasColumnName("show_all");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseModuleUninstallCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_module_uninstall_create_uid_fkey");

            entity.HasOne(d => d.Module).WithMany(p => p.BaseModuleUninstall)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("base_module_uninstall_module_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseModuleUninstallWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_module_uninstall_write_uid_fkey");
            });
        }
    }
}