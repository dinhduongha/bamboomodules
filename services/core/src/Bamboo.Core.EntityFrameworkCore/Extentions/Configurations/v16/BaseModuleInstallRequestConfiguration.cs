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
        public static void ConfigureBaseModuleInstallRequest(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BaseModuleInstallRequest>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_module_install_request_pkey");

            entity.ToTable("base_module_install_request");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.BodyHtml).HasColumnName("body_html");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.ModuleId).HasColumnName("module_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BaseModuleInstallRequestCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_module_install_request_create_uid_fkey");

            entity.HasOne(d => d.Module).WithMany(p => p.BaseModuleInstallRequest)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("base_module_install_request_module_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.BaseModuleInstallRequestUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("base_module_install_request_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BaseModuleInstallRequestWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("base_module_install_request_write_uid_fkey");
            });
        }
    }
}